using BeautySalon.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.DAL.Data
{
    public class BeautySalonDBContext : DbContext
    {
        public BeautySalonDBContext(DbContextOptions<BeautySalonDBContext> options)
        : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<EmployeeService> EmployeeServices { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Client
            modelBuilder.Entity<Client>()
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Client>()
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Client>()
                .Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Client>()
                .Property(c => c.Email)
                .HasMaxLength(100);

            // Employee
            modelBuilder.Entity<Employee>()
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Employee>()
                .Property(c => c.Position)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .Property(c => c.IsActive)
                .IsRequired();

            // Category
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Service
            modelBuilder.Entity<Service>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Service>()
                .Property(s => s.Price)
                .HasColumnType("decimal(10,2)");

            // Service -> Category (many-to-one)
            modelBuilder.Entity<Service>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Services)
                .HasForeignKey(s => s.CategoryId);

            // EmployeeService (many-to-many)
            modelBuilder.Entity<EmployeeService>()
                .HasKey(es => new { es.EmployeeId, es.ServiceId });

            modelBuilder.Entity<EmployeeService>()
                .HasOne(es => es.Employee)
                .WithMany(e => e.EmployeeServices)
                .HasForeignKey(es => es.EmployeeId);

            modelBuilder.Entity<EmployeeService>()
                .HasOne(es => es.Service)
                .WithMany(s => s.EmployeeServices)
                .HasForeignKey(es => es.ServiceId);

            // Appointment
            modelBuilder.Entity<Appointment>()
                .Property(a => a.TotalPrice)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(20);

            // Appointment relations
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Client)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.ClientId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Appointments)
                .HasForeignKey(a => a.EmployeeId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Service)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.ServiceId);
        }
    }
}
