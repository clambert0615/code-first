using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookwithcodefirst.Context
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(30)]
        [Required]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Author { get; set; }
    }

    public class BooksDbContext : DbContext
    {
       public DbSet<Book> Books { get; set; }
        public BooksDbContext(DbContextOptions options) : base(options) { }
    }
}
