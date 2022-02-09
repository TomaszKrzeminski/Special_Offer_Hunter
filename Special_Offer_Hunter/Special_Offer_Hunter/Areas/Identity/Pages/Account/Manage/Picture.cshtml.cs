using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Special_Offer_Hunter.Models;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Areas.Identity.Pages.Account.Manage
{


    public partial class PictureModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IRepository repository;

        public PictureModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IRepository repository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.repository = repository;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public string ReturnUrl { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string UserPhotoPath { get; set; }
            public string UserId { get; set; }
            public string UserName { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var UserX = await _userManager.GetUserAsync(User);

            ApplicationUser u = new ApplicationUser();

            Input = new InputModel
            {
                UserName = userName,
                UserId = UserX.Id,
                UserPhotoPath = UserX.UserImagePath
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //returnUrl = returnUrl ?? Url.Content("~/");
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            /////////



            if (Input.UserPhotoPath != null)
            {
                ApplicationUser User = await _userManager.FindByIdAsync(user.Id);

                User.UserImagePath = Input.UserPhotoPath;

                IdentityResult check = await _userManager.UpdateAsync(User);


                if (!check.Succeeded)
                {
                    StatusMessage = "Nie udało się wprowadzić zmian";
                    return RedirectToPage();
                }


            }

            //////////


            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }






}