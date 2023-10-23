
﻿using System.Collections.Generic;
using System.Reflection.Emit;
using TrabajoPracticoP3.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TrabajoPracticoP3.DBContext
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; } 

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Name = "Juan",
                    SurName = "Perez",
                    Email = "JuanPerez@gmail.com",
                    UserName = "JuancitoPerez",
                    UserType = "Admin",
                    Password = "987654",
                }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = 1,
                    Name = "Ernesto",
                    SurName = "Gutierrez",
                    Email = "Erne22@gmail.com",
                    UserName = "ElGuason21",
                    UserType = "Client",
                    Password = "123321",
                    PhoneNumber = "3415123212",
                    Address = "Pellegrini 211"
                },
                new Client
                {
                    Id = 2,
                    Name = "Sebastuan",
                    SurName = "Gonzalez",
                    Email = "Seba25@gmail.com",
                    UserName = "Batman21",
                    UserType = "Client",
                    Password = "554466",
                    PhoneNumber = "3415123333",
                    Address = "Mendoza 211"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Pizza de Muzzarella",
                    Price = "3000"
                },
                new Product
                {
                    Id = 2,
                    Name = "Pizza de Jamon",
                    Price = "3500"
                },

               new Product
               {
                   Id = 3,
                   Name = "Pizza de Pepperoni",
                   Price = "4000"
               },
              

            
        

            modelBuilder.Entity<Order>()
                .HasOne(sub => sub.Client)
                .WithMany(pro => pro.OrderAttended)
                .UsingEntity(j => j
                    .ToTable("ClientOrder")
                    .HasData(new[]
                        {
                            new { ClientId = 4, OrderId = 1},
                            new { ClientId= 5, OrderId = 1},
                            new { ClientId = 4, OrderId = 2},
                        }
                    )),

            modelBuilder.Entity<Order>()
                .HasOne(sub => sub.Client);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderProducts)
                .WithOne(op => op.Order)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderProducts)
                .WithOne(op => op.Product)
                .HasForeignKey(op => op.ProductId);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });


            modelBuilder.Entity<OrderProduct>()
                .ToTable("OrderProduct")
                .HasData(new[]
                {
                    new { OrderId = 4, ProductId = 1},
                    new { OrderId= 5, ProductId = 1},
                    new { OrderId = 4, ProductId = 2},
                });


            base.OnModelCreating(modelBuilder);

        }
    }
}