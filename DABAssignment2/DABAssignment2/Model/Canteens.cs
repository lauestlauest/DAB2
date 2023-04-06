using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DABAssignment2.Model
{
    public class Canteens
    {
        //Table Elements
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CanteenName;

        [Required]
        [Range(1301, 9990)]
        public int PostCode;


        //Relations
        public ICollection<Menu> Menu { get; }

        public ICollection<Reservations> Reservations { get; }
        
        public ICollection<Ratings> Ratings { get; }
    }
}
