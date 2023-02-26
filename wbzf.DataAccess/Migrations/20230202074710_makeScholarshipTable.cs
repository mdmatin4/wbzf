using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbzf.DataAccess.Migrations
{
    public partial class makeScholarshipTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Academic_Qualification",
                table: "coachingForms");

            migrationBuilder.AddColumn<string>(
                name: "qualification1Board",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification1Class",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification1Exam",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification1Marks",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification1Remarks",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification1Sub",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification1Year",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification2Board",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification2Class",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification2Exam",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification2Marks",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification2Remarks",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification2Sub",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification2Year",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification3Board",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification3Class",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification3Exam",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification3Marks",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification3Remarks",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification3Sub",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification3Year",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification4Board",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification4Class",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification4Exam",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification4Marks",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification4Remarks",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification4Sub",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qualification4Year",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scholarshipApplications");

            migrationBuilder.DropColumn(
                name: "qualification1Board",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification1Class",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification1Exam",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification1Marks",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification1Remarks",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification1Sub",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification1Year",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification2Board",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification2Class",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification2Exam",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification2Marks",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification2Remarks",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification2Sub",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification2Year",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification3Board",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification3Class",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification3Exam",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification3Marks",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification3Remarks",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification3Sub",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification3Year",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification4Board",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification4Class",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification4Exam",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification4Marks",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification4Remarks",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification4Sub",
                table: "coachingForms");

            migrationBuilder.DropColumn(
                name: "qualification4Year",
                table: "coachingForms");

            migrationBuilder.AddColumn<string>(
                name: "Academic_Qualification",
                table: "coachingForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
