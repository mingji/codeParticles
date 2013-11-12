using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParticles.DataModels.Models
{
    public class CodeElement
    {
        public int Id { get; set; }
        public string Text { get; set; }
        //public int NuLines { get; set; }
        public DateTime Created { get; set; }
        //public int NuTags { get; set; }

        //public ICollection<Tag> Tags { get; set; }
    }
}
