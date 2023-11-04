using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using proyecto_final_webconfig.Data;
using proyecto_final_webconfig.Models.Entities;
using System;

namespace proyecto_final_webconfig.Repository
{
    public class StatsRepository : IStatsRepository
    {
        private readonly EspressoContext espressoContext;

        public StatsRepository(EspressoContext espressoContext)
        {
            this.espressoContext = espressoContext;
        }

        public Stats GetStatistics()
        {
            var data = new Stats();

            data.UsersConnected = espressoContext.Devices.Count(d => d.LastUpDetected >= DateTime.Now.AddMinutes(-1));
            data.RecentIncidents = espressoContext.Events.Count(e => e.Timestamp >= DateTime.Now.AddMinutes(-1));
            data.ReconnectionIncidents = espressoContext.Events.Count(e => e.IdTypeDetection == 6);

            data.CantLowSeverity = espressoContext.Events.Include(e => e.TypeDetection).Count(e => e.TypeDetection.Severity == 0);
            data.CantMediumSeverity = espressoContext.Events.Include(e => e.TypeDetection).Count(e => e.TypeDetection.Severity == 1);
            data.CantHighSeverity = espressoContext.Events.Include(e => e.TypeDetection).Count(e => e.TypeDetection.Severity >= 2);

            data.Uptime = espressoContext.Events.OrderByDescending(e => e.Timestamp).First().Timestamp.ToShortTimeString();

            data.CantSmallIncidents = espressoContext.Events.Count(e => e.CantPacketsDetect <= 50);
            data.CantMediumIncidents = espressoContext.Events.Count(e => e.CantPacketsDetect > 50 && e.CantPacketsDetect <= 300);
            data.CantBigIncidents = espressoContext.Events.Count(e => e.CantPacketsDetect > 300);

            return data;
        }


    }
}
