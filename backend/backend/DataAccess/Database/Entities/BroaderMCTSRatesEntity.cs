﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Entities
{
    [Table("broader_mcts_rates")]
    public class BroaderMCTSRatesEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public double time_study_per_test { get; set; }
        public double rate_per_hour { get; set; }
    }
}
