using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABAssignment2.Model
{
    public class Menu
    {
        //Table Elements
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MenuItemsId { get; set; } //Primary Key

        [Required]
        [Range(0,2)] // 0: warm  1: street  2: JIT 
        public int MealType { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string MealName { get; set;}

        [Required]
        [ForeignKey("Canteens")]
        public string CanteenName { get; set; }

        [Required]
        public int NrReservations { get; set; }

        //Relations
        public Canteens Canteens { get; set; }
        public ICollection<Reservations> Reservations { get; }
    }
}
