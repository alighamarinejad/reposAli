using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class PhoneBook:Base.entity
    {
        public PhoneBook()
        {

        }
    


        [System.ComponentModel.DataAnnotations.MaxLength
            (length:11,ErrorMessage =nameof(DataDictionary.Dictionaries.PhoneDictionary.PhoneBookDictionary.MaxLengthPhone))]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(DataDictionary.Dictionaries.PhoneDictionary.PhoneBookDictionary)
            , Name = nameof(DataDictionary.Dictionaries.PhoneDictionary.PhoneBookDictionary.PhoneNumber))]
        public string PhoneNo { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }



    }
}
