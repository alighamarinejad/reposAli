using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Base
{
    public class entity:object
    {
        public entity()
        {
                
        }


        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
            (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }


    }
}
