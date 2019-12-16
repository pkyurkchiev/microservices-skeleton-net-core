﻿// <auto-generated />
using System;
using KnowledgeBase.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KnowledgeBase.API.Migrations
{
    [DbContext(typeof(KnowledgeBaseDbContext))]
    partial class KnowledgeBaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KnowledgeBase.Data.Entities.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("KnowledgeBase.Data.Entities.DifficultyLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("DifficultyLevels");
                });

            modelBuilder.Entity("KnowledgeBase.Data.Entities.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CorrectAnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DifficultyLevelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("CorrectAnswerId");

                    b.HasIndex("DifficultyLevelId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("KnowledgeBase.Data.Entities.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("KnowledgeBase.Data.Entities.TestQuestionAnswer", b =>
                {
                    b.Property<Guid>("TestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnswerText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("QuestionText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestId", "QuestionId", "AnswerId");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("TestQuestionAnswers");
                });

            modelBuilder.Entity("KnowledgeBase.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KnowledgeBase.Data.Entities.UserTest", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "TestId");

                    b.HasIndex("TestId");

                    b.ToTable("UserTest");
                });

            modelBuilder.Entity("KnowledgeBase.Data.Entities.Answer", b =>
                {
                    b.HasOne("KnowledgeBase.Data.Entities.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("KnowledgeBase.Data.Entities.Question", b =>
                {
                    b.HasOne("KnowledgeBase.Data.Entities.Answer", "CorrectAnswer")
                        .WithMany()
                        .HasForeignKey("CorrectAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KnowledgeBase.Data.Entities.DifficultyLevel", "DifficultyLevel")
                        .WithMany("Questions")
                        .HasForeignKey("DifficultyLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KnowledgeBase.Data.Entities.TestQuestionAnswer", b =>
                {
                    b.HasOne("KnowledgeBase.Data.Entities.Answer", "Answer")
                        .WithMany("TestQuestionAnswers")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KnowledgeBase.Data.Entities.Question", "Question")
                        .WithMany("TestQuestionAnswers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KnowledgeBase.Data.Entities.Test", "Test")
                        .WithMany("TestQuestionAnswers")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KnowledgeBase.Data.Entities.UserTest", b =>
                {
                    b.HasOne("KnowledgeBase.Data.Entities.Test", "Test")
                        .WithMany("UserTests")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KnowledgeBase.Data.Entities.User", "User")
                        .WithMany("UserTests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
