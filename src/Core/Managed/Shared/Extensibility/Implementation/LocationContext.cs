﻿namespace Microsoft.ApplicationInsights.Extensibility.Implementation
{
    using System.Collections.Generic;
    using Microsoft.ApplicationInsights.DataContracts;
    using Microsoft.ApplicationInsights.Extensibility.Implementation.External;

    /// <summary>
    /// Encapsulates telemetry location information.
    /// </summary>
    public sealed class LocationContext
    {
        private string ip;

        internal LocationContext()
        {
        }

        /// <summary>
        /// Gets or sets the location IP.
        /// </summary>
        public string Ip
        {
            get { return this.ip == string.Empty ? null : this.ip; }
            set { this.ip = value; }
        }

        internal void UpdateTags(IDictionary<string, string> tags)
        {
            tags.UpdateTagValue(ContextTagKeys.Keys.LocationIp, this.Ip);
        }

        internal void CopyFrom(TelemetryContext telemetryContext)
        {
            var source = telemetryContext.Location;
            Tags.CopyTagValue(source.Ip, ref this.ip);
        }
    }
}