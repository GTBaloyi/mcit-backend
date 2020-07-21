using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class FocusAreaModel
    {
        public FocusAreaModel(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public FocusAreaModel()
        {

        }
       
        public int id { get; set; }
        public string name { get; set; }
    }
}
