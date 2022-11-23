﻿namespace ManagementService.Data.Models
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}
