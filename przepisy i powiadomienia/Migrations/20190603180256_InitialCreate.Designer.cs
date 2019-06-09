using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using przepisy_i_powiadomienia;

namespace przepisy_i_powiadomienia.Migrations
{
    [DbContext(typeof(PoradnikContext))]
    [Migration("20190603180256_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.6");

            modelBuilder.Entity("przepisy_i_powiadomienia.Measurement", b =>
                {
                    b.Property<int>("MeasurementId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Calories");

                    b.Property<int>("Distance");

                    b.Property<int>("Water");

                    b.Property<int>("Weight");

                    b.HasKey("MeasurementId");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("przepisy_i_powiadomienia.Target", b =>
                {
                    b.Property<int>("TargetId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Calories");

                    b.Property<int>("Distance");

                    b.Property<int>("Water");

                    b.Property<int>("Weight");

                    b.HasKey("TargetId");

                    b.ToTable("Targets");
                });
        }
    }
}
