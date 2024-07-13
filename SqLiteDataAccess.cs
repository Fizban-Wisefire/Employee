using Microsoft.Data.Sqlite;
using System.Net;
using System.Reflection;

namespace Employee
{
    public class SqLiteDataAccess : IDataAccess
    {
        public SqLiteDataAccess() { }
        public void CreateEntity(EmployeeEntity employee, EmploymentEntity employment)
        {
            SQLitePCL.Batteries.Init();

            Console.WriteLine($"{employee.first_name}, {employee.last_name}, {employee.date_of_birth}, {employee.gender}, {employee.address}, {employee.email}, {employee.phone_number}");

            string dbFilePath = "C:\\Users\\Patrick\\source\\repos\\Employee\\Employee.db";
            string connectionString = $"Data Source={dbFilePath}";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $@"
                    INSERT INTO Employees (first_name, last_name, date_of_birth, gender, address, email, phone_number)
                    VALUES (@first_name, @last_name, @date_of_birth, @gender, @address, @email, @phone_number)
                    ";
                command.Parameters.AddWithValue("@first_name", employee.first_name);
                command.Parameters.AddWithValue("@last_name", employee.last_name);
                command.Parameters.AddWithValue("@date_of_birth", employee.date_of_birth);
                command.Parameters.AddWithValue("@gender", employee.gender);
                command.Parameters.AddWithValue("@address", employee.address);
                command.Parameters.AddWithValue("@email", employee.email);
                command.Parameters.AddWithValue("@phone_number", employee.phone_number);

                command.ExecuteNonQuery();
                Console.WriteLine($"Added EMPLOYEE DETAILS for {employee.first_name} {employee.last_name}");

                var getLastInsertIdCommand = connection.CreateCommand();
                getLastInsertIdCommand.CommandText = "SELECT last_insert_rowid();";
                var employeeId = (long)getLastInsertIdCommand.ExecuteScalar();

                Console.WriteLine(employment.employment_type);

                Console.WriteLine($"{employeeId}, {employment.department}, {employment.job_title}, {employment.supervisor}, {employment.employment_status}, {employment.date_of_hire}, {employment.employment_type}");

                var insertEmploymentDetailsCommand = connection.CreateCommand();
                insertEmploymentDetailsCommand.CommandText = @"
                    INSERT INTO Employment_Details (employee_id, department, job_title, supervisor, employment_status, date_of_hire, employment_type)
                    VALUES (@EmployeeId, @Department, @JobTitle, @Supervisor, @EmploymentStatus, @DateOfHire, @EmploymentType)";
                insertEmploymentDetailsCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
                insertEmploymentDetailsCommand.Parameters.AddWithValue("@Department", employment.department);
                insertEmploymentDetailsCommand.Parameters.AddWithValue("@JobTitle", employment.job_title);
                insertEmploymentDetailsCommand.Parameters.AddWithValue("@Supervisor", employment.supervisor);
                insertEmploymentDetailsCommand.Parameters.AddWithValue("@EmploymentStatus", employment.employment_status);
                insertEmploymentDetailsCommand.Parameters.AddWithValue("@DateOfHire", employment.date_of_hire);
                insertEmploymentDetailsCommand.Parameters.AddWithValue("@EmploymentType", employment.employment_type);


                insertEmploymentDetailsCommand.ExecuteNonQuery();
                Console.WriteLine($"Added EMPLOYMENT DETAILS for {employee.first_name} {employee.last_name}");

            }
            Console.WriteLine("Post Finish");
        }
        public List<EmployeeEntity> ReadEmployeeEntity(string offset)
        {
            Console.WriteLine(offset);
            List<EmployeeEntity> EmployeeList = new List<EmployeeEntity>();

            SQLitePCL.Batteries.Init();


            string dbFilePath = "C:\\Users\\Patrick\\source\\repos\\Employee\\Employee.db";
            string connectionString = $"Data Source={dbFilePath}";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var readCommand = connection.CreateCommand();
                readCommand.CommandText =
                    $@"
                    SELECT *
                    FROM Employees
                    LIMIT 10
                    OFFSET @offset
                    ";

                readCommand.Parameters.AddWithValue("@offset", offset);

                using (var reader = readCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EmployeeList.Add(new EmployeeEntity(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), DateOnly.Parse(reader.GetString(3)), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7)));

                    }
                    Console.WriteLine($"Returned {EmployeeList.Count} employees.");

                    return EmployeeList;
                }
            }
        }

        public List<EmploymentEntity> ReadEmploymentEntity(string offset)
        {
            List<EmploymentEntity> EmploymentList = new List<EmploymentEntity>();
            return EmploymentList;
        }

        public void UpdateEntity(EmployeeEntity Employee, string Query)
        {
            Console.WriteLine($"Update {Query}");
        }
        public void DeleteEntity(EmployeeEntity Employee, string Query)
        {
            Console.WriteLine($"Delete {Query}");
        }
    }
}