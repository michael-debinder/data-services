// <copyright file="SampleSearches.aspx.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataService
{
    using System;
    using System.Net.Http.Formatting;
    using SDK.API;
    using SDK.Entities;
    using SDK.Search;
    using SDK.Utilities;

    /// <summary>
    /// Page to generate some search JSON for posting to the API.
    /// </summary>
    public partial class SampleSearches : System.Web.UI.Page
    {
        /// <summary>
        /// Formatter for converting objects to JSON and vice versa.
        /// </summary>
        private JsonMediaTypeFormatter json = new JsonMediaTypeFormatter();

        /// <summary>
        /// Handles the Load event of the page. Displays results of a bunch of sample queries converted to JSON.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var searchRequest = new DSSearchRequest();
            DSSearch search;

            searchRequest.APIContext = new DSAPIContext { UserID = 943, SessionID = Guid.Empty.ToString() };

            search = new DSSearch(DSEnrollment.EntityName);
            search.AddSelect(DSEnrollment.Attrs.EnrollmentID);
            search.AddSelect(DSEnrollment.Attrs.Student.LastName);
            search.AddSelect(DSEnrollment.Attrs.Student.ID);
            search.AddSelect(DSEnrollment.Attrs.Course.Title);
            search.AddSelect(DSEnrollment.Attrs.Course.Department.Name);

            searchRequest.Search = search;

            AppendSearch("Simple search", searchRequest);

            search = new DSSearch(DSEnrollment.EntityName);
            search.AddSelect(DSEnrollment.Attrs.EnrollmentID);
            search.AddSelect(DSEnrollment.Attrs.Student.LastName);
            search.AddSelect(DSEnrollment.Attrs.Student.ID);
            search.AddSelect(DSEnrollment.Attrs.Course.Title);
            search.AddSelect(DSEnrollment.Attrs.Course.Department.Name);
            search.AddSelect(DSEnrollment.Attrs.Grade);

            search.Where.Add(new DSPredicate
            {
                Column = DSEnrollment.Attrs.Course.Title,
                Operator = DSSearchOperatorEnum.Contains,
                Value = "e",
            });

            search.AddOrder(DSEnrollment.Attrs.Student.LastName);

            searchRequest.Search = search;

            AppendSearch("Search with filter", searchRequest);

            searchRequest.Search.Where.OrGroup = true;
            searchRequest.Search.Where.DSContains(DSEnrollment.Attrs.Course.Title, "s");

            AppendSearch("Search with multiple filters", searchRequest);
        }

        /// <summary>
        /// Helper method to append text to the display.
        /// </summary>
        /// <param name="title">Title of the search.</param>
        /// <param name="searchRequest">The Search Request instance.</param>
        private void AppendSearch(string title, DSSearchRequest searchRequest)
        {
            SampleSearchText.Text += string.Format(
                "<h2>{0}</h2><div>{1}</div>",
                title,
                DSSerializer.Serialize(json, searchRequest));
        }
    }
}