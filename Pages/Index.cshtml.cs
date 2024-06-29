using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

namespace Employee.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            //            string dbFilePath = "C:\\Users\\Patrick\\source\\repos\\Employee\\Employee.db";
            //            string connectionString = $"Data Source={dbFilePath}";
            //
            //            using (var connection = new SqliteConnection(connectionString))
            //            {
            //            connection.Open();
            //
            //            var command = connection.CreateCommand();
            //
            //           command.CommandText =
            //           $@" 
            //           CREATE TABLE Employees (
            //          employee_id INTEGER PRIMARY KEY AUTOINCREMENT,
            //          first_name TEXT NOT NULL,
            //          last_name TEXT NOT NULL,
            //         date_of_birth DATE,
            //                      gender TEXT,
            //         address TEXT,
            //phone_number TEXT,
            //email TEXT
            //       ); ";
            //
            //command.ExecuteNonQuery();
            //
            //command.CommandText =
            //$@"
            //CREATE TABLE Employment_Details (
            //detail_id INTEGER PRIMARY KEY AUTOINCREMENT,
            //employee_id INTEGER NOT NULL,
            //department TEXT NOT NULL,
            //job_title TEXT NOT NULL,
            //supervisor TEXT,
            //employment_status TEXT NOT NULL,
            //date_of_hire DATE NOT NULL,
            //employment_type TEXT NOT NULL,
            //FOREIGN KEY (employee_id) REFERENCES Employees (employee_id)
            //        ); ";
            //
            //command.ExecuteNonQuery();
            //}
        }
    }
}
