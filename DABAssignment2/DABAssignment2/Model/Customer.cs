


using Microsoft.EntityFrameworkCore;

namespace DABAssignment2.Model
{
    public class Customer
    {
        //Table Elements
        public int CustomerCPR;
        
        //Relations
        public ICollection<Reservations>? Reservations { get; }
        public ICollection<Ratings>? Ratings { get; }
    }
}
