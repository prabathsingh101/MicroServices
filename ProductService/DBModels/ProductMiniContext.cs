using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductService.DBModels;

public partial class ProductMiniContext : DbContext
{
    public ProductMiniContext()
    {
    }

    public ProductMiniContext(DbContextOptions<ProductMiniContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }    

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Product>(entity =>
    //    {
    //        entity.ToTable("Product");
    //    });

    //    OnModelCreatingPartial(modelBuilder);
    //}

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
