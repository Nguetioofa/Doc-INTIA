using AntiaApp.Data.Entities;
using AntiaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiaApp.Services.DBServices;

public class SiteService(AntiaAppDbContext _dbContext) : ISiteService
{
    public async Task<bool> Add(Site site)
    {
        await _dbContext.Sites.AddAsync(site);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Site site)
    {
        _dbContext.Sites.Remove(site);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Site>> GetAll() => await _dbContext.Sites.ToListAsync();


    public async Task<Site> GetById(int id) => await _dbContext.Sites.FindAsync(id);

    public bool Exists(int id) => _dbContext.Sites.Any(e => e.Id == id);

   

    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    public async Task<bool> Update(Site site)
    {
        _dbContext.Sites.Update(site);
        return await _dbContext.SaveChangesAsync() > 0;
    }
}
