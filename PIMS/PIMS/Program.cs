using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIMS.Data;
using PIMS.Models;

namespace PIMS
{
    public class Program
    {
        public static void Main(string[] args)
        {   using (var db = new RoleContext())
            {
                var user = new RoleMod {ID = 1, Email = "demo@gmail.com", Role = 1 };
                db.Roles.Add(user);
                db.SaveChanges();
            }
                CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
