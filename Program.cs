using EFTest.Models;
using EFTest.Services;
#nullable disable warnings

BlogService BlogService = new(new BloggingContext());
string option;

do
{
    PrintMenu();
    option = Console.ReadLine();
    Console.Clear();

    switch (option)
    {
        case "1":
            Console.WriteLine("Getting blogs list...");
            Console.WriteLine("-----------------");
            List<Blog> blogs = await BlogService.GetBlogsAsync();
            foreach (Blog item in blogs)
            {
                Console.WriteLine(item);
            }
            break;
        case "2":
            Console.Write("Enter the blog id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Getting blog...");
            Blog? blog = await BlogService.GetBlogAsync(id);
            if (blog != null)
            {
                Console.WriteLine(blog.Url);
                foreach (Post post in blog.Posts)
                {
                    Console.WriteLine($"-  {post}");
                }
            }
            else
            {
                Console.WriteLine("Blog not found");
            }

            break;
        case "3":

            Console.Write("Enter the blog url: ");
            string url = Console.ReadLine();
            Console.WriteLine("Creating blog...");
            await BlogService.CreateBlogAsync(url);
            Console.WriteLine("Blog created");

            break;
        case "4":

            Console.Write("Enter the blog id: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Enter the new url: ");
            url = Console.ReadLine();
            try
            {
                Console.WriteLine("Updating blog...");
                await BlogService.UpdateBlogAsync(id, url);
                Console.WriteLine("Blog updated");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case "5":

            Console.Write("Enter the blog id: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Enter the post title: ");
            string title = Console.ReadLine();
            Console.Write("Enter the post content: ");
            string content = Console.ReadLine();
            try
            {
                Console.WriteLine("Adding post to blog...");
                await BlogService.AddPostToBlogAsync(id, title, content);
                Console.WriteLine("Post added");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case "6":
            Console.Write("Enter the blog id: ");
            id = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine("Deleting blog...");
                await BlogService.DeleteBlogAsync(id);
                Console.WriteLine("Blog deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case "7":
            Console.WriteLine("Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
    Console.ReadLine();
    Console.Clear();

} while (option != "7");

static void PrintMenu()
{
    Console.WriteLine("1. List blogs");
    Console.WriteLine("2. Get blog");
    Console.WriteLine("3. Create blog");
    Console.WriteLine("4. Update blog");
    Console.WriteLine("5. Add post to blog");
    Console.WriteLine("6. Delete blog");
    Console.WriteLine("7. Exit");
    Console.Write("Choose an option: ");
}