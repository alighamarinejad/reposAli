using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
   public class Contact:Object
    {
        public int UserId { get; set; }

        public string Fname { get; set; }

        public string Lname { get; set; }

        public string NationalID { get; set; }

        public string PhoneNo { get; set; }

        public int Id { get; set; }


    }
}
