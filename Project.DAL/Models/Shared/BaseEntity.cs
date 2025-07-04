﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAcessLayer.Models.Shared
{
    public  class  BaseEntity
    {
        public int Id{ get; set; }

        public int CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; } 

        public int UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; } 

        public bool IsDeleted { get; set; } 
    }
}
