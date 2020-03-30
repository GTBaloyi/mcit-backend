﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Entities
{
    [Table("company")]
    public class CompanyEntity
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string company_profile { get; set; }
        public bool isCompanyPresent { get; set; }
    }
}