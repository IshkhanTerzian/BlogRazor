using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogRazor.Web.Data
    {
    public class AuthDbContext : IdentityDbContext
        {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
            {
            }

        protected override void OnModelCreating(ModelBuilder builder)
            {
            base.OnModelCreating(builder);

            var superAdminRoleId = "73fac54b-477c-4592-91cc-3379798e6bec";
            var adminRoleId = "0eb4409e-43e6-4eba-96e5-019b2d28392d";
            var userRoleId = "7415ce6b-a032-4f57-a697-c8e532e7ca0d";

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

            builder.Entity<IdentityRole>().HasData(roles);

            var superAdminId = "de0b87d9-f234-4f85-875c-1816f73563ff";

            var superAdminUser = new IdentityUser()
                {
                Id = superAdminId,
                UserName = "superadmin@test.com",
                Email = "superadmin@test.com",
                NormalizedEmail = "superadmin@test.com".ToUpper(),
                NormalizedUserName = "superadmin@test.com".ToUpper()
                };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "superadmin123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

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

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

            }
        }
    }
