using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogRazor.Web.Data
{
    /// <summary>
    /// Represents the database context for authentication-related data using Identity.
    /// </summary>
    public class AuthDbContext : IdentityDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Customizes the database schema for the authentication context.
        /// </summary>
        /// <param name="builder">The model builder used to construct the database schema.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Defining roles and their IDs
            var superAdminRoleId = "73fac54b-477c-4592-91cc-3379798e6bec";
            var adminRoleId = "0eb4409e-43e6-4eba-96e5-019b2d28392d";
            var userRoleId = "7415ce6b-a032-4f57-a697-c8e532e7ca0d";

            // Creating IdentityRole instances for SuperAdmin, Admin, and User roles
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Name ="SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },
                new IdentityRole()
                {
                    Name ="Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                 new IdentityRole()
                {
                    Name ="User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };

            // Adding roles to the database
            builder.Entity<IdentityRole>().HasData(roles);

            // Defining the SuperAdmin user and its ID
            var superAdminId = "de0b87d9-f234-4f85-875c-1816f73563ff";

            // Creating the SuperAdmin IdentityUser
            var superAdminUser = new IdentityUser()
            {
                Id = superAdminId,
                UserName = "superadmin@test.com",
                Email = "superadmin@test.com",
                NormalizedEmail = "superadmin@test.com".ToUpper(),
                NormalizedUserName = "superadmin@test.com".ToUpper()
            };

            // Hashing the SuperAdmin user's password
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser,"superadmin123");

            // Adding the SuperAdmin user to the database
            builder.Entity<IdentityUser>().HasData(superAdminUser);

            // Assigning roles to the SuperAdmin user
            var superAdminRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                },
            };

            // Adding the roles assigned to the SuperAdmin user to the database
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
