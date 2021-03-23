﻿// <auto-generated />
using CS_EFCore_Code_First.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CS_EFCore_Code_First.Migrations
{
    [DbContext(typeof(DXCDbContext))]
    partial class DXCDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CS_EFCore_Code_First.Models.Category", b =>
                {
                    b.Property<int>("CategoryRowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BasePrice")
                        .HasColumnType("int");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryRowId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CS_EFCore_Code_First.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CS_EFCore_Code_First.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrderItem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CS_EFCore_Code_First.Models.Product", b =>
                {
                    b.Property<int>("ProductRowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryRowId")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductRowId");

                    b.HasIndex("CategoryRowId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CS_EFCore_Code_First.Models.ProductionUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductionUnits");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ProductionUnit");
                });

            modelBuilder.Entity("CustomerOrder", b =>
                {
                    b.Property<int>("CustomersCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersOrderId")
                        .HasColumnType("int");

                    b.HasKey("CustomersCustomerId", "OrdersOrderId");

                    b.HasIndex("OrdersOrderId");

                    b.ToTable("CustomersOrders");
                });

            modelBuilder.Entity("CS_EFCore_Code_First.Models.Movies", b =>
                {
                    b.HasBaseType("CS_EFCore_Code_First.Models.ProductionUnit");

                    b.Property<double>("BoxOfficeCollection")
                        .HasColumnType("float");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayDuration")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Dr.No",
                            ReleaseYear = 1963,
                            BoxOfficeCollection = 12222.0,
                            Category = "Spy",
                            PlayDuration = 150
                        },
                        new
                        {
                            Id = 2,
                            Name = "Golmal",
                            ReleaseYear = 1976,
                            BoxOfficeCollection = 122.0,
                            Category = "Comedy",
                            PlayDuration = 180
                        });
                });

            modelBuilder.Entity("CS_EFCore_Code_First.Models.WebSeries", b =>
                {
                    b.HasBaseType("CS_EFCore_Code_First.Models.ProductionUnit");

                    b.Property<int>("EpisodPerSeason")
                        .HasColumnType("int");

                    b.Property<int>("Seasons")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("WebSeries");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Name = "Ramayan",
                            ReleaseYear = 1986,
                            EpisodPerSeason = 100,
                            Seasons = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "House of Cards",
                            ReleaseYear = 2005,
                            EpisodPerSeason = 50,
                            Seasons = 6
                        });
                });

            modelBuilder.Entity("CS_EFCore_Code_First.Models.Product", b =>
                {
                    b.HasOne("CS_EFCore_Code_First.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryRowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CustomerOrder", b =>
                {
                    b.HasOne("CS_EFCore_Code_First.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CS_EFCore_Code_First.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CS_EFCore_Code_First.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}