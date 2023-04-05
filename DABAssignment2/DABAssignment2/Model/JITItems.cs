using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABAssignment2.Model
{
    public class JITItems
    {
        //Table Elements
        public int JITItemsId { get; set; }

        public string JITMealName { get; set;}

        [ForeignKey("Canteens")]
        public string CanteenName { get; set; }


        //Relations
        public Canteens Canteens { get; set; }
    }
}
