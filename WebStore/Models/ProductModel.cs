﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class ProductViewModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Display(Name="Название")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Категория")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Подкатегория")]
        public string Subcategory { get; set; }
        [Required]
        [Display(Name = "Цена")]
        public double Price { get; set; }
    }
    public class ProductModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Subcategory { get; set; }
        [Required]
        public double Price { get; set; }
        public virtual ProductPhoto Photo { get; set; }
        
    }

    public class ProductPhoto
    {
        [Key]
        [ForeignKey("Product")]
        public int ProductId { get; set;}
        public string MimeType { get; set; }
        public byte[] Photo { get; set; }
        public virtual ProductModel Product { get; set; }
    }


    public class ProductContext : DbContext
    {
        public ProductContext() : base("DefaultConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // other code 
            Database.SetInitializer<ProductContext>(null);
            // more code here.
        }
        public DbSet<ProductPhoto> Photos { get; set; }
        public DbSet<ProductModel> Products { get; set; }
    }
}