using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SeniorLibrary.Models;
using Microsoft.AspNetCore.Identity;

namespace SeniorLibrary.Data
{
    public class SeniorLibraryContext : IdentityDbContext
    {
        public SeniorLibraryContext (
            DbContextOptions<SeniorLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<SeniorLibrary.Models.Entrying> Entrying { get; set; }
    }

}
