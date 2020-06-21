using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_KOL.Models
{
    public class Event_Organiser
    {
        [Key]
        public int IdEvent { get; set; }
        [Key]
        public int IdOrganiser { get; set; }
        public virtual Event Event { get; set; }
        public virtual Organiser Organiser { get; set; }
    }
}
