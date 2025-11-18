using System;
using System.Collections.Generic;

namespace AntiaApp.Domain.Entities;

public partial class Log
{
    public int Id { get; set; }

    public string Level { get; set; } = null!;

    public string MehodName { get; set; } = null!;

    public string ClassName { get; set; } = null!;

    public string? Message { get; set; }

    public string? StackTrace { get; set; }

    public string? Data { get; set; }
}
