using backend.DataAccess.Database.Entities;
using backend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UsersEntity> users { get; set; }
        public DbSet<UserStatusEntity> userStatus { get; set; }
        public DbSet<AccessLevelEntity> accessLevel { get; set; }
        public DbSet<CompanyRepresentativeEntity> businessRepresentatives { get; set; }
        public DbSet<CompanyEntity> company { get; set; }
        public DbSet<EnquiryEntity> enquiry { get; set; }
        public DbSet<QuotationEntity> quotation { get; set; }
        public DbSet <QuotationItemEntity> quotationItem { get; set; }
        public DbSet<EmailTemplateEntity> emailTemplate { get; set; }
        public DbSet<InvoiceEntity> invoice { get; set; }
        public DbSet<EquipmentUtilizationEntity> equipmentUtilization { get; set; }
        public DbSet<BroaderMCTSRatesEntity> broaderMCTSRates { get; set; }
        public DbSet<TermsAndConditionsEntity> termsAndConditions { get; set; }
        public DbSet<FocusAreaEntity> focusAreas { get; set; }
        public DbSet<ProductsEntity> products { get; set; }
        public DbSet<EmployeesEntity> employees { get; set; }
        public DbSet<EmployeesPositionEntity> employeesPosition { get; set; }
        public DbSet<ProjectExpenditure> projectExpenditures { get; set; }
        public DbSet<ProjectTODO> projectTODOs { get; set; }
        public DbSet<ProjectProgress> projectProgresses { get; set; }
        public DbSet<ProjectEntity> project { get; set; }
        public DbSet<QuarterEntity> quarter { get; set; }
        public DbSet<PaymentEntity> payments { get; set; }
        public DbSet<TargetSettingsEntity> targetSettings { get; set; }
        public DbSet<SPGetAllProjectEntity> sPGetAllProjects { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SPGetAllProjectEntity>()
                .HasNoKey();

            modelBuilder.Entity<ProjectEntity>()
                .HasIndex(p => p.invoice_reference)
                .IsUnique();

            modelBuilder.Entity<ProjectEntity>()
                .HasIndex(p => p.project_number)
                .IsUnique();

            modelBuilder.Entity<CompanyEntity>()
                .HasIndex(p => p.registration_number)
                .IsUnique();

            modelBuilder.Entity<EmployeesEntity>()
                .HasIndex(p => p.employee_number)
                .IsUnique();

            modelBuilder.Entity<EmployeesEntity>()
               .HasIndex(p => p.email)
               .IsUnique();

            modelBuilder.Entity<CompanyRepresentativeEntity>()
                .HasIndex(p => p.email)
                .IsUnique();

            modelBuilder.Entity<InvoiceEntity>()
               .HasIndex(p => p.reference)
               .IsUnique();


            modelBuilder.Entity<InvoiceEntity>()
               .HasIndex(p => p.quotation_reference)
               .IsUnique();

            modelBuilder.Entity<ProjectProgress>()
               .HasIndex(p => p.project_number)
               .IsUnique();

            modelBuilder.Entity<QuarterEntity>()
               .HasIndex(p => p.quarter)
               .IsUnique();

            modelBuilder.Entity<QuotationEntity>()
               .HasIndex(p => p.Quote_reference)
               .IsUnique();

            modelBuilder.Entity<UserStatusEntity>().HasData(
                    new UserStatusEntity() {id =1, status = "Active"},
                    new UserStatusEntity() {id = 2, status = "InActive"},
                    new UserStatusEntity() {id = 3, status = "Suspended"},
                    new UserStatusEntity() {id = 4, status = "Deactivated"}
                );

            modelBuilder.Entity<EmployeesPositionEntity>().HasData(
                    new EmployeesPositionEntity() { id=1, position = "Administrator"},
                    new EmployeesPositionEntity() { id = 2, position = "General Staff" },
                    new EmployeesPositionEntity() { id = 3, position = "Manager" }
                );

            modelBuilder.Entity<AccessLevelEntity>().HasData(
                    new AccessLevelEntity() {id=1, level = "Admin" },
                    new AccessLevelEntity() { id = 2, level = "Employee" },
                    new AccessLevelEntity() { id = 3, level = "Client" }
                );

            modelBuilder.Entity<EmailTemplateEntity>().HasData(
                    new EmailTemplateEntity() { id = 1, code = EmailTemplate.ForgotPassword, email_type="Forgot Password"},
                    new EmailTemplateEntity() { id = 2, code = EmailTemplate.Registration, email_type = "Registration"},
                    new EmailTemplateEntity() { id = 3, code = EmailTemplate.ResetPassword, email_type = "ResetPassword"},
                    new EmailTemplateEntity() { id = 4, code = EmailTemplate.EmployeeRegistration, email_type="Employee Registration"},
                    new EmailTemplateEntity() { id = 5, code = EmailTemplate.QuotationPending, email_type="QuotationPending"},
                    new EmailTemplateEntity() { id = 6, code = EmailTemplate.QuotationPendingManagerApproval, email_type = "QuotationPendingManagerApproval" },
                    new EmailTemplateEntity() { id = 7, code = EmailTemplate.QuotationPendingClientApproval, email_type = "QuotationClientApproval" },
                    new EmailTemplateEntity() { id = 8, code = EmailTemplate.QuotationAccepted, email_type = "QuotationApproved" },
                    new EmailTemplateEntity() { id = 9, code = EmailTemplate.QuoatationRejected, email_type = "QuotationRejected" },
                    new EmailTemplateEntity() { id = 10, code = EmailTemplate.GenericEmail, email_type = "GenericEmail" },
                    new EmailTemplateEntity() { id = 11, code = EmailTemplate.PaymentConfirmation, email_type = "PaymentConfirmation" }
                );

            modelBuilder.Entity<FocusAreaEntity>().HasData(
                    new FocusAreaEntity() { id = 1, name = "Physical Metallurgy"},
                    new FocusAreaEntity() { id = 2, name = "Moulding Tech" },
                    new FocusAreaEntity() { id = 3, name = "Foundry Tech" },
                    new FocusAreaEntity() { id = 4, name = "SupportEquipment" },
                    new FocusAreaEntity() { id = 5, name = "Support" },
                    new FocusAreaEntity() { id = 6, name = "Other"},
                    new FocusAreaEntity() { id = 7, name = "BroaderMCTSRates" }
                );

            modelBuilder.Entity<ProductExpectation>().HasData(
                    new ProductExpectation() { id = 1, name = "SABS Approval" },
                    new ProductExpectation() { id = 2, name = "Quality Standards" },
                    new ProductExpectation() { id = 3, name = "Compliance" },
                    new ProductExpectation() { id = 4, name = "Competitive" },
                    new ProductExpectation() { id = 5, name = "Green Technology " },
                    new ProductExpectation() { id = 6, name = "Other" }
                );

            modelBuilder.Entity<ProductsEntity>().HasData(
                    new ProductsEntity() { id = 1, name = "ProE", time_study_per_test = 60, rate_per_hour = 550.00, focus_area_fk = 3 },
                    new ProductsEntity() { id = 2, name = "MDX", time_study_per_test = 60, rate_per_hour = 550.00, focus_area_fk = 3 },
                    new ProductsEntity() { id = 3, name = "AutoD", time_study_per_test = 60, rate_per_hour = 550.00, focus_area_fk = 3 },
                    new ProductsEntity() { id = 4, name = "ALIA", time_study_per_test = 9600, rate_per_hour = 937.50, focus_area_fk = 3 },
                    new ProductsEntity() { id = 5, name = "3DP", time_study_per_test = 60, rate_per_hour = 550.00, focus_area_fk = 3 },
                    new ProductsEntity() { id = 6, name = "Click To Cast", time_study_per_test = 60, rate_per_hour = 550.00, focus_area_fk = 3 },
                    new ProductsEntity() { id = 7, name = "Non Testing Act(Ftec)", time_study_per_test = 60, rate_per_hour = 772.32, focus_area_fk = 3 },

                   new ProductsEntity() { id = 8, name = "Spin Cast", time_study_per_test = 60, rate_per_hour = 250.00,focus_area_fk = 4  },
                   new ProductsEntity() { id = 9, name = "Ind Coil Furn", time_study_per_test = 60, rate_per_hour = 250.00, focus_area_fk = 4 },
                   new ProductsEntity() { id = 10, name = "Valcanizer", time_study_per_test = 60, rate_per_hour = 250.00, focus_area_fk = 4 },
                   new ProductsEntity() { id = 11, name = "Host Interns", time_study_per_test = 60, rate_per_hour = 0.00, focus_area_fk = 4 },
                   new ProductsEntity() { id = 12, name = "SLP / Tail Dem1", time_study_per_test = 1, rate_per_hour = 18.20, focus_area_fk = 4 },
                   new ProductsEntity() { id = 13, name = "SLP / Tail Dem2", time_study_per_test = 0, rate_per_hour = 0.00, focus_area_fk = 4 },
                   new ProductsEntity() { id = 14, name = "SLP / Tail Dem3", time_study_per_test = 0, rate_per_hour = 0.00, focus_area_fk = 4 },
                   new ProductsEntity() { id = 15, name = "SLP / Tail Dem4", time_study_per_test = 0, rate_per_hour = 0.00, focus_area_fk = 4 },
                   new ProductsEntity() { id = 16, name = "Lazer Cutter", time_study_per_test = 60, rate_per_hour = 20.00, focus_area_fk = 4 },
                   new ProductsEntity() { id = 17, name = "Design Software", time_study_per_test = 60, rate_per_hour = 50.00, focus_area_fk = 4 },
                   new ProductsEntity() { id = 18, name = "Non Testing Act (Sup)", time_study_per_test = 60, rate_per_hour = 687.73, focus_area_fk = 4 },

                   new ProductsEntity() { id = 19, name = "Testing & Analysis", time_study_per_test = 0, rate_per_hour = 224.38, focus_area_fk = 7 },
                   new ProductsEntity() { id = 20, name = "Prototyping & Manufacturing", time_study_per_test = 0, rate_per_hour = 800.00, focus_area_fk = 7 },
                   new ProductsEntity() { id = 21, name = "Consult / Technology Audit", time_study_per_test = 0, rate_per_hour = 500.00, focus_area_fk = 7 },
                   new ProductsEntity() { id = 22, name = "Product and Process Development", time_study_per_test = 0, rate_per_hour = 800.00, focus_area_fk = 7 },
                   new ProductsEntity() { id = 23, name = "Research and Development", time_study_per_test = 0, rate_per_hour = 800.00, focus_area_fk = 7 },
                   new ProductsEntity() { id = 24, name = "Technology Demonstration / Transfer", time_study_per_test = 0, rate_per_hour = 800.00, focus_area_fk = 7 },
                   new ProductsEntity() { id = 25, name = "Knowledge Transfer / SLP", time_study_per_test = 0, rate_per_hour = 250.00, focus_area_fk = 7 },
                   new ProductsEntity() { id = 26, name = "Investigative Projects (Failure / Defect)", time_study_per_test = 0, rate_per_hour = 0.00, focus_area_fk = 7 },


                   new ProductsEntity() { id = 27, name = "Green Stren", time_study_per_test = 120, rate_per_hour = 21.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 28, name = "Dry Stren", time_study_per_test = 240, rate_per_hour = 42.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 29, name = "Friability", time_study_per_test = 120, rate_per_hour = 21.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 30, name = "Permeab", time_study_per_test = 120, rate_per_hour = 21.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 31, name = "Green Shea", time_study_per_test = 120, rate_per_hour = 21.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 32, name = "Dry Shea", time_study_per_test = 240, rate_per_hour = 42.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 33, name = "Shatter In", time_study_per_test = 120, rate_per_hour = 21.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 34, name = "Wet Ten", time_study_per_test = 120, rate_per_hour = 21.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 35, name = "Compact", time_study_per_test = 120, rate_per_hour = 21.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 36, name = "Compress", time_study_per_test = 120, rate_per_hour = 21.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 37, name = "Moisture", time_study_per_test = 240, rate_per_hour = 42.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 38, name = "Voliti", time_study_per_test = 160, rate_per_hour = 28.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 39, name = "Activ C", time_study_per_test = 90, rate_per_hour = 18.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 40, name = "Clay Wash", time_study_per_test = 180, rate_per_hour = 32.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 41, name = "LOl", time_study_per_test = 160, rate_per_hour = 28.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 42, name = "Tensile", time_study_per_test = 120, rate_per_hour = 179.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 43, name = "Transv Stre", time_study_per_test = 120, rate_per_hour = 179.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 44, name = "Swe Ind", time_study_per_test = 120, rate_per_hour = 47.23, focus_area_fk = 2 },
                   new ProductsEntity() { id = 45, name = "Visco", time_study_per_test = 60, rate_per_hour = 27.63, focus_area_fk = 2 },
                   new ProductsEntity() { id = 46, name = "CEC", time_study_per_test = 120, rate_per_hour = 47.23, focus_area_fk = 2 },
                   new ProductsEntity() { id = 47, name = "PH", time_study_per_test = 120, rate_per_hour = 47.23, focus_area_fk = 2 },
                   new ProductsEntity() { id = 48, name = "XRF", time_study_per_test = 180, rate_per_hour = 66.51, focus_area_fk = 2 },
                   new ProductsEntity() { id = 49, name = "XRD Sand", time_study_per_test = 180, rate_per_hour = 66.51, focus_area_fk = 2 },
                   new ProductsEntity() { id = 50, name = "Sieve Ana", time_study_per_test = 60, rate_per_hour = 27.66, focus_area_fk = 2 },
                   new ProductsEntity() { id = 51, name = "Grain Sha", time_study_per_test = 60, rate_per_hour = 14.78, focus_area_fk = 2 },
                   new ProductsEntity() { id = 52, name = "Sintering", time_study_per_test = 480, rate_per_hour = 72.32, focus_area_fk = 2 },
                   new ProductsEntity() { id = 53, name = "ADV", time_study_per_test = 180, rate_per_hour = 41.84, focus_area_fk = 2 },
                   new ProductsEntity() { id = 54, name = "Core Preparation", time_study_per_test = 20, rate_per_hour = 42.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 55, name = "Full Green Sand Anal", time_study_per_test = 2270, rate_per_hour = 400.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 56, name = "Full Resin Sand Aval", time_study_per_test = 480, rate_per_hour = 400.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 57, name = "Full Bentonite Anal", time_study_per_test = 1240, rate_per_hour = 400.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 58, name = "Full Ref San Anal", time_study_per_test = 1720, rate_per_hour = 400.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 59, name = "Core Making", time_study_per_test = 260, rate_per_hour = 400.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 60, name = "Calibration", time_study_per_test = 60, rate_per_hour = 400.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 61, name = "Mould Coating", time_study_per_test = 60, rate_per_hour = 400.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 62, name = "Oolitization", time_study_per_test = 60, rate_per_hour = 300.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 63, name = "TGA Analysis", time_study_per_test = 120, rate_per_hour = 21.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 64, name = "Sample Preparation", time_study_per_test = 180, rate_per_hour = 84.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 65, name = "Total Gas Evolution", time_study_per_test = 120, rate_per_hour = 600.00, focus_area_fk = 2 },
                   new ProductsEntity() { id = 66, name = "Non Testing Act", time_study_per_test = 60, rate_per_hour = 1233.64, focus_area_fk = 2 },

                    new ProductsEntity() { id = 67, name = "Macr Vick", time_study_per_test = 15, rate_per_hour = 75.00, focus_area_fk = 1},
                   new ProductsEntity() { id = 68, name = "Micr Vick", time_study_per_test = 15, rate_per_hour = 75.00, focus_area_fk = 1 },
                   new ProductsEntity() { id = 69, name = "Rockewell", time_study_per_test = 15, rate_per_hour = 75.00, focus_area_fk = 1 },
                   new ProductsEntity() { id = 70, name = "Brinell", time_study_per_test = 60, rate_per_hour = 75.00, focus_area_fk = 1 },
                   new ProductsEntity() { id = 71, name = "Charpy", time_study_per_test = 80, rate_per_hour = 490.00, focus_area_fk = 1 },
                   new ProductsEntity() { id = 72, name = "Tensile", time_study_per_test = 80, rate_per_hour = 450.00, focus_area_fk = 1 },
                   new ProductsEntity() { id = 73, name = "HT Fur 1", time_study_per_test = 60, rate_per_hour = 118.75, focus_area_fk = 1 },
                   new ProductsEntity() { id = 74, name = "HT Fur Big", time_study_per_test = 60, rate_per_hour = 118.75, focus_area_fk = 1 },
                   new ProductsEntity() { id = 75, name = "AI Furn", time_study_per_test = 60, rate_per_hour = 118.75, focus_area_fk = 1 },
                   new ProductsEntity() { id = 76, name = "Ind Furn", time_study_per_test = 60, rate_per_hour = 400.00, focus_area_fk = 1 },
                   new ProductsEntity() { id = 77, name = "Metallog", time_study_per_test = 80, rate_per_hour = 400.00, focus_area_fk = 1 },
                   new ProductsEntity() { id = 78, name = "Spectro", time_study_per_test = 60, rate_per_hour = 200.00, focus_area_fk = 1 },
                   new ProductsEntity() { id = 79, name = "Lecco", time_study_per_test = 80, rate_per_hour = 200.00, focus_area_fk = 1 },
                   new ProductsEntity() { id = 80, name = "XRD", time_study_per_test = 60, rate_per_hour = 500.00, focus_area_fk = 1 },
                   new ProductsEntity() { id = 81, name = "SEM", time_study_per_test = 60, rate_per_hour = 250.00, focus_area_fk = 1 },
                   new ProductsEntity() { id = 82, name = "Mill&M", time_study_per_test = 60, rate_per_hour = 250.00, focus_area_fk = 1 },
                   new ProductsEntity() { id = 83, name = "Stereo", time_study_per_test = 30, rate_per_hour = 80.00, focus_area_fk = 1 },
                   new ProductsEntity() { id = 84, name = "XRF", time_study_per_test = 60, rate_per_hour = 500.00, focus_area_fk = 1 },
                   new ProductsEntity() { id = 85, name = "Non Testing Act (Phys)", time_study_per_test = 60, rate_per_hour = 953.30, focus_area_fk = 1 }
               );

            modelBuilder.Entity<SocioEconomicImpactEntity>().HasData(
                   new SocioEconomicImpactEntity() { id = 1, name = "Productivity/ Increase in turnover " },
                   new SocioEconomicImpactEntity() { id = 2, name = "New Markets or Larger Markets" },
                   new SocioEconomicImpactEntity() { id = 3, name = "Export Facilitated" },
                   new SocioEconomicImpactEntity() { id = 4, name = "Job Created/ Secured " },
                   new SocioEconomicImpactEntity() { id = 5, name = "Productivity/ Increase in turnover" },
                   new SocioEconomicImpactEntity() { id = 6, name = "Youth Development" },
                   new SocioEconomicImpactEntity() { id = 7, name = "Cofference/ Journal Article" },
                   new SocioEconomicImpactEntity() { id = 8, name = "Other" }
                );

            modelBuilder.Entity<TechStationServiceEntity>().HasData(
                   new TechStationServiceEntity() { id = 1, name = "Testing & Analysis" },
                   new TechStationServiceEntity() { id = 2, name = "Prototyping & Manufacturing" },
                   new TechStationServiceEntity() { id = 3, name = "Consultation / Technology Audit" },
                   new TechStationServiceEntity() { id = 4, name = "Product and Process Development" },
                   new TechStationServiceEntity() { id = 5, name = "Research and Development" },
                   new TechStationServiceEntity() { id = 6, name = "Technology Demonstration / Transfer" },
                   new TechStationServiceEntity() { id = 7, name = "Knowledge Transfer / SLP" },
                   new TechStationServiceEntity() { id = 8, name = "Investigative Project (Failure /  Defect)" }
                );
          
        }

        private class EmailTemplate
        {
            public static string ForgotPassword = @"<html>
 <head>
   <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
   <meta name='viewport' content='width=320, initial-scale=1' />
   <style type='text/css' media='screen'>
 
     /* ----- Client Fixes ----- */
 
     /* Force Outlook to provide a 'view in browser' message */
     #outlook a {
       padding: 0;
     }
 
     /* Force Hotmail to display emails at full width */
     .ReadMsgBody {
       width: 100%;
     }	
 
     .ExternalClass {
       width: 100%;
     }
 
     /* Force Hotmail to display normal line spacing */
     .ExternalClass,
     .ExternalClass p,
     .ExternalClass span,
     .ExternalClass font,
     .ExternalClass td,
     .ExternalClass div {
       line-height: 100%;
     }
 
 
      /* Prevent WebKit and Windows mobile changing default text sizes */
     body, table, td, p, a, li, blockquote {
       -webkit-text-size-adjust: 100%;
       -ms-text-size-adjust: 100%;
     }
 
     /* Remove spacing between tables in Outlook 2007 and up */
     table, td {
       mso-table-lspace: 0pt;
       mso-table-rspace: 0pt;
     }
 
     /* Allow smoother rendering of resized image in Internet Explorer */
     img {
       -ms-interpolation-mode: bicubic;
     }
 
      /* ----- Reset ----- */
 
     html,
     body,
     .body-wrap,
     .body-wrap-cell {
       margin: 0;
       padding: 0;
       background: #ffffff;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       text-align: left;
     }
 
     img {
       border: 0;
       line-height: 100%;
       outline: none;
       text-decoration: none;
     }
 
     table {
       border-collapse: collapse !important;
     }
 
     td, th {
       text-align: left;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       line-height:1.5em;
     }
 
     /* ----- General ----- */
 
     h1, h2 {
       line-height: 1.1;
       text-align: right;
     }
 
     h1 {
       margin-top: 0;
       margin-bottom: 10px;
       font-size: 24px;
     }
 
     h2 {
       margin-top: 0;
       margin-bottom: 60px;
       font-weight: normal;
       font-size: 17px;
     }
 
     .outer-padding {
       padding: 50px 0;
     }
 
     .col-1 {
       border-right: 1px solid #D9DADA;
       width: 180px;
     }
 
     td.hide-for-desktop-text {
       font-size: 0;
       height: 0;
       display: none;
       color: #ffffff;
     }
 
     img.hide-for-desktop-image {
       font-size: 0 !important;
       line-height: 0 !important;
       width: 0 !important;
       height: 0 !important;
       display: none !important;
     }
 
     .body-cell {
       background-color: #ffffff;
       padding-top: 60px;
       vertical-align: top;
     }
 
     .body-cell-left-pad {
       padding-left: 30px;
       padding-right: 14px;
     }
 
     /* ----- Modules ----- */
 
     .brand td {
       padding-top: 25px;
     }
 
     .brand a {
       font-size: 16px;
       line-height: 59px;
       font-weight: bold;
     }
 
     .data-table th,
     .data-table td {
       width: 350px;
       padding-top: 5px;
       padding-bottom: 5px;
       padding-left: 5px;
     }
 
     .data-table th {
       background-color: #f9f9f9;
       color: #f8931e;
     }
 
     .data-table td {
       padding-bottom: 30px;
     }
 
     .data-table .data-table-amount {
       font-weight: bold;
       font-size: 20px;
     }
 
 
   </style>
 
   <style type='text/css' media='only screen and (max-width: 650px)'>
     @media only screen and (max-width: 650px) {
       table[class*='w320'] {
         width: 320px !important;
       }
 
       td[class*='col-1'] {
         border: none;
       }
 
       td[class*='hide-for-mobile'] {
         font-size: 0 !important; line-height: 0 !important; width: 0 !important;
         height: 0 !important; display: none !important;
       }
 
       img[class*='hide-for-desktop-image']{
         width: 176px !important;
         height: 135px !important;
         display:block !important;
         padding-left: 60px;
       }
 
       td[class*='hide-for-desktop-image'] {
         width: 100% !important;
         display: block !important;
         text-align: right !important;
       }
 
       td[class*='hide-for-desktop-text'] {
         display: block !important;
         text-align: center !important;
         font-size: 16px !important;
         height: 61px !important;
         padding-top: 30px !important;
         padding-bottom: 20px !important;
         color: #89898D !important;
       }
 
       td[class*='mobile-padding'] {
         padding-top: 15px;
       }
 
       td[class*='outer-padding'] {
         padding: 0 !important;
       }
 
       td[class*='body-cell-left-pad'] {
         padding-left: 20px;
         padding-right: 20px;
       }
     }
 
   </style>
 </head>
 
 <body class='body' style='padding:0; margin:0; display:block; background:#ffffff; -webkit-text-size-adjust:none' bgcolor='#ffffff'>
 <table width='100%' border='0' cellspacing='0' cellpadding='0' bgcolor='#ffffff'>
 <tr>
   <td class='outer-padding' valign='top' align='left'>
   <center>
     <table class='w320' cellspacing='0' cellpadding='0' width='600'>
       <tr>
 
         <td class='col-1 hide-for-mobile'>
 
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='hide-for-mobile' style='text-align: center;'>
                 <img width='50' height='41' src='https://useless-assets.s3.us-east-2.amazonaws.com/uj.jpg' alt='logo' />
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile'  height='150' valign='top' style='text-align: center;'>
                 <b>
                   <span>MCTS</span>
                   </b>
                 <br>
                 <span>University of Johannesburg</span>
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile' style='height:180px; width:299px; text-align: center;'>
                 <img width='auto' height='auto'src='https://useless-assets.s3.us-east-2.amazonaws.com/mtcs.jpg' alt='large logo' />
               </td>
             </tr>
           </table>
         </td>
 
         <td valign='top' class='col-2'>
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='body-cell body-cell-left-pad'>
                 <table cellspacing='0' cellpadding='0' width='100%'>
                   <tr>
                     <td>
 
                       <table cellspacing='0' cellpadding='10' width='100%'>
                         <tr>
                           <td class='mobile-padding'>
                             Hi {first_name},
                           </td>
                         </tr>
                       </table>
 
                       <table cellspacing='0' cellpadding='10' width='100%' >
                         <tr>
                           <td style='text-align: justify;'>
                             You have reset your password your new password is below. 
                           </td>
                         </tr>
 						 <tr>
                           <td style='text-align: center; font-size: 9pt;'>
                             <b>Password: {pwd}</b>
                           </td>
                         </tr>
                       </table>
 
                     
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
                         <tr>
                           <td style='text-align:center;padding-top:30px;'>
                             <img src='https://www.filepicker.io/api/file/F7k2y1vcTu2AVmcPTkPJ' alt='signature' />
                           </td>
                         </tr>
 						
                       </table>
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
                         <tr>
                           <td class='hide-for-desktop-text'>
                             <b>
                               <span>Awesome Co</span>
                             </b>
                             <br>
                             <span>1337 Swuby Lane<br>Victoria, BC A1B 2C3</span>
                           </td>
                         </tr>
 						<tr>
 						<br>
 							<td style='text-align: center; font-size: 7pt;'>if you did not create an account with us please <a href='#'>contact support</a>.</td>
 						</tr>
                       </table>
                     </td>
                   </tr>
                 </table>
 
               </td>
             </tr>
           </table>
         </td>
 
       </tr>
     </table>
   </center>
   </td>
 </tr>
 </table>
 </body>
 </html>";

            public static string Registration = @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>
  <html xmlns='http://www.w3.org/1999/xhtml'>
  <head>
    <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
    <meta name='viewport' content='width=320, initial-scale=1' />
    <title>Cleave Ping</title>
    <style type='text/css' media='screen'>
  
      /* ----- Client Fixes ----- */
  
      /* Force Outlook to provide a 'view in browser' message */
      #outlook a {
        padding: 0;
      }
  
      /* Force Hotmail to display emails at full width */
      .ReadMsgBody {
        width: 100%;
      }
  
      .ExternalClass {
        width: 100%;
      }
  
      /* Force Hotmail to display normal line spacing */
      .ExternalClass,
      .ExternalClass p,
      .ExternalClass span,
      .ExternalClass font,
      .ExternalClass td,
      .ExternalClass div {
        line-height: 100%;
      }
  
  
       /* Prevent WebKit and Windows mobile changing default text sizes */
      body, table, td, p, a, li, blockquote {
        -webkit-text-size-adjust: 100%;
        -ms-text-size-adjust: 100%;
      }
  
      /* Remove spacing between tables in Outlook 2007 and up */
      table, td {
        mso-table-lspace: 0pt;
        mso-table-rspace: 0pt;
      }
  
      /* Allow smoother rendering of resized image in Internet Explorer */
      img {
        -ms-interpolation-mode: bicubic;
      }
  
       /* ----- Reset ----- */
  
      html,
      body,
      .body-wrap,
      .body-wrap-cell {
        margin: 0;
        padding: 0;
        background: #ffffff;
        font-family: Arial, Helvetica, sans-serif;
        font-size: 16px;
        color: #89898D;
        text-align: left;
      }
  
      img {
        border: 0;
        line-height: 100%;
        outline: none;
        text-decoration: none;
      }
  
      table {
        border-collapse: collapse !important;
      }
  
      td, th {
        text-align: left;
        font-family: Arial, Helvetica, sans-serif;
        font-size: 16px;
        color: #89898D;
        line-height:1.5em;
      }
  
      /* ----- General ----- */
  
      h1, h2 {
        line-height: 1.1;
        text-align: right;
      }
  
      h1 {
        margin-top: 0;
        margin-bottom: 10px;
        font-size: 24px;
      }
  
      h2 {
        margin-top: 0;
        margin-bottom: 60px;
        font-weight: normal;
        font-size: 17px;
      }
  
      .outer-padding {
        padding: 50px 0;
      }
  
      .col-1 {
        border-right: 1px solid #D9DADA;
        width: 180px;
      }
  
      td.hide-for-desktop-text {
        font-size: 0;
        height: 0;
        display: none;
        color: #ffffff;
      }
  
      img.hide-for-desktop-image {
        font-size: 0 !important;
        line-height: 0 !important;
        width: 0 !important;
        height: 0 !important;
        display: none !important;
      }
  
      .body-cell {
        background-color: #ffffff;
        padding-top: 60px;
        vertical-align: top;
      }
  
      .body-cell-left-pad {
        padding-left: 30px;
        padding-right: 14px;
      }
  
      /* ----- Modules ----- */
  
      .brand td {
        padding-top: 25px;
      }
  
      .brand a {
        font-size: 16px;
        line-height: 59px;
        font-weight: bold;
      }
  
      .data-table th,
      .data-table td {
        width: 350px;
        padding-top: 5px;
        padding-bottom: 5px;
        padding-left: 5px;
      }
  
      .data-table th {
        background-color: #f9f9f9;
        color: #f8931e;
      }
  
      .data-table td {
        padding-bottom: 30px;
      }
  
      .data-table .data-table-amount {
        font-weight: bold;
        font-size: 20px;
      }
  
  
    </style>
  
    <style type='text/css' media='only screen and (max-width: 650px)'>
      @media only screen and (max-width: 650px) {
        table[class*='w320'] {
          width: 320px !important;
        }
  
        td[class*='col-1'] {
          border: none;
        }
  
        td[class*='hide-for-mobile'] {
          font-size: 0 !important; line-height: 0 !important; width: 0 !important;
          height: 0 !important; display: none !important;
        }
  
        img[class*='hide-for-desktop-image']{
          width: 176px !important;
          height: 135px !important;
          display:block !important;
          padding-left: 60px;
        }
  
        td[class*='hide-for-desktop-image'] {
          width: 100% !important;
          display: block !important;
          text-align: right !important;
        }
  
        td[class*='hide-for-desktop-text'] {
          display: block !important;
          text-align: center !important;
          font-size: 16px !important;
          height: 61px !important;
          padding-top: 30px !important;
          padding-bottom: 20px !important;
          color: #89898D !important;
        }
  
        td[class*='mobile-padding'] {
          padding-top: 15px;
        }
  
        td[class*='outer-padding'] {
          padding: 0 !important;
        }
  
        td[class*='body-cell-left-pad'] {
          padding-left: 20px;
          padding-right: 20px;
        }
      }
  
    </style>
  </head>
  
  <body class='body' style='padding:0; margin:0; display:block; background:#ffffff; -webkit-text-size-adjust:none' bgcolor='#ffffff'>
  <table width='100%' border='0' cellspacing='0' cellpadding='0' bgcolor='#ffffff'>
  <tr>
    <td class='outer-padding' valign='top' align='left'>
    <center>
      <table class='w320' cellspacing='0' cellpadding='0' width='600'>
        <tr>
  
          <td class='col-1 hide-for-mobile'>
  
            <table cellspacing='0' cellpadding='0' width='100%'>
              <tr>
                <td class='hide-for-mobile' style='text-align: center;'>
                  <img width='50' height='41' src='https://useless-assets.s3.us-east-2.amazonaws.com/uj.jpg' alt='logo' />
                </td>
              </tr>
  
              <tr>
                <td class='hide-for-mobile'  height='150' valign='top' style='text-align: center;'>
                  <b>
                    <span>MCTS</span>
                    </b>
                  <br>
                  <span>University of Johannesburg</span>
                </td>
              </tr>
  
              <tr>
                <td class='hide-for-mobile' style='height:180px; width:299px; text-align: center;'>
                  <img width='auto' height='auto'src='https://useless-assets.s3.us-east-2.amazonaws.com/mtcs.jpg' alt='large logo' />
                </td>
              </tr>
            </table>
          </td>
  
          <td valign='top' class='col-2'>
            <table cellspacing='0' cellpadding='0' width='100%'>
              <tr>
                <td class='body-cell body-cell-left-pad'>
                  <table cellspacing='0' cellpadding='0' width='100%'>
                    <tr>
                      <td>
  
                        <table cellspacing='0' cellpadding='10' width='100%'>
                          <tr>
                            <td class='mobile-padding'>
                              Hi {first_name},
                            </td>
                          </tr>
                        </table>
  
                        <table cellspacing='0' cellpadding='10' width='100%' >
                          <tr>
                            <td style='text-align: justify; width:100%;'>
                              Thank you for choosing UJ-MCIT for your company.Your account with UJ-MCIT has been successfully registered and here are your login credintials. Please activate your account so that you can be able to login the system
                            </td>
                          </tr>
  						 <tr>
                            <td style='text-align: center; font-size: 9pt;'>
                              <b>Username: {usr}</b><br>
  							<b>Password: {pwd}</b>
                            </td>
                          </tr>
                        </table>
  
                        <table cellspacing='0' cellpadding='10' width='100%'>
                          <tr>
                            <td class='hide-for-mobile'  width='65' style='width:65px;'>
                              &nbsp;
                            </td>
                            <td width='150' style='width:229px;'>
                              <div style='text-align:center; background-color:#48be19;'><!--[if mso]>
                                    <v:roundrect xmlns:v='urn:schemas-microsoft-com:vml' xmlns:w='urn:schemas-microsoft-com:office:word' href='#' style='height:35px;v-text-anchor:middle;width:229px;' arcsize='8%' stroke='f' fillcolor='#48be19'>
                                      <w:anchorlock/>
                                      <center style='color:#ffffff;font-family:sans-serif;font-size:16px;'>Review Account Settings</center>
                                    </v:roundrect>
                                  <![endif]-->
                                  <!--[if !mso]><!-- --><a href='http://mcp-frontend.s3-website.us-east-2.amazonaws.com/login'><table cellspacing='0' cellpadding='0' width='100%'><tr><td style='background-color:#6E00B4;border-radius:5px;color:#ffffff;display:inline-block;font-family:sans-serif;font-size:16px;line-height:45px;text-align:center;text-decoration:none;width:229px;-webkit-text-size-adjust:none;mso-hide:all;'><span style='color:#ffffff'>Activate&nbsp;Account</span></td></tr></table></a>
                                  <!--<![endif]-->
                                </div>
                            </td>
                            <td class='hide-for-mobile'  width='65' style='width:65px;'>
                              &nbsp;
                            </td>
                          </tr>
  						
                        </table>
  
                        <table cellspacing='0' cellpadding='0' width='100%'>
                          <tr>
                            <td style='text-align:center;padding-top:30px;'>
                              <img src='https://www.filepicker.io/api/file/F7k2y1vcTu2AVmcPTkPJ' alt='signature' />
                            </td>
                          </tr>
  						
                        </table>
  
                        <table cellspacing='0' cellpadding='0' width='100%'>
                          <tr>
                            <td class='hide-for-desktop-text'>
                              <b>
                                <span>Awesome Co</span>
                              </b>
                              <br>
                              <span>1337 Swuby Lane<br>Victoria, BC A1B 2C3</span>
                            </td>
                          </tr>
  						<tr>
  						<br>
  							<td style='text-align: center; font-size: 7pt;'>if you did not create an account with us please <a href='#'>contact support</a>.</td>
  						</tr>
                        </table>
                      </td>
                    </tr>
                  </table>
  
                </td>
              </tr>
            </table>
          </td>
  
        </tr>
      </table>
    </center>
    </td>
  </tr>
  </table>
  </body>
  </html>";

            public static string ResetPassword = @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>
 <html xmlns='http://www.w3.org/1999/xhtml'>
 <head>
   <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
   <meta name='viewport' content='width=320, initial-scale=1' />
   <title>Cleave Ping</title>
   <style type='text/css' media='screen'>
 
     /* ----- Client Fixes ----- */
 
     /* Force Outlook to provide a 'view in browser' message */
     #outlook a {
       padding: 0;
     }
 
     /* Force Hotmail to display emails at full width */
     .ReadMsgBody {
       width: 100%;
     }
 
     .ExternalClass {
       width: 100%;
     }
 
     /* Force Hotmail to display normal line spacing */
     .ExternalClass,
     .ExternalClass p,
     .ExternalClass span,
     .ExternalClass font,
     .ExternalClass td,
     .ExternalClass div {
       line-height: 100%;
     }
 
 
      /* Prevent WebKit and Windows mobile changing default text sizes */
     body, table, td, p, a, li, blockquote {
       -webkit-text-size-adjust: 100%;
       -ms-text-size-adjust: 100%;
     }
 
     /* Remove spacing between tables in Outlook 2007 and up */
     table, td {
       mso-table-lspace: 0pt;
       mso-table-rspace: 0pt;
     }
 
     /* Allow smoother rendering of resized image in Internet Explorer */
     img {
       -ms-interpolation-mode: bicubic;
     }
 
      /* ----- Reset ----- */
 
     html,
     body,
     .body-wrap,
     .body-wrap-cell {
       margin: 0;
       padding: 0;
       background: #ffffff;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       text-align: left;
     }
 
     img {
       border: 0;
       line-height: 100%;
       outline: none;
       text-decoration: none;
     }
 
     table {
       border-collapse: collapse !important;
     }
 
     td, th {
       text-align: left;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       line-height:1.5em;
     }
 
     /* ----- General ----- */
 
     h1, h2 {
       line-height: 1.1;
       text-align: right;
     }
 
     h1 {
       margin-top: 0;
       margin-bottom: 10px;
       font-size: 24px;
     }
 
     h2 {
       margin-top: 0;
       margin-bottom: 60px;
       font-weight: normal;
       font-size: 17px;
     }
 
     .outer-padding {
       padding: 50px 0;
     }
 
     .col-1 {
       border-right: 1px solid #D9DADA;
       width: 180px;
     }
 
     td.hide-for-desktop-text {
       font-size: 0;
       height: 0;
       display: none;
       color: #ffffff;
     }
 
     img.hide-for-desktop-image {
       font-size: 0 !important;
       line-height: 0 !important;
       width: 0 !important;
       height: 0 !important;
       display: none !important;
     }
 
     .body-cell {
       background-color: #ffffff;
       padding-top: 60px;
       vertical-align: top;
     }
 
     .body-cell-left-pad {
       padding-left: 30px;
       padding-right: 14px;
     }
 
     /* ----- Modules ----- */
 
     .brand td {
       padding-top: 25px;
     }
 
     .brand a {
       font-size: 16px;
       line-height: 59px;
       font-weight: bold;
     }
 
     .data-table th,
     .data-table td {
       width: 350px;
       padding-top: 5px;
       padding-bottom: 5px;
       padding-left: 5px;
     }
 
     .data-table th {
       background-color: #f9f9f9;
       color: #f8931e;
     }
 
     .data-table td {
       padding-bottom: 30px;
     }
 
     .data-table .data-table-amount {
       font-weight: bold;
       font-size: 20px;
     }
 
 
   </style>
 
   <style type='text/css' media='only screen and (max-width: 650px)'>
     @media only screen and (max-width: 650px) {
       table[class*='w320'] {
         width: 320px !important;
       }
 
       td[class*='col-1'] {
         border: none;
       }
 
       td[class*='hide-for-mobile'] {
         font-size: 0 !important; line-height: 0 !important; width: 0 !important;
         height: 0 !important; display: none !important;
       }
 
       img[class*='hide-for-desktop-image']{
         width: 176px !important;
         height: 135px !important;
         display:block !important;
         padding-left: 60px;
       }
 
       td[class*='hide-for-desktop-image'] {
         width: 100% !important;
         display: block !important;
         text-align: right !important;
       }
 
       td[class*='hide-for-desktop-text'] {
         display: block !important;
         text-align: center !important;
         font-size: 16px !important;
         height: 61px !important;
         padding-top: 30px !important;
         padding-bottom: 20px !important;
         color: #89898D !important;
       }
 
       td[class*='mobile-padding'] {
         padding-top: 15px;
       }
 
       td[class*='outer-padding'] {
         padding: 0 !important;
       }
 
       td[class*='body-cell-left-pad'] {
         padding-left: 20px;
         padding-right: 20px;
       }
     }
 
   </style>
 </head>
 
 <body class='body' style='padding:0; margin:0; display:block; background:#ffffff; -webkit-text-size-adjust:none' bgcolor='#ffffff'>
 <table width='100%' border='0' cellspacing='0' cellpadding='0' bgcolor='#ffffff'>
 <tr>
   <td class='outer-padding' valign='top' align='left'>
   <center>
     <table class='w320' cellspacing='0' cellpadding='0' width='600'>
       <tr>
 
         <td class='col-1 hide-for-mobile'>
 
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='hide-for-mobile' style='text-align: center;'>
                 <img width='50' height='41' src='https://useless-assets.s3.us-east-2.amazonaws.com/uj.jpg' alt='logo' />
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile'  height='150' valign='top' style='text-align: center;'>
                 <b>
                   <span>MCTS</span>
                   </b>
                 <br>
                 <span>University of Johannesburg</span>
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile' style='height:180px; width:299px; text-align: center;'>
                 <img width='auto' height='auto'src='https://useless-assets.s3.us-east-2.amazonaws.com/mtcs.jpg' alt='large logo' />
               </td>
             </tr>
           </table>
         </td>
 
         <td valign='top' class='col-2'>
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='body-cell body-cell-left-pad'>
                 <table cellspacing='0' cellpadding='0' width='100%'>
                   <tr>
                     <td>
 
                       <table cellspacing='0' cellpadding='10' width='100%'>
                         <tr>
                           <td class='mobile-padding'>
                             Hi {first_name},
                           </td>
                         </tr>
                       </table>
 
                       <table cellspacing='0' cellpadding='10' width='100%' >
                         <tr>
                           <td style='text-align: justify; width:100%;'>
                             Your reset password request has been successful. Here is your new password.
                           </td>
                         </tr>
 						 <tr>
                           <td style='text-align: center; font-size: 9pt;'>
 							<b>Password: {pwd}</b>
                           </td>
                         </tr>
                       </table>
 
                       <table cellspacing='0' cellpadding='10' width='100%'>
                         <tr>
                           <td class='hide-for-mobile'  width='65' style='width:65px;'>
                             &nbsp;
                           </td>
                           <td width='150' style='width:229px;'>
                             <div style='text-align:center; background-color:#48be19;'><!--[if mso]>
                                   <v:roundrect xmlns:v='urn:schemas-microsoft-com:vml' xmlns:w='urn:schemas-microsoft-com:office:word' href='#' style='height:35px;v-text-anchor:middle;width:229px;' arcsize='8%' stroke='f' fillcolor='#48be19'>
                                     <w:anchorlock/>
                                     <center style='color:#ffffff;font-family:sans-serif;font-size:16px;'>Review Account Settings</center>
                                   </v:roundrect>
                                 <![endif]-->
                                 <!--[if !mso]><!-- <a href='#'><table cellspacing='0' cellpadding='0' width='100%'><tr><td style='background-color:#6E00B4;border-radius:5px;color:#ffffff;display:inline-block;font-family:sans-serif;font-size:16px;line-height:45px;text-align:center;text-decoration:none;width:229px;-webkit-text-size-adjust:none;mso-hide:all;'><span style='color:#ffffff'>Activate&nbsp;Account</span></td></tr></table></a>
                                 <!--<![endif]-->
                               </div>
                           </td>
                           <td class='hide-for-mobile'  width='65' style='width:65px;'>
                             &nbsp;
                           </td>
                         </tr>
 						
                       </table>
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
                         <tr>
                           <td style='text-align:center;padding-top:30px;'>
                             <img src='https://www.filepicker.io/api/file/F7k2y1vcTu2AVmcPTkPJ' alt='signature' />
                           </td>
                         </tr>
 						
                       </table>
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
                         <tr>
                           <td class='hide-for-desktop-text'>
                             <b>
                               <span>Awesome Co</span>
                             </b>
                             <br>
                             <span>1337 Swuby Lane<br>Victoria, BC A1B 2C3</span>
                           </td>
                         </tr>
 						<tr>
 						<br>
 							<td style='text-align: center; font-size: 7pt;'>if you did not create an account with us please <a href='#'>contact support</a>.</td>
 						</tr>
                       </table>
                     </td>
                   </tr>
                 </table>
 
               </td>
             </tr>
           </table>
         </td>
 
       </tr>
     </table>
   </center>
   </td>
 </tr>
 </table>
 </body>
 </html>";

            public static string EmployeeRegistration = @"<html>
 <head>
   <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
   <meta name='viewport' content='width=320, initial-scale=1' />
   <style type='text/css' media='screen'>
 
     /* ----- Client Fixes ----- */
 
     /* Force Outlook to provide a 'view in browser' message */
     #outlook a {
       padding: 0;
     }
 
     /* Force Hotmail to display emails at full width */
     .ReadMsgBody {
       width: 100%;
     }	
 
     .ExternalClass {
       width: 100%;
     }
 
     /* Force Hotmail to display normal line spacing */
     .ExternalClass,
     .ExternalClass p,
     .ExternalClass span,
     .ExternalClass font,
     .ExternalClass td,
     .ExternalClass div {
       line-height: 100%;
     }
 
 
      /* Prevent WebKit and Windows mobile changing default text sizes */
     body, table, td, p, a, li, blockquote {
       -webkit-text-size-adjust: 100%;
       -ms-text-size-adjust: 100%;
     }
 
     /* Remove spacing between tables in Outlook 2007 and up */
     table, td {
       mso-table-lspace: 0pt;
       mso-table-rspace: 0pt;
     }
 
     /* Allow smoother rendering of resized image in Internet Explorer */
     img {
       -ms-interpolation-mode: bicubic;
     }
 
      /* ----- Reset ----- */
 
     html,
     body,
     .body-wrap,
     .body-wrap-cell {
       margin: 0;
       padding: 0;
       background: #ffffff;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       text-align: left;
     }
 
     img {
       border: 0;
       line-height: 100%;
       outline: none;
       text-decoration: none;
     }
 
     table {
       border-collapse: collapse !important;
     }
 
     td, th {
       text-align: left;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       line-height:1.5em;
     }
 
     /* ----- General ----- */
 
     h1, h2 {
       line-height: 1.1;
       text-align: right;
     }
 
     h1 {
       margin-top: 0;
       margin-bottom: 10px;
       font-size: 24px;
     }
 
     h2 {
       margin-top: 0;
       margin-bottom: 60px;
       font-weight: normal;
       font-size: 17px;
     }
 
     .outer-padding {
       padding: 50px 0;
     }
 
     .col-1 {
       border-right: 1px solid #D9DADA;
       width: 180px;
     }
 
     td.hide-for-desktop-text {
       font-size: 0;
       height: 0;
       display: none;
       color: #ffffff;
     }
 
     img.hide-for-desktop-image {
       font-size: 0 !important;
       line-height: 0 !important;
       width: 0 !important;
       height: 0 !important;
       display: none !important;
     }
 
     .body-cell {
       background-color: #ffffff;
       padding-top: 60px;
       vertical-align: top;
     }
 
     .body-cell-left-pad {
       padding-left: 30px;
       padding-right: 14px;
     }
 
     /* ----- Modules ----- */
 
     .brand td {
       padding-top: 25px;
     }
 
     .brand a {
       font-size: 16px;
       line-height: 59px;
       font-weight: bold;
     }
 
     .data-table th,
     .data-table td {
       width: 350px;
       padding-top: 5px;
       padding-bottom: 5px;
       padding-left: 5px;
     }
 
     .data-table th {
       background-color: #f9f9f9;
       color: #f8931e;
     }
 
     .data-table td {
       padding-bottom: 30px;
     }
 
     .data-table .data-table-amount {
       font-weight: bold;
       font-size: 20px;
     }
 
 
   </style>
 
   <style type='text/css' media='only screen and (max-width: 650px)'>
     @media only screen and (max-width: 650px) {
       table[class*='w320'] {
         width: 320px !important;
       }
 
       td[class*='col-1'] {
         border: none;
       }
 
       td[class*='hide-for-mobile'] {
         font-size: 0 !important; line-height: 0 !important; width: 0 !important;
         height: 0 !important; display: none !important;
       }
 
       img[class*='hide-for-desktop-image']{
         width: 176px !important;
         height: 135px !important;
         display:block !important;
         padding-left: 60px;
       }
 
       td[class*='hide-for-desktop-image'] {
         width: 100% !important;
         display: block !important;
         text-align: right !important;
       }
 
       td[class*='hide-for-desktop-text'] {
         display: block !important;
         text-align: center !important;
         font-size: 16px !important;
         height: 61px !important;
         padding-top: 30px !important;
         padding-bottom: 20px !important;
         color: #89898D !important;
       }
 
       td[class*='mobile-padding'] {
         padding-top: 15px;
       }
 
       td[class*='outer-padding'] {
         padding: 0 !important;
       }
 
       td[class*='body-cell-left-pad'] {
         padding-left: 20px;
         padding-right: 20px;
       }
     }
 
   </style>
 </head>
 
 <body class='body' style='padding:0; margin:0; display:block; background:#ffffff; -webkit-text-size-adjust:none' bgcolor='#ffffff'>
 <table width='100%' border='0' cellspacing='0' cellpadding='0' bgcolor='#ffffff'>
 <tr>
   <td class='outer-padding' valign='top' align='left'>
   <center>
     <table class='w320' cellspacing='0' cellpadding='0' width='600'>
       <tr>
 
         <td class='col-1 hide-for-mobile'>
 
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='hide-for-mobile' style='text-align: center;'>
                 <img width='50' height='41' src='https://useless-assets.s3.us-east-2.amazonaws.com/uj.jpg' alt='logo' />
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile'  height='150' valign='top' style='text-align: center;'>
                 <b>
                   <span>MCTS</span>
                   </b>
                 <br>
                 <span>University of Johannesburg</span>
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile' style='height:180px; width:299px; text-align: center;'>
                 <img width='auto' height='auto'src='https://useless-assets.s3.us-east-2.amazonaws.com/mtcs.jpg' alt='large logo' />
               </td>
             </tr>
           </table>
         </td>
 
         <td valign='top' class='col-2'>
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='body-cell body-cell-left-pad'>
                 <table cellspacing='0' cellpadding='0' width='100%'>
                   <tr>
                     <td>
 
                       <table cellspacing='0' cellpadding='10' width='100%'>
                         <tr>
                           <td class='mobile-padding'>
                             Hi {first_name},
                           </td>
                         </tr>
                       </table>
 
                       <table cellspacing='0' cellpadding='10' width='100%' >
                         <tr>
                           <td style='text-align: justify;'>
                             Welcome to MCIT's online system as our employee. Your login credentials are as follow
                           </td>
                         </tr>
 						 <tr>
                           <td style='text-align: center; font-size: 9pt;'>
                             <b>Employee Number: {empNum}</b>
                           </td>
                         </tr>
						 <tr>
                           <td style='text-align: center; font-size: 9pt;'>
                             <b>Password: {pwd}</b>
                           </td>
                         </tr>
						 
						 <tr>
                           <td style='text-align: justify;'>
                            You will be instructed to change your password on login for the first time. Please keep these credentials safe as we track everything that is being done by our employees on the system.
                           </td>
                         </tr>
                       </table>
 
                     
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
 						
                       </table>
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
                         <tr>
                           <td class='hide-for-desktop-text'>
                             <b>
                               <span>Awesome Co</span>
                             </b>
                             <br>
                             <span>1337 Swuby Lane<br>Victoria, BC A1B 2C3</span>
                           </td>
                         </tr>
 						<tr>
 						<br>
 							<td style='text-align: center; font-size: 7pt;'>if you did not create an account with us please <a href='#'>contact support</a>.</td>
 						</tr>
                       </table>
                     </td>
                   </tr>
                 </table>
 
               </td>
             </tr>
           </table>
         </td>
 
       </tr>
     </table>
   </center>
   </td>
 </tr>
 </table>
 </body>
 </html>";

            public static string QuotationPending = @"<html>
 <head>
   <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
   <meta name='viewport' content='width=320, initial-scale=1' />
   <style type='text/css' media='screen'>
 
     /* ----- Client Fixes ----- */
 
     /* Force Outlook to provide a 'view in browser' message */
     #outlook a {
       padding: 0;
     }
 
     /* Force Hotmail to display emails at full width */
     .ReadMsgBody {
       width: 100%;
     }	
 
     .ExternalClass {
       width: 100%;
     }
 
     /* Force Hotmail to display normal line spacing */
     .ExternalClass,
     .ExternalClass p,
     .ExternalClass span,
     .ExternalClass font,
     .ExternalClass td,
     .ExternalClass div {
       line-height: 100%;
     }
 
 
      /* Prevent WebKit and Windows mobile changing default text sizes */
     body, table, td, p, a, li, blockquote {
       -webkit-text-size-adjust: 100%;
       -ms-text-size-adjust: 100%;
     }
 
     /* Remove spacing between tables in Outlook 2007 and up */
     table, td {
       mso-table-lspace: 0pt;
       mso-table-rspace: 0pt;
     }
 
     /* Allow smoother rendering of resized image in Internet Explorer */
     img {
       -ms-interpolation-mode: bicubic;
     }
 
      /* ----- Reset ----- */
 
     html,
     body,
     .body-wrap,
     .body-wrap-cell {
       margin: 0;
       padding: 0;
       background: #ffffff;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       text-align: left;
     }
 
     img {
       border: 0;
       line-height: 100%;
       outline: none;
       text-decoration: none;
     }
 
     table {
       border-collapse: collapse !important;
     }
 
     td, th {
       text-align: left;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       line-height:1.5em;
     }
 
     /* ----- General ----- */
 
     h1, h2 {
       line-height: 1.1;
       text-align: right;
     }
 
     h1 {
       margin-top: 0;
       margin-bottom: 10px;
       font-size: 24px;
     }
 
     h2 {
       margin-top: 0;
       margin-bottom: 60px;
       font-weight: normal;
       font-size: 17px;
     }
 
     .outer-padding {
       padding: 50px 0;
     }
 
     .col-1 {
       border-right: 1px solid #D9DADA;
       width: 180px;
     }
 
     td.hide-for-desktop-text {
       font-size: 0;
       height: 0;
       display: none;
       color: #ffffff;
     }
 
     img.hide-for-desktop-image {
       font-size: 0 !important;
       line-height: 0 !important;
       width: 0 !important;
       height: 0 !important;
       display: none !important;
     }
 
     .body-cell {
       background-color: #ffffff;
       padding-top: 60px;
       vertical-align: top;
     }
 
     .body-cell-left-pad {
       padding-left: 30px;
       padding-right: 14px;
     }
 
     /* ----- Modules ----- */
 
     .brand td {
       padding-top: 25px;
     }
 
     .brand a {
       font-size: 16px;
       line-height: 59px;
       font-weight: bold;
     }
 
     .data-table th,
     .data-table td {
       width: 350px;
       padding-top: 5px;
       padding-bottom: 5px;
       padding-left: 5px;
     }
 
     .data-table th {
       background-color: #f9f9f9;
       color: #f8931e;
     }
 
     .data-table td {
       padding-bottom: 30px;
     }
 
     .data-table .data-table-amount {
       font-weight: bold;
       font-size: 20px;
     }
 
 
   </style>
 
   <style type='text/css' media='only screen and (max-width: 650px)'>
     @media only screen and (max-width: 650px) {
       table[class*='w320'] {
         width: 320px !important;
       }
 
       td[class*='col-1'] {
         border: none;
       }
 
       td[class*='hide-for-mobile'] {
         font-size: 0 !important; line-height: 0 !important; width: 0 !important;
         height: 0 !important; display: none !important;
       }
 
       img[class*='hide-for-desktop-image']{
         width: 176px !important;
         height: 135px !important;
         display:block !important;
         padding-left: 60px;
       }
 
       td[class*='hide-for-desktop-image'] {
         width: 100% !important;
         display: block !important;
         text-align: right !important;
       }
 
       td[class*='hide-for-desktop-text'] {
         display: block !important;
         text-align: center !important;
         font-size: 16px !important;
         height: 61px !important;
         padding-top: 30px !important;
         padding-bottom: 20px !important;
         color: #89898D !important;
       }
 
       td[class*='mobile-padding'] {
         padding-top: 15px;
       }
 
       td[class*='outer-padding'] {
         padding: 0 !important;
       }
 
       td[class*='body-cell-left-pad'] {
         padding-left: 20px;
         padding-right: 20px;
       }
     }
 
   </style>
 </head>
 
 <body class='body' style='padding:0; margin:0; display:block; background:#ffffff; -webkit-text-size-adjust:none' bgcolor='#ffffff'>
 <table width='100%' border='0' cellspacing='0' cellpadding='0' bgcolor='#ffffff'>
 <tr>
   <td class='outer-padding' valign='top' align='left'>
   <center>
     <table class='w320' cellspacing='0' cellpadding='0' width='600'>
       <tr>
 
         <td class='col-1 hide-for-mobile'>
 
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='hide-for-mobile' style='text-align: center;'>
                 <img width='50' height='41' src='https://useless-assets.s3.us-east-2.amazonaws.com/uj.jpg' alt='logo' />
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile'  height='150' valign='top' style='text-align: center;'>
                 <b>
                   <span>MCTS</span>
                   </b>
                 <br>
                 <span>University of Johannesburg</span>
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile' style='height:180px; width:299px; text-align: center;'>
                 <img width='auto' height='auto'src='https://useless-assets.s3.us-east-2.amazonaws.com/mtcs.jpg' alt='large logo' />
               </td>
             </tr>
           </table>
         </td>
 
         <td valign='top' class='col-2'>
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='body-cell body-cell-left-pad'>
                 <table cellspacing='0' cellpadding='0' width='100%'>
                   <tr>
                     <td>
 
                       <table cellspacing='0' cellpadding='10' width='100%'>
                         <tr>
                           <td class='mobile-padding'>
                             Dear {company_name},
                           </td>
                         </tr>
                       </table>
 
                       <table cellspacing='0' cellpadding='10' width='100%' >
                         <tr>
                           <td style='text-align: justify;'>
                             Thank you for requesting a quotation with us. Our Employees are currently working very hard to quickly attend to your quote and we will always do our level best to quickly come back to you.
                           </td>
                         </tr>
 						 <tr>
                           <td style='text-align: center; font-size: 9pt;'>
                             <b>Current Quotation Status: {quotationi_status}</b>
                           </td>
                         </tr>
						 <tr>
                           <td style='text-align: justify;'>
                            Please keep on checking your email for the update of you quotation status or alternatively you can create a profile on our online system or mobile application and track the quotation status from there.
                           </td>
                         </tr>
                       </table>
 
                     
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
 						
                       </table>
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
                         <tr>
                           <td class='hide-for-desktop-text'>
                             <b>
                               <span>Metal Casting Technology Systems with University of Johannesburg</span>
                             </b>
                             <br>
                           </td>
                         </tr>
 						<tr>
 						<br>
 							<td style='text-align: center; font-size: 7pt;'>if you did not create an account with us please <a href='#'>contact support</a>.</td>
 						</tr>
                       </table>
                     </td>
                   </tr>
                 </table>
 
               </td>
             </tr>
           </table>
         </td>
 
       </tr>
     </table>
   </center>
   </td>
 </tr>
 </table>
 </body>
 </html>";

            public static string QuotationPendingManagerApproval = @"<html>
 <head>
   <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
   <meta name='viewport' content='width=320, initial-scale=1' />
   <style type='text/css' media='screen'>
 
     /* ----- Client Fixes ----- */
 
     /* Force Outlook to provide a 'view in browser' message */
     #outlook a {
       padding: 0;
     }
 
     /* Force Hotmail to display emails at full width */
     .ReadMsgBody {
       width: 100%;
     }	
 
     .ExternalClass {
       width: 100%;
     }
 
     /* Force Hotmail to display normal line spacing */
     .ExternalClass,
     .ExternalClass p,
     .ExternalClass span,
     .ExternalClass font,
     .ExternalClass td,
     .ExternalClass div {
       line-height: 100%;
     }
 
 
      /* Prevent WebKit and Windows mobile changing default text sizes */
     body, table, td, p, a, li, blockquote {
       -webkit-text-size-adjust: 100%;
       -ms-text-size-adjust: 100%;
     }
 
     /* Remove spacing between tables in Outlook 2007 and up */
     table, td {
       mso-table-lspace: 0pt;
       mso-table-rspace: 0pt;
     }
 
     /* Allow smoother rendering of resized image in Internet Explorer */
     img {
       -ms-interpolation-mode: bicubic;
     }
 
      /* ----- Reset ----- */
 
     html,
     body,
     .body-wrap,
     .body-wrap-cell {
       margin: 0;
       padding: 0;
       background: #ffffff;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       text-align: left;
     }
 
     img {
       border: 0;
       line-height: 100%;
       outline: none;
       text-decoration: none;
     }
 
     table {
       border-collapse: collapse !important;
     }
 
     td, th {
       text-align: left;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       line-height:1.5em;
     }
 
     /* ----- General ----- */
 
     h1, h2 {
       line-height: 1.1;
       text-align: right;
     }
 
     h1 {
       margin-top: 0;
       margin-bottom: 10px;
       font-size: 24px;
     }
 
     h2 {
       margin-top: 0;
       margin-bottom: 60px;
       font-weight: normal;
       font-size: 17px;
     }
 
     .outer-padding {
       padding: 50px 0;
     }
 
     .col-1 {
       border-right: 1px solid #D9DADA;
       width: 180px;
     }
 
     td.hide-for-desktop-text {
       font-size: 0;
       height: 0;
       display: none;
       color: #ffffff;
     }
 
     img.hide-for-desktop-image {
       font-size: 0 !important;
       line-height: 0 !important;
       width: 0 !important;
       height: 0 !important;
       display: none !important;
     }
 
     .body-cell {
       background-color: #ffffff;
       padding-top: 60px;
       vertical-align: top;
     }
 
     .body-cell-left-pad {
       padding-left: 30px;
       padding-right: 14px;
     }
 
     /* ----- Modules ----- */
 
     .brand td {
       padding-top: 25px;
     }
 
     .brand a {
       font-size: 16px;
       line-height: 59px;
       font-weight: bold;
     }
 
     .data-table th,
     .data-table td {
       width: 350px;
       padding-top: 5px;
       padding-bottom: 5px;
       padding-left: 5px;
     }
 
     .data-table th {
       background-color: #f9f9f9;
       color: #f8931e;
     }
 
     .data-table td {
       padding-bottom: 30px;
     }
 
     .data-table .data-table-amount {
       font-weight: bold;
       font-size: 20px;
     }
 
 
   </style>
 
   <style type='text/css' media='only screen and (max-width: 650px)'>
     @media only screen and (max-width: 650px) {
       table[class*='w320'] {
         width: 320px !important;
       }
 
       td[class*='col-1'] {
         border: none;
       }
 
       td[class*='hide-for-mobile'] {
         font-size: 0 !important; line-height: 0 !important; width: 0 !important;
         height: 0 !important; display: none !important;
       }
 
       img[class*='hide-for-desktop-image']{
         width: 176px !important;
         height: 135px !important;
         display:block !important;
         padding-left: 60px;
       }
 
       td[class*='hide-for-desktop-image'] {
         width: 100% !important;
         display: block !important;
         text-align: right !important;
       }
 
       td[class*='hide-for-desktop-text'] {
         display: block !important;
         text-align: center !important;
         font-size: 16px !important;
         height: 61px !important;
         padding-top: 30px !important;
         padding-bottom: 20px !important;
         color: #89898D !important;
       }
 
       td[class*='mobile-padding'] {
         padding-top: 15px;
       }
 
       td[class*='outer-padding'] {
         padding: 0 !important;
       }
 
       td[class*='body-cell-left-pad'] {
         padding-left: 20px;
         padding-right: 20px;
       }
     }
 
   </style>
 </head>
 
 <body class='body' style='padding:0; margin:0; display:block; background:#ffffff; -webkit-text-size-adjust:none' bgcolor='#ffffff'>
 <table width='100%' border='0' cellspacing='0' cellpadding='0' bgcolor='#ffffff'>
 <tr>
   <td class='outer-padding' valign='top' align='left'>
   <center>
     <table class='w320' cellspacing='0' cellpadding='0' width='600'>
       <tr>
 
         <td class='col-1 hide-for-mobile'>
 
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='hide-for-mobile' style='text-align: center;'>
                 <img width='50' height='41' src='https://useless-assets.s3.us-east-2.amazonaws.com/uj.jpg' alt='logo' />
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile'  height='150' valign='top' style='text-align: center;'>
                 <b>
                   <span>MCTS</span>
                   </b>
                 <br>
                 <span>University of Johannesburg</span>
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile' style='height:180px; width:299px; text-align: center;'>
                 <img width='auto' height='auto'src='https://useless-assets.s3.us-east-2.amazonaws.com/mtcs.jpg' alt='large logo' />
               </td>
             </tr>
           </table>
         </td>
 
         <td valign='top' class='col-2'>
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='body-cell body-cell-left-pad'>
                 <table cellspacing='0' cellpadding='0' width='100%'>
                   <tr>
                     <td>
 
                       <table cellspacing='0' cellpadding='10' width='100%'>
                         <tr>
                           <td class='mobile-padding'>
                             Dear {company_name},
                           </td>
                         </tr>
                       </table>
 
                       <table cellspacing='0' cellpadding='10' width='100%' >
                         <tr>
                           <td style='text-align: justify;'>
                            Good News! Your quotation (reference: quotation_reference) is currently being verified by our department managers. Be on alert to hear from us very soon.
                           </td>
                         </tr>
 						 <tr>
                           <td style='text-align: center; font-size: 9pt;'>
                             <b>Current Quotation Status: {quotationi_status}</b>
                           </td>
                         </tr>
                         </tr>
                       </table>
 
                     
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
 						
                       </table>
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
                         <tr>
                           <td class='hide-for-desktop-text'>
                             <b>
                               <span>Metal Casting Technology Systems with University of Johannesburg</span>
                             </b>
                             <br>
                           </td>
                         </tr>
 						<tr>
 						<br>
 							<td style='text-align: center; font-size: 7pt;'>if you did not create an account with us please <a href='#'>contact support</a>.</td>
 						</tr>
                       </table>
                     </td>
                   </tr>
                 </table>
 
               </td>
             </tr>
           </table>
         </td>
 
       </tr>
     </table>
   </center>
   </td>
 </tr>
 </table>
 </body>
 </html>";

            public static string QuotationPendingClientApproval = @"<html>
 <head>
   <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
   <meta name='viewport' content='width=320, initial-scale=1' />
   <style type='text/css' media='screen'>
 
     /* ----- Client Fixes ----- */
 
     /* Force Outlook to provide a 'view in browser' message */
     #outlook a {
       padding: 0;
     }
 
     /* Force Hotmail to display emails at full width */
     .ReadMsgBody {
       width: 100%;
     }	
 
     .ExternalClass {
       width: 100%;
     }
 
     /* Force Hotmail to display normal line spacing */
     .ExternalClass,
     .ExternalClass p,
     .ExternalClass span,
     .ExternalClass font,
     .ExternalClass td,
     .ExternalClass div {
       line-height: 100%;
     }
 
 
      /* Prevent WebKit and Windows mobile changing default text sizes */
     body, table, td, p, a, li, blockquote {
       -webkit-text-size-adjust: 100%;
       -ms-text-size-adjust: 100%;
     }
 
     /* Remove spacing between tables in Outlook 2007 and up */
     table, td {
       mso-table-lspace: 0pt;
       mso-table-rspace: 0pt;
     }
 
     /* Allow smoother rendering of resized image in Internet Explorer */
     img {
       -ms-interpolation-mode: bicubic;
     }
 
      /* ----- Reset ----- */
 
     html,
     body,
     .body-wrap,
     .body-wrap-cell {
       margin: 0;
       padding: 0;
       background: #ffffff;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       text-align: left;
     }
 
     img {
       border: 0;
       line-height: 100%;
       outline: none;
       text-decoration: none;
     }
 
     table {
       border-collapse: collapse !important;
     }
 
     td, th {
       text-align: left;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       line-height:1.5em;
     }
 
     /* ----- General ----- */
 
     h1, h2 {
       line-height: 1.1;
       text-align: right;
     }
 
     h1 {
       margin-top: 0;
       margin-bottom: 10px;
       font-size: 24px;
     }
 
     h2 {
       margin-top: 0;
       margin-bottom: 60px;
       font-weight: normal;
       font-size: 17px;
     }
 
     .outer-padding {
       padding: 50px 0;
     }
 
     .col-1 {
       border-right: 1px solid #D9DADA;
       width: 180px;
     }
 
     td.hide-for-desktop-text {
       font-size: 0;
       height: 0;
       display: none;
       color: #ffffff;
     }
 
     img.hide-for-desktop-image {
       font-size: 0 !important;
       line-height: 0 !important;
       width: 0 !important;
       height: 0 !important;
       display: none !important;
     }
 
     .body-cell {
       background-color: #ffffff;
       padding-top: 60px;
       vertical-align: top;
     }
 
     .body-cell-left-pad {
       padding-left: 30px;
       padding-right: 14px;
     }
 
     /* ----- Modules ----- */
 
     .brand td {
       padding-top: 25px;
     }
 
     .brand a {
       font-size: 16px;
       line-height: 59px;
       font-weight: bold;
     }
 
     .data-table th,
     .data-table td {
       width: 350px;
       padding-top: 5px;
       padding-bottom: 5px;
       padding-left: 5px;
     }
 
     .data-table th {
       background-color: #f9f9f9;
       color: #f8931e;
     }
 
     .data-table td {
       padding-bottom: 30px;
     }
 
     .data-table .data-table-amount {
       font-weight: bold;
       font-size: 20px;
     }
 
 
   </style>
 
   <style type='text/css' media='only screen and (max-width: 650px)'>
     @media only screen and (max-width: 650px) {
       table[class*='w320'] {
         width: 320px !important;
       }
 
       td[class*='col-1'] {
         border: none;
       }
 
       td[class*='hide-for-mobile'] {
         font-size: 0 !important; line-height: 0 !important; width: 0 !important;
         height: 0 !important; display: none !important;
       }
 
       img[class*='hide-for-desktop-image']{
         width: 176px !important;
         height: 135px !important;
         display:block !important;
         padding-left: 60px;
       }
 
       td[class*='hide-for-desktop-image'] {
         width: 100% !important;
         display: block !important;
         text-align: right !important;
       }
 
       td[class*='hide-for-desktop-text'] {
         display: block !important;
         text-align: center !important;
         font-size: 16px !important;
         height: 61px !important;
         padding-top: 30px !important;
         padding-bottom: 20px !important;
         color: #89898D !important;
       }
 
       td[class*='mobile-padding'] {
         padding-top: 15px;
       }
 
       td[class*='outer-padding'] {
         padding: 0 !important;
       }
 
       td[class*='body-cell-left-pad'] {
         padding-left: 20px;
         padding-right: 20px;
       }
     }
 
   </style>
 </head>
 
 <body class='body' style='padding:0; margin:0; display:block; background:#ffffff; -webkit-text-size-adjust:none' bgcolor='#ffffff'>
 <table width='100%' border='0' cellspacing='0' cellpadding='0' bgcolor='#ffffff'>
 <tr>
   <td class='outer-padding' valign='top' align='left'>
   <center>
     <table class='w320' cellspacing='0' cellpadding='0' width='600'>
       <tr>
 
         <td class='col-1 hide-for-mobile'>
 
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='hide-for-mobile' style='text-align: center;'>
                 <img width='50' height='41' src='https://useless-assets.s3.us-east-2.amazonaws.com/uj.jpg' alt='logo' />
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile'  height='150' valign='top' style='text-align: center;'>
                 <b>
                   <span>MCTS</span>
                   </b>
                 <br>
                 <span>University of Johannesburg</span>
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile' style='height:180px; width:299px; text-align: center;'>
                 <img width='auto' height='auto'src='https://useless-assets.s3.us-east-2.amazonaws.com/mtcs.jpg' alt='large logo' />
               </td>
             </tr>
           </table>
         </td>
 
         <td valign='top' class='col-2'>
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='body-cell body-cell-left-pad'>
                 <table cellspacing='0' cellpadding='0' width='100%'>
                   <tr>
                     <td>
 
                       <table cellspacing='0' cellpadding='10' width='100%'>
                         <tr>
                           <td class='mobile-padding'>
                             Dear {company_name},
                           </td>
                         </tr>
                       </table>
 
                       <table cellspacing='0' cellpadding='10' width='100%' >
                         <tr>
                           <td style='text-align: justify;'>
                            The Wait is over! Your quotation (reference: quotation_reference) has been generated. Please login to our online system(mobile app or web system). If you haven't created an account yet please register with the same email you used to request the quotation. As we wait to get your response! :)
                           </td>
                         </tr>
 						 <tr>
                           <td style='text-align: center; font-size: 9pt;'>
                             <b>Current Quotation Status: {quotationi_status}</b>
                           </td>
                         </tr>
                         </tr>
                       </table>
 
                     
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
 						
                       </table>
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
                         <tr>
                           <td class='hide-for-desktop-text'>
                             <b>
                               <span>Metal Casting Technology Systems with University of Johannesburg</span>
                             </b>
                             <br>
                           </td>
                         </tr>
 						<tr>
 						<br>
 							<td style='text-align: center; font-size: 7pt;'>if you did not create an account with us please <a href='#'>contact support</a>.</td>
 						</tr>
                       </table>
                     </td>
                   </tr>
                 </table>
 
               </td>
             </tr>
           </table>
         </td>
 
       </tr>
     </table>
   </center>
   </td>
 </tr>
 </table>
 </body>
 </html>";

            public static string QuotationAccepted = @"<html>
 <head>
   <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
   <meta name='viewport' content='width=320, initial-scale=1' />
   <style type='text/css' media='screen'>
 
     /* ----- Client Fixes ----- */
 
     /* Force Outlook to provide a 'view in browser' message */
     #outlook a {
       padding: 0;
     }
 
     /* Force Hotmail to display emails at full width */
     .ReadMsgBody {
       width: 100%;
     }	
 
     .ExternalClass {
       width: 100%;
     }
 
     /* Force Hotmail to display normal line spacing */
     .ExternalClass,
     .ExternalClass p,
     .ExternalClass span,
     .ExternalClass font,
     .ExternalClass td,
     .ExternalClass div {
       line-height: 100%;
     }
 
 
      /* Prevent WebKit and Windows mobile changing default text sizes */
     body, table, td, p, a, li, blockquote {
       -webkit-text-size-adjust: 100%;
       -ms-text-size-adjust: 100%;
     }
 
     /* Remove spacing between tables in Outlook 2007 and up */
     table, td {
       mso-table-lspace: 0pt;
       mso-table-rspace: 0pt;
     }
 
     /* Allow smoother rendering of resized image in Internet Explorer */
     img {
       -ms-interpolation-mode: bicubic;
     }
 
      /* ----- Reset ----- */
 
     html,
     body,
     .body-wrap,
     .body-wrap-cell {
       margin: 0;
       padding: 0;
       background: #ffffff;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       text-align: left;
     }
 
     img {
       border: 0;
       line-height: 100%;
       outline: none;
       text-decoration: none;
     }
 
     table {
       border-collapse: collapse !important;
     }
 
     td, th {
       text-align: left;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       line-height:1.5em;
     }
 
     /* ----- General ----- */
 
     h1, h2 {
       line-height: 1.1;
       text-align: right;
     }
 
     h1 {
       margin-top: 0;
       margin-bottom: 10px;
       font-size: 24px;
     }
 
     h2 {
       margin-top: 0;
       margin-bottom: 60px;
       font-weight: normal;
       font-size: 17px;
     }
 
     .outer-padding {
       padding: 50px 0;
     }
 
     .col-1 {
       border-right: 1px solid #D9DADA;
       width: 180px;
     }
 
     td.hide-for-desktop-text {
       font-size: 0;
       height: 0;
       display: none;
       color: #ffffff;
     }
 
     img.hide-for-desktop-image {
       font-size: 0 !important;
       line-height: 0 !important;
       width: 0 !important;
       height: 0 !important;
       display: none !important;
     }
 
     .body-cell {
       background-color: #ffffff;
       padding-top: 60px;
       vertical-align: top;
     }
 
     .body-cell-left-pad {
       padding-left: 30px;
       padding-right: 14px;
     }
 
     /* ----- Modules ----- */
 
     .brand td {
       padding-top: 25px;
     }
 
     .brand a {
       font-size: 16px;
       line-height: 59px;
       font-weight: bold;
     }
 
     .data-table th,
     .data-table td {
       width: 350px;
       padding-top: 5px;
       padding-bottom: 5px;
       padding-left: 5px;
     }
 
     .data-table th {
       background-color: #f9f9f9;
       color: #f8931e;
     }
 
     .data-table td {
       padding-bottom: 30px;
     }
 
     .data-table .data-table-amount {
       font-weight: bold;
       font-size: 20px;
     }
 
 
   </style>
 
   <style type='text/css' media='only screen and (max-width: 650px)'>
     @media only screen and (max-width: 650px) {
       table[class*='w320'] {
         width: 320px !important;
       }
 
       td[class*='col-1'] {
         border: none;
       }
 
       td[class*='hide-for-mobile'] {
         font-size: 0 !important; line-height: 0 !important; width: 0 !important;
         height: 0 !important; display: none !important;
       }
 
       img[class*='hide-for-desktop-image']{
         width: 176px !important;
         height: 135px !important;
         display:block !important;
         padding-left: 60px;
       }
 
       td[class*='hide-for-desktop-image'] {
         width: 100% !important;
         display: block !important;
         text-align: right !important;
       }
 
       td[class*='hide-for-desktop-text'] {
         display: block !important;
         text-align: center !important;
         font-size: 16px !important;
         height: 61px !important;
         padding-top: 30px !important;
         padding-bottom: 20px !important;
         color: #89898D !important;
       }
 
       td[class*='mobile-padding'] {
         padding-top: 15px;
       }
 
       td[class*='outer-padding'] {
         padding: 0 !important;
       }
 
       td[class*='body-cell-left-pad'] {
         padding-left: 20px;
         padding-right: 20px;
       }
     }
 
   </style>
 </head>
 
 <body class='body' style='padding:0; margin:0; display:block; background:#ffffff; -webkit-text-size-adjust:none' bgcolor='#ffffff'>
 <table width='100%' border='0' cellspacing='0' cellpadding='0' bgcolor='#ffffff'>
 <tr>
   <td class='outer-padding' valign='top' align='left'>
   <center>
     <table class='w320' cellspacing='0' cellpadding='0' width='600'>
       <tr>
 
         <td class='col-1 hide-for-mobile'>
 
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='hide-for-mobile' style='text-align: center;'>
                 <img width='50' height='41' src='https://useless-assets.s3.us-east-2.amazonaws.com/uj.jpg' alt='logo' />
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile'  height='150' valign='top' style='text-align: center;'>
                 <b>
                   <span>MCTS</span>
                   </b>
                 <br>
                 <span>University of Johannesburg</span>
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile' style='height:180px; width:299px; text-align: center;'>
                 <img width='auto' height='auto'src='https://useless-assets.s3.us-east-2.amazonaws.com/mtcs.jpg' alt='large logo' />
               </td>
             </tr>
           </table>
         </td>
 
         <td valign='top' class='col-2'>
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='body-cell body-cell-left-pad'>
                 <table cellspacing='0' cellpadding='0' width='100%'>
                   <tr>
                     <td>
 
                       <table cellspacing='0' cellpadding='10' width='100%'>
                         <tr>
                           <td class='mobile-padding'>
                             Dear {company_name},
                           </td>
                         </tr>
                       </table>
 
                       <table cellspacing='0' cellpadding='10' width='100%' >
                         <tr>
                           <td style='text-align: justify;'>
                             We are pleased that we have managed to reach your expectations. It is going to be an exciting journey. Feel free to explore other options on our system such as project tracking, invoice, chats with project leaders, online payments and many more.
                           </td>
                         </tr>
 
                     
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
 						
                       </table>
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
                         <tr>
                           <td class='hide-for-desktop-text'>
                             <b>
                               <span>Metal Casting Technology Systems with University of Johannesburg</span>
                             </b>
                             <br>
                           </td>
                         </tr>
 						<tr>
 						<br>
 							<td style='text-align: center; font-size: 7pt;'>if you did not create an account with us please <a href='#'>contact support</a>.</td>
 						</tr>
                       </table>
                     </td>
                   </tr>
                 </table>
 
               </td>
             </tr>
           </table>
         </td>
 
       </tr>
     </table>
   </center>
   </td>
 </tr>
 </table>
 </body>
 </html>";

            public static string QuoatationRejected = @"<html>
 <head>
   <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
   <meta name='viewport' content='width=320, initial-scale=1' />
   <style type='text/css' media='screen'>
 
     /* ----- Client Fixes ----- */
 
     /* Force Outlook to provide a 'view in browser' message */
     #outlook a {
       padding: 0;
     }
 
     /* Force Hotmail to display emails at full width */
     .ReadMsgBody {
       width: 100%;
     }	
 
     .ExternalClass {
       width: 100%;
     }
 
     /* Force Hotmail to display normal line spacing */
     .ExternalClass,
     .ExternalClass p,
     .ExternalClass span,
     .ExternalClass font,
     .ExternalClass td,
     .ExternalClass div {
       line-height: 100%;
     }
 
 
      /* Prevent WebKit and Windows mobile changing default text sizes */
     body, table, td, p, a, li, blockquote {
       -webkit-text-size-adjust: 100%;
       -ms-text-size-adjust: 100%;
     }
 
     /* Remove spacing between tables in Outlook 2007 and up */
     table, td {
       mso-table-lspace: 0pt;
       mso-table-rspace: 0pt;
     }
 
     /* Allow smoother rendering of resized image in Internet Explorer */
     img {
       -ms-interpolation-mode: bicubic;
     }
 
      /* ----- Reset ----- */
 
     html,
     body,
     .body-wrap,
     .body-wrap-cell {
       margin: 0;
       padding: 0;
       background: #ffffff;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       text-align: left;
     }
 
     img {
       border: 0;
       line-height: 100%;
       outline: none;
       text-decoration: none;
     }
 
     table {
       border-collapse: collapse !important;
     }
 
     td, th {
       text-align: left;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       line-height:1.5em;
     }
 
     /* ----- General ----- */
 
     h1, h2 {
       line-height: 1.1;
       text-align: right;
     }
 
     h1 {
       margin-top: 0;
       margin-bottom: 10px;
       font-size: 24px;
     }
 
     h2 {
       margin-top: 0;
       margin-bottom: 60px;
       font-weight: normal;
       font-size: 17px;
     }
 
     .outer-padding {
       padding: 50px 0;
     }
 
     .col-1 {
       border-right: 1px solid #D9DADA;
       width: 180px;
     }
 
     td.hide-for-desktop-text {
       font-size: 0;
       height: 0;
       display: none;
       color: #ffffff;
     }
 
     img.hide-for-desktop-image {
       font-size: 0 !important;
       line-height: 0 !important;
       width: 0 !important;
       height: 0 !important;
       display: none !important;
     }
 
     .body-cell {
       background-color: #ffffff;
       padding-top: 60px;
       vertical-align: top;
     }
 
     .body-cell-left-pad {
       padding-left: 30px;
       padding-right: 14px;
     }
 
     /* ----- Modules ----- */
 
     .brand td {
       padding-top: 25px;
     }
 
     .brand a {
       font-size: 16px;
       line-height: 59px;
       font-weight: bold;
     }
 
     .data-table th,
     .data-table td {
       width: 350px;
       padding-top: 5px;
       padding-bottom: 5px;
       padding-left: 5px;
     }
 
     .data-table th {
       background-color: #f9f9f9;
       color: #f8931e;
     }
 
     .data-table td {
       padding-bottom: 30px;
     }
 
     .data-table .data-table-amount {
       font-weight: bold;
       font-size: 20px;
     }
 
 
   </style>
 
   <style type='text/css' media='only screen and (max-width: 650px)'>
     @media only screen and (max-width: 650px) {
       table[class*='w320'] {
         width: 320px !important;
       }
 
       td[class*='col-1'] {
         border: none;
       }
 
       td[class*='hide-for-mobile'] {
         font-size: 0 !important; line-height: 0 !important; width: 0 !important;
         height: 0 !important; display: none !important;
       }
 
       img[class*='hide-for-desktop-image']{
         width: 176px !important;
         height: 135px !important;
         display:block !important;
         padding-left: 60px;
       }
 
       td[class*='hide-for-desktop-image'] {
         width: 100% !important;
         display: block !important;
         text-align: right !important;
       }
 
       td[class*='hide-for-desktop-text'] {
         display: block !important;
         text-align: center !important;
         font-size: 16px !important;
         height: 61px !important;
         padding-top: 30px !important;
         padding-bottom: 20px !important;
         color: #89898D !important;
       }
 
       td[class*='mobile-padding'] {
         padding-top: 15px;
       }
 
       td[class*='outer-padding'] {
         padding: 0 !important;
       }
 
       td[class*='body-cell-left-pad'] {
         padding-left: 20px;
         padding-right: 20px;
       }
     }
 
   </style>
 </head>
 
 <body class='body' style='padding:0; margin:0; display:block; background:#ffffff; -webkit-text-size-adjust:none' bgcolor='#ffffff'>
 <table width='100%' border='0' cellspacing='0' cellpadding='0' bgcolor='#ffffff'>
 <tr>
   <td class='outer-padding' valign='top' align='left'>
   <center>
     <table class='w320' cellspacing='0' cellpadding='0' width='600'>
       <tr>
 
         <td class='col-1 hide-for-mobile'>
 
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='hide-for-mobile' style='text-align: center;'>
                 <img width='50' height='41' src='https://useless-assets.s3.us-east-2.amazonaws.com/uj.jpg' alt='logo' />
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile'  height='150' valign='top' style='text-align: center;'>
                 <b>
                   <span>MCTS</span>
                   </b>
                 <br>
                 <span>University of Johannesburg</span>
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile' style='height:180px; width:299px; text-align: center;'>
                 <img width='auto' height='auto'src='https://useless-assets.s3.us-east-2.amazonaws.com/mtcs.jpg' alt='large logo' />
               </td>
             </tr>
           </table>
         </td>
 
         <td valign='top' class='col-2'>
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='body-cell body-cell-left-pad'>
                 <table cellspacing='0' cellpadding='0' width='100%'>
                   <tr>
                     <td>
 
                       <table cellspacing='0' cellpadding='10' width='100%'>
                         <tr>
                           <td class='mobile-padding'>
                             Dear {company_name},
                           </td>
                         </tr>
                       </table>
 
                       <table cellspacing='0' cellpadding='10' width='100%' >
                         <tr>
                           <td style='text-align: justify;'>
                             We are sad to see that we couldn't meet your expectations. We highly value our client's opinion and we would like to find out where we went wrong. Our staff will get back to you and see if we cant make you an offer which you would be pleased with.
                           </td>
                         </tr>
 
                     
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
 						
                       </table>
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
                         <tr>
                           <td class='hide-for-desktop-text'>
                             <b>
                               <span>Metal Casting Technology Systems with University of Johannesburg</span>
                             </b>
                             <br>
                           </td>
                         </tr>
 						<tr>
 						<br>
 							<td style='text-align: center; font-size: 7pt;'>if you did not create an account with us please <a href='#'>contact support</a>.</td>
 						</tr>
                       </table>
                     </td>
                   </tr>
                 </table>
 
               </td>
             </tr>
           </table>
         </td>
 
       </tr>
     </table>
   </center>
   </td>
 </tr>
 </table>
 </body>
 </html>";

            public static string GenericEmail = @"<html>
 <head>
   <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
   <meta name='viewport' content='width=320, initial-scale=1' />
   <style type='text/css' media='screen'>
 
     /* ----- Client Fixes ----- */
 
     /* Force Outlook to provide a 'view in browser' message */
     #outlook a {
       padding: 0;
     }
 
     /* Force Hotmail to display emails at full width */
     .ReadMsgBody {
       width: 100%;
     }	
 
     .ExternalClass {
       width: 100%;
     }
 
     /* Force Hotmail to display normal line spacing */
     .ExternalClass,
     .ExternalClass p,
     .ExternalClass span,
     .ExternalClass font,
     .ExternalClass td,
     .ExternalClass div {
       line-height: 100%;
     }
 
 
      /* Prevent WebKit and Windows mobile changing default text sizes */
     body, table, td, p, a, li, blockquote {
       -webkit-text-size-adjust: 100%;
       -ms-text-size-adjust: 100%;
     }
 
     /* Remove spacing between tables in Outlook 2007 and up */
     table, td {
       mso-table-lspace: 0pt;
       mso-table-rspace: 0pt;
     }
 
     /* Allow smoother rendering of resized image in Internet Explorer */
     img {
       -ms-interpolation-mode: bicubic;
     }
 
      /* ----- Reset ----- */
 
     html,
     body,
     .body-wrap,
     .body-wrap-cell {
       margin: 0;
       padding: 0;
       background: #ffffff;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       text-align: left;
     }
 
     img {
       border: 0;
       line-height: 100%;
       outline: none;
       text-decoration: none;
     }
 
     table {
       border-collapse: collapse !important;
     }
 
     td, th {
       text-align: left;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       line-height:1.5em;
     }
 
     /* ----- General ----- */
 
     h1, h2 {
       line-height: 1.1;
       text-align: right;
     }
 
     h1 {
       margin-top: 0;
       margin-bottom: 10px;
       font-size: 24px;
     }
 
     h2 {
       margin-top: 0;
       margin-bottom: 60px;
       font-weight: normal;
       font-size: 17px;
     }
 
     .outer-padding {
       padding: 50px 0;
     }
 
     .col-1 {
       border-right: 1px solid #D9DADA;
       width: 180px;
     }
 
     td.hide-for-desktop-text {
       font-size: 0;
       height: 0;
       display: none;
       color: #ffffff;
     }
 
     img.hide-for-desktop-image {
       font-size: 0 !important;
       line-height: 0 !important;
       width: 0 !important;
       height: 0 !important;
       display: none !important;
     }
 
     .body-cell {
       background-color: #ffffff;
       padding-top: 60px;
       vertical-align: top;
     }
 
     .body-cell-left-pad {
       padding-left: 30px;
       padding-right: 14px;
     }
 
     /* ----- Modules ----- */
 
     .brand td {
       padding-top: 25px;
     }
 
     .brand a {
       font-size: 16px;
       line-height: 59px;
       font-weight: bold;
     }
 
     .data-table th,
     .data-table td {
       width: 350px;
       padding-top: 5px;
       padding-bottom: 5px;
       padding-left: 5px;
     }
 
     .data-table th {
       background-color: #f9f9f9;
       color: #f8931e;
     }
 
     .data-table td {
       padding-bottom: 30px;
     }
 
     .data-table .data-table-amount {
       font-weight: bold;
       font-size: 20px;
     }
 
 
   </style>
 
   <style type='text/css' media='only screen and (max-width: 650px)'>
     @media only screen and (max-width: 650px) {
       table[class*='w320'] {
         width: 320px !important;
       }
 
       td[class*='col-1'] {
         border: none;
       }
 
       td[class*='hide-for-mobile'] {
         font-size: 0 !important; line-height: 0 !important; width: 0 !important;
         height: 0 !important; display: none !important;
       }
 
       img[class*='hide-for-desktop-image']{
         width: 176px !important;
         height: 135px !important;
         display:block !important;
         padding-left: 60px;
       }
 
       td[class*='hide-for-desktop-image'] {
         width: 100% !important;
         display: block !important;
         text-align: right !important;
       }
 
       td[class*='hide-for-desktop-text'] {
         display: block !important;
         text-align: center !important;
         font-size: 16px !important;
         height: 61px !important;
         padding-top: 30px !important;
         padding-bottom: 20px !important;
         color: #89898D !important;
       }
 
       td[class*='mobile-padding'] {
         padding-top: 15px;
       }
 
       td[class*='outer-padding'] {
         padding: 0 !important;
       }
 
       td[class*='body-cell-left-pad'] {
         padding-left: 20px;
         padding-right: 20px;
       }
     }
 
   </style>
 </head>
 
 <body class='body' style='padding:0; margin:0; display:block; background:#ffffff; -webkit-text-size-adjust:none' bgcolor='#ffffff'>
 <table width='100%' border='0' cellspacing='0' cellpadding='0' bgcolor='#ffffff'>
 <tr>
   <td class='outer-padding' valign='top' align='left'>
   <center>
     <table class='w320' cellspacing='0' cellpadding='0' width='600'>
       <tr>
 
         <td class='col-1 hide-for-mobile'>
 
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='hide-for-mobile' style='text-align: center;'>
                 <img width='50' height='41' src='https://useless-assets.s3.us-east-2.amazonaws.com/uj.jpg' alt='logo' />
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile'  height='150' valign='top' style='text-align: center;'>
                 <b>
                   <span>MCTS</span>
                   </b>
                 <br>
                 <span>University of Johannesburg</span>
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile' style='height:180px; width:299px; text-align: center;'>
                 <img width='auto' height='auto'src='https://useless-assets.s3.us-east-2.amazonaws.com/mtcs.jpg' alt='large logo' />
               </td>
             </tr>
           </table>
         </td>
 
         <td valign='top' class='col-2'>
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='body-cell body-cell-left-pad'>
                 <table cellspacing='0' cellpadding='0' width='100%'>
                   <tr>
                     <td>
 
                       
 
                       <table cellspacing='0' cellpadding='10' width='100%' >
                         <tr>
                           <td style='text-align: justify;'>
                             {body} 
                           </td>
                         </tr>
                       </table>
 
                     
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
                         <tr>
                           <td style='text-align:center;padding-top:30px;'>
                             <img src='https://www.filepicker.io/api/file/F7k2y1vcTu2AVmcPTkPJ' alt='signature' />
                           </td>
                         </tr>
 						
                       </table>
 
                       
                     </td>
                   </tr>
                 </table>
 
               </td>
             </tr>
           </table>
         </td>
 
       </tr>
     </table>
   </center>
   </td>
 </tr>
 </table>
 </body>
 </html>";

            public static string PaymentConfirmation = @"<html>
 <head>
   <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
   <meta name='viewport' content='width=320, initial-scale=1' />
   <style type='text/css' media='screen'>
 
     /* ----- Client Fixes ----- */
 
     /* Force Outlook to provide a 'view in browser' message */
     #outlook a {
       padding: 0;
     }
 
     /* Force Hotmail to display emails at full width */
     .ReadMsgBody {
       width: 100%;
     }	
 
     .ExternalClass {
       width: 100%;
     }
 
     /* Force Hotmail to display normal line spacing */
     .ExternalClass,
     .ExternalClass p,
     .ExternalClass span,
     .ExternalClass font,
     .ExternalClass td,
     .ExternalClass div {
       line-height: 100%;
     }
 
 
      /* Prevent WebKit and Windows mobile changing default text sizes */
     body, table, td, p, a, li, blockquote {
       -webkit-text-size-adjust: 100%;
       -ms-text-size-adjust: 100%;
     }
 
     /* Remove spacing between tables in Outlook 2007 and up */
     table, td {
       mso-table-lspace: 0pt;
       mso-table-rspace: 0pt;
     }
 
     /* Allow smoother rendering of resized image in Internet Explorer */
     img {
       -ms-interpolation-mode: bicubic;
     }
 
      /* ----- Reset ----- */
 
     html,
     body,
     .body-wrap,
     .body-wrap-cell {
       margin: 0;
       padding: 0;
       background: #ffffff;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       text-align: left;
     }
 
     img {
       border: 0;
       line-height: 100%;
       outline: none;
       text-decoration: none;
     }
 
     table {
       border-collapse: collapse !important;
     }
 
     td, th {
       text-align: left;
       font-family: Arial, Helvetica, sans-serif;
       font-size: 16px;
       color: #89898D;
       line-height:1.5em;
     }
 
     /* ----- General ----- */
 
     h1, h2 {
       line-height: 1.1;
       text-align: right;
     }
 
     h1 {
       margin-top: 0;
       margin-bottom: 10px;
       font-size: 24px;
     }
 
     h2 {
       margin-top: 0;
       margin-bottom: 60px;
       font-weight: normal;
       font-size: 17px;
     }
 
     .outer-padding {
       padding: 50px 0;
     }
 
     .col-1 {
       border-right: 1px solid #D9DADA;
       width: 180px;
     }
 
     td.hide-for-desktop-text {
       font-size: 0;
       height: 0;
       display: none;
       color: #ffffff;
     }
 
     img.hide-for-desktop-image {
       font-size: 0 !important;
       line-height: 0 !important;
       width: 0 !important;
       height: 0 !important;
       display: none !important;
     }
 
     .body-cell {
       background-color: #ffffff;
       padding-top: 60px;
       vertical-align: top;
     }
 
     .body-cell-left-pad {
       padding-left: 30px;
       padding-right: 14px;
     }
 
     /* ----- Modules ----- */
 
     .brand td {
       padding-top: 25px;
     }
 
     .brand a {
       font-size: 16px;
       line-height: 59px;
       font-weight: bold;
     }
 
     .data-table th,
     .data-table td {
       width: 350px;
       padding-top: 5px;
       padding-bottom: 5px;
       padding-left: 5px;
     }
 
     .data-table th {
       background-color: #f9f9f9;
       color: #f8931e;
     }
 
     .data-table td {
       padding-bottom: 30px;
     }
 
     .data-table .data-table-amount {
       font-weight: bold;
       font-size: 20px;
     }
 
 
   </style>
 
   <style type='text/css' media='only screen and (max-width: 650px)'>
     @media only screen and (max-width: 650px) {
       table[class*='w320'] {
         width: 320px !important;
       }
 
       td[class*='col-1'] {
         border: none;
       }
 
       td[class*='hide-for-mobile'] {
         font-size: 0 !important; line-height: 0 !important; width: 0 !important;
         height: 0 !important; display: none !important;
       }
 
       img[class*='hide-for-desktop-image']{
         width: 176px !important;
         height: 135px !important;
         display:block !important;
         padding-left: 60px;
       }
 
       td[class*='hide-for-desktop-image'] {
         width: 100% !important;
         display: block !important;
         text-align: right !important;
       }
 
       td[class*='hide-for-desktop-text'] {
         display: block !important;
         text-align: center !important;
         font-size: 16px !important;
         height: 61px !important;
         padding-top: 30px !important;
         padding-bottom: 20px !important;
         color: #89898D !important;
       }
 
       td[class*='mobile-padding'] {
         padding-top: 15px;
       }
 
       td[class*='outer-padding'] {
         padding: 0 !important;
       }
 
       td[class*='body-cell-left-pad'] {
         padding-left: 20px;
         padding-right: 20px;
       }
     }
 
   </style>
 </head>
 
 <body class='body' style='padding:0; margin:0; display:block; background:#ffffff; -webkit-text-size-adjust:none' bgcolor='#ffffff'>
 <table width='100%' border='0' cellspacing='0' cellpadding='0' bgcolor='#ffffff'>
 <tr>
   <td class='outer-padding' valign='top' align='left'>
   <center>
     <table class='w320' cellspacing='0' cellpadding='0' width='600'>
       <tr>
 
         <td class='col-1 hide-for-mobile'>
 
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='hide-for-mobile' style='text-align: center;'>
                 <img width='50' height='41' src='https://useless-assets.s3.us-east-2.amazonaws.com/uj.jpg' alt='logo' />
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile'  height='150' valign='top' style='text-align: center;'>
                 <b>
                   <span>MCTS</span>
                   </b>
                 <br>
                 <span>University of Johannesburg</span>
               </td>
             </tr>
 
             <tr>
               <td class='hide-for-mobile' style='height:180px; width:299px; text-align: center;'>
                 <img width='auto' height='auto'src='https://useless-assets.s3.us-east-2.amazonaws.com/mtcs.jpg' alt='large logo' />
               </td>
             </tr>
           </table>
         </td>
 
         <td valign='top' class='col-2'>
           <table cellspacing='0' cellpadding='0' width='100%'>
             <tr>
               <td class='body-cell body-cell-left-pad'>
                 <table cellspacing='0' cellpadding='0' width='100%'>
                   <tr>
                     <td>
 
                       <table cellspacing='0' cellpadding='10' width='100%'>
                         <tr>
                           <td class='mobile-padding'>
                             Dear {company_name},
                           </td>
                         </tr>
                       </table>
 
                       <table cellspacing='0' cellpadding='10' width='100%' >
                         <tr>
                           <td style='text-align: justify;'>
                             We are pleased to confirm that we have recieved you payment for invoice {invoiceReference}. Please log in the mcts system to view any amount due.
                           </td>
                         </tr>
 
                     
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
 						
                       </table>
 
                       <table cellspacing='0' cellpadding='0' width='100%'>
                         <tr>
                           <td class='hide-for-desktop-text'>
                             <b>
                               <span>Metal Casting Technology Systems with University of Johannesburg</span>
                             </b>
                             <br>
                           </td>
                         </tr>
 						<tr>
 						<br>
 							<td style='text-align: center; font-size: 7pt;'>if you did not create an account with us please <a href='#'>contact support</a>.</td>
 						</tr>
                       </table>
                     </td>
                   </tr>
                 </table>
 
               </td>
             </tr>
           </table>
         </td>
 
       </tr>
     </table>
   </center>
   </td>
 </tr>
 </table>
 </body>
 </html>";
        }
    }

    
}
