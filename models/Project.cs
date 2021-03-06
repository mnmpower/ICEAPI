﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICE_API.models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Img { get; set; }
        public string Title { get; set; }
        public string datum { get; set; }
        public int PersonID { get; set; }
        public int? CategoryID { get; set; }
        public int? AgeCategoryID { get; set; }
        public int? DurationID { get; set; }
        public bool Show { get; set; }

        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        [ForeignKey("AgeCategoryID")]
        public AgeCategory AgeCategory { get; set; }

        [ForeignKey("DurationID")]
        public Duration Duration { get; set; }
    }
}
