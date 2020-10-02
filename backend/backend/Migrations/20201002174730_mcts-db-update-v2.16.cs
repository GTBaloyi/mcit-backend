using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class mctsdbupdatev216 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "approved_by",
                table: "payments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "payments",
                nullable: true);

            migrationBuilder.InsertData(
                table: "email_templates",
                columns: new[] { "id", "code", "email_type" },
                values: new object[] { 11, @"<html>
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
 </html>", "PaymentConfirmation" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "email_templates",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DropColumn(
                name: "approved_by",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "status",
                table: "payments");
        }
    }
}
