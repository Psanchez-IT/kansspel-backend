using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using chancegame_backend.Models;

namespace chancegame_backend.Models
{
    public class ChanceGameDbContext : DbContext
    {
        public ChanceGameDbContext(DbContextOptions<ChanceGameDbContext> options)
            : base(options){}

        public DbSet<CardModel> CardModel { get; set; }
    }
}
