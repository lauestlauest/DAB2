using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAB_2_Solution.Model;
using Microsoft.EntityFrameworkCore;

namespace DABAssignment2.Model
{
    public class Canteens
    {
        //Table Elements
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CanteenName; //Primary Key

        [Required]
        [Range(1301, 9990)]
        public int PostCode;


        //Relations
        public ICollection<Menu> Menu { get; }

        public ICollection<Reservations> Reservations { get; }
        
        public ICollection<Ratings> Ratings { get; }

        public ICollection<Staff> Staff { get; }
    }
}
