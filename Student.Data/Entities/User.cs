using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Student.Data.Entities
{
    public class User: IdentityUser<int>
    {
        //public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public ICollection<LessonUserMap> ClassUserMaps { get; set; }
    }
}
