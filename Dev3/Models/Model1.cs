namespace Dev3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=pdfentities")
        {
        }

        public virtual DbSet<pdf_tbl> pdf_tbl { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<pdf_tbl>()
                .Property(e => e.bookTitle)
                .IsUnicode(false);
        }
    }
}
