using IdentityServer4.Models;
using System.Collections.Generic;

namespace Identity.API.Configuration
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                //new ApiResource("identity", "Identity Service"),
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
                    ClientId = "skeleton_client_id",
                    ClientName = "Skeleton",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedCorsOrigins = { $"{clientsUrl["Spa"]}", $"{clientsUrl["LocationsApi"]}" },
                    AllowAccessTokensViaBrowser = true,

                    AllowedScopes =
                    {
                        //"identity",
                        "locations"
                    }
                }
            };
        }
    }
}
