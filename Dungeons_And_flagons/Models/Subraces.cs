using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeons_And_Flagons.Models
{
    public class Subraces
    {
    
        [Key]
        public int ID { get; set; }

        public String MainRace { get; set; }

        public String Name { get; set; }

        public String Description {get;set;}

        public String Features { get; set; }

        
        //public int permissions { get; set; }


        //FK to Source
        [ForeignKey(" Book")]
        public int Source { get; set; }
        public virtual Sources Book { get; set; }

  
    }
}
