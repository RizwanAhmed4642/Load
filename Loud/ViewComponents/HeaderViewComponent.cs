using Microsoft.AspNetCore.Mvc;

namespace SAS.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {

        public HeaderViewComponent()
        {
        }

        public IViewComponentResult Invoke(string filter)
        {
            return View();
        }
    }
}
