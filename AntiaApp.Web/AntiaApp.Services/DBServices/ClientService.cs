using AntiaApp.Data.Entities;
using AntiaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiaApp.Services.DBServices;

public class ClientService(AntiaAppDbContext _dbContext) : IClientService
{
    public async Task<bool> Add(Client client)
    {
        client.DateCreation = DateTime.UtcNow;
        await _dbContext.Clients.AddAsync(client);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Client site)
    {
        _dbContext.Clients.Remove(site);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Client>> GetAll() => await _dbContext.Clients.Include(x=>x.Site).ToListAsync();


    public async Task<Client> GetById(int id) => await _dbContext.Clients.Include(x=>x.Site).FirstOrDefaultAsync(x=>x.Id == id);

    public bool Exists(int id) => _dbContext.Clients.Any(e => e.Id == id);



    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    public async Task<bool> Update(Client client)
    {
        client.DateModification = DateTime.UtcNow;
        _dbContext.Clients.Update(client);
        return await _dbContext.SaveChangesAsync() > 0;
    }
}
