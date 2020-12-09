using System;
using System.Collections.Generic;

namespace HW8Project.Models
{
    public partial class Tag
    {
        public Tag()
        {
            AssignmentTags = new HashSet<AssignmentTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AssignmentTag> AssignmentTags { get; set; }
    }
}
