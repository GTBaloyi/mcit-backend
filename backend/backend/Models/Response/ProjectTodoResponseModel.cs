using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class ProjectTodoResponseModel
    {
        public int id { get; set; }
        public string projectNumber { get; set; }
        public int sequenceNumber { get; set; }
        public bool isSequential { get; set; }
        public string focusArea { get; set; }
        public string item { get; set; }
        public DateTime dateStarted { get; set; }
        public DateTime dateEnded { get; set; }
        public string[] responsibleEmployees { get; set; }
    }
}
