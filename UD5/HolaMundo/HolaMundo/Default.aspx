<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HolaMundo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div>
            <asp:Label ID="Enunciado" runat="server" Text="Introduce tu nombre"></asp:Label>
            <asp:TextBox ID="Nombre" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/>
            <asp:Label ID="resultado" runat="server" Text=""></asp:Label>
            <asp:Label ID="error" runat="server" Text="" ForeColor ="Red"></asp:Label>
        </div>
        
    </main>
</asp:Content>
