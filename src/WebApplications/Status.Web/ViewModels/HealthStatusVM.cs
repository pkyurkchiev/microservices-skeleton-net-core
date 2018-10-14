using Microsoft.Extensions.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Status.Web.ViewModels
{
    public class HealthStatusVM
    {
        private readonly CheckStatus _overall;

        private readonly Dictionary<string, IHealthCheckResult> _results;

        public CheckStatus OverallStatus => _overall;

        public IEnumerable<NamedCheckResultVM> Results => _results.Select(kvp => new NamedCheckResultVM(kvp.Key, kvp.Value));

        private HealthStatusVM() => _results = new Dictionary<string, IHealthCheckResult>();

        public HealthStatusVM(CheckStatus overall) : this() => _overall = overall;

        public void AddResult(string name, IHealthCheckResult result) => _results.Add(name, result);
    }
}
