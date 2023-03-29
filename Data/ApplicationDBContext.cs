using System;
using Microsoft.EntityFrameworkCore;
using BulkyBook.Models;

namespace BulkyBook.Data
{
	public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{
		}


		public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			//base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlite("Data Source=/Users/sricharanbodduna/Projects/BulkyBook/Data/DB/db2.db;Cache=Shared");
        }
    }
}

