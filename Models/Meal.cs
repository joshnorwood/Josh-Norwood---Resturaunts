using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturants.Models
{
	public class Meal
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MealID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int? CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category? Category { get; set; }

        public int? NotesID { get; set; }

        [ForeignKey("NotesID")]
        public virtual Note Note { get; set; }
    }
}
