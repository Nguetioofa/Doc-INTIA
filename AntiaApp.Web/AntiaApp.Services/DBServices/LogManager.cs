using AntiaApp.Data.Entities;
using AntiaApp.Domain.Entities;
using AntiaApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AntiaApp.Services.DBServices;

public class LogManager(AntiaAppDbContext _dbContext)
{

    public void Info(string message, string className, string mehodName, object data = null)
    {
        Add(new Log
        {
            Level = LogLevel.Info.ToString(),
            ClassName = className,
            MehodName = mehodName,
            Message = message,
            Data = JsonSerializer.Serialize(data)
        });
    }


    public void Warn(string message, string className, string mehodName, object data = null)
    {
        Add(new Log
        {
            Level = LogLevel.Warn.ToString(),
            ClassName = className,
            MehodName = mehodName,
            Message = message,
            Data = JsonSerializer.Serialize(data)
        });
    }


    public void Error(string message, string className, string mehodName, object data = null)
    {
        Add(new Log
        {
            Level = LogLevel.Error.ToString(),
            ClassName = className,
            MehodName = mehodName,
            Message = message,
            Data = JsonSerializer.Serialize(data)
        });
    }

    public void Critical(string message, string className, string mehodName,string stackTrace, object data = null)
    {
        Add(new Log
        {
            Level = LogLevel.Critical.ToString(),
            ClassName = className,
            MehodName = mehodName,
            Message = message,
            StackTrace = stackTrace,
            Data = JsonSerializer.Serialize(data)
        });
    }

    private bool Add(Log site)
    {
         _dbContext.Logs.Add(site);
        return _dbContext.SaveChanges() > 0;
    }



    public async Task<IEnumerable<Log>> GetAll() => await _dbContext.Logs.ToListAsync();

}
