using System;
using System.ComponentModel.DataAnnotations;


namespace Resturants.Models
{
    public class Note
    {
        [Key]
        public int NotesID { get; set; }
        public string Description { get; set; }
    }
}

