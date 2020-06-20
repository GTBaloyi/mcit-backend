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
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
