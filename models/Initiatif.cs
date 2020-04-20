using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ICE_API.models
{
    public class Initiatif
    {
        [Key]
        public int InitiatifID { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public string About { get; set; }
        public string TaskDescription { get; set; }
        public bool Confirmed { get; set; }
        public string location { get; set; }
        public int PersonID { get; set; }
        public int StatusID { get; set; }
        public int CategoryID { get; set; }

        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }

        [ForeignKey("StatusID")]
        public virtual Status Status { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
    }
}
