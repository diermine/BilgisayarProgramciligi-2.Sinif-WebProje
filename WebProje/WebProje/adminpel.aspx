<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="adminpel.aspx.cs" Inherits="WebProje.adminpel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server"  style="color:whitesmoke; " OnRowCommand="GridView1_RowCommand" OnRowDeleted="GridView1_RowDeleted" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" >
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
                        <asp:TemplateField>
                <ItemTemplate>
                    <img src="images/oyun/<%# Eval("urun_resim") %>" style="width:80px;height:75px" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
    <br /><br />
    <div id="adminbutton" style="color:white; margin-left:10px; background-color:#171a21; border-radius:20px; padding:15px;box-shadow: 5px 5px 5px green;" >

        <table style="width: 100%" >
            <tr>
                <td class="auto-style5" style="width: 294px">&nbsp;Adı :  </td>
                <td>
						<span>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style5" style="width: 294px">&nbsp;Açıklaması : </td>
                <td>
						<span>
                    <asp:TextBox ID="TextBox2" runat="server" style="margin-bottom: 0px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style5" style="width: 294px">Fiaytı :</td>
                <td>
						<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="width: 294px">Platformu :</td>
                <td>
						<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="width: 294px">Stok : </td>
                <td>
						<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="width: 294px; height: 33px;">
                    <asp:TextBox ID="TextBox6" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td style="height: 33px">
						<asp:Button ID="Button1" runat="server" Text="Güncelle" OnClick="Button1_Click" Height="28px" Width="83px" style="background:#212630; color:whitesmoke; border-color:white; border-radius:15px; box-shadow: 2px 2px 3px green;font-weight:bold;"/>
                        &nbsp &nbsp &nbsp &nbsp<asp:Button ID="Button2" runat="server" Text="İptal" Height="29px" OnClick="Button2_Click" Width="48px" style="background:#212630; color:whitesmoke; border-color:white; border-radius:15px; box-shadow: 2px 2px 3px green;font-weight:bold;"/>
                </td>
            </tr>
        </table>

    </div>
    &nbsp<asp:Button ID="Button3" runat="server" Text="Ürün Ekle" Height="33px" Width="76px" OnClick="Button3_Click" style="margin-top:30px; margin-left:50px;background:#212630; color:whitesmoke; border-color:white; border-radius:15px; box-shadow: 2px 2px 3px green;font-weight:bold;" Enabled="False"/>
    <br />
    <br />
    <div id="admpanel" style="color:white; margin-left:10px; background-color:#171a21; border-radius:20px; padding:15px;box-shadow: 5px 5px 5px green;">
            <asp:Panel ID="Panel1" runat="server" >
                <table style="width: 100%">
                    <tr>
                        <td class="auto-style5" style="width: 294px">Adı :</td>
                        <td>
                            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 294px">Türü :</td>
                        <td>
                            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 294px">Fiyatı :</td>
                        <td>
                            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 294px">Platformu :</td>
                        <td>
                            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 294px">Resim Yolu :</td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 294px">Stok :</td>
                        <td>
                            <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 294px">
                            <br />
                        </td>
                        <td>
                            <asp:Button ID="Button4" runat="server" Text="Yükle" OnClick="Button4_Click" Height="30px" Width="54px" style="margin-top:10px;background:#212630; color:whitesmoke; border-color:white; border-radius:15px; box-shadow: 2px 2px 3px green; font-weight:bold;"/>
                        </td>
                    </tr>
                </table>

            </asp:Panel>

            <br />
    </div>
            <asp:Button ID="Button5" runat="server" Text="Kullanici" OnClick="Button5_Click" Height="33px" Width="76px"  style="margin-top:30px; margin-left:50px;background:#212630; color:whitesmoke; border-color:white; border-radius:15px; box-shadow: 2px 2px 3px green;font-weight:bold;" Enabled="False"/>
        <br />
						<span>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:GridView ID="GridView2" runat="server" OnRowCommand="GridView2_RowCommand" OnRowDeleting="GridView2_RowDeleting" style="color:whitesmoke; margin-left:150px;">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
                </span>
        <div style="color:white; margin-left:10px; background-color:#171a21; border-radius:20px; padding:15px;box-shadow: 5px 5px 5px green; margin-top:20px;">
            <asp:Panel ID="Panel2" runat="server">
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 174px">Adı :</td>
                        <td>
                            <asp:TextBox ID="TextBox13" runat="server" Width="174px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 174px">Kullanıcı Adı :</td>
                        <td>
                            <asp:TextBox ID="TextBox14" runat="server" Width="174px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 174px">Parola :</td>
                        <td>
                            <asp:TextBox ID="TextBox15" runat="server" Width="174px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 174px">E-Mail :</td>
                        <td>
                            <asp:TextBox ID="TextBox16" runat="server" Width="174px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 174px">Yetki :</td>
                        <td>
                            <asp:TextBox ID="TextBox17" runat="server" Width="173px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 174px">
                            <asp:TextBox ID="TextBox18" runat="server" Visible="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="Button7" runat="server" Text="Yeni Kayıt" Height="30px" Width="90px" style="margin-top:10px;background:#212630; color:whitesmoke; border-color:white; border-radius:15px; box-shadow: 2px 2px 3px green; font-weight:bold;" OnClick="Button7_Click"/>
                            <span>
                            <asp:Button ID="Button6" runat="server" Text="Güncelle" Height="30px" Width="80px" style="margin-top:10px;background:#212630; color:whitesmoke; border-color:white; border-radius:15px; box-shadow: 2px 2px 3px green;font-weight:bold; margin-left:20px;margin-right:20px;" OnClick="Button6_Click"/>
                            </span>
                        </td>
                    </tr>
                </table>

            </asp:Panel>
        </div>
    <div>
        <asp:Button ID="Button8" runat="server" Text="Sipariş" Height="33px" Width="76px"  style="margin-top:30px; margin-left:50px;background:#212630; color:whitesmoke; border-color:white; border-radius:15px; box-shadow: 2px 2px 3px green;font-weight:bold;" Enabled="False"/>
        
        <asp:GridView ID="GridView3" runat="server" style="color:whitesmoke; margin-left:150px;"></asp:GridView>
        
    </div>

</asp:Content>

