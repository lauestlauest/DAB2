using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABAssignment2.Model
{
    public class Canteens
    {
        //Table Elements
        [Key]
        public string CanteenName;

        public string WarmMealName;

        public string StreetMealName;

        public int AmountWarmMeal;

        public int AmountStreetMeal;

        public int PostCode;


        //Relations
        public ICollection<JITItems> JitItems { get; }

        public ICollection<Reservations> Reservations { get; }
        
        public ICollection<Ratings> Ratings { get; }
    }
}
