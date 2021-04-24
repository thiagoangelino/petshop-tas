using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPI_Petshop.Models;

namespace WebAPI_Petshop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Pet> Pets { get; set; }

        //Create Tables
        protected override void OnModelCreating(ModelBuilder builder){
            
            //Create the Table Accomodation with initial values
            builder.Entity<Accommodation>()
            .HasData(new List<Accommodation>(){
                new Accommodation(1, "Acomodação 1", 0, 2),
                new Accommodation(2, "Acomodação 2", 0, 3),
                new Accommodation(3, "Acomodação 3", 0, 1),
                new Accommodation(4, "Acomodação 4", 0, 0),
                new Accommodation(5, "Acomodação 5", 0, 0),
                new Accommodation(6, "Acomodação 6", 0, 0),
                new Accommodation(7, "Acomodação 7", 0, 0),
                new Accommodation(8, "Acomodação 8", 0, 0),
                new Accommodation(9, "Acomodação 9", 0, 0),
                new Accommodation(10, "Acomodação 10", 0, 0),
            });

            //Create the Table Pet with initial values
            builder.Entity<Pet>()
            .HasData(new List<Pet>(){
                new Pet(1,"Bethoven", "Antônio Vasconcelos", "Av. dos Pets, 1234", "85912345678", "Febre canina", 0, 3),
                new Pet(2,"Yoda", "Anakim", "Av. dos Jedi, s/n", "85901101010", "Incômodo na coluna vertebral", 0, 1),
                new Pet(3,"Dalek", "Dora Holanda", "Av. Tardis, 987", "85543215678", "Perda de visão no olho", 0, 2)
            });
        }

    }
}