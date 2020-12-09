using System;
using System.Collections.Generic;

namespace HW8Project.Models
{
    public partial class Course
    {
        public Course()
        {
            Assignments = new HashSet<Assignment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
