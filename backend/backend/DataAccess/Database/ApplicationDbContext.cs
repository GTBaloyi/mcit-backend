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
        public DbSet<EmailTemplateEntity> emailTemplate { get; set; }
        public DbSet<InvoiceEntity> invoice { get; set; }
        public DbSet<EquipmentUtilizationEntity> equipmentUtilization { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserStatusEntity>().HasData(
                    new UserStatusEntity() {id =1, status = "Active"},
                    new UserStatusEntity() {id = 2, status = "InActive"},
                    new UserStatusEntity() {id = 3, status = "Suspended"},
                    new UserStatusEntity() {id = 4, status = "Deactivated"}
                );

            modelBuilder.Entity<AccessLevelEntity>().HasData(
                    new AccessLevelEntity() {id=1, level = "Admin" },
                    new AccessLevelEntity() { id = 2, level = "Employee" },
                    new AccessLevelEntity() { id = 3, level = "Client" }
                );

            modelBuilder.Entity<EmailTemplateEntity>().HasData(
                    new EmailTemplateEntity() { id = 1, code = EmailTemplate.ForgotPassword, email_type="Forgot Password"},
                    new EmailTemplateEntity() { id = 2, code = EmailTemplate.Registration, email_type = "Registration"},
                    new EmailTemplateEntity() { id = 3, code = EmailTemplate.ResetPassword, email_type = "ResetPassword"}
                );

            modelBuilder.Entity<FocusAreaEntity>().HasData(
                    new FocusAreaEntity() { id = 1, name = "Physical Metallurgy"},
                    new FocusAreaEntity() { id = 2, name = "Moulding Tech" },
                    new FocusAreaEntity() { id = 3, name = "Foundry Tech" },
                    new FocusAreaEntity() { id = 4, name = "Support" },
                    new FocusAreaEntity() { id = 5, name = "Other"}
                );

            modelBuilder.Entity<ProductExpectation>().HasData(
                    new ProductExpectation() { id = 1, name = "SABS Approval" },
                    new ProductExpectation() { id = 2, name = "Quality Standards" },
                    new ProductExpectation() { id = 3, name = "Compliance" },
                    new ProductExpectation() { id = 4, name = "Competitive" },
                    new ProductExpectation() { id = 5, name = "Green Technology " },
                    new ProductExpectation() { id = 6, name = "Other" }
                );

            modelBuilder.Entity<FoundryTechEquipmentEntity>().HasData(
                    new FoundryTechEquipmentEntity() { id = 1, name = "ProE" },
                    new FoundryTechEquipmentEntity() { id = 2, name = "MDX" },
                    new FoundryTechEquipmentEntity() { id = 3, name = "AutoD" },
                    new FoundryTechEquipmentEntity() { id = 4, name = "ALIA" },
                    new FoundryTechEquipmentEntity() { id = 5, name = "3DP" },
                    new FoundryTechEquipmentEntity() { id = 6, name = "Click To Cast" },
                    new FoundryTechEquipmentEntity() { id = 7, name = "Non Testing Act(Ftec)" }                
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

            modelBuilder.Entity<SupportEquipmentEntity>().HasData(
                   new SupportEquipmentEntity() { id = 1, name = "Spin Cast" },
                   new SupportEquipmentEntity() { id = 2, name = "Ind Coil Furn" },
                   new SupportEquipmentEntity() { id = 3, name = "Valcanizer" },
                   new SupportEquipmentEntity() { id = 4, name = "Host Interns" },
                   new SupportEquipmentEntity() { id = 5, name = "SLP / Tail Dem1" },
                   new SupportEquipmentEntity() { id = 6, name = "SLP / Tail Dem2" },
                   new SupportEquipmentEntity() { id = 7, name = "SLP / Tail Dem3" },
                   new SupportEquipmentEntity() { id = 8, name = "SLP / Tail Dem4" },
                   new SupportEquipmentEntity() { id = 9, name = "Lazer Cutter" },
                   new SupportEquipmentEntity() { id = 10, name = "Design Software" },
                   new SupportEquipmentEntity() { id = 11, name = "Non Testing Act (Sup)" }
                );

            modelBuilder.Entity<MouldingTechEquipmentEntity>().HasData(
                   new MouldingTechEquipmentEntity() { id = 1, name = "Green Stren" },
                   new MouldingTechEquipmentEntity() { id = 2, name = "Dry Stren" },
                   new MouldingTechEquipmentEntity() { id = 3, name = "Friability" },
                   new MouldingTechEquipmentEntity() { id = 4, name = "Permeab" },
                   new MouldingTechEquipmentEntity() { id = 5, name = "Green Shea" },
                   new MouldingTechEquipmentEntity() { id = 6, name = "Dry Shea" },
                   new MouldingTechEquipmentEntity() { id = 7, name = "Shatter In" },
                   new MouldingTechEquipmentEntity() { id = 8, name = "Wet Ten" },
                   new MouldingTechEquipmentEntity() { id = 9, name = "Compact" },
                   new MouldingTechEquipmentEntity() { id = 10, name = "Compress" },
                   new MouldingTechEquipmentEntity() { id = 11, name = "Moisture" },
                   new MouldingTechEquipmentEntity() { id = 12, name = "Voliti" },
                   new MouldingTechEquipmentEntity() { id = 13, name = "Activ C" },
                   new MouldingTechEquipmentEntity() { id = 14, name = "Clay Wash" },
                   new MouldingTechEquipmentEntity() { id = 15, name = "LOl" },
                   new MouldingTechEquipmentEntity() { id = 16, name = "Tensile" },
                   new MouldingTechEquipmentEntity() { id = 17, name = "Transv Stre" },
                   new MouldingTechEquipmentEntity() { id = 18, name = "Swe Ind" },
                   new MouldingTechEquipmentEntity() { id = 19, name = "Visco" },
                   new MouldingTechEquipmentEntity() { id = 20, name = "CEC" },
                   new MouldingTechEquipmentEntity() { id = 21, name = "PH" },
                   new MouldingTechEquipmentEntity() { id = 22, name = "XRF" },
                   new MouldingTechEquipmentEntity() { id = 23, name = "XRD Sand" },
                   new MouldingTechEquipmentEntity() { id = 24, name = "Sieve Ana" },
                   new MouldingTechEquipmentEntity() { id = 25, name = "Grain Sha" }, 
                   new MouldingTechEquipmentEntity() { id = 26, name = "Sintering" },
                   new MouldingTechEquipmentEntity() { id = 27, name = "ADV" },
                   new MouldingTechEquipmentEntity() { id = 28, name = "Core Preparation" },
                   new MouldingTechEquipmentEntity() { id = 29, name = "Full Green Sand Anal" },
                   new MouldingTechEquipmentEntity() { id = 30, name = "Full Resin Sand Aval" },
                   new MouldingTechEquipmentEntity() { id = 31, name = "Full Bentonite Anal" },
                   new MouldingTechEquipmentEntity() { id = 32, name = "Full Ref San Anal" },
                   new MouldingTechEquipmentEntity() { id = 33, name = "Core Making" },
                   new MouldingTechEquipmentEntity() { id = 34, name = "Calibration" },
                   new MouldingTechEquipmentEntity() { id = 35, name = "Mould Coating " },
                   new MouldingTechEquipmentEntity() { id = 36, name = "Oolitization" },
                   new MouldingTechEquipmentEntity() { id = 37, name = "TGA Analysis" },
                   new MouldingTechEquipmentEntity() { id = 38, name = "Sample Preparation" },
                   new MouldingTechEquipmentEntity() { id = 39, name = "Total Gas Evolution" }
                );

            modelBuilder.Entity<PhysicalMetallurgyEquipmentEntity>().HasData(
                   new PhysicalMetallurgyEquipmentEntity() { id = 1, name = "Macr Vick" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 2, name = "Micr Vick" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 3, name = "Rockewell" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 4, name = "Brinell" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 5, name = "Charpy" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 6, name = "Tensile" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 7, name = "HT Fur 1" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 8, name = "HT Fur Big" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 9, name = "AI Furn" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 10, name = "Ind Furn" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 11, name = "Metallog" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 12, name = "Spectro" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 13, name = "Lecco" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 14, name = "XRD" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 15, name = "SEM" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 16, name = "Mill&M" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 17, name = "Stereo" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 18, name = "XRF" },
                   new PhysicalMetallurgyEquipmentEntity() { id = 19, name = "Non Testing Act (Phys)" }
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
        }
    }

    
}
