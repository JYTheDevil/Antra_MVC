using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
namespace ApplicationCore.RepositoryInterfaces
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetUserByEmail(string email);
        Task<IEnumerable<Movie>> GetPurchasedMovies(int Id);
        Task<IEnumerable<Movie>> GetFavoritedMovies(int Id);
        Task<User> EditUser(User user);
    }
}
