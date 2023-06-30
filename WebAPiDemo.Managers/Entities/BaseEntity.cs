using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.Domain.Entities
{
    public class BaseEntity 
    {
         
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
    }
}
