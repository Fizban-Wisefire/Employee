using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

namespace Employee.Pages
{
    public class ReadModel : PageModel
    {
        public List<EmployeeEntity> Employees { get; set; }
        public void OnGet()
        {


            IDataAccess dataAccess = new SqLiteDataAccess();
            dataAccess.ReadEntity();


        }
    }
}
