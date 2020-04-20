using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICE_API.models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Project> Projects { get; set; }
        public ICollection<Initiatif> Initiatifs { get; set; }
    }
}
