using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABAssignment2.Model
{
    public class Ratings
    {
        //Table Elements

        public int RatingsId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerCPR { get; set; }

        [ForeignKey("Canteens")]
        public string CanteenName { get; set; }

        public int Rating { get; set; }

        public DateTime RatingDate { get; set; }
        

        //Relations
        public Customer Customer { get; set; }
        public Canteens Canteens { get; set; }

    }
}
