using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> EditUserProfile(UserDetailsModel user)
        {
            var dbUser = _userRepository.GetUserByEmail(user.Email);
            if (dbUser != null)
            {
                throw new Exception("Email already exists and please check!");
                return false;
            }

            if (user.GivenName == null && user.SurName == null && user.DateOfBirth == null
                 && user.Email == null && user.PhoneNum == null)
            {
                return false;
            }

            var _user = new User
            {
                Id = user.Id,
                FirstName = user.GivenName,
                LastName = user.SurName,
                Email = user.Email,
                PhoneNumber = user.PhoneNum,
                DateOfBirth = user.DateOfBirth
            };
            _user = await _userRepository.EditUser(_user);
            return true;
        }

        public async Task<UserDetailsModel> GetUserDetails(int id)
        {
            var user = await _userRepository.GetById(id);

            var userDetails = new UserDetailsModel
            {
                Id = id,
                GivenName = user.FirstName,
                SurName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                PhoneNum = user.PhoneNumber
            };
            return userDetails;
        }

        public async Task<List<MovieCardResponseModel>> GetUserFavoritedMovies(int id)
        {
            var movie = await _userRepository.GetFavoritedMovies(id);

            var movieCards = new List<MovieCardResponseModel>();

            foreach (var item in movie)
            {
                movieCards.Add(new MovieCardResponseModel
                { Id = item.Id, PosterUrl = item.PosterUrl, Title = item.Title });
            }

            return movieCards;
        }

        public async Task<List<PurchasedMovieResponseModel>> GetUserPurchasedMovies(int id)
        {
            var movie = await _userRepository.GetPurchasedMovies(id);

            var movieCards = new List<PurchasedMovieResponseModel>();

            foreach (var item in movie)
            {
                var purchase = item.Purchases[0];
                movieCards.Add(new PurchasedMovieResponseModel
                {
                    Id = item.Id,
                    PosterUrl = item.PosterUrl,
                    Title = item.Title,
                    Price = item.Price,
                    Purchases = new PurchasedResponseModel
                    {
                        Id = purchase.Id,
                        PurchaseNumber = purchase.PurchaseNumber,
                        PurchaseDateTime = purchase.PurchaseDateTime
                    }
                });
            }

            return movieCards;
        }
    }
}
