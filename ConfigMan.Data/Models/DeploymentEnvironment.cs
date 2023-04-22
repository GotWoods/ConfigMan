﻿using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfigMan.Data.Models;

public class DeploymentEnvironment
{
    public string Name { get; set; } = string.Empty;

    public int Order { get; set; }

    [Column(TypeName = "jsonb")]
    public List<Setting>? Settings { get; set; }
    
}

