using AdysTech.CredentialManager;
using LC_VersionOne.DataTypeClasses;
using LC_VersionOne.JsonClasses;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace LC_VersionOne
{
    public static class VersionOne
    {
        private static readonly string _target = "VersionOneAPILogin";
        private static readonly CredentialType _credentialType = CredentialType.Generic;

        public static List<Member> AllMembers { get; private set; } = new List<Member>();
        public static List<Category> StoryCategories { get; private set; } = new List<Category>();
        public static List<Category> TaskCategories { get; private set; } = new List<Category>();
        public static List<Category> TestCategories { get; private set; } = new List<Category>();

        /// <summary>
        /// Initializes the VersionOne system by performing several asynchronous initialization tasks.
        /// </summary>
        static VersionOne()
        {
            Task.WhenAll(
                InitializeMembersAsync(),
                InitializeCategoriesAsync("Story"),
                InitializeCategoriesAsync("Task"),
                InitializeCategoriesAsync("Test")
            //InitializeStatusesAsync("Story"),
            //InitializeStatusesAsync("Task"),
            //InitializeStatusesAsync("Test")
            );
        }


        /// <summary>
        /// Initializes the members by retrieving information from the specified URL.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private static async Task InitializeMembersAsync()
        {
            RootObject? members = await GetAsync("https://www5.v1host.com/TheLakeCompaniesInc26//rest-1.v1/Data/Member?sel=Username,Email,Name,Nickname&where=AssetState=%2764%27&sort=Name");
            foreach (Asset member in members?.Assets!)
            {
                AllMembers.Add(member.ToMember());
            }
        }

        /// <summary>
        /// Initializes the categories based on the specified category type.
        /// </summary>
        /// <param name="categoryType">The type of category to initialize.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private static async Task InitializeCategoriesAsync(string categoryType)
        {
            RootObject? categories = await GetAsync($"https:/www5.v1host.com/TheLakeCompaniesInc26/rest-1.v1/Data/{categoryType}Category?sel=Name&sort=Name");

            switch (categoryType)
            {
                case "Story":
                    foreach (Asset category in categories?.Assets!)
                    {
                        StoryCategories.Add(category.ToCategory());
                    }
                    break;
                case "Task":
                    foreach (Asset category in categories?.Assets!)
                    {
                        TaskCategories.Add(category.ToCategory());
                    }
                    break;
                case "Test":
                    foreach (Asset category in categories?.Assets!)
                    {
                        TestCategories.Add(category.ToCategory());
                    }
                    break;
                default:
                    throw new ArgumentException($"Invalid categoryType: {categoryType}");
            }
        }


        /// <summary>
        /// Initializes the statuses based on the specified status type.
        /// </summary>
        /// <param name="statusType">The type of status to initialize.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private static async Task InitializeStatusesAsync(string statusType)
        {
            RootObject? statuses = await GetAsync($"https:/www5.v1host.com/TheLakeCompaniesInc26/rest-1.v1/Data/{statusType}Status?sel=Name&sort=Name");

            switch (statusType)
            {
                case "Story":
                    foreach (Asset status in statuses?.Assets!)
                    {
                        StoryCategories.Add(status.ToCategory());
                    }
                    break;
                case "Task":
                    foreach (Asset status in statuses?.Assets!)
                    {
                        TaskCategories.Add(status.ToCategory());
                    }
                    break;
                case "Test":
                    foreach (Asset status in statuses?.Assets!)
                    {
                        TestCategories.Add(status.ToCategory());
                    }
                    break;
                default:
                    throw new ArgumentException($"Invalid categoryType: {statusType}");
            }
        }


        /// <summary>
        /// Retrieves the network credentials for the specified target using the specified credential type.
        /// </summary>
        /// <returns>The <see cref="NetworkCredential"/> object containing the credentials.</returns>
        public static NetworkCredential GetCredentials()
        {
            return CredentialManager.GetCredentials(_target, _credentialType);
        }

        /// <summary>
        /// Saves the specified username and password as network credentials for the target.
        /// If credentials already exist, they will be removed before saving the new credentials.
        /// </summary>
        /// <param name="username">The username to be saved.</param>
        /// <param name="password">The password to be saved.</param>
        public static void SaveCredentials(string username, string password)
        {
            // Check if credentials exist
            if (GetCredentials() != null)
            {
                CredentialManager.RemoveCredentials(_target, _credentialType);
            }

            CredentialManager.SaveCredentials(_target, new NetworkCredential(username, password), _credentialType);
        }

        /// <summary>
        /// Asynchronously sends a GET request to the specified URL and retrieves the response as a JSON object.
        /// Uses network credentials from the Windows Credential Manager.
        /// </summary>
        /// <param name="url">The URL to send the request to.</param>
        /// <returns>The deserialized JSON response as a <see cref="RootObject"/> object.</returns>
        /// <exception cref="InvalidOperationException">Thrown when credentials are not found in the Windows Credential Manager.</exception>
        /// <exception cref="HttpRequestException">Thrown when the request fails with a non-successful status code.</exception>
        internal static async Task<RootObject?> GetAsync(string url)
        {
            //NetworkCredential networkCredential = GetCredentials() ?? throw new InvalidOperationException("Credentials not found in Windows Credential Manager.");
            NetworkCredential networkCredential = new()
            {
                UserName = "mschoofs",
                Password = "p@$$W0rd"
            };

            HttpClientHandler handler = new()
            {
                UseDefaultCredentials = true,
                PreAuthenticate = true,
                Credentials = networkCredential
            };

            HttpClient client = new(handler)
            {
                DefaultRequestHeaders =
                {
                    Accept =
                    {
                        new MediaTypeWithQualityHeaderValue("application/json")
                    }
                }
            };

            HttpResponseMessage response = client.GetAsync(url).Result;

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON into appropriate classes
                return JsonConvert.DeserializeObject<RootObject>(json)!;
            }
            else
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}.\n\n{url}");
            }
        }
    }
}
