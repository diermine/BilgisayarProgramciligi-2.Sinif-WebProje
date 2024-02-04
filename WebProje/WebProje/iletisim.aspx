<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="iletisim.aspx.cs" Inherits="WebProje.iletisim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="ilett" style="">
            <table style="width: 100%">
                <tr>
                    <td style="width: 214px">Konu :</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="252px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 214px">İçerik :</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" Height="214px" TextMode="MultiLine" Width="322px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 214px">Mail Adresi :</td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" Width="238px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 214px">&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Height="36px" OnClick="Button1_Click" Text="Gönder" Width="79px" style="margin-top:20px; background:#212630; color:whitesmoke; border-color:white; border-radius:15px; box-shadow: 2px 2px 3px green;" />
                    </td>
                </tr>
            </table>
</div>

</asp:Content>
