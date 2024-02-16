using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksMVC.Models;

public partial class Book
{
    public int Bookid { get; set; }
    [Required(ErrorMessage ="Please Enter Book Name !!")]
    public string Bookname { get; set; } = null!;
    [Required(ErrorMessage = "Please Enter Book Author Name !!")]
    public string Bookauthor { get; set; } = null!;
    [Required(ErrorMessage = "Please Enter Book Price !!")]
    public decimal Bookprice { get; set; }
}
