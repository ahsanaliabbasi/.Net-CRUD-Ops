using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NZWalksDBContext dBContext;

        public UserRepository(NZWalksDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<User?> CreateUserAsync(User user)
        {
            var nuser= await dBContext.Users.FindAsync(user.QLID);
            if(nuser!=null)
            {
                return nuser;
            }
            var myuser = await dBContext.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
            if(myuser!=null)
            {
                return myuser;
            }

            await dBContext.Users.AddAsync(user);
            await dBContext.SaveChangesAsync();
            return null;
            

        }

        public async Task<User?> DeleteUserAsync(string QLID)
        {
            var nuser= await dBContext.Users.FindAsync(QLID);
            if (nuser == null)
            {
                return null;
            }
            dBContext.Users.Remove(nuser);
            await dBContext.SaveChangesAsync();
            return nuser;
        }

        public async Task<User?> GetSingleUserAsync(string QLID)
        {
            var suser=await dBContext.Users.FindAsync(QLID);
            if (suser == null)
            {
                return null;
            }
            return suser;
        }

        public async Task<List<User>> GetUsersAsync(string? filterOn = null, string? filterQuery = null,
            [FromQuery] string? sortBy = null, [FromQuery] bool isAscending = true, 
            [FromQuery] int pageNumber = 1,[FromQuery] int pageSize = 1000)
        {
            var users = dBContext.Users.AsQueryable();

            //Filter

            if(string.IsNullOrWhiteSpace(filterOn)==false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {

                // Filter based on Role column.
                if (filterOn.Equals("FirstName", StringComparison.OrdinalIgnoreCase))
                {
                    users=users.Where(x=>x.FirstName.Contains(filterQuery));
                }
            }


            // Sorting


            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("QLID", StringComparison.OrdinalIgnoreCase))
                {
                    users = isAscending?  users.OrderBy(x=>x.QLID): users.OrderByDescending(x=>x.QLID) ;
                }


                if (sortBy.Equals("FirstName", StringComparison.OrdinalIgnoreCase))
                {
                    users= isAscending? users.OrderBy(x=>x.FirstName): users.OrderByDescending(x=>x.FirstName) ;
                }

            }

            // Pagination



            var skipResults = (pageNumber - 1) * pageSize;

            return await users.Skip(skipResults).Take(pageSize).ToListAsync();

            //return await dBContext.Users.ToListAsync();
            
        }

        public async Task<User?> UpdateUserAsync(string QLID, User user)
        {
            var myuser=await dBContext.Users.FindAsync(QLID);
            if (myuser == null)
            {
                return null;
            }
            myuser.QLID = user.QLID;
            myuser.FirstName = user.FirstName;
            myuser.LastName = user.LastName;
            myuser.Email = user.Email;
            myuser.APM = user.APM;
            myuser.Role = user.Role;

            await dBContext.SaveChangesAsync();
            return myuser;
        }   
    }
}
