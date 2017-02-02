<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MvpDemo.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>MPV Demo</h1>
        <p class="lead">MVP is a derivative of MVC aimed at providing a cleaner separation between the view, the model, and the controller.</p>
    </div>

    <div class="row">
        <div>
            <h2>Stocks</h2>

            <div class="form-inline">
                <asp:TextBox CssClass="form-control" ID="txtSymbols" runat="server" Text="MSFT,GOOG,AMZN,CMG.TO,BEI-UN.TO"></asp:TextBox>
                <asp:Button CssClass="btn btn-default" ID="btnRefresh" runat="server" Text="Refresh" onclick="RefreshClick"/>
                <asp:Button CssClass="btn btn-default" ID="btnRedirect" runat="server" Text="About" onclick="RedirectClick"/>
            </div>

            <p>
                <asp:GridView 
                    CssClass="table table-bordered" 
                    ID="GridView1" 
                    runat="server">
                </asp:GridView>
            </p>

            <p class="text-right">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </p>
        </div>
    </div>

</asp:Content>