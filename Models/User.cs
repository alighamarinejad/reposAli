using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class User : Base.entity
    {
        public User()
        {

        }

        [System.ComponentModel.DataAnnotations.MaxLength
     (length: 30)]
        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(DataDictionary.Dictionaries.UserDictionary.UserDictionary)
            ,Name = nameof(DataDictionary.Dictionaries.UserDictionary.UserDictionary.FirstName))]
        public string Fname { get; set; }



        [System.ComponentModel.DataAnnotations.MaxLength
        (length: 50)]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(DataDictionary.Dictionaries.UserDictionary.UserDictionary)
            , Name = nameof(DataDictionary.Dictionaries.UserDictionary.UserDictionary.LastName))]
        public string Lname { get; set; }



        [System.ComponentModel.DataAnnotations.MaxLength
            (length: 10, ErrorMessage =nameof( DataDictionary.Dictionaries.UserDictionary.UserDictionary.NationalIDError))]
        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(DataDictionary.Dictionaries.UserDictionary.UserDictionary)
            , Name = nameof(DataDictionary.Dictionaries.UserDictionary.UserDictionary.NationalID))]
        public string NationalID { get; set; }

        public System.Collections.Generic.ICollection<PhoneBook> User_PhoneBooks { get; set; }


    }
}
