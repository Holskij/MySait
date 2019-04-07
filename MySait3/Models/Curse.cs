using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySait3.Models
{
    public class Curse
    {
        public int Id { get; set; }
        public string NameCurse { get; set; }
        public string Specialty { get; set; }
        public string ProgramCurse { get; set; }
        public string OpusCurse { get; set; }

        public ICollection<Work> Works { get; set; }

        public Curse()
        {
            Works = new List<Work>();
        }
    }
}