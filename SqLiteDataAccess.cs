using Microsoft.Data.Sqlite;

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

                var insertEmploymentDetailsCommand = connection.CreateCommand();
                insertEmploymentDetailsCommand.CommandText = @"
                    INSERT INTO Employment_Details (employee_id, department, job_title, supervisor, employment_status, date_of_hire, employment_type)
                    VALUES (@EmployeeId, @Department, @JobTitle, @Supervisor, @EmploymentStatus, @DateOfHire, @EmploymentType)";

                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                command.Parameters.AddWithValue("@Department", employment.department);
                command.Parameters.AddWithValue("@JobTitle", employment.job_title);
                command.Parameters.AddWithValue("@Supervisor", employment.supervisor);
                command.Parameters.AddWithValue("@EmploymentStatus", employment.employment_status);
                command.Parameters.AddWithValue("@DateOfHire", employment.date_of_hire);
                command.Parameters.AddWithValue("@EmploymentType", employment.employment_type);

                command.ExecuteNonQuery();
            }
            Console.WriteLine("Post Finish");
        }
        public List<EmployeeEntity> ReadEntity(string offset)
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
                        EmployeeList.Add(new EmployeeEntity(reader.GetInt32(0), reader.GetString(2), reader.GetString(3), DateOnly.Parse(reader.GetString(4)), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8)));
                    }
                    Console.WriteLine($"Returned {EmployeeList.Count} employees.");

                    return EmployeeList;
                }
            }
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