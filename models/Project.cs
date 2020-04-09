using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICE_API.models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public string IFrame { get; set; }
        public string Description { get; set; }
        public int PersonID { get; set; }

        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }

    }
}
