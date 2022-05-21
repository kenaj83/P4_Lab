using System;
using System.Collections.Generic;

namespace Lab_4_10_04_2022.Northwind
{
    public partial class CustomerAndSuppliersByCity
    {
        public string? City { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string Relationship { get; set; } = null!;
    }
}
