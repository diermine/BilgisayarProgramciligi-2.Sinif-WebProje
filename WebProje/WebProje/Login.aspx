<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebProje.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="Panel1" runat="server">
		<table style="margin-left:240px; margin-top:40px; color:whitesmoke; background-color:#171a21; width:450px; height:150px;padding:15px;border-radius:15px;box-shadow: 3px 6px 3px green;">
		<tr>
			<td>Kullanıcı Adı : </td>
			<td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
		</tr>
			<tr>
				<td>Şifre : </td>
				<td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
				
				<td><asp:CheckBox ID="CheckBox1" runat="server" />Beni Hatırla</td>
			</tr>
			<tr>
				<td><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Kayıt Ol</asp:LinkButton></td>				
				<td><asp:Button ID="Button1" runat="server" Text="Giriş" Width="87px" style="margin-left:45px;background:#212630; color:whitesmoke; border-color:white; border-radius:15px; box-shadow: 2px 2px 3px green;" OnClick="Button1_Click"/></td>
		
			</tr>
	</table>
	</asp:Panel>

	
	<asp:Panel ID="Panel2" runat="server">
		<table style="margin-left:240px; margin-top:40px; color:whitesmoke; background-color:#171a21; width:450px; height:500px;padding:20px;border-radius:15px;box-shadow: 3px 6px 3px green;">
			<tr>
				<td>Ad Soyad:</td>
				<td class="auto-style1"><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" Ad soyad alanı boş geçilemez" ControlToValidate="TextBox3">*</asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>Kullanıcı Adı:</td>
				<td class="auto-style1"><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Kullanıcı Adı Boş Geçilemez" ControlToValidate="TextBox4">*</asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Kullanıcı Adı En Az 5 Karakter Olmalıdır." ControlToValidate="TextBox4" ValidationExpression=".{5,}">*</asp:RegularExpressionValidator>
				</td>
			</tr>
			<tr>
				<td>Şifre</td>
				<td class="auto-style1"><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Şifre Alanı Boş Geçilemez" ControlToValidate="TextBox5">*</asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
                <td>Kullanici Resmi :</td>
                <td class="auto-style1">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
			<tr>
				<td>E-Mail Adresi:</td>
				<td class="auto-style1"><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="E-mail Alanı Boş Geçilemez" ControlToValidate="TextBox6">*</asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Lütfen Geçerli Bir E-Mail Adresi Girinz." ControlToValidate="TextBox6" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
				</td>
			</tr>
			<tr>
				<td></td>	
				<td class="auto-style1"><asp:Button ID="Button2" runat="server" Text="Kayıt Ol" Width="87px" style="margin-left:45px;background:#212630; color:whitesmoke; border-color:white; border-radius:15px; box-shadow: 2px 2px 3px green;" OnClick="Button2_Click"/></td>			
			</tr>
			 <tr>
				 <td></td>
				 <td class="auto-style1">
					  <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
				 </td>
			 </tr>
		</table>

	</asp:Panel>
    </asp:Content>
