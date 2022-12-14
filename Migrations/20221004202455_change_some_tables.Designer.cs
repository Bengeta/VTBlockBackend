// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VTBlockBackend.Data;

#nullable disable

namespace VTBlockBackend.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20221004202455_change_some_tables")]
    partial class change_some_tables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.ImageStorage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ImageStorage");
                });

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.MarketItemImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ImageId")
                        .HasColumnType("integer");

                    b.Property<int>("MarketItemId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("MarketItemId");

                    b.ToTable("MarketItemImage");
                });

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.MarketItemTagModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MarketItemId")
                        .HasColumnType("integer");

                    b.Property<int>("TagId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MarketItemId");

                    b.HasIndex("TagId");

                    b.ToTable("MarketItemTag");
                });

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.TagModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.TaskImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ImageId")
                        .HasColumnType("integer");

                    b.Property<int>("TaskId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskImage");
                });

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.TaskModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Reward")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.TaskTagModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("TagId")
                        .HasColumnType("integer");

                    b.Property<int>("TaskId")
                        .HasColumnType("integer");

                    b.Property<int>("TaskModelId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("TaskModelId");

                    b.ToTable("TaskTag");
                });

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.UserModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.HasIndex("token")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.UserTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("TaskId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTask");
                });

            modelBuilder.Entity("VTBlockBackend.Models.MarketItemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("MarketItem");
                });

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.MarketItemImage", b =>
                {
                    b.HasOne("VTBlockBackend.Models.MarketItemModel", "MarketItem")
                        .WithMany("MarketItemImages")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VTBlockBackend.Models.DBTables.ImageStorage", "Image")
                        .WithMany("MarketItemImages")
                        .HasForeignKey("MarketItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("MarketItem");
                });

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.MarketItemTagModel", b =>
                {
                    b.HasOne("VTBlockBackend.Models.MarketItemModel", "MarketItem")
                        .WithMany()
                        .HasForeignKey("MarketItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VTBlockBackend.Models.DBTables.TagModel", "Tag")
                        .WithMany("MarketItemTag")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MarketItem");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.TaskImage", b =>
                {
                    b.HasOne("VTBlockBackend.Models.DBTables.ImageStorage", "Image")
                        .WithMany("TaskImages")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VTBlockBackend.Models.DBTables.TaskModel", "Task")
                        .WithMany("TaskImages")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.TaskTagModel", b =>
                {
                    b.HasOne("VTBlockBackend.Models.DBTables.TagModel", "Tag")
                        .WithMany("TaskTag")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VTBlockBackend.Models.DBTables.TaskModel", "TaskModel")
                        .WithMany()
                        .HasForeignKey("TaskModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("TaskModel");
                });

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.UserTask", b =>
                {
                    b.HasOne("VTBlockBackend.Models.DBTables.TaskModel", "Task")
                        .WithMany("UserTasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VTBlockBackend.Models.DBTables.UserModel", "User")
                        .WithMany("UserTasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.ImageStorage", b =>
                {
                    b.Navigation("MarketItemImages");

                    b.Navigation("TaskImages");
                });

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.TagModel", b =>
                {
                    b.Navigation("MarketItemTag");

                    b.Navigation("TaskTag");
                });

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.TaskModel", b =>
                {
                    b.Navigation("TaskImages");

                    b.Navigation("UserTasks");
                });

            modelBuilder.Entity("VTBlockBackend.Models.DBTables.UserModel", b =>
                {
                    b.Navigation("UserTasks");
                });

            modelBuilder.Entity("VTBlockBackend.Models.MarketItemModel", b =>
                {
                    b.Navigation("MarketItemImages");
                });
#pragma warning restore 612, 618
        }
    }
}
