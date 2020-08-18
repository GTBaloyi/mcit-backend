using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class mctsdbupdatev10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "access_levels",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    level = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_access_levels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "broader_mcts_rates",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    time_study_per_test = table.Column<double>(nullable: false),
                    rate_per_hour = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_broader_mcts_rates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    registration_number = table.Column<string>(nullable: true),
                    company_profile = table.Column<string>(nullable: true),
                    isCompanyPresent = table.Column<bool>(nullable: false),
                    quarter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "company_representative",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    company_fk = table.Column<int>(nullable: false),
                    date_captured = table.Column<DateTime>(nullable: false),
                    avatar_path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company_representative", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "email_templates",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(nullable: true),
                    email_type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email_templates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    employee_number = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    position_fk = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    cell = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    created_on = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employees_position",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees_position", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "enquiry",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    focus_area_fk = table.Column<int>(nullable: false),
                    enquiry_date = table.Column<DateTime>(nullable: false),
                    quarter = table.Column<string>(nullable: true),
                    company = table.Column<string>(nullable: true),
                    company_registration_number = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    service_tech_fk = table.Column<int>(nullable: false),
                    socio_economic_impact_fk = table.Column<int>(nullable: false),
                    product_expectation_fk = table.Column<int>(nullable: false),
                    project_budget = table.Column<double>(nullable: false),
                    expected_completion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enquiry", x => x.id);
                });

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
                name: "invoice",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    reference = table.Column<string>(nullable: true),
                    invoice_date = table.Column<DateTime>(nullable: false),
                    date_due = table.Column<DateTime>(nullable: false),
                    quotation_reference = table.Column<string>(nullable: true),
                    vat_number = table.Column<double>(nullable: false),
                    bill_address = table.Column<string>(nullable: true),
                    vat = table.Column<double>(nullable: false),
                    subtotal = table.Column<double>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    total_due = table.Column<double>(nullable: false),
                    company_registration = table.Column<string>(nullable: true),
                    generatedBy = table.Column<string>(nullable: true),
                    approvedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice", x => x.id);
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
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    time_study_per_test = table.Column<double>(nullable: false),
                    rate_per_hour = table.Column<double>(nullable: false),
                    focus_area_fk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quotation",
                columns: table => new
                {
                    Quote_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quote_reference = table.Column<string>(nullable: true),
                    Date_generated = table.Column<DateTime>(nullable: false),
                    Quote_expiryDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Company_name = table.Column<string>(nullable: true),
                    Bill_address = table.Column<string>(nullable: true),
                    Phone_Number = table.Column<string>(nullable: true),
                    Grand_total = table.Column<double>(nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotation", x => x.Quote_id);
                });

            migrationBuilder.CreateTable(
                name: "quotation_item",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FocusArea = table.Column<string>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Unit_Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    quote_reference = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotation_item", x => x.id);
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

            migrationBuilder.CreateTable(
                name: "terms_and_conditions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_terms_and_conditions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_status",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    username = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: true),
                    retry = table.Column<int>(nullable: false),
                    user_status_fk = table.Column<int>(nullable: false),
                    access_fk = table.Column<int>(nullable: false),
                    company_rep_fk = table.Column<int>(nullable: false),
                    last_login = table.Column<DateTime>(nullable: false),
                    otp = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.username);
                });

            migrationBuilder.InsertData(
                table: "access_levels",
                columns: new[] { "id", "level" },
                values: new object[,]
                {
                    { 2, "Employee" },
                    { 1, "Admin" },
                    { 3, "Client" }
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
                  </html>", "Registration" },
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
                    { 4, @"<html>
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
                 </html>", "Employee Registration" },
                    { 5, @"<html>
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
                 </html>", "QuotationPending" },
                    { 6, @"<html>
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
                 </html>", "QuotationPendingManagerApproval" },
                    { 7, @"<html>
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
                 </html>", "QuotationClientApproval" },
                    { 8, @"<html>
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
                 </html>", "QuotationApproved" },
                    { 9, @"<html>
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
                 </html>", "QuotationRejected" }
                });

            migrationBuilder.InsertData(
                table: "employees_position",
                columns: new[] { "id", "position" },
                values: new object[,]
                {
                    { 3, "Manager" },
                    { 2, "General Staff" },
                    { 1, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "focus_area",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 2, "Moulding Tech" },
                    { 3, "Foundry Tech" },
                    { 4, "SupportEquipment" },
                    { 5, "Support" },
                    { 6, "Other" },
                    { 7, "BroaderMCTSRates" },
                    { 1, "Physical Metallurgy" }
                });

            migrationBuilder.InsertData(
                table: "product_expectation",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 6, "Other" },
                    { 5, "Green Technology " },
                    { 4, "Competitive" },
                    { 3, "Compliance" },
                    { 2, "Quality Standards" },
                    { 1, "SABS Approval" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "focus_area_fk", "name", "rate_per_hour", "time_study_per_test" },
                values: new object[,]
                {
                    { 63, 2, "TGA Analysis", 21.0, 120.0 },
                    { 62, 2, "Oolitization", 300.0, 60.0 },
                    { 61, 2, "Mould Coating", 400.0, 60.0 },
                    { 60, 2, "Calibration", 400.0, 60.0 },
                    { 59, 2, "Core Making", 400.0, 260.0 },
                    { 58, 2, "Full Ref San Anal", 400.0, 1720.0 },
                    { 57, 2, "Full Bentonite Anal", 400.0, 1240.0 },
                    { 56, 2, "Full Resin Sand Aval", 400.0, 480.0 },
                    { 54, 2, "Core Preparation", 42.0, 20.0 },
                    { 64, 2, "Sample Preparation", 84.0, 180.0 },
                    { 53, 2, "ADV", 41.840000000000003, 180.0 },
                    { 52, 2, "Sintering", 72.319999999999993, 480.0 },
                    { 51, 2, "Grain Sha", 14.779999999999999, 60.0 },
                    { 50, 2, "Sieve Ana", 27.66, 60.0 },
                    { 49, 2, "XRD Sand", 66.510000000000005, 180.0 },
                    { 48, 2, "XRF", 66.510000000000005, 180.0 },
                    { 47, 2, "PH", 47.229999999999997, 120.0 },
                    { 55, 2, "Full Green Sand Anal", 400.0, 2270.0 },
                    { 65, 2, "Total Gas Evolution", 600.0, 120.0 },
                    { 79, 1, "Lecco", 200.0, 80.0 },
                    { 67, 1, "Macr Vick", 75.0, 15.0 },
                    { 85, 1, "Non Testing Act (Phys)", 953.29999999999995, 60.0 },
                    { 84, 1, "XRF", 500.0, 60.0 },
                    { 83, 1, "Stereo", 80.0, 30.0 },
                    { 82, 1, "Mill&M", 250.0, 60.0 },
                    { 81, 1, "SEM", 250.0, 60.0 },
                    { 80, 1, "XRD", 500.0, 60.0 },
                    { 46, 2, "CEC", 47.229999999999997, 120.0 },
                    { 78, 1, "Spectro", 200.0, 60.0 },
                    { 66, 2, "Non Testing Act", 1233.6400000000001, 60.0 },
                    { 77, 1, "Metallog", 400.0, 80.0 },
                    { 75, 1, "AI Furn", 118.75, 60.0 },
                    { 74, 1, "HT Fur Big", 118.75, 60.0 },
                    { 73, 1, "HT Fur 1", 118.75, 60.0 },
                    { 72, 1, "Tensile", 450.0, 80.0 },
                    { 71, 1, "Charpy", 490.0, 80.0 },
                    { 70, 1, "Brinell", 75.0, 60.0 },
                    { 69, 1, "Rockewell", 75.0, 15.0 },
                    { 68, 1, "Micr Vick", 75.0, 15.0 },
                    { 76, 1, "Ind Furn", 400.0, 60.0 },
                    { 45, 2, "Visco", 27.629999999999999, 60.0 },
                    { 42, 2, "Tensile", 179.0, 120.0 },
                    { 43, 2, "Transv Stre", 179.0, 120.0 },
                    { 19, 7, "Testing & Analysis", 224.38, 0.0 },
                    { 18, 4, "Non Testing Act (Sup)", 687.73000000000002, 60.0 },
                    { 17, 4, "Design Software", 50.0, 60.0 },
                    { 16, 4, "Lazer Cutter", 20.0, 60.0 },
                    { 15, 4, "SLP / Tail Dem4", 0.0, 0.0 },
                    { 14, 4, "SLP / Tail Dem3", 0.0, 0.0 },
                    { 13, 4, "SLP / Tail Dem2", 0.0, 0.0 },
                    { 44, 2, "Swe Ind", 47.229999999999997, 120.0 },
                    { 11, 4, "Host Interns", 0.0, 60.0 },
                    { 10, 4, "Valcanizer", 250.0, 60.0 },
                    { 9, 4, "Ind Coil Furn", 250.0, 60.0 },
                    { 8, 4, "Spin Cast", 250.0, 60.0 },
                    { 7, 3, "Non Testing Act(Ftec)", 772.32000000000005, 60.0 },
                    { 6, 3, "Click To Cast", 550.0, 60.0 },
                    { 5, 3, "3DP", 550.0, 60.0 },
                    { 4, 3, "ALIA", 937.5, 9600.0 },
                    { 3, 3, "AutoD", 550.0, 60.0 },
                    { 2, 3, "MDX", 550.0, 60.0 },
                    { 1, 3, "ProE", 550.0, 60.0 },
                    { 20, 7, "Prototyping & Manufacturing", 800.0, 0.0 },
                    { 21, 7, "Consult / Technology Audit", 500.0, 0.0 },
                    { 12, 4, "SLP / Tail Dem1", 18.199999999999999, 1.0 },
                    { 23, 7, "Research and Development", 800.0, 0.0 },
                    { 22, 7, "Product and Process Development", 800.0, 0.0 },
                    { 40, 2, "Clay Wash", 32.0, 180.0 },
                    { 41, 2, "LOl", 28.0, 160.0 },
                    { 39, 2, "Activ C", 18.0, 90.0 },
                    { 38, 2, "Voliti", 28.0, 160.0 },
                    { 37, 2, "Moisture", 42.0, 240.0 },
                    { 36, 2, "Compress", 21.0, 120.0 },
                    { 35, 2, "Compact", 21.0, 120.0 },
                    { 34, 2, "Wet Ten", 21.0, 120.0 },
                    { 33, 2, "Shatter In", 21.0, 120.0 },
                    { 32, 2, "Dry Shea", 42.0, 240.0 },
                    { 31, 2, "Green Shea", 21.0, 120.0 },
                    { 30, 2, "Permeab", 21.0, 120.0 },
                    { 29, 2, "Friability", 21.0, 120.0 },
                    { 28, 2, "Dry Stren", 42.0, 240.0 },
                    { 27, 2, "Green Stren", 21.0, 120.0 },
                    { 26, 7, "Investigative Projects (Failure / Defect)", 0.0, 0.0 },
                    { 25, 7, "Knowledge Transfer / SLP", 250.0, 0.0 },
                    { 24, 7, "Technology Demonstration / Transfer", 800.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "socio_economic_impact",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 8, "Other" },
                    { 7, "Cofference/ Journal Article" },
                    { 3, "Export Facilitated" },
                    { 5, "Productivity/ Increase in turnover" },
                    { 4, "Job Created/ Secured " },
                    { 1, "Productivity/ Increase in turnover " },
                    { 2, "New Markets or Larger Markets" },
                    { 6, "Youth Development" }
                });

            migrationBuilder.InsertData(
                table: "tech_station_service",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 8, "Investigative Project (Failure /  Defect)" },
                    { 6, "Technology Demonstration / Transfer" },
                    { 7, "Knowledge Transfer / SLP" },
                    { 4, "Product and Process Development" },
                    { 3, "Consultation / Technology Audit" },
                    { 2, "Prototyping & Manufacturing" },
                    { 1, "Testing & Analysis" },
                    { 5, "Research and Development" }
                });

            migrationBuilder.InsertData(
                table: "user_status",
                columns: new[] { "id", "status" },
                values: new object[,]
                {
                    { 3, "Suspended" },
                    { 1, "Active" },
                    { 2, "InActive" },
                    { 4, "Deactivated" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "access_levels");

            migrationBuilder.DropTable(
                name: "broader_mcts_rates");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "company_representative");

            migrationBuilder.DropTable(
                name: "email_templates");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "employees_position");

            migrationBuilder.DropTable(
                name: "enquiry");

            migrationBuilder.DropTable(
                name: "equipment_utilization");

            migrationBuilder.DropTable(
                name: "focus_area");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "product_expectation");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "quotation");

            migrationBuilder.DropTable(
                name: "quotation_item");

            migrationBuilder.DropTable(
                name: "socio_economic_impact");

            migrationBuilder.DropTable(
                name: "tech_station_service");

            migrationBuilder.DropTable(
                name: "terms_and_conditions");

            migrationBuilder.DropTable(
                name: "user_status");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
