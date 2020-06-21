using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_KOL.Models
{
    public class Organiser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrganiser { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public virtual ICollection<Event_Organiser> Event_Organisers { get; set; }
    }
}
