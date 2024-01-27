using Microsoft.AspNetCore.Identity;

namespace BlogRazor.Web.Repositories
{
    /// <summary>
    /// Interface for managing user-related operations in the application.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets all users from the identity system asynchronously.
        /// </summary>
        /// <returns>A collection of all users in the identity system.</returns>
        Task<IEnumerable<IdentityUser>> GetAll();

        /// <summary>
        /// Adds a new user to the identity system asynchronously.
        /// </summary>
        /// <param name="identityUser">The user to be added.</param>
        /// <param name="password">The password for the new user.</param>
        /// <param name="roles">A list of roles to assign to the new user.</param>
        /// <returns>True if the user is added successfully; otherwise, false.</returns>
        Task<bool> Add(IdentityUser identityUser,string password,List<string> roles);

        /// <summary>
        /// Deletes a user from the identity system by their unique identifier.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to be deleted.</param>
        Task Delete(Guid userId);
    }
}
