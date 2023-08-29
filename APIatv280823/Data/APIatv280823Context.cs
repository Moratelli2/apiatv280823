using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIatv280823.Models;

namespace APIatv280823.Data
{
    public class APIatv280823Context : DbContext
    {
        public APIatv280823Context (DbContextOptions<APIatv280823Context> options)
            : base(options)
        {
        }

        public DbSet<APIatv280823.Models.Equacao> Equacao { get; set; } = default!;
    }
}
