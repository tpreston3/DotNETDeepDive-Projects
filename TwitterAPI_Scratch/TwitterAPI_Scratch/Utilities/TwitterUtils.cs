using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TwitterAPI_Scratch.Models;


namespace TwitterAPI_Scratch.Utilities
{
    public class TwitterUtils
    {

        private string searchUri = "search/tweets.json?q=";
        /*q A UTF-8, URL-encoded search query of 500 characters maximum, including operators. 
         * ex.  https://api.twitter.com/1.1/search/tweets.json?q=%23freebandnames
         * */
        public async Task<bool> Authenticated(Models.TwitterAPIAuth OAuthParams, TwitterAPI_ScratchContext _context)
        {

            var DbContext = _context;

            //create a post client to send authentication to Yelp API 
            HttpClient client = new HttpClient();
            var oauth_nonce = OauthNonce.GenerateOauthNonce().ToString();



            // created the url for which the Http Post will be used 
            client.BaseAddress = new System.UriBuilder(OAuthParams.BaseURL).Uri;
            var content = new FormUrlEncodedContent(
                new[]
                {
                    new KeyValuePair<string, string>("oauth_comsumer_key", Uri.EscapeDataString(OAuthParams.ConsumerKey)),
                   // new KeyValuePair<string, string>("oauth_nonce", Uri.EscapeDataString(oauth_nonce),
                    new KeyValuePair<string, string>("oauth_signature_method", Uri.EscapeDataString("HMAC-SHA1")),
                    new KeyValuePair<string, string>("oauth_timestamp", Uri.EscapeDataString(DateTime.Now.TimeOfDay.ToString())),
                    new KeyValuePair<string, string>("oauth_token", Uri.EscapeDataString(OAuthParams.AccessToken))

                });

            return false;
        }
    }
}
