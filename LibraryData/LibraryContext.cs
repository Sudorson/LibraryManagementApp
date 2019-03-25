using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryData
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options) { }
        public DbSet<User> users { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<BranchHours> branchHours { get; set; }
        public DbSet<Chechout> chechouts { get; set; }
        public DbSet<CheckoutHistry> checkoutHistries { get; set; }
        public DbSet<Hold> holds { get; set; }
        public DbSet<LibraryAsset> libraryAssets { get; set; }
        public DbSet<LibraryBranch> libraryBranches { get; set; }
        public DbSet<LibraryCard> libraryCards { get; set; }
        public DbSet<Media> medias { get; set; }
        public DbSet<Status> statuses { get; set; }





    }
}
