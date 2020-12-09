using System;
using System.Collections.Generic;

namespace HW8Project.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            AssignmentTags = new HashSet<AssignmentTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Due { get; set; }
        public bool Completion { get; set; }
        public int? Priority { get; set; }
        public string Notes { get; set; }
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<AssignmentTag> AssignmentTags { get; set; }
    }
}
