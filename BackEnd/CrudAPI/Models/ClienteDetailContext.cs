using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Models
{
    public class ClienteDetailContext : DbContext
    {
        public ClienteDetailContext(DbContextOptions<ClienteDetailContext> options) : base(options)
        {

        }

        public DbSet<ClienteDetail> ClienteDetails { get; set; }

    }
}
