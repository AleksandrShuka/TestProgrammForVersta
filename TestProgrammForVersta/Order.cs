using System;
using System.Collections.Generic;

namespace TestProgrammForVersta
{
    public partial class Order
    {
        public int Id { get; set; }
        public string? SenderCity { get; set; }
        public string? SenderAddress { get; set; }
        public string? RecieverCity { get; set; }
        public string? RecieverAddress { get; set; }
        public double Weight { get; set; }
        public DateTime Date { get; set; }
    }
}
