using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Model
{
	public class Bill
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public decimal Amount { get; set; }
        public bool Paid { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public List<Bill>? BillList { get; set; }

        private static List<Bill> _instances = new List<Bill>() { };

    }
}

