﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegExpChallenge.Database;

#nullable disable

namespace RegExpChallenge.Database.Migrations
{
    [DbContext(typeof(ChallengesDbContext))]
    [Migration("20240406215751_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("RegExpChallenge.Database.Challenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Challenges");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Match all uppercase letters. If there are multiple uppercase letters after each other, match character sequences together.",
                            Name = "Uppercase letters"
                        });
                });

            modelBuilder.Entity("RegExpChallenge.Database.Example", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChallengeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.ToTable("Examples");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChallengeId = 1,
                            IsPublic = true,
                            Text = "THIS IS AN ALL UPPERCASE SENTENCE."
                        },
                        new
                        {
                            Id = 2,
                            ChallengeId = 1,
                            IsPublic = true,
                            Text = "This IS a SENTENCE with BOTH uppercase AND lowercase WORDS."
                        },
                        new
                        {
                            Id = 3,
                            ChallengeId = 1,
                            IsPublic = true,
                            Text = "this is a sentence with all lowercase."
                        },
                        new
                        {
                            Id = 4,
                            ChallengeId = 1,
                            IsPublic = true,
                            Text = "This sentence has only one uppercase letter."
                        },
                        new
                        {
                            Id = 5,
                            ChallengeId = 1,
                            IsPublic = true,
                            Text = "In This Sentence, Every Word Starts With Uppercase."
                        });
                });

            modelBuilder.Entity("RegExpChallenge.Database.ExampleMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExampleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Length")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ExampleId");

                    b.ToTable("ExampleMatches");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExampleId = 1,
                            Index = 0,
                            Length = 4
                        },
                        new
                        {
                            Id = 2,
                            ExampleId = 1,
                            Index = 5,
                            Length = 2
                        },
                        new
                        {
                            Id = 3,
                            ExampleId = 1,
                            Index = 8,
                            Length = 2
                        },
                        new
                        {
                            Id = 4,
                            ExampleId = 1,
                            Index = 11,
                            Length = 3
                        },
                        new
                        {
                            Id = 5,
                            ExampleId = 1,
                            Index = 15,
                            Length = 9
                        },
                        new
                        {
                            Id = 6,
                            ExampleId = 1,
                            Index = 25,
                            Length = 8
                        },
                        new
                        {
                            Id = 7,
                            ExampleId = 2,
                            Index = 0,
                            Length = 1
                        },
                        new
                        {
                            Id = 8,
                            ExampleId = 2,
                            Index = 5,
                            Length = 2
                        },
                        new
                        {
                            Id = 9,
                            ExampleId = 2,
                            Index = 10,
                            Length = 8
                        },
                        new
                        {
                            Id = 10,
                            ExampleId = 2,
                            Index = 24,
                            Length = 4
                        },
                        new
                        {
                            Id = 11,
                            ExampleId = 2,
                            Index = 39,
                            Length = 3
                        },
                        new
                        {
                            Id = 12,
                            ExampleId = 2,
                            Index = 53,
                            Length = 5
                        },
                        new
                        {
                            Id = 13,
                            ExampleId = 4,
                            Index = 0,
                            Length = 1
                        },
                        new
                        {
                            Id = 14,
                            ExampleId = 5,
                            Index = 0,
                            Length = 1
                        },
                        new
                        {
                            Id = 15,
                            ExampleId = 5,
                            Index = 3,
                            Length = 1
                        },
                        new
                        {
                            Id = 16,
                            ExampleId = 5,
                            Index = 8,
                            Length = 1
                        },
                        new
                        {
                            Id = 17,
                            ExampleId = 5,
                            Index = 18,
                            Length = 1
                        },
                        new
                        {
                            Id = 18,
                            ExampleId = 5,
                            Index = 24,
                            Length = 1
                        },
                        new
                        {
                            Id = 19,
                            ExampleId = 5,
                            Index = 29,
                            Length = 1
                        },
                        new
                        {
                            Id = 20,
                            ExampleId = 5,
                            Index = 36,
                            Length = 1
                        },
                        new
                        {
                            Id = 21,
                            ExampleId = 5,
                            Index = 41,
                            Length = 1
                        });
                });

            modelBuilder.Entity("RegExpChallenge.Database.Example", b =>
                {
                    b.HasOne("RegExpChallenge.Database.Challenge", "Challenge")
                        .WithMany("Examples")
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Challenge");
                });

            modelBuilder.Entity("RegExpChallenge.Database.ExampleMatch", b =>
                {
                    b.HasOne("RegExpChallenge.Database.Example", "Example")
                        .WithMany("Matches")
                        .HasForeignKey("ExampleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Example");
                });

            modelBuilder.Entity("RegExpChallenge.Database.Challenge", b =>
                {
                    b.Navigation("Examples");
                });

            modelBuilder.Entity("RegExpChallenge.Database.Example", b =>
                {
                    b.Navigation("Matches");
                });
#pragma warning restore 612, 618
        }
    }
}