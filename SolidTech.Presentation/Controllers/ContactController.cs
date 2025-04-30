
namespace SolidTech.Presentation.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IMessageService _messageService;
        private readonly IProjectService _projectService;

        public ContactController(IMessageService messageService, IProjectService projectService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            List<MessageDto> messages = _messageService.Messages();
            return View();
        }

        [HttpPost]
        public IActionResult AddAcontact(string name, string email, string subject, string message)
        {
            int messages = _messageService.AddMessage(
            new MessageDto
            {
                Email = email,
                Name = name,
                MessageHeader = subject,
                MessageContent = message,
                MessageTypeId = 2
            });

            return RedirectToAction("Index", "Contact");
        }
    }
}
