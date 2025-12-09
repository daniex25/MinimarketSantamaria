using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MinimarketSantamaria.ViewComponents
{
    public class IdiomaViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult>
           InvokeAsync()
        {
            var idiomas = new List<SelectListItem>();
            idiomas.Add(new SelectListItem()
            {
                Value = "en-US",
                Text = "English"
            });
            idiomas.Add(new SelectListItem()
            {
                Value = "es-PE",
                Text = "Español"
            });
            idiomas.Add(new SelectListItem()
            {
                Value = "fr-FR",
                Text = "Français"
            });
            var currentCulture = HttpContext.Features.Get<IRequestCultureFeature>();

            ViewBag.IdiomaSel = currentCulture?.RequestCulture?.UICulture?.Name
                                ?? System.Globalization.CultureInfo.CurrentUICulture.Name;

            return View(idiomas);
        }
    }
}
