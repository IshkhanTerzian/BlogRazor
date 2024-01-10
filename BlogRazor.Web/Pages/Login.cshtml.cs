using BlogRazor.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRazor.Web.Pages
    {
    public class LoginModel : PageModel
        {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Login Login { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
            {
            this.signInManager = signInManager;
            }

        public void OnGet()
            {
            }

        public async Task<IActionResult> OnPost()
            {
            var signInResult = await signInManager.PasswordSignInAsync(Login.Username, Login.Password, false, false);

            if (signInResult.Succeeded)
                {
                return RedirectToPage("Index");
                }
            else
                {
                ViewData["Notification"] = new Notification
                    {
                    Type = Enums.NotificationType.Error,
                    Message = "Unable to Login"
                    };
                return Page();
                }
            }
        }
    }
