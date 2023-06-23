using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.DTO
{
    public class BaseEntityDto
    {
        public DateTime CreatedAt
        {
            get;
            set;
        }
        public DateTime ModifiedAt
        {
            get;
            set;
        }
        public bool IsActiveEntity
        {
            get;
            set;
        }
    }
}
