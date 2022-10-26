using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Configurations
{
    public class OperationConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            // Operation
            builder.Ignore(x => x.ID);
            builder.HasKey(x => new { x.StudentID, x.BookID });
            //builder.ToTable("Operasyonlar");
            builder.HasOne(o => o.Book).WithMany(o => o.Operations).HasForeignKey(o => o.BookID);
            builder.HasOne(O => O.Student).WithMany(o => o.Operations).HasForeignKey(o => o.StudentID);
        }
    }
}
