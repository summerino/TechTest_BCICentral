using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechTest_BCICentral.Models;

namespace TechTest_BCICentral.Data
{
    public class TechTest_BCICentralContext : DbContext
    {
        public TechTest_BCICentralContext (DbContextOptions<TechTest_BCICentralContext> options)
            : base(options)
        {
        }

        public DbSet<TechTest_BCICentral.Models.ConstructionProject> ConstructionProject { get; set; } = default!;
    }
}
