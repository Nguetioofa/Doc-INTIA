using AntiaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiaApp.Services.DBServices;

public interface IClientService
{
    Task<bool> Add(Client site);
    Task<bool> Update(Client site);
    Task<bool> Delete(Client site);
    Task<Client> GetById(int id);
    Task<IEnumerable<Client>> GetAll();
    Task<int> SaveChangesAsync();
    bool Exists(int id);
}
