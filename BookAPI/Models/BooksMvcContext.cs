using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Models;

public partial class BooksMvcContext : DbContext
{
    public BooksMvcContext()
    {
    }

    public BooksMvcContext(DbContextOptions<BooksMvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BooksMVC;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Bookid).HasName("PK__Books__8BEA95C59A682D6C");

            entity.Property(e => e.Bookid).HasColumnName("bookid");
            entity.Property(e => e.Bookauthor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bookauthor");
            entity.Property(e => e.Bookname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bookname");
            entity.Property(e => e.Bookprice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("bookprice");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
