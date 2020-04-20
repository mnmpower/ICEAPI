using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICE_API.models
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        public string Name { get; set; }

        public ICollection<Initiatif> Initiatifs { get; set; }
    }
}
