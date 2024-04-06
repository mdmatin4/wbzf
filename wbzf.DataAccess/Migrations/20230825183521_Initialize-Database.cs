using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbzf.DataAccess.Migrations
{
    public partial class InitializeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ifsc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    micr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isvisibletoPublic = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "coachingForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    application_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exam_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aadharno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    guardain_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    guardain_occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    guardian_Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    present_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    permanant_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Whatsappno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    family_income = table.Column<int>(type: "int", nullable: false),
                    qualification1Exam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification1Board = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification1Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification1Marks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification1Sub = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification1Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification1Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification2Exam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification2Board = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification2Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification2Marks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification2Sub = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification2Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification2Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification3Exam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification3Board = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification3Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification3Marks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification3Sub = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification3Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification3Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification4Exam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification4Board = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification4Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification4Marks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification4Sub = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification4Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification4Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    other_qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currently_working = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_appeared_bafore = table.Column<bool>(type: "bit", nullable: false),
                    attempt_year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_from_zakat_category = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coachingForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contactforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "galleryCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_galleryCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "membersforHome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    displayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membersforHome", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "newslinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    publish_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewsOrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    displayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newslinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentGateways",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logo_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    intro_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentGateways", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "professions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "purposes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purposes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    statement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "scholarshipApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    application_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aadharno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    guardain_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    guardain_occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    guardian_Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vill_Ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Road = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostOffice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Whatsappno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fatheraddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fatheroccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fatherincome = table.Column<int>(type: "int", nullable: true),
                    motheraddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motheroccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motherincome = table.Column<int>(type: "int", nullable: true),
                    guardianaddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    guardianoccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    guardianincome = table.Column<int>(type: "int", nullable: false),
                    instituteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    instituteAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    class_course = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nature_of_course = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    duration_of_course = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateofJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateofCoruseEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    admissionFees = table.Column<int>(type: "int", nullable: false),
                    admissionFeesRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tutionFees = table.Column<int>(type: "int", nullable: true),
                    tutionFeesRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sessionCharge = table.Column<int>(type: "int", nullable: true),
                    sessionChargeRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cautionMoneyDepsoit = table.Column<int>(type: "int", nullable: true),
                    cautionMoneyRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    developementFees = table.Column<int>(type: "int", nullable: true),
                    developementFeesRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    porcessingFees = table.Column<int>(type: "int", nullable: true),
                    porcessingFeesRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    examfees = table.Column<int>(type: "int", nullable: true),
                    examfeesRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    libraryFees = table.Column<int>(type: "int", nullable: true),
                    libraryFeesRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    laboratoryFees = table.Column<int>(type: "int", nullable: true),
                    laboratoryFeesRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gameFees = table.Column<int>(type: "int", nullable: true),
                    gameFeesRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    miscFees = table.Column<int>(type: "int", nullable: true),
                    miscFeesRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalFees = table.Column<int>(type: "int", nullable: false),
                    admission_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registration_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateofAdmission = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dateofPayment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    paymentreceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_in_receiptScholarship = table.Column<bool>(type: "bit", nullable: false),
                    scholarshipName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    scholarshipAmoutn = table.Column<int>(type: "int", nullable: true),
                    year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    scholarshipDetials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_applied_anyscholarship = table.Column<bool>(type: "bit", nullable: false),
                    appliedScholarshipName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    appliedScholarshipAmount = table.Column<int>(type: "int", nullable: true),
                    appliedScholarshipDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    branchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bankAcNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bankIfsc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bankMicr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    insBankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    insBankBranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    insBankAcNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    insBankIfsc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    insBankMicr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    person1Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    person1Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    person1MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    person2Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    person2Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    person2MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admitcardUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    examResultUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    admissionReceiptUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passbookUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aadharCardUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    incomeCertificateUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholarshipApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sponsors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    displayOrder = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sponsors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    statement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testimonials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filetypeId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gallery_galleryCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "galleryCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accountGatewaySetups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    PaymentGatewayId = table.Column<int>(type: "int", nullable: false),
                    SecretName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    secretValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountGatewaySetups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accountGatewaySetups_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accountGatewaySetups_PaymentGateways_PaymentGatewayId",
                        column: x => x.PaymentGatewayId,
                        principalTable: "PaymentGateways",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Full_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mother_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vill = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostOffice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliceStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProfessionId = table.Column<int>(type: "int", nullable: true),
                    familyIncome = table.Column<int>(type: "int", nullable: true),
                    parentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    guardianName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    guardianOccupationId = table.Column<int>(type: "int", nullable: true),
                    guardianIncome = table.Column<int>(type: "int", nullable: true),
                    bankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bankIFSC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bankBranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bankAcNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_professions_guardianOccupationId",
                        column: x => x.guardianOccupationId,
                        principalTable: "professions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsStartEndVisible = table.Column<bool>(type: "bit", nullable: false),
                    Eligibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Form_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    purposeId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schemes_purposes_purposeId",
                        column: x => x.purposeId,
                        principalTable: "purposes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    accountId = table.Column<int>(type: "int", nullable: false),
                    transaction_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymentGatewayId = table.Column<int>(type: "int", nullable: false),
                    payment_gateway_orderid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    purposeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    donated_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    received_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    transaction_fees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    completed_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_donations_Accounts_accountId",
                        column: x => x.accountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_donations_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_donations_PaymentGateways_paymentGatewayId",
                        column: x => x.paymentGatewayId,
                        principalTable: "PaymentGateways",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_donations_purposes_purposeId",
                        column: x => x.purposeId,
                        principalTable: "purposes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accountGatewaySetups_AccountId",
                table: "accountGatewaySetups",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_accountGatewaySetups_PaymentGatewayId",
                table: "accountGatewaySetups",
                column: "PaymentGatewayId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_guardianOccupationId",
                table: "AspNetUsers",
                column: "guardianOccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfessionId",
                table: "AspNetUsers",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_donations_accountId",
                table: "donations",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_donations_paymentGatewayId",
                table: "donations",
                column: "paymentGatewayId");

            migrationBuilder.CreateIndex(
                name: "IX_donations_purposeId",
                table: "donations",
                column: "purposeId");

            migrationBuilder.CreateIndex(
                name: "IX_donations_userId",
                table: "donations",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_gallery_CategoryId",
                table: "gallery",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Schemes_purposeId",
                table: "Schemes",
                column: "purposeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accountGatewaySetups");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "coachingForms");

            migrationBuilder.DropTable(
                name: "contactforms");

            migrationBuilder.DropTable(
                name: "donations");

            migrationBuilder.DropTable(
                name: "gallery");

            migrationBuilder.DropTable(
                name: "membersforHome");

            migrationBuilder.DropTable(
                name: "newslinks");

            migrationBuilder.DropTable(
                name: "quotes");

            migrationBuilder.DropTable(
                name: "Schemes");

            migrationBuilder.DropTable(
                name: "scholarshipApplications");

            migrationBuilder.DropTable(
                name: "sponsors");

            migrationBuilder.DropTable(
                name: "testimonials");

            migrationBuilder.DropTable(
                name: "videos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PaymentGateways");

            migrationBuilder.DropTable(
                name: "galleryCategories");

            migrationBuilder.DropTable(
                name: "purposes");

            migrationBuilder.DropTable(
                name: "professions");
        }
    }
}
