using AntiaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiaApp.Services.DBServices;

public interface ISiteService
{
    Task<bool> Add(Site site);
    Task<bool> Update(Site site);
    Task<bool> Delete(Site site);
    Task<Site> GetById(int id);
    Task<IEnumerable<Site>> GetAll();
    Task<int> SaveChangesAsync();
    bool Exists(int id);
}
