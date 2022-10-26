using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            // Book
            builder.HasOne(o => o.Author).WithMany(o => o.Books).HasForeignKey(o => o.AuthorID);
            builder.HasOne(o => o.BookType).WithMany(o => o.Books).HasForeignKey(o => o.BookTypeID);
        }
    }
}
