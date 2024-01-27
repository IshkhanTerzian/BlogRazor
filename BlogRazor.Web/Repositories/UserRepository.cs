using BlogRazor.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogRazor.Web.Repositories
{
    /// <summary>
    /// Repository for managing user-related operations in the application.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext authDbContext;
        private readonly UserManager<IdentityUser> userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="authDbContext">The database context for authentication.</param>
        /// <param name="userManager">The user manager for managing identity users.</param>
        public UserRepository(AuthDbContext authDbContext,UserManager<IdentityUser> userManager)
        {
            this.authDbContext = authDbContext;
            this.userManager = userManager;
        }

        /// <summary>
        /// Adds a new user to the identity system asynchronously.
        /// </summary>
        /// <param name="identityUser">The user to be added.</param>
        /// <param name="password">The password for the new user.</param>
        /// <param name="roles">A list of roles to assign to the new user.</param>
        /// <returns>True if the user is added successfully; otherwise, false.</returns>
        public async Task<bool> Add(IdentityUser identityUser,string password,List<string> roles)
        {
            var user = await userManager.CreateAsync(identityUser,password);

            if (user.Succeeded)
            {
                var newUser = await userManager.AddToRolesAsync(identityUser,roles);

                if (newUser.Succeeded)
                {
                    return true; // User added successfully
                }
            }

            return false; // User creation or role assignment failed
        }

        /// <summary>
        /// Deletes a user from the identity system by their unique identifier.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to be deleted.</param>
        public async Task Delete(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            if (user != null)
            {
                await userManager.DeleteAsync(user);
            }
        }

        /// <summary>
        /// Gets all users from the identity system asynchronously.
        /// </summary>
        /// <returns>A collection of all users in the identity system.</returns>
        public async Task<IEnumerable<IdentityUser>> GetAll()
        {
            var users = await authDbContext.Users.ToListAsync();
            var superAdminUser = await authDbContext.Users.FirstOrDefaultAsync(x => x.Email == "superadmin@test.com");

            if (superAdminUser != null)
            {
                users.Remove(superAdminUser); // Exclude super admin user from the list
            }

            return users;
        }
    }
}
