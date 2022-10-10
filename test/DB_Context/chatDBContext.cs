using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test.Models.MessageModel;
using test.Models.UserModel;

namespace test.DB_Context
{
    public class chatDBContext : DbContext
    {
        public chatDBContext(DbContextOptions options):base(options)
        {
               
        }
        

        public DbSet<User> users { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<Contact> contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne<User>(m => m.SenderUser)
                .WithMany(u => u.SendMessages)
                .HasForeignKey(m => m.SenderUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne<User>(m => m.ReceiverUser)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .HasMaxLength(100);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.FollowerUser)
                .WithMany(u => u.FollowerUsers)
                .HasForeignKey(u => u.FollowerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.FollowingUser)
                .WithMany(u => u.FollowingUsers)
                .HasForeignKey(c => c.FollowingUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}


