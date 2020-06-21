using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_KOL.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEvent { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime StastDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<Artist_Event> Artist_Events { get; set; }
        public virtual ICollection<Event_Organiser> Event_Organisers { get; set; }
    }
}
