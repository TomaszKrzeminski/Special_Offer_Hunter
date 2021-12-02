﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Special_Offer_Hunter.Models;

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

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            public ApplicationUser userData { get; set; }

            public string Username { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            ApplicationUser u = new ApplicationUser();

            Input = new InputModel
            {
                Username = userName,
                PhoneNumber = phoneNumber,
                userData = user
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

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            /////////



            if (Input.userData != null)
            {
                ApplicationUser User = await _userManager.FindByIdAsync(user.Id);

                User.SetUser(Input.userData);
                IdentityResult check = await _userManager.UpdateAsync(User);


                if (!check.Succeeded)
                {
                    StatusMessage = "Nie udało się wprowadzić zmian";
                    return RedirectToPage();
                }


            }

            //////////
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }






}