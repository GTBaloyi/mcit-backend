using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class ClientModel
    {

        public ClientModel(int? clientId, string title, string name, string surname, string gender, string? email, string? phone, string quarter, int businessId, DateTime? dateCapture, string? username)
        {
            this.clientId = clientId;
            this.title = title;
            this.name = name;
            this.surname = surname;
            this.gender = gender;
            this.email = email;
            this.phone = phone;
            this.quarter = quarter;
            this.businessId = businessId;
            this.dateCapture = dateCapture;
            this.username = username;

        }

        public int? clientId { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string gender { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string quarter { get; set; }
        public int businessId { get; set; }
        public DateTime? dateCapture { get; set; }
        public string username { get; set; }
    }


}
