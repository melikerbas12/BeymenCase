using BeymenCase.ConfLib.Context;
using BeymenCase.Core.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BeymenCase.ConfLib.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private ConfigurationDbContext _context;
        public ConfigurationRepository(string connectionString)
        {
            _context = new ConfigurationDbContext(connectionString);
        }

        public async Task<Setting> GetByApplicationName(string applicationName, string key)
        {
            return await _context.Settings.
                          Where(s => s.ApplicationName == applicationName && s.IsActive && s.Name == key)
                         .FirstOrDefaultAsync();
        }

        public async Task<IList<Setting>> Get(string applicationName)
        {
           return await _context.Settings
                        .Where(s => s.ApplicationName == applicationName && s.IsActive)
                        .ToListAsync();
        }
    }
}