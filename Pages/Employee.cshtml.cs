using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employee.Pages
{
    public class EmployeeModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public EmployeeEntity employee { get; set; }

        public void OnGet()
        {
            System.DateOnly date = new System.DateOnly();

            EmployeeEntity employee = new EmployeeEntity(0, "fName", "lName", date, "male", "99 P Road", "fName@co.com", "999-888-7777");


            IDataAccess dataAccess = new SqLiteDataAccess();
            employee = dataAccess.ReadEmployeeEntity("0")[0];

            string Placeholder = "PLACEHOLDER";

            Console.WriteLine($"Employee: {Placeholder}");
        }
    }
}
