using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeons_And_Flagons.Models
{
    public class Spells
    {
        [Key]
        public int ID { get; set; }
        public String Name { get; set; }
        public int Level { get; set; }
        public String CastingTime { get; set; }

        public String Range { get; set; }

        public String Components { get; set; }
        
        public String Duration { get; set; }

        public String School { get; set; }

        public String Description { get; set; }

        //FK to source
        [ForeignKey(nameof(Book))]
        public int Source { get; set; }
        public Sources Book { get; set; }

    }
}
