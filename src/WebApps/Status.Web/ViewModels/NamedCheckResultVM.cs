using Microsoft.Extensions.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Status.Web.ViewModels
{
    public class NamedCheckResultVM
    {
        public string Name { get; }

        public IHealthCheckResult Result { get; }

        public NamedCheckResultVM(string name, IHealthCheckResult result)
        {
            Name = name;
            Result = result;
        }
    }
}
