using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Identity.API.Configuration
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("identity", "Identity Service"),
                new ApiResource("locations", "Locations Service")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients(Dictionary<string, string> clientsUrl)
        {
            return new List<Client>
            {
                // Resource Owner Password Flow
                new Client
                {
                    ClientId = "optimum_client_id",
                    ClientName = "Optimum",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedCorsOrigins = { $"{clientsUrl["Spa"]}", $"{clientsUrl["LocationsApi"]}", $"{clientsUrl["OptimumApi"]}" },
                    AllowAccessTokensViaBrowser = true,

                    AllowedScopes =
                    {
                        "identity",
                        "locations"
                    }
                }
            };
        }
    }
}
