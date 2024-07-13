using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using System.Xml.Linq;

namespace Employee.Pages
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
            Console.WriteLine("Create Get");
        }

        public void OnPost()
        {

            // Information for EmployeeEntity

            string first_name = Request.Form["first_name"];
            string last_name = Request.Form["last_name"];
            DateOnly date_of_birth = DateOnly.Parse(Request.Form["date_of_birth"]);
            string gender = Request.Form["gender"];
            string address = Request.Form["address"];
            string email = Request.Form["email"];
            string phone_number = Request.Form["phone_number"];



            // Information for EmploymentEntity

            string department = Request.Form["department"];
            string job_title = Request.Form["job_title"];
            string supervisor = Request.Form["supervisor"];
            string employment_type = Request.Form["employment_type"];
            DateOnly date_of_hire = DateOnly.Parse(Request.Form["date_of_hire"]);
            string employment_status = "active";



            Console.WriteLine($"{first_name} {last_name} {date_of_birth} {gender} {address} {email} {phone_number}");
            Console.WriteLine($"{department} {job_title} {supervisor} {employment_status} {date_of_hire} {employment_type}");

            EmployeeEntity newEmployee = new EmployeeEntity(0, first_name, last_name, date_of_birth, gender, address, email, phone_number);



            Console.WriteLine($"TEST newEmployee: {newEmployee.first_name}, {newEmployee.last_name}, {newEmployee.date_of_birth}, {newEmployee.gender}, {newEmployee.address}, {newEmployee.email}, {newEmployee.phone_number}");



            EmploymentEntity newEmployment = new EmploymentEntity(0, 0, department, job_title, supervisor, employment_status, date_of_hire, employment_type);

            Console.WriteLine($"TEST newEmployment: {newEmployment.department}, {newEmployment.job_title}, {newEmployment.supervisor}, {newEmployment.employment_status}, {newEmployment.date_of_hire}, {newEmployment.employment_type}");



            IDataAccess dataAccess = new SqLiteDataAccess();

            dataAccess.CreateEntity(newEmployee, newEmployment);
        }
    }
}
