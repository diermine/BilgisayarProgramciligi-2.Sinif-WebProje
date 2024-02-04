<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="siparis.aspx.cs" Inherits="WebProje.siparis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <p>
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="40pt" ForeColor="White" Text="Sipariş Geçmişi"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="color:white;">
        </asp:GridView>
    </p>
    <p>
        <asp:Label ID="Label6" runat="server" Text="Label" style="color:white;font-weight:bold; font-size:30px;"></asp:Label>
    </p>
</asp:Content>
