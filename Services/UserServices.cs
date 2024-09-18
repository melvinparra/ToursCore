using Microsoft.EntityFrameworkCore;
using tour.Interfaces;
using tour.models;
using tour.repos.Base;

namespace tour.Services
{
    public class UserServices : BaseRepository<Users>, IUsers
    {

        public UserServices(MyDBContext context):base(context)
        {
        }

        public async Task CreateUserAsync(Users user)
        {
            await Create(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {

            var user = await FindByCondiction(x => x.Id == id,false).FirstOrDefaultAsync();
               if (user != null)
                {
                await Update(user);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

              return false;
            }
        }
        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await FindByCondiction(x => x.Id > 0, false).ToListAsync();
        }

        public async Task<Users?> GetUserByIdAsync(int id) => await FindByCondiction(x => x.Id == id, false).FirstOrDefaultAsync();

        public async Task<bool> UpdateUserAsync(Users user)
        {
            try
            {
                await Update(user);
                return  true;
            }
            catch (Exception)
            {
            return false;
            }

        }
    }
}
