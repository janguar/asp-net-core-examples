using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace WebApiDemo.Entities
{
    public class ItemEntity: BaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } 
    }
}
