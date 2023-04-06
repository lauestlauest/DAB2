using System;
using Microsoft.EntityFrameworkCore;

namespace DABAssignment2.Model
{
    public class Canteens
    {
        //Table Elements
        public string CanteenName;

        public string WarmMealName;

        public string StreetMealName;

        public int AmountWarmMeal;

        public int AmountStreetMeal;

        public int PostCode;


        //Relations
        public ICollection<Menu> JitItems { get; }

        public ICollection<Reservations> Reservations { get; }
        
        public ICollection<Ratings> Ratings { get; }
    }
}
