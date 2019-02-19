﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bookstore.UI.Models
{
  public class Book
  {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(120)]
    [Required]
    [Index]
    public string Name { get; set; }

    [Required]
    [Index]
    public decimal Price { get; set; }

    [StringLength(500)]
    public string CoverImagePath { get; set; }

    [Required]
    [StringLength(50)]
    public string Author { get; set; }

    [StringLength(800)]
    public string Description { get; set; }

    [StringLength(500)]
    public string Condition { get; set; }

    [StringLength(15)]
    public string PublishYear { get; set; }

    public bool IsDeleted { get; set; }

    [StringLength(50)]
    public string ISBN { get; set; }

    [Column(TypeName ="datetime2")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime2")]
    public DateTime? ModifiedDate { get; set; }

    [StringLength(50)]
    public string SellerId { get; set; }

    public virtual ApplicationUser Seller { get; set; }

    public bool? Offered { get; set; }

    [Column(TypeName = "datetime2")]
    public DateTime? OfferDate { get; set; }

    [StringLength(50)]
    public string BuyerId { get; set; }

    public virtual ApplicationUser Buyer { get; set; }

  }
}