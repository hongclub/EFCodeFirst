using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var db = new BloggingContext())
            //{
            //    // Create and save a new Blog
            //    Console.Write("Enter a name for a new Blog: ");
            //    var name = Console.ReadLine();

            //    var blog = new Blog { Name = name };
            //    db.Blogs.Add(blog);
            //    db.SaveChanges();

            //    // Display all Blogs from the database
            //    var query = from b in db.Blogs
            //                orderby b.Name
            //                select b;

            //    Console.WriteLine("All blogs in the database:");
            //    foreach (var item in query)
            //    {
            //        Console.WriteLine(item.Name);
            //    }

            //    Console.WriteLine("Press any key to exit...");
            //    Console.ReadKey();
            //}


            //CallGetBlogData();
            CallGetBlogDataThroughDBContext();
            Console.ReadKey();
        }

        // Simple stored procedure binding
        public static void CallGetBlogData()
        {

            var db = new BloggingContext();

            IList<GetBlogDataResult> data = db.Database.SqlQuery<GetBlogDataResult>("GetBlogData").ToList();
        }

        public static void CallGetBlogDataThroughDBContext()
        {

            var db = new BloggingContext();

            IList<GetBlogDataResult> data = db.GetBlogData().ToList();
        }

    }

   

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }



    partial class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }


        public IList<GetBlogDataResult> GetBlogData()
        {
            IList<GetBlogDataResult> blogs = ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<GetBlogDataResult>("GetBlogData").ToList<GetBlogDataResult>();
            return blogs;
        }


    }

}
