<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MvpDemo.Web.AboutView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>This application provides a brief demo of the MVP pattern.</h3>
    <p>The demo highlights implementation of MVP in ASP.NET WebForms, utilizing S.O.L.I.D. design principles, 
        and a dependency injection framework.
    </p>
     <p>
        <strong><asp:Label ID="lblParam" runat="server"></asp:Label></strong>
    </p>
    <p>
        <asp:Button CssClass="btn btn-default" ID="btnRedirect" runat="server" Text="Home" onclick="RedirectClick"/>
    </p>
</asp:Content>
