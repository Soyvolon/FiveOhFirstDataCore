﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDataCore.Data.Structures.Roster;

/// <summary>
/// Holds settings for a roster display.
/// </summary>
public class RosterDisplaySettings : DataObject<Guid>
{
    public string Name { get; set; }
    public bool Whitelist { get; set; } = true;
    public List<Guid> TreeKeys { get; set; } = new();

}
