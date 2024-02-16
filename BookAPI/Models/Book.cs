using System;
using System.Collections.Generic;

namespace BookAPI.Models;

public partial class Book
{
    public int Bookid { get; set; }

    public string Bookname { get; set; } = null!;

    public string Bookauthor { get; set; } = null!;

    public decimal Bookprice { get; set; }
}
