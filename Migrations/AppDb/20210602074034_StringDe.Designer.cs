// <auto-generated />
using System;
using Buglog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Buglog.Migrations.AppDb
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210602074034_StringDe")]
    partial class StringDe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Buglog.Model.Audit", b =>
                {
                    b.Property<long>("AuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Administrator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChangedColumns")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("EntityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("EntityPrimaryKey")
                        .HasColumnType("bigint");

                    b.Property<string>("EntityTableName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuditId");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("Buglog.Model.Comment", b =>
                {
                    b.Property<long>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("IssueId")
                        .HasColumnType("bigint");

                    b.Property<string>("PersonNameComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("statement")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentId");

                    b.HasIndex("IssueId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Buglog.Model.Issue", b =>
                {
                    b.Property<long>("IssueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Decription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("MemberId")
                        .HasColumnType("bigint");

                    b.Property<string>("MemberName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PriorityId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("PriorityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StatusId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IssueId");

                    b.HasIndex("MemberId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StatusId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("Buglog.Model.Member", b =>
                {
                    b.Property<long>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssignedRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Buglog.Model.Priority", b =>
                {
                    b.Property<long>("PriorityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PriorityId");

                    b.ToTable("Priority");
                });

            modelBuilder.Entity("Buglog.Model.Project", b =>
                {
                    b.Property<long>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Buglog.Model.Status", b =>
                {
                    b.Property<long>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Buglog.Model.Comment", b =>
                {
                    b.HasOne("Buglog.Model.Issue", null)
                        .WithMany("Comments")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Buglog.Model.Issue", b =>
                {
                    b.HasOne("Buglog.Model.Member", "Member")
                        .WithMany("Tasks")
                        .HasForeignKey("MemberId");

                    b.HasOne("Buglog.Model.Priority", "Priority")
                        .WithMany("Issues")
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Buglog.Model.Project", "Project")
                        .WithMany("ProjectIssues")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Buglog.Model.Status", "Status")
                        .WithMany("Issues")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Priority");

                    b.Navigation("Project");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Buglog.Model.Issue", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Buglog.Model.Member", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Buglog.Model.Priority", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("Buglog.Model.Project", b =>
                {
                    b.Navigation("ProjectIssues");
                });

            modelBuilder.Entity("Buglog.Model.Status", b =>
                {
                    b.Navigation("Issues");
                });
#pragma warning restore 612, 618
        }
    }
}
