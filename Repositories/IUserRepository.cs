using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync(string? filterOn=null, string? filterQuery=null,
            string? sortBy=null, bool isAscending=true, int pageNumber=1, int pageSize=1000);
        Task<User?> CreateUserAsync(User user);

        Task<User?> UpdateUserAsync(string QLID,User user);

        Task<User?> GetSingleUserAsync(string QLID);
        
        Task <User?> DeleteUserAsync(string QLID);

    }
}
