using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeService.Domain.Base
{
   
    public abstract class BaseEntity
    {        
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }        
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}