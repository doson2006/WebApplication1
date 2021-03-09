using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
    public class OracleDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseOracle(
                "DATA SOURCE=127.0.0.1:1521/orcl;USER ID= basemanage ;PASSWORD=basemanage001;"
                , b => b.UseOracleSQLCompatibility("11"));   //指定数据库版本


            //配置Sql输出控制台
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EFLoggerProvider());
            optionsBuilder.UseLoggerFactory(loggerFactory);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("SYS_DEPARTMENT");
                //entity.Property(e => e.Id).UseHiLo("SEQ_SYSUSER");
                entity.Property(e => e.Id).UseIdentityColumn();
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.ToTable("SYS_USER");
                //entity.Property(e => e.Id).UseHiLo("SEQ_SYSUSER");
                entity.Property(e => e.UserId).UseIdentityColumn();
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Department> Department { get; set; }

        public DbSet<SysUser> SysUser { get; set; }
    }
}
