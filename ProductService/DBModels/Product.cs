using System;
using System.Collections.Generic;

namespace ProductService.DBModels;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? ProductImage { get; set; }
}
