using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataBaseStuff
{

    public class MovieList
    {
        [Key]
        public int MovieKey { get; set; }
        public String MovieName { get; set; }
        public int MinAge { get; set; }
        public int Rating { get; set; }
    }
}
