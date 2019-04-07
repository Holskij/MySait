using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySait3.Models
{
    public class Work
    {
        public int WorkId { get; set; }
        public string Autors { get; set; }
        public string NameWork { get; set; }
        public string NamePublishing { get; set; }
        public int Year { get; set; }
        public int Page { get; set; }
        public string TypePublishing { get; set; }
        public string NameFile { get; set; }

        public int? CurseId { get; set; }
        public Curse Curse { get; set; }
    }
}