using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employee.Pages
{
    public class DeleteModel : PageModel
    {
        public void OnGet()
        {
            IDataAccess dataAccess = new SqLiteDataAccess();
            Console.WriteLine("Delete");
        }
    }
}
