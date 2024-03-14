using EFTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Services;

public class BlogService(BloggingContext context)
{
    public async Task<List<Blog>> GetBlogsAsync()
    {
        return await context.Blogs.Include(blog => blog.Posts).ToListAsync();
    }

    public async Task<Blog?> GetBlogAsync(int id)
    {
        return await context.Blogs
            .Where(blog => blog.BlogId == id)
            .Include(blog => blog.Posts)
            .FirstOrDefaultAsync();
    }

    public async Task<Blog> CreateBlogAsync(string url)
    {
        var blog = new Blog { Url = url };
        context.Blogs.Add(blog);
        await context.SaveChangesAsync();
        return blog;
    }

    public async Task UpdateBlogAsync(int id, string url)
    {
        var blog = await context.Blogs.FindAsync(id);
        if (blog != null)
        {
            blog.Url = url;
            await context.SaveChangesAsync();
        }
        else 
        {
            throw new NotFoundException("Blog not found");
        }
    }

    public async Task AddPostToBlogAsync(int blogId, string title, string content)
    {
        var blog = await context.Blogs.FindAsync(blogId);
        if (blog != null)
        {
            blog.Posts.Add(new Post { Title = title, Content = content });
            await context.SaveChangesAsync();
        }
        else
        {
            throw new NotFoundException("Blog not found");
        }
    }

    public async Task DeleteBlogAsync(int id)
    {
        var blog = await context.Blogs.FindAsync(id);
        if (blog != null)
        {
            context.Blogs.Remove(blog);
            await context.SaveChangesAsync();
        }
        else
        {
            throw new NotFoundException("Blog not found");
        }
    }
}