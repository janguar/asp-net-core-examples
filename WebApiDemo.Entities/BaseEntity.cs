using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.Entities
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
