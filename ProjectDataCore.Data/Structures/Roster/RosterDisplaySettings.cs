﻿using ProjectDataCore.Data.Structures.Page.Components;
using ProjectDataCore.Data.Structures.Policy;

using System;
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
    public RosterTree HostRoster { get; set; }
    public Guid HostRosterId { get; set; }

    public List<RosterComponentSettings> DisplayComponents { get; set; } = new();
    public List<EditableComponentSettings> EditableComponentsAllowedEditors { get; set; } = new();

    public List<DynamicAuthorizationPolicy> DynamicPolicies { get; set; } = new();
}