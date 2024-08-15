using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FakeStore.Models;

namespace FakeStore.Data
{
    public class FakeStoreContext : DbContext
    {
        public FakeStoreContext (DbContextOptions<FakeStoreContext> options)
            : base(options)
        {
        }

        public DbSet<FakeStore.Models.Product> Product { get; set; } = default!;
    }
}
