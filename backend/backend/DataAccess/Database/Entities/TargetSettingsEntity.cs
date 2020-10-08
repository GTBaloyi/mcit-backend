﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Entities
{
    [Table("target_settings")]
    public class TargetSettingsEntity
    {
        public int id { get; set; }
        public string title { get; set; }
        public double overallTarget { get; set; }
        public double q1_target { get; set; }
        public double q2_target { get; set; }
        public double q3_target { get; set; }
        public double q4_target { get; set; }
        public double q1_actual { get; set; }
        public double q2_actual { get; set; }
        public double q3_actual { get; set; }
        public double q4_actual { get; set; }
    }
}