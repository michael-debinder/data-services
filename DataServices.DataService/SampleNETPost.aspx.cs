// <copyright file="SampleNETPost.aspx.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataService
{
    using System;
    using System.Net.Http.Formatting;
    using SDK.API;
    using SDK.Utilities;

    /// <summary>
    /// Page to test posting to the API from .NET code.
    /// </summary>
    public partial class SampleNETPost : System.Web.UI.Page
    {
        /// <summary>
        /// Formatter for converting objects to JSON and vice versa.
        /// </summary>
        private JsonMediaTypeFormatter json = new JsonMediaTypeFormatter();

        /// <summary>
        /// API instance utilizing JSON.
        /// </summary>
        private DSAPI api = new DSAPI(new DSAPIJsonConnector());

        /// <summary>
        /// Handles the Load event of the page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ResetPage();
            }
        }

        /// <summary>
        /// Handles the Click event of the Execute button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Execute_Click(object sender, EventArgs e)
        {
            JSONRequest.Visible = false;

            var searchRequest = DSSerializer.Deserialize<DSSearchRequest>(json, jsonText.Text);
            
            var response = api.ExecuteSearch(searchRequest);

            ResultText.Text = DSSerializer.Serialize(json, response);
            JSONResponse.Visible = true;
        }

        /// <summary>
        /// Handles the Click event of the Reset button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Reset_Click(object sender, EventArgs e)
        {
            ResetPage();
        }

        /// <summary>
        /// Revert the page to its initial settings and text.
        /// </summary>
        private void ResetPage()
        {
            JSONRequest.Visible = true;
            //jsonText.Text = "{\"APIContext\":{\"SessionID\":\"00000000 - 0000 - 0000 - 0000 - 000000000000\",\"UserID\":943},\"Search\":{\"Type\":\"Enrollment\",\"PageSize\":25,\"Page\":1,\"Select\":[\"EnrollmentID\",\"Student.LastName\",\"Student.ID\",\"Course.Title\",\"Course.Department.Name\",\"Grade\"],\"Where\":{\"Column\":\"Course.Title\",\"Operator\":10,\"ValueType\":null,\"Value\":\"e\",\"OrGroup\":false,\"Predicates\":[]},\"Order\":[{\"Name\":\"Student.LastName\"}]}}";
            jsonText.Text = "{\"APIContext\":{\"SessionID\":\"00000000 - 0000 - 0000 - 0000 - 000000000000\",\"UserID\":943},\"Search\":{\"Type\":\"Enrollment\",\"PageSize\":25,\"Page\":1,\"Select\":[\"EnrollmentID\",\"Student.LastName\",\"Student.ID\",\"Course.Title\",\"Course.Department.Name\",\"Grade\"],\"Where\":{\"Column\":null,\"Operator\":0,\"ValueType\":null,\"Value\":null,\"OrGroup\":true,\"Predicates\":[{\"Column\":\"Course.Title\",\"Operator\":10,\"ValueType\":null,\"Value\":\"e\",\"OrGroup\":false,\"Predicates\":[]},{\"Column\":\"Course.Title\",\"Operator\":10,\"ValueType\":null,\"Value\":\"s\",\"OrGroup\":false,\"Predicates\":[]}]},\"Order\":[{\"Name\":\"Student.LastName\"}]}}";
            JSONResponse.Visible = false;
        }
    }
}