using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using YelpAPI.Models;

namespace YelpAPI
{
    internal class YelpHelpers
    {

        private string baseUrl = "https://api.yelp.com";
        private string authUri = "/oauth2/token";
        private string searchUri = "/v3/businesses/search";

        internal async Task<bool> Authenticate(Models.ConfigurationKeys appKeys, Models.YelpAPIContext _context)
        {
            if (_context.YelpAuthToken.Any())
            {
                if (_context.YelpAuthToken.OrderByDescending(a => a.expire_date)
                             .FirstOrDefault()
                             .expire_date >= DateTime.Now)
                {
                    return true;
                }
            }
            
            
            //create a post client to send authentication to Yelp API 
            var client = new HttpClient();

            // created the url for which the Http Post will be used 
            client.BaseAddress = new System.UriBuilder(baseUrl + authUri).Uri;
            // clean up headers for API call operations 
            client.DefaultRequestHeaders.Accept.Clear();

            // name = [value] Post data in the Http header
            var content = new FormUrlEncodedContent(
                new[]
                {
                    new KeyValuePair<string, string>("client_id", Uri.EscapeDataString(appKeys.YelpClientID)),
                    new KeyValuePair<string, string>("client_secret", Uri.EscapeDataString(appKeys.YelpClientSecret)),
                    new KeyValuePair<string, string>("grant_type", Uri.EscapeDataString("client_credentials"))
                });
            //Posting the content created to the URL
            var response = await client.PostAsync(client.BaseAddress, content);
            // The Response returns from yelp 
            var responseString = await response.Content.ReadAsStringAsync();
            // Take the response string and convert to the json
            var authStatus = JsonConvert.DeserializeObject<Models.YelpAuthToken>(responseString);

            authStatus.expire_date = DateTime.Now.AddSeconds(authStatus.expires_in-100);
            _context.YelpAuthToken.Add(authStatus);
            _context.SaveChanges();
            return true;
        }

        internal async Task<YelpSearchResult> GetResults(YelpAPIContext context, YelpSearch search)
        {

            var authToken = context.YelpAuthToken.OrderByDescending(a => a.expire_date).SingleOrDefault();

            var client = new HttpClient();

            //creat the query search string 
            var queryString = Uri.EscapeUriString(String.Format($"?term={search.Term}&location={search.Location}", search.Term, search.Location));

            // created the complete url for which the Http Post will be used 
            client.BaseAddress = new System.UriBuilder(baseUrl + searchUri + queryString).Uri;
            // clean up headers for API call operations 
            client.DefaultRequestHeaders.Accept.Clear();

            // name = [value] Post data in the Http header -  Adding to the the Authorization to header        
            client.DefaultRequestHeaders.Add("Authorization", authToken.token_type + " " + Uri.EscapeDataString(authToken.access_token));

            //Posting the content created to the URL
            var response = await client.GetAsync(client.BaseAddress);

            // The Response returns from yelp 
            var responseString = await response.Content.ReadAsStringAsync();

            // Take the response string and convert to the json
            var searchResult = JsonConvert.DeserializeObject<YelpSearchResult>(responseString);

            return searchResult;

        }

       

    }
}