﻿using BookListRazor.Model;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
