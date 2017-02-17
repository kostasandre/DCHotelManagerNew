// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HttpClient.cs" company="">
//   
// </copyright>
// <summary>
//   The http client.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.UINew.Helpers
{
    using System;

    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// The http client.
    /// </summary>
    public class HttpClientHelper
    {
        /// <summary>
        /// The get http client.
        /// </summary>
        /// <returns>
        /// The <see cref="HttpClientHelper"/>.
        /// </returns>
        public static HttpClientHelper GetHttpClient()
        {
            var myHttpClient = new HttpClientHelper();

             //dynamic _token = HttpContext.Current.Session["token"];
             //if (_token == null) throw new ArgumentNullException(nameof(_token));
             //MyHttpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _token.AccessToken));
            return myHttpClient;
        }
    }
}