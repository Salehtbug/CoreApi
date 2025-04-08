using System;
using System.Collections.Generic;

namespace FirstCoreApi_Project.Server.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductDescription { get; set; }
}
