using IdentityServer4;
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
                new ApiResource("locations", "Locations Service"),
                new ApiResource("knowledgebase", "KnowledgeBase Service")
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
                //new Client
                //{
                //    ClientId = "skeleton_client_id",
                //    ClientName = "Skeleton",
                //    ClientSecrets = { new Secret("secret".Sha256()) },
                //    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                //    AllowedCorsOrigins = { $"{clientsUrl["SpaAdministration"]}", /*$"{clientsUrl["IdentityApi"]}",*/ $"{clientsUrl["LocationsApi"]}", $"{clientsUrl["KnowledgeBaseApi"]}" },
                //    AllowAccessTokensViaBrowser = true,

                //    AllowedScopes =
                //    {
                //        //"identity",
                //        "locations",
                //        "knowledgebase"
                //    }
                //},
                new Client
                {
                    ClientId = "locationsswaggerui",
                    ClientName = "Locations Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { $"{clientsUrl["LocationsApi"]}/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { $"{clientsUrl["LocationsApi"]}/swagger/" },

                    AllowedScopes =
                    {
                        "locations"
                    }
                },
                new Client
                {
                    ClientId = "knowledgebaseswaggerui",
                    ClientName = "KnowledgeBase Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { $"{clientsUrl["KnowledgeBaseApi"]}/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { $"{clientsUrl["KnowledgeBaseApi"]}/swagger/" },

                    AllowedScopes =
                    {
                        "knowledgebase"
                    }
                },
                // JavaScript Client Administration
                new Client
                {
                    ClientId = "js",
                    ClientName = "Administration SPA OpenId Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris =           { $"{clientsUrl["SpaAdministration"]}/" },
                    RequireConsent = false,
                    PostLogoutRedirectUris = { $"{clientsUrl["SpaAdministration"]}/" },
                    AllowedCorsOrigins =     { $"{clientsUrl["SpaAdministration"]}" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "locations"
                    },
                },
                // JavaScript Client KnowledgeBase
                new Client
                {
                    ClientId = "js-knowledgebase",
                    ClientName = "KnowledgeBase SPA OpenId Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris =           { $"{clientsUrl["SpaKnowledgeBase"]}/" },
                    RequireConsent = false,
                    PostLogoutRedirectUris = { $"{clientsUrl["SpaKnowledgeBase"]}/" },
                    AllowedCorsOrigins =     { $"{clientsUrl["SpaKnowledgeBase"]}" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "locations",
                        "knowledgebase"
                    },
                },
            };
        }
    }
}
