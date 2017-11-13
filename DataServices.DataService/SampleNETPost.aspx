<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SampleNETPost.aspx.cs" Inherits="DataServices.DataService.SampleNETPost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple API Test in .NET</title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Simple API Test in .NET</h1>
    <div runat="server" id="JSONRequest" style="width: 800px;">
        <h3>Enter JSON below and click the "Execute" button to submit against the Search API.</h3>
        <asp:TextBox runat="server" id="jsonText" TextMode="MultiLine" Columns="95" Rows="30"></asp:TextBox>
        <div style="width: 100%; text-align: right">
            <asp:Button runat="server" id="Execute" Text="Execute" OnClick="Execute_Click" />
        </div>
    </div>
    <div runat="server" id="JSONResponse" style="width: 800px;">
        <h3>Results from "api/search". Click "Reset" button below to try something else.</h3>
        <div>
            <asp:Literal runat="server" id="ResultText"></asp:Literal>
        </div>
        <div style="width: 100%; text-align: right">
            <asp:Button runat="server" id="Reset" Text="Reset" OnClick="Reset_Click" />
        </div>
    </div>
    <a href="SampleSearches.aspx" target="_blank">See some sample searches.</a>
    </form>
</body>
</html>
