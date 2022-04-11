#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndroidCA2Backend;

namespace AndroidCA2Backend.Data
{
    public class AndroidCA2BackendContext : DbContext
    {
        public AndroidCA2BackendContext (DbContextOptions<AndroidCA2BackendContext> options)
            : base(options)
        {
        }

        public DbSet<AndroidCA2Backend.Games> Games { get; set; }

        public DbSet<AndroidCA2Backend.Console> Console { get; set; }
    }
}
