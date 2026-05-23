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
        public DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }

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

            // EmployeeSchedule relations
            modelBuilder.Entity<EmployeeSchedule>()
                .HasOne(es => es.Employee)
                .WithMany(e => e.Schedules)
                .HasForeignKey(es => es.EmployeeId);

            // Seed data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Hair Care", PhotoUrl = "category_hair.png" },
                new Category { Id = 2, Name = "Nails", PhotoUrl = "category_nails.png" },
                new Category { Id = 3, Name = "Makeup", PhotoUrl = "category_makeup.png" }
            );

            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, CategoryId = 1, Name = "Women's Haircut", Price = 60, DurationMinutes = 60 },
                new Service { Id = 2, CategoryId = 1, Name = "Hair Coloring", Price = 85, DurationMinutes = 90 },
                new Service { Id = 3, CategoryId = 1, Name = "Wash & Blow Dry", Price = 40, DurationMinutes = 45 },
                new Service { Id = 4, CategoryId = 1, Name = "Keratin Treatment", Price = 150, DurationMinutes = 120 },
                new Service { Id = 5, CategoryId = 2, Name = "Classic Manicure", Price = 25, DurationMinutes = 45 },
                new Service { Id = 6, CategoryId = 2, Name = "Gel Manicure", Price = 50, DurationMinutes = 90 },
                new Service { Id = 7, CategoryId = 2, Name = "Nail Extensions", Price = 85, DurationMinutes = 90 },
                new Service { Id = 8, CategoryId = 2, Name = "Gel Removal", Price = 15, DurationMinutes = 30 },
                new Service { Id = 9, CategoryId = 3, Name = "Everyday Makeup", Price = 50, DurationMinutes = 45 },
                new Service { Id = 10, CategoryId = 3, Name = "Evening Makeup", Price = 150, DurationMinutes = 120 },
                new Service { Id = 11, CategoryId = 3, Name = "Bridal Makeup", Price = 150, DurationMinutes = 120 },
                new Service { Id = 12, CategoryId = 3, Name = "Makeup Trial", Price = 100, DurationMinutes = 90 }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "Emma", LastName = "Watson", Position = "Top Hair Stylist", PhoneNumber = "+380001111111", IsActive = true, Rating = 5.0, PhotoUrl = "master_hair1.png" },
                new Employee { Id = 2, FirstName = "Anna", LastName = "Smith", Position = "Hair Stylist", PhoneNumber = "+380002222222", IsActive = true, Rating = 4.8, PhotoUrl = "master_hair2.png" },
                new Employee { Id = 3, FirstName = "Sarah", LastName = "Johnson", Position = "Expert Colorist", PhoneNumber = "+380003333333", IsActive = true, Rating = 4.9, PhotoUrl = "master_hair3.png" },
                new Employee { Id = 4, FirstName = "Michael", LastName = "Brown", Position = "Junior Hair Stylist", PhoneNumber = "+380004444444", IsActive = true, Rating = 4.4, PhotoUrl = "master_hair4.png" },
                new Employee { Id = 5, FirstName = "Jessica", LastName = "Davis", Position = "Top Nail Master", PhoneNumber = "+380005555555", IsActive = true, Rating = 5.0, PhotoUrl = "master_nails1.png" },
                new Employee { Id = 6, FirstName = "Emily", LastName = "Miller", Position = "Senior Nail Technician", PhoneNumber = "+380006666666", IsActive = true, Rating = 4.8, PhotoUrl = "master_nails2.png" },
                new Employee { Id = 7, FirstName = "Anna", LastName = "Wilson", Position = "Nail Technician", PhoneNumber = "+380007777777", IsActive = true, Rating = 4.6, PhotoUrl = "master_nails3.png" },
                new Employee { Id = 8, FirstName = "Sophia", LastName = "Taylor", Position = "Junior Nail Technician", PhoneNumber = "+380008888888", IsActive = true, Rating = 4.3, PhotoUrl = "master_nails4.png" },
                new Employee { Id = 9, FirstName = "Olivia", LastName = "Martinez", Position = "Celebrity Makeup Artist", PhoneNumber = "+380009999999", IsActive = true, Rating = 5.0, PhotoUrl = "master_makeup1.png" },
                new Employee { Id = 10, FirstName = "Isabella", LastName = "Anderson", Position = "Bridal Makeup Specialist", PhoneNumber = "+380010101010", IsActive = true, Rating = 4.9, PhotoUrl = "master_makeup2.png" },
                new Employee { Id = 11, FirstName = "Mia", LastName = "Thomas", Position = "Senior Makeup Artist", PhoneNumber = "+380011111111", IsActive = true, Rating = 4.7, PhotoUrl = "master_makeup3.png" },
                new Employee { Id = 12, FirstName = "Chloe", LastName = "Jackson", Position = "Junior Makeup Artist", PhoneNumber = "+380012121212", IsActive = true, Rating = 4.5, PhotoUrl = "master_makeup4.png" }
            );

            modelBuilder.Entity<EmployeeService>().HasData(
                new EmployeeService { EmployeeId = 1, ServiceId = 1 },
                new EmployeeService { EmployeeId = 1, ServiceId = 2 },
                new EmployeeService { EmployeeId = 2, ServiceId = 1 },
                new EmployeeService { EmployeeId = 2, ServiceId = 3 },
                new EmployeeService { EmployeeId = 3, ServiceId = 2 },
                new EmployeeService { EmployeeId = 3, ServiceId = 4 },
                new EmployeeService { EmployeeId = 4, ServiceId = 1 },
                new EmployeeService { EmployeeId = 4, ServiceId = 3 },
                new EmployeeService { EmployeeId = 5, ServiceId = 5 },
                new EmployeeService { EmployeeId = 5, ServiceId = 6 },
                new EmployeeService { EmployeeId = 6, ServiceId = 5 },
                new EmployeeService { EmployeeId = 6, ServiceId = 7 },
                new EmployeeService { EmployeeId = 7, ServiceId = 6 },
                new EmployeeService { EmployeeId = 7, ServiceId = 8 },
                new EmployeeService { EmployeeId = 8, ServiceId = 5 },
                new EmployeeService { EmployeeId = 8, ServiceId = 8 },
                new EmployeeService { EmployeeId = 9, ServiceId = 9 },
                new EmployeeService { EmployeeId = 9, ServiceId = 10 },
                new EmployeeService { EmployeeId = 10, ServiceId = 10 },
                new EmployeeService { EmployeeId = 10, ServiceId = 11 },
                new EmployeeService { EmployeeId = 11, ServiceId = 9 },
                new EmployeeService { EmployeeId = 11, ServiceId = 12 },
                new EmployeeService { EmployeeId = 12, ServiceId = 9 },
                new EmployeeService { EmployeeId = 12, ServiceId = 12 }
            );

            var scheduleId = 1;
            var scheduleData = new List<EmployeeSchedule>();
            var workDays = new[]
            {
                DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday,
                DayOfWeek.Thursday, DayOfWeek.Friday
            };

            for (int empId = 1; empId <= 12; empId++)
            {
                foreach (var day in workDays)
                {
                    scheduleData.Add(new EmployeeSchedule
                    {
                        Id = scheduleId++,
                        EmployeeId = empId,
                        DayOfWeek = day,
                        WorkStart = new TimeSpan(9, 0, 0),
                        WorkEnd = new TimeSpan(18, 0, 0)
                    });
                }
            }

            modelBuilder.Entity<EmployeeSchedule>().HasData(scheduleData);
        }
    }
}
