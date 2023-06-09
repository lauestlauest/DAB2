﻿using System;
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MealId { get; set; } //Primary Key

        [ForeignKey("Customer")]
        public int? AUid { get; set; }
        public int? CustomerCPR { get; set; }
        [ForeignKey("Menu")]
        public int MenuItemId { get; set; }

        [ForeignKey("Canteens")]
        public string CanteenName { get; set; }


        //Relations
        public Customer Customer { get; set; }
        public Menu Menu { get; set; }
        public Canteens Canteens { get; set; }


    }
}
