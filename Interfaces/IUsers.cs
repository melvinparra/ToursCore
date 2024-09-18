using tour.models;

namespace tour.Interfaces
{
    public interface IUsers
    {
        // Create a new user
        Task CreateUserAsync(Users user);

        // Get a user by ID
        Task<Users?> GetUserByIdAsync(int id);

        // Get all users
        Task<IEnumerable<Users>> GetAllUsersAsync();

        // Update an existing user
        Task<bool> UpdateUserAsync(Users user);

        // Delete a user by ID
        Task<bool> DeleteUserAsync(int id);

    }
}
