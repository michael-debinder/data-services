// <copyright file="DSAPIJsonConnector.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.API
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using Utilities;

    /// <summary>
    /// Execute an AP call using JSON.
    /// </summary>
    public class DSAPIJsonConnector : IDSAPIConnector
    {
        /// <summary>
        /// An instance of an HTTP Client to make the request.
        /// </summary>
        private HttpClient client = new HttpClient();

        /// <summary>
        /// Formatter for converting objects to JSON and vice versa.
        /// </summary>
        private JsonMediaTypeFormatter json = new JsonMediaTypeFormatter();

        /// <summary>
        /// Initializes a new instance of the <see cref="DSAPIJsonConnector"/> class.
        /// </summary>
        public DSAPIJsonConnector()
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("JsonApiUrl"));
        }

        /// <summary>
        /// Execute the supplied search request.
        /// </summary>
        /// <param name="searchRequest">Incoming Search Request.</param>
        /// <returns>Search results or errors.</returns>
        public DSSearchResponse ExecuteSearch(DSSearchRequest searchRequest)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsJsonAsync("api/search", searchRequest);
            response.Wait();

            if (response.Exception != null)
            {
                var errReturn = new DSSearchResponse();
                errReturn.Errors.Add(response.Exception.Message + response.Exception.StackTrace);
                return errReturn;
            }

            if (!response.Result.IsSuccessStatusCode)
            {
                try
                {
                    var error = response.Result.Content.ReadAsAsync<Dictionary<string, string>>();
                    error.Wait();

                    var errReturn = new DSSearchResponse();
                    errReturn.Errors = new List<string> { error.Result["ExceptionMessage"] + ": " + error.Result["StackTrace"] };
                    return errReturn;
                }
                catch
                {
                    // If unable to get specific error data, dump whole message as string
                    var error = response.Result.Content.ReadAsStringAsync();
                    error.Wait();

                    var errReturn = new DSSearchResponse();
                    errReturn.Errors = new List<string> { error.Result };
                    return errReturn;
                }
            }

            var contents = response.Result.Content.ReadAsStringAsync();
            contents.Wait();

            return DSSerializer.Deserialize<DSSearchResponse>(json, contents.Result);
        }
    }
}
