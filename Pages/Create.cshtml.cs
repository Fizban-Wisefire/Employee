using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

namespace Employee.Pages
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
            EmployeeEntity John = new EmployeeEntity("John", 50, "HR");
            IDataAccess dataAccess = new SqLiteDataAccess();
            dataAccess.CreateEntity(John);


            
        }
    }
}
