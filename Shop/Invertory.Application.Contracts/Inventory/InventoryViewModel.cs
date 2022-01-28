﻿namespace Invertory.Application.Contracts.Inventory
{
    public class InventoryViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public long CurrentCount { get; set; }
        public bool Instock { get; set; }
    }

}