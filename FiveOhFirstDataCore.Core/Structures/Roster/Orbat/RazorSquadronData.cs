﻿using FiveOhFirstDataCore.Data.Account;

namespace FiveOhFirstDataCore.Data.Structures.Roster
{
    public class RazorSquadronData : IAssignable<Trooper>
    {
        public Trooper Commander { get; set; }
        public Trooper SubCommander { get; set; }
        public RazorFlightData[] Flights { get; set; } = new RazorFlightData[] { new(), new(), new(), new() };

        public void Assign(Trooper t)
        {
            var val = (int)t.Slot % 10;
            if (val == 0)
            {
                switch (t.Role)
                {
                    case Role.Commander:
                        Commander = t;
                        break;
                    case Role.SubCommander:
                        SubCommander = t;
                        break;
                }
            }
            else if (val >= 1 && val <= Flights.Length)
            {
                Flights[val - 1].Assign(t);
            }
        }
    }
}
