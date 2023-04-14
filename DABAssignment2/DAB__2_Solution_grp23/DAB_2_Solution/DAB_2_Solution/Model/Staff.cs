using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DABAssignment2.Model;

namespace DAB_2_Solution.Model
{
	public class Staff
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int StaffId { get; set; }

		public string Name { get; set; }
		public string Title { get; set; }
		public int Salary { get; set; }

		[ForeignKey("Canteens")]
		public string CanteenName { get; set; }

		public Canteens Canteens { get; set; }

	}
}
