using BlogRazor.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlogRazor.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace BlogRazor.Web.Pages.Admin.Users
    {

    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
        {
        private readonly IUserRepository userRepository;

        [BindProperty]
        public AddUser AddUserRequest { get; set; }

        [BindProperty]
        public List<User> Users { get; set; }

        [BindProperty]
        public Guid SelectedUserId { get; set; }

        public IndexModel(IUserRepository userRepository)
            {
            this.userRepository = userRepository;
            }

        public async Task<IActionResult> OnGet()
            {
            var users = await userRepository.GetAll();

            Users = new List<User>();
            foreach (var user in users)
                {
                Users.Add(new Models.ViewModels.User()
                    {
                    Id = Guid.Parse(user.Id),
                    Username = user.UserName,
                    Email = user.Email
                    });
                }

            return Page();
            }

        public async Task<IActionResult> OnPost()
            {
            var user = new IdentityUser()
                {
                UserName = AddUserRequest.Username,
                Email = AddUserRequest.Email
                };

            var roles = new List<string>
                {
                    "User"
                };

            if (AddUserRequest.AdminCheckbox)
                {
                roles.Add("Admin");
                }

            var result = await userRepository.Add(user, AddUserRequest.Password, roles);

            if (result)
                {
                return RedirectToPage("/Admin/Users/Index");
                }

            return Page();
            }


        public async Task<IActionResult> OnPostDelete()
            {
            await userRepository.Delete(SelectedUserId);
            return RedirectToPage("/Admin/Users/Index");
            }
        }
    }
