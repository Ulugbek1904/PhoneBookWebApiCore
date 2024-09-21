using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NPOI.SS.Formula.Functions;
using STX.EFxceptions.SqlServer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBookWebApiCore.Brokers.StorageBrokers
{
    public partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private IConfiguration configuration;
        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }

        public async Task<T> InsertAsync<T>(T entity) where T : class
        {
            await this.Set<T>().AddAsync(entity);
            await this.SaveChangesAsync();

            return entity;
        }

        public async Task<List<T>> SelectAllAsync<T>() where T : class
        {
            return await this.Set<T>().ToListAsync();
        }

        public async Task<T> SelectByIdAsync<T>(Guid itemGuid) where T : class
        {
            return await this.Set<T>().FindAsync(itemGuid);
        }

        public async Task<T> UpdateAsync<T>(T entity) where T : class
        {
            this.Set<T>().Update(entity);
            await this.SaveChangesAsync();

            return entity;
        }

        public async Task<T> DeleteAsync<T>(T entity) where T : class
        {
            this.Set<T>().Remove(entity);
            await this.SaveChangesAsync();

            return entity;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConnectionString = this.configuration.GetConnectionString("DefaultConnectionString");
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
