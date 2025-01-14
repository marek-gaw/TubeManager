﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TubeManager.Infrastructure.DataAccessLayer;

#nullable disable

namespace TubeManager.Infrastructure.DataAccessLayer.Migrations
{
    [DbContext(typeof(BookmarksDbContext))]
    [Migration("20240520182615_AddChannelsTable")]
    partial class AddChannelsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("TubeManager.Core.Entities.Bookmark", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Channel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ThumbnailUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Bookmarks");
                });

            modelBuilder.Entity("TubeManager.Core.Entities.BookmarkTag", b =>
                {
                    b.Property<Guid>("BookmarkId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TagId")
                        .HasColumnType("TEXT");

                    b.HasKey("BookmarkId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("BookmarkTag");
                });

            modelBuilder.Entity("TubeManager.Core.Entities.Channel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ChannelId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("TubeManager.Core.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("TubeManager.Core.Entities.BookmarkTag", b =>
                {
                    b.HasOne("TubeManager.Core.Entities.Bookmark", "Bookmark")
                        .WithMany("BookmarkTags")
                        .HasForeignKey("BookmarkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TubeManager.Core.Entities.Tag", "Tag")
                        .WithMany("BookmarkTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bookmark");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("TubeManager.Core.Entities.Bookmark", b =>
                {
                    b.Navigation("BookmarkTags");
                });

            modelBuilder.Entity("TubeManager.Core.Entities.Tag", b =>
                {
                    b.Navigation("BookmarkTags");
                });
#pragma warning restore 612, 618
        }
    }
}
