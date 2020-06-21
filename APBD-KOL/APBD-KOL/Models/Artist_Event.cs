using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_KOL.Models
{
    public class Artist_Event
    {
        [Key]
        public int IdEvent { get; set; }
        [Key]
        public int IdArtist { get; set; }
        public DateTime PerformanceDate { get; set; }
        public virtual Event Event { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
