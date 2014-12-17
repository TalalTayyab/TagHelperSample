using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TagHelperSample.Model
{
    public class Person
    {
        [Required]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
       
     
        [Range(typeof(DateTime),"01/01/1930","01/01/2014",ErrorMessage = "Enter birth date between 1930 and 2014")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

       
        [Required(AllowEmptyStrings =false)]
        public string Country { get; set; }

        [Required]
        public string Information { get; set; }


        /// <summary>
        /// For now -we store all the persons in a static list :O
        /// </summary>
        public  static List<Person> Persons { get; set; } = new List<Person>();
     
    }
}