using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Centras.Pages
{
    public class ServiceModel : PageModel
    {
        private readonly ILogger<ServiceModel> _logger;

        public ServiceModel(ILogger<ServiceModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
