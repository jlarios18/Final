using System;
using System.Collections.Generic;

namespace HW8Project.Models
{
    public partial class AssignmentTag
    {
        public int Id { get; set; }
        public int? AssignmentId { get; set; }
        public int? TagNameId { get; set; }

        public virtual Assignment Assignment { get; set; }
        public virtual Tag TagName { get; set; }
    }
}
