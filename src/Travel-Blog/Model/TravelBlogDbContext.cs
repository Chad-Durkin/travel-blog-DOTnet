using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Blog.Model;

namespace Travel_Blog.Model
{
    public class TravelBlogDbContext : DbContext
    {
        public TravelBlogDbContext()
        {

        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTags> PostTags { get; set; }
        public DbSet<Type> Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TravelBlogWithMigrations;integrated security=True");
        }

        public TravelBlogDbContext(DbContextOptions<TravelBlogDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PostTags>().HasKey(x => new { x.PostId, x.TagId });
        }

        public List<Tag> TagSaver(string tagString)
        {
            List<string> TagStringList = new List<string>();
            List<Tag> TagList = new List<Tag>();
            string TagHolder = "";

            for (var i = 0; i < tagString.Length; i++)
            {
                if (tagString[i] != ',' && tagString[i] != ' ')
                {
                    TagHolder += tagString[i];
                }
                else
                {
                    if (tagString[i - 1] != ',' && tagString[i - 1] != ' ')
                    {
                        TagHolder.ToLower();
                        TagList.Add(new Tag() { Name = TagHolder });
                    }
                    TagHolder = "";
                }
            }
            TagList.Add(new Tag() { Name = TagHolder });
            return TagList;
        }
    }
}
