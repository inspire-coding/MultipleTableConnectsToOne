using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Post
    {
        public Post()
        {
            Courses = new HashSet<Course>();
            Tutorials = new HashSet<Tutorial>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Tutorial> Tutorials { get; set; }
    }
}
