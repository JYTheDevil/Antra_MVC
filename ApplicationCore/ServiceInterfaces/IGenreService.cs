using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreModel>> GetAllGenres();
        Task<List<MovieCardResponseModel>> GetMovieGenre(int Id);
    }
}