using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{

    [Serializable]
    public class Book                   //class book included information about people
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Data { get; set; }
        public string Phone { get; set; }
        public int Id { get; set; }

    }

    public class Find         // class used for find information in collection
    {
        public string FindName { get; set; }
        

    }
}