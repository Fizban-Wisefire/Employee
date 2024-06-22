using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

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
            string fName = Request.Form["fName"];
            string lName = Request.Form["lName"];
            string name = fName + " " + lName;
            string empAge = Request.Form["payRate"];
            int age = Int32.Parse(empAge);
            string department = Request.Form["department"];

            Console.WriteLine($"Name: {fName} {lName} Aged: {age} Department: {department}");
            EmployeeEntity newEmp = new EmployeeEntity(name, age, department);
            IDataAccess dataAccess = new SqLiteDataAccess();
            EmployeeEntity employee = new EmployeeEntity
                (
                Request.Form["fName"],
                Int32.Parse(Request.Form["payRate"]), 
                Request.Form["department"]
                );
            dataAccess.CreateEntity(employee);
        }
    }
}
