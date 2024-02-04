<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="hesabim.aspx.cs" Inherits="WebProje.hesabim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="width:400px; background-color:#171a21; height:380px; margin-left:250px; margin-top:100px; border-radius:15px;  box-shadow: 5px 5px 10px green; padding:20px; color:white; font-weight:bold; font-size:20px;">
                <table style="width: 100%">
                <tr>
                    <td style="width: 181px; height: 22px;">
                            <asp:Image ID="imgUyeResim" runat="server" Width="166" Height="166" style="padding:5px;"/>

                    </td>
                    <td style="height: 22px"></td>
                </tr>
                <tr>
                    <td style="width: 181px">Ad Soyad:</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 181px">Parola :</td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 181px">Kullanıcı Adı :</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 181px">Mail :</td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 181px">Katılım Tarihi :</td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
            </table>
        <asp:Button ID="Button1" runat="server" Text="Sipariş Geçmişi" OnClick="Button1_Click" style="margin-left:110px; margin-top:30px; border-color:white; background-color:#171a21;color:green; width:160px; height:30px; border-radius:10px;"  />
    </div>
</asp:Content>
