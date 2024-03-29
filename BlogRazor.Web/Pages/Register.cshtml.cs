using BlogRazor.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRazor.Web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;

        [BindProperty]
        public Register Register { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = Register.UserName,
                    Email = Register.Email,

                };

                var identityResult = await userManager.CreateAsync(user,Register.Password);

                if (identityResult.Succeeded)
                {

                    var addRolesResult = await userManager.AddToRoleAsync(user,"User");

                    if (addRolesResult.Succeeded)
                    {
                        ViewData["Notification"] = new Notification
                        {
                            Type = Enums.NotificationType.Success,
                            Message = "User registered succesfully."
                        };

                        return Page();
                    }
                }

                ViewData["Notification"] = new Notification
                {
                    Type = Enums.NotificationType.Error,
                    Message = "Registration failed."
                };
                return Page();
            } else
            {
                return Page();
            }
        }

    }
}
