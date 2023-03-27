using System.Collections.Generic;

namespace test.Models;
public class UsersWithFollowing
{
    public List<User2> users { get; set; }
}
public class User2
{
    public string userName { get; set; }
    public List<User2> followings { get; set; }
}