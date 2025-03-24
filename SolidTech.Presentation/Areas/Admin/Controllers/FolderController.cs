//using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SolidTech.Presentation.Areas.Admin.Controllers
{
    [RequestSizeLimit(80 * 1024 * 1024)]
    [Area("Admin")]
    public class FolderController : Controller
    {
        private readonly string _uploadsFolderName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetFile(IFormFile file)
        {
            if (file != null)
            {

                var fileName = file.FileName;
                var filePath = Path.Combine(_uploadsFolderName, fileName);

                if (!Directory.Exists(_uploadsFolderName))
                {
                    Directory.CreateDirectory(_uploadsFolderName);
                }

                var folder_new = new FileStream(filePath, FileMode.Create);


                file.CopyTo(folder_new);






            }




            return RedirectToAction();
        }
    }
}
