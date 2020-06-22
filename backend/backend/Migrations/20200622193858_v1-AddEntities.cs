using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class v1AddEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "equipment_utilization",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment_utilization", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "focus_area",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_focus_area", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "foundry_tech_equipment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foundry_tech_equipment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "moulding_tech_equipment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moulding_tech_equipment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "physical_metallurgy_equipment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_physical_metallurgy_equipment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_expectation",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_expectation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "socio_economic_impact",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socio_economic_impact", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "support_equipment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_support_equipment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tech_station_service",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tech_station_service", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "access_levels",
                columns: new[] { "id", "level" },
                values: new object[,]
                {
                    { 3, "Client" },
                    { 1, "Admin" },
                    { 2, "Employee" }
                });

            migrationBuilder.InsertData(
                table: "email_templates",
                columns: new[] { "id", "code", "email_type" },
                values: new object[,]
                {
                    { 1, @"<html>
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
                 </html>", "Forgot Password" },
                    { 3, @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>
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
                 </html>", "ResetPassword" },
                    { 2, @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>
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
                  </html>", "Registration" }
                });

            migrationBuilder.InsertData(
                table: "focus_area",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 2, "Moulding Tech" },
                    { 3, "Foundry Tech" },
                    { 4, "Support" },
                    { 5, "Other" },
                    { 1, "Physical Metallurgy" }
                });

            migrationBuilder.InsertData(
                table: "foundry_tech_equipment",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 6, "Click To Cast" },
                    { 7, "Non Testing Act(Ftec)" },
                    { 4, "ALIA" },
                    { 3, "AutoD" },
                    { 2, "MDX" },
                    { 1, "ProE" },
                    { 5, "3DP" }
                });

            migrationBuilder.InsertData(
                table: "moulding_tech_equipment",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 30, "Full Resin Sand Aval" },
                    { 24, "Sieve Ana" },
                    { 25, "Grain Sha" },
                    { 26, "Sintering" },
                    { 27, "ADV" },
                    { 28, "Core Preparation" },
                    { 29, "Full Green Sand Anal" },
                    { 31, "Full Bentonite Anal" },
                    { 38, "Sample Preparation" },
                    { 33, "Core Making" },
                    { 34, "Calibration" },
                    { 35, "Mould Coating " },
                    { 36, "Oolitization" },
                    { 37, "TGA Analysis" },
                    { 23, "XRD Sand" },
                    { 39, "Total Gas Evolution" },
                    { 32, "Full Ref San Anal" },
                    { 22, "XRF" },
                    { 20, "CEC" },
                    { 7, "Shatter In" },
                    { 1, "Green Stren" },
                    { 2, "Dry Stren" },
                    { 3, "Friability" },
                    { 4, "Permeab" },
                    { 5, "Green Shea" },
                    { 6, "Dry Shea" },
                    { 21, "PH" },
                    { 8, "Wet Ten" },
                    { 10, "Compress" },
                    { 9, "Compact" },
                    { 12, "Voliti" },
                    { 13, "Activ C" },
                    { 14, "Clay Wash" },
                    { 15, "LOl" },
                    { 16, "Tensile" },
                    { 17, "Transv Stre" },
                    { 18, "Swe Ind" },
                    { 19, "Visco" },
                    { 11, "Moisture" }
                });

            migrationBuilder.InsertData(
                table: "physical_metallurgy_equipment",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 15, "SEM" },
                    { 14, "XRD" },
                    { 16, "Mill&M" },
                    { 13, "Lecco" },
                    { 18, "XRF" },
                    { 19, "Non Testing Act (Phys)" },
                    { 17, "Stereo" },
                    { 12, "Spectro" },
                    { 3, "Rockewell" },
                    { 10, "Ind Furn" },
                    { 2, "Micr Vick" },
                    { 11, "Metallog" },
                    { 4, "Brinell" },
                    { 5, "Charpy" },
                    { 1, "Macr Vick" },
                    { 7, "HT Fur 1" },
                    { 6, "Tensile" },
                    { 9, "AI Furn" },
                    { 8, "HT Fur Big" }
                });

            migrationBuilder.InsertData(
                table: "product_expectation",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "SABS Approval" },
                    { 2, "Quality Standards" },
                    { 3, "Compliance" },
                    { 4, "Competitive" },
                    { 5, "Green Technology " },
                    { 6, "Other" }
                });

            migrationBuilder.InsertData(
                table: "socio_economic_impact",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 8, "Other" },
                    { 7, "Cofference/ Journal Article" },
                    { 4, "Job Created/ Secured " },
                    { 5, "Productivity/ Increase in turnover" },
                    { 3, "Export Facilitated" },
                    { 2, "New Markets or Larger Markets" },
                    { 1, "Productivity/ Increase in turnover " },
                    { 6, "Youth Development" }
                });

            migrationBuilder.InsertData(
                table: "support_equipment",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 9, "Lazer Cutter" },
                    { 11, "Non Testing Act (Sup)" },
                    { 10, "Design Software" },
                    { 8, "SLP / Tail Dem4" },
                    { 4, "Host Interns" },
                    { 6, "SLP / Tail Dem2" },
                    { 5, "SLP / Tail Dem1" },
                    { 3, "Valcanizer" },
                    { 2, "Ind Coil Furn" },
                    { 7, "SLP / Tail Dem3" },
                    { 1, "Spin Cast" }
                });

            migrationBuilder.InsertData(
                table: "tech_station_service",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Testing & Analysis" },
                    { 2, "Prototyping & Manufacturing" },
                    { 3, "Consultation / Technology Audit" },
                    { 4, "Product and Process Development" },
                    { 5, "Research and Development" },
                    { 6, "Technology Demonstration / Transfer" },
                    { 7, "Knowledge Transfer / SLP" },
                    { 8, "Investigative Project (Failure /  Defect)" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipment_utilization");

            migrationBuilder.DropTable(
                name: "focus_area");

            migrationBuilder.DropTable(
                name: "foundry_tech_equipment");

            migrationBuilder.DropTable(
                name: "moulding_tech_equipment");

            migrationBuilder.DropTable(
                name: "physical_metallurgy_equipment");

            migrationBuilder.DropTable(
                name: "product_expectation");

            migrationBuilder.DropTable(
                name: "socio_economic_impact");

            migrationBuilder.DropTable(
                name: "support_equipment");

            migrationBuilder.DropTable(
                name: "tech_station_service");

            migrationBuilder.DeleteData(
                table: "access_levels",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "access_levels",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "access_levels",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "email_templates",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "email_templates",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "email_templates",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
