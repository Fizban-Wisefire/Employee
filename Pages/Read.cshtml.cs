using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

namespace Employee.Pages
{
    public class ReadModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public List<EmployeeEntity> EmployeeList { get; set; }
        public static int offset = 0;
        public void OnGet()
        {
            EmployeeList = new List<EmployeeEntity>();

            IDataAccess dataAccess = new SqLiteDataAccess();
            string passedOffset = offset.ToString();
            EmployeeList = dataAccess.ReadEmployeeEntity(passedOffset);
        }

        public void OnPostPrevBtn()
        {
            offset = offset - 10;
            Console.WriteLine(offset);
            if ( offset < 0)
            {
                offset = 0;
            }
            Console.WriteLine("Prev Test");

            EmployeeList = new List<EmployeeEntity>();

            IDataAccess dataAccess = new SqLiteDataAccess();
            string passedOffset = offset.ToString();
            EmployeeList = dataAccess.ReadEmployeeEntity(passedOffset);
        }


        public void OnPostNextBtn()
        {
            offset = offset + 10;

            Console.WriteLine("Next Test");

            EmployeeList = new List<EmployeeEntity>();

            IDataAccess dataAccess = new SqLiteDataAccess();
            string passedOffset = offset.ToString();
            EmployeeList = dataAccess.ReadEmployeeEntity(passedOffset);
        }
    }
}
