using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_KOL.Models
{
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArtist { get; set; }
        [MaxLength(30)]
        public string Nickname { get; set; }
        public virtual ICollection<Artist_Event> Artist_Events { get; set; }
    }
}
