namespace user.Models;

public class Userposts
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool email { get; set; }
    public Array Post { get; set; } = null!;
}