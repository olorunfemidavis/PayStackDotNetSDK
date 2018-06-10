<%@ Page Title="" Language="C#" MasterPageFile="~/Store.Master" AutoEventWireup="true" Async="true" CodeBehind="Default.aspx.cs" Inherits="Tester.Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <button runat="server" id="ActionBusson" onserverclick="ActionBusson_ServerClick">Initialize Transaction</button>
    <div id="contentDiv" runat="server"></div>
</asp:Content>
