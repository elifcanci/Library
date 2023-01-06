using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Author : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        //Relational Property

        public List<Book> Books { get; set; }
    }
}
