using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class PurchasedMovieResponseModel
    {
        public PurchasedMovieResponseModel()
        {
            Purchases = new PurchasedResponseModel();
        }
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public string? PosterUrl { get; set; }
        public PurchasedResponseModel Purchases { get; set; }
    }
}