using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductWebAPI.Models;

namespace ProductWebAPI.Data
{
    public class Productdbcontext: DbContext 
    {
        public Productdbcontext(DbContextOptions<Productdbcontext>options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
