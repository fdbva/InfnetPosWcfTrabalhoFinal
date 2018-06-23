﻿using System.IO;
using Evaluation.Domain.Model.Entities;
using Evaluation.Infrastructure.Data.EntitiesConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Evaluation.Infrastructure.Data.Context
{
    public class EvaluationContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }

        public EvaluationContext(DbContextOptions<EvaluationContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //optionsBuilder.UseSqlServer(config.GetConnectionString("EvaluationLocalMsSql"));
            optionsBuilder.UseSqlServer("Server=fva;Database=EvaluationService;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new QuestionConfig());
        }
    }
}