﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;
using PM.Infrastrcture.Persistence;

#nullable disable

namespace PM.Infrastrcture.Migrations
{
    [DbContext(typeof(PMDbContext))]
    partial class PMDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PM.Domain.IssueAggregate.Issue", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AssigneeId")
                        .HasColumnType("uuid")
                        .HasColumnName("AssigneeId");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(2147483645)
                        .HasColumnType("text");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid")
                        .HasColumnName("ProjectId");

                    b.Property<Guid>("ReporterId")
                        .HasColumnType("uuid")
                        .HasColumnName("ReporterId");

                    b.Property<NpgsqlTsVector>("SearchVector")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("tsvector")
                        .HasAnnotation("Npgsql:TsVectorConfig", "vietnamese")
                        .HasAnnotation("Npgsql:TsVectorProperties", new[] { "Code", "Title", "Description" });

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("SearchVector");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("SearchVector"), "GIN");

                    b.ToTable("Issues", (string)null);
                });

            modelBuilder.Entity("PM.Domain.ProjectAggregate.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("CreatedBy");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<NpgsqlTsVector>("SearchVector")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("tsvector")
                        .HasAnnotation("Npgsql:TsVectorConfig", "vietnamese")
                        .HasAnnotation("Npgsql:TsVectorProperties", new[] { "Code", "Name", "Description" });

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("SearchVector");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("SearchVector"), "GIN");

                    b.ToTable("Projects", (string)null);
                });

            modelBuilder.Entity("PM.Domain.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Avatar")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<NpgsqlTsVector>("SearchVector")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("tsvector")
                        .HasAnnotation("Npgsql:TsVectorConfig", "vietnamese")
                        .HasAnnotation("Npgsql:TsVectorProperties", new[] { "Username", "Name", "PhoneNumber" });

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("SearchVector");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("SearchVector"), "GIN");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("PM.Domain.IssueAggregate.Issue", b =>
                {
                    b.OwnsMany("PM.Domain.IssueAggregate.Entities.Attachment", "Attachments", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("AttachmentId");

                            b1.Property<Guid>("IssueId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<Guid>("CreatedBy")
                                .HasColumnType("uuid")
                                .HasColumnName("CreatedBy");

                            b1.Property<string>("FileName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<string>("FilePath")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("character varying(255)");

                            b1.Property<DateTime>("UpdatedAt")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("Id", "IssueId");

                            b1.HasIndex("IssueId");

                            b1.ToTable("IssueAttachments", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("IssueId");
                        });

                    b.OwnsMany("PM.Domain.IssueAggregate.Entities.Comment", "Comments", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("CommentId");

                            b1.Property<Guid>("IssueId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Content")
                                .IsRequired()
                                .HasMaxLength(2147483645)
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime>("UpdatedAt")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid")
                                .HasColumnName("UserId");

                            b1.HasKey("Id", "IssueId");

                            b1.HasIndex("IssueId");

                            b1.ToTable("IssueComments", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("IssueId");
                        });

                    b.Navigation("Attachments");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("PM.Domain.ProjectAggregate.Project", b =>
                {
                    b.OwnsMany("PM.Domain.ProjectAggregate.Entities.Member", "Members", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("MemberId");

                            b1.Property<Guid>("ProjectId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<int>("Role")
                                .HasColumnType("integer");

                            b1.Property<DateTime>("UpdatedAt")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid")
                                .HasColumnName("UserId");

                            b1.HasKey("Id", "ProjectId");

                            b1.HasIndex("ProjectId");

                            b1.ToTable("ProjectMembers", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ProjectId");
                        });

                    b.Navigation("Members");
                });

            modelBuilder.Entity("PM.Domain.UserAggregate.User", b =>
                {
                    b.OwnsMany("PM.Domain.UserAggregate.Entities.Notification", "Notifications", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("NotificationId");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<bool>("IsRead")
                                .HasColumnType("boolean");

                            b1.Property<string>("Message")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime>("UpdatedAt")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("Id", "UserId");

                            b1.HasIndex("UserId");

                            b1.ToTable("Notifications", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("PM.Domain.UserAggregate.ValueObjects.RefreshToken", "RefreshToken", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("ExpireTime")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Notifications");

                    b.Navigation("RefreshToken")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
