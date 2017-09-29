//using System;
//using Microsoft.Data.Entity;
//using Microsoft.Data.Entity.Infrastructure;
//using Microsoft.Data.Entity.Metadata;
//using Microsoft.Data.Entity.Migrations;
//using TjAppUI.Models;

//namespace TjAppUI.Migrations
//{
//    [DbContext(typeof(AppDbContext))]
//    [Migration("20160325160228_Initial")]
//    partial class Initial
//    {
//        protected override void BuildTargetModel(ModelBuilder modelBuilder)
//        {
//            modelBuilder
//                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
//                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//            modelBuilder.Entity("TjAppUI.Models.Customer", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd();

//                    b.Property<string>("CustomerFullName");

//                    b.HasKey("Id");
//                });

//            modelBuilder.Entity("TjAppUI.Models.Order", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd();

//                    b.Property<decimal>("Amount");

//                    b.Property<int>("CustomerId");

//                    b.Property<string>("CustomerName");

//                    b.Property<DateTime>("DateOperation");

//                    b.Property<int>("OrderNumber");

//                    b.HasKey("Id");
//                });

//            modelBuilder.Entity("TjAppUI.Models.Product", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd();

//                    b.Property<string>("Name");

//                    b.Property<decimal>("Price");

//                    b.Property<int>("Quantity");

//                    b.HasKey("Id");
//                });

//            modelBuilder.Entity("TjAppUI.Models.ProductOrder", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd();

//                    b.Property<int>("OrderId");

//                    b.Property<int>("ProductId");

//                    b.Property<int>("Quantity");

//                    b.HasKey("Id");
//                });

//            modelBuilder.Entity("TjAppUI.Models.Order", b =>
//                {
//                    b.HasOne("TjAppUI.Models.Customer")
//                        .WithMany()
//                        .HasForeignKey("CustomerId");
//                });

//            modelBuilder.Entity("TjAppUI.Models.ProductOrder", b =>
//                {
//                    b.HasOne("TjAppUI.Models.Order")
//                        .WithMany()
//                        .HasForeignKey("OrderId");

//                    b.HasOne("TjAppUI.Models.Product")
//                        .WithMany()
//                        .HasForeignKey("ProductId");
//                });
//        }
//    }
//}
