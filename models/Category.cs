using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICE_API.models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }


        public ICollection<Initiatif> Initiatifs { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
