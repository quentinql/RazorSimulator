using System;
using Microsoft.EntityFrameworkCore;
using RazorPage.Models;

namespace RazorPage.Data
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
