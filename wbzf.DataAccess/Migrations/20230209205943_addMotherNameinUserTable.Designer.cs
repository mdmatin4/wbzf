﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wbzf.DataAccess.Data;

#nullable disable

namespace wbzf.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230209205943_addMotherNameinUserTable")]
    partial class addMotherNameinUserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("wbzf.Model.coachingForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Whatsappno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aadharno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("application_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("attempt_year")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("currently_working")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("exam_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("family_income")
                        .HasColumnType("int");

                    b.Property<string>("guardain_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("guardain_occupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("guardian_Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_appeared_bafore")
                        .HasColumnType("bit");

                    b.Property<bool>("is_from_zakat_category")
                        .HasColumnType("bit");

                    b.Property<string>("other_qualification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("permanant_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("present_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification1Board")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification1Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification1Exam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification1Marks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification1Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification1Sub")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification1Year")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification2Board")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification2Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification2Exam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification2Marks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification2Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification2Sub")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification2Year")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification3Board")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification3Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification3Exam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification3Marks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification3Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification3Sub")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification3Year")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification4Board")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification4Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification4Exam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification4Marks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification4Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification4Sub")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification4Year")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("coachingForms");
                });

            modelBuilder.Entity("wbzf.Model.donation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("completed_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("payment_gateway_orderid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("payment_status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("transaction_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("donations");
                });

            modelBuilder.Entity("wbzf.Model.Profession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("professions");
                });

            modelBuilder.Entity("wbzf.Model.ScholarshipApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostOffice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Road")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vill_Ward")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Whatsappno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aadharCardUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aadharno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("admissionFees")
                        .HasColumnType("int");

                    b.Property<string>("admissionFeesRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admissionReceiptUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admission_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admitcardUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("application_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("appliedScholarshipAmount")
                        .HasColumnType("int");

                    b.Property<string>("appliedScholarshipDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("appliedScholarshipName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bankAcNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bankIfsc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bankMicr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("branchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("cautionMoneyDepsoit")
                        .HasColumnType("int");

                    b.Property<string>("cautionMoneyRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("class_course")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dateofAdmission")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dateofCoruseEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateofJoining")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dateofPayment")
                        .HasColumnType("datetime2");

                    b.Property<int?>("developementFees")
                        .HasColumnType("int");

                    b.Property<string>("developementFeesRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("duration_of_course")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("examResultUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("examfees")
                        .HasColumnType("int");

                    b.Property<string>("examfeesRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fatheraddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("fatherincome")
                        .HasColumnType("int");

                    b.Property<string>("fatheroccupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("gameFees")
                        .HasColumnType("int");

                    b.Property<string>("gameFeesRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("guardain_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("guardain_occupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("guardian_Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("guardianaddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("guardianincome")
                        .HasColumnType("int");

                    b.Property<string>("guardianoccupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("incomeCertificateUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("insBankAcNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("insBankBranchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("insBankIfsc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("insBankMicr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("insBankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("instituteAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("instituteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_applied_anyscholarship")
                        .HasColumnType("bit");

                    b.Property<bool>("is_in_receiptScholarship")
                        .HasColumnType("bit");

                    b.Property<int?>("laboratoryFees")
                        .HasColumnType("int");

                    b.Property<string>("laboratoryFeesRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("libraryFees")
                        .HasColumnType("int");

                    b.Property<string>("libraryFeesRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("miscFees")
                        .HasColumnType("int");

                    b.Property<string>("miscFeesRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("motheraddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("motherincome")
                        .HasColumnType("int");

                    b.Property<string>("motheroccupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nature_of_course")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passbookUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentreceiptNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("person1Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("person1MobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("person1Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("person2Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("person2MobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("person2Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("porcessingFees")
                        .HasColumnType("int");

                    b.Property<string>("porcessingFeesRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("registration_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("scholarshipAmoutn")
                        .HasColumnType("int");

                    b.Property<string>("scholarshipDetials")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("scholarshipName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("sessionCharge")
                        .HasColumnType("int");

                    b.Property<string>("sessionChargeRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("totalFees")
                        .HasColumnType("int");

                    b.Property<int?>("tutionFees")
                        .HasColumnType("int");

                    b.Property<string>("tutionFeesRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("scholarshipApplications");
                });

            modelBuilder.Entity("wbzf.Model.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<DateTime?>("DateofBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Full_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mother_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PoliceStation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostOffice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfessionId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vill")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bankAcNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bankBranchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bankIFSC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("familyIncome")
                        .HasColumnType("int");

                    b.Property<int?>("guardianIncome")
                        .HasColumnType("int");

                    b.Property<string>("guardianName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("guardianOccupationId")
                        .HasColumnType("int");

                    b.Property<string>("parentType")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("ProfessionId");

                    b.HasIndex("guardianOccupationId");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wbzf.Model.ApplicationUser", b =>
                {
                    b.HasOne("wbzf.Model.Profession", "Profession")
                        .WithMany()
                        .HasForeignKey("ProfessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wbzf.Model.Profession", "Occupation")
                        .WithMany()
                        .HasForeignKey("guardianOccupationId");

                    b.Navigation("Occupation");

                    b.Navigation("Profession");
                });
#pragma warning restore 612, 618
        }
    }
}
