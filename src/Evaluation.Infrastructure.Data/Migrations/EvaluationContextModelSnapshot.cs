using System;
using Evaluation.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Evaluation.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EvaluationContext))]
    partial class EvaluationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Evaluation.Domain.Model.Entities.Question", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Text")
                    .IsRequired()
                    .HasMaxLength(255);

                b.HasKey("Id");

                b.ToTable("Questions");
            });
#pragma warning restore 612, 618
        }
    }
}