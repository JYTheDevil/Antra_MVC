using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        public async override Task<List<Genre>> GetAll()
        {
            return await _dbContext.Set<Genre>().OrderBy(g => g.Name).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetGenreMovies(int Id)
        {
            var movie = await _dbContext.Movies.Where(
                 x => _dbContext.MoviesGenre.Where(g => g.GenreId == Id).Select(g => g.MovieId).Contains(x.Id))
                 .ToListAsync();

            return movie;
        }
    }
}