using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABAssignment2.Model
{
    public class Reservations
    {


        //Table Elements
        [Key]
        public int MealId { get; set; } //Primart Key

        [ForeignKey("Customer")]
        public int CustomerCPR { get; set; }

        [ForeignKey("Menu")]
        public string MenuItemId { get; set; }

        [ForeignKey("Canteens")]
        public string CanteenName { get; set; }


        //Relations
        public Customer Customer { get; set; }
        public Menu Menu { get; set; }
        public Canteens Canteens { get; set; }


    }
}
