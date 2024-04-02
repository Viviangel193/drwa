using System.Collections.Generic;

namespace user.Models
{
    using System.Collections.Generic;

namespace user.Models
{
    public class UserpostsResponse
    {
        public List<Userposts> UserPosts { get; set; }
    }

    public class Userposts
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Post> Posts { get; set; }
    }
}

    public class StudentsResponse
    {
        public List<Students>? Students { get; set; }
    }
}
