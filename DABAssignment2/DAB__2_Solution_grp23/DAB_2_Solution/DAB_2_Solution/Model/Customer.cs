


using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DABAssignment2.Model
{
    public class Customer
    {
        //Table Elements
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AUid; //Primary Key 
        public int? CustomerCPR { get; set; }
        //Relations
        public ICollection<Reservations> Reservations { get; }
        public ICollection<Ratings> Ratings { get; }
    }
}
