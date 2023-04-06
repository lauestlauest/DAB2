using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABAssignment2.Model
{
    public class Ratings
    {
        //Table Elements
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RatingsId { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerCPR { get; set; }

        [Required]
        [ForeignKey("Canteens")]
        public string CanteenName { get; set; }

        [Required]
        [Range(1, 10)]
        public int Rating { get; set; }

        
        public DateTime RatingDate { get; set; }
        

        //Relations
        public Customer Customer { get; set; }
        public Canteens Canteens { get; set; }

    }
}
