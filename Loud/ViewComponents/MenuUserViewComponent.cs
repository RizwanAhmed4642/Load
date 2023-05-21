using SAS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SAS.ViewComponents
{
    public class MenuUserViewComponent : ViewComponent
    {

        public MenuUserViewComponent()
        {
        }

        public IViewComponentResult Invoke(string filter)
        {
            return View();
        }
    }
}
