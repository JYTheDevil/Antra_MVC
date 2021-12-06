using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApplicationCore.Entities;
public class Trailer
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public string TrailerUrl { get; set; }
    public string Name { get; set; }
    //public Movie Movie { get; set; }
}