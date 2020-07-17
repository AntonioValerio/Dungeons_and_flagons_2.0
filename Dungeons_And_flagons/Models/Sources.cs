using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeons_And_Flagons.Models
{
    public class Sources
    {
        
        [Key]
        public int ID { get; set; }
        public String Name { get; set; }
        public String Summary { get; set;}
        public int Permission { get; set; }
        public String Path { get; set; }
        public String Category { get; set; }


        public ICollection<Classes> Classes { get; set; }
        public ICollection<Subclasses> Subclasses { get; set; }
        public ICollection<Spells> Spells { get; set; }
        public ICollection<Subraces> Subraces { get; set; }


    }
}
