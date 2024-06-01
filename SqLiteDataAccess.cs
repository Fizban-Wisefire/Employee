using Microsoft.Data.Sqlite;

namespace Employee
{
    public class SqLiteDataAccess : IDataAccess
    {
        public SqLiteDataAccess() { }
        public void CreateEntity(EmployeeEntity employee)
        {
            SQLitePCL.Batteries.Init();


            string dbFilePath = "C:\\Users\\Patrick\\source\\repos\\Employee\\Employee.db";
            string connectionString = $"Data Source={dbFilePath}";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $@"
                    INSERT INTO employee (Name, Age, Department)
                    VALUES (@Name, @Age, @Department)
                    ";
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Age", employee.Age);
                command.Parameters.AddWithValue("@Department", employee.Department);

                command.ExecuteNonQuery();
            }
        }
        public List<EmployeeEntity> ReadEntity()
        {
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
                    FROM employee
                    ";
                using (var reader = readCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EmployeeList.Add(new EmployeeEntity(reader.GetString(1), reader.GetInt32(2), reader.GetString(3)));
                    }
                    Console.WriteLine(EmployeeList.Count);
                    for (int i = 0; i < EmployeeList.Count; i++)
                    {
                        Console.WriteLine(EmployeeList[i].Name);
                    }
                }
            }

/// FIX THIS SO IT RETURNS THE NEW LIST
            return new List<EmployeeEntity>();
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