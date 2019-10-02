using System;

namespace Exploratory
{
    public class Utilities
    {
        /// <summary>
        /// Determines if the current host is running in development
        /// </summary>
        /// <remarks>IHostingEnvironment is unavailable from xUnit runner.</remarks>
        /// <returns><c>True</c> if development environment, else <c>False</c>.</returns>
        public static bool IsDevelopment()
        {
            var env = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            return string.IsNullOrEmpty(env) || env.ToLower() == "development";
        }
    }
}
