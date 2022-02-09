using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Special_Offer_Hunter.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LockoutModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}
