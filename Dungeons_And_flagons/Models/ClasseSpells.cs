using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeons_And_Flagons.Models
{
    public class ClasseSpells
    {

        [Key]
        [ForeignKey(nameof(Classe))]
        public int ClasseID { get; set; }
        public virtual Classes Classe { get; set; }


        [Key]
        [ForeignKey(nameof(Tome))]
        public int SpellID { get; set; }
        public virtual Spells Tome { get; set; }

    }
}
