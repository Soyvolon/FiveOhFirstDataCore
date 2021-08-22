﻿using FiveOhFirstDataCore.Core.Account;

using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveOhFirstDataCore.Pages.Misc
{
    public partial class ChangeRequestData
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Parameter]
        public TrooperChangeRequestData Model { get; set; }

        [Parameter]
        public Trooper User { get; set; }

        [Parameter]
        public bool LockEdit { get; set; } = false;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
