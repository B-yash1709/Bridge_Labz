using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Context
{
    public class HelloAppContext : DbContext

    {
        public HelloAppContext(DbContextOptions<HelloAppContext> options) : base(options)
        {
            
        }
        public virtual DbSet<UserEntity> Users { get; set; }
    }
}
