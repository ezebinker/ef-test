
namespace EFTest.Models;
public class Blog
{
    public int BlogId { get; set; }
    public string? Url { get; set; }

    public string? Owner { get; set; }

    public List<Post> Posts { get; } = [];

    public override string ToString()
    {
        return $"Id: {BlogId}, Url: {Url ?? "no-url"}, Owner: {Owner ?? "Unknown"}";
    }
}