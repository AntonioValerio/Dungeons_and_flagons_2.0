using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeons_And_Flagons.Models
{
    public class SubraceSpell
    {
       
        [Key]
        [ForeignKey(nameof(Race))]
        public int SubraceID { get; set; }
        public virtual Subraces Race { get; set; }



        [Key]
        [ForeignKey(nameof(Tome))]
        public int SpellID { get; set; }
        public virtual Spells Tome { get; set; }


    }
}
