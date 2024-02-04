<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="detay.aspx.cs" Inherits="WebProje.detay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="ListView1" runat="server">
        <ItemTemplate>
            <div id="detay">
				<div id="dSol">
				<hgroup><h1><%# Eval("urun_ad") %></h1></hgroup>
				<div class="aciklama"><%# Eval("urun_aciklama") %> </div>
				<span>Satış Fiyatı: <h3><%# Eval("urun_fiyat") %></h3></span>  <br/>
				<span>Platform : <p><%# Eval("urun_turu") %></p></span>
				<span>Adet:
					<asp:DropDownList ID="DropDownList1" runat="server">
							<asp:ListItem>Adet Seçin</asp:ListItem>
					<asp:ListItem>1</asp:ListItem>
					<asp:ListItem>2</asp:ListItem>
					<asp:ListItem>3</asp:ListItem>
					<asp:ListItem>4</asp:ListItem>
					<asp:ListItem>5</asp:ListItem>
				           </asp:DropDownList></span>
            <span>
				<asp:Button ID="Button1" runat="server" Text="Sepete Ekle" CssClass="btnsepet" OnClick="Button1_Click" style="background:#212630; color:whitesmoke; border-color:white; border-radius:15px; box-shadow: 2px 2px 3px green;" /></span>
            
            <div class="temiz"></div>
			
		</div>
		<div id="dSag">
			<a href="#">
				<figure><img src="images/oyun/<%# Eval("urun_resim") %>" alt="Yazı Başlığı"/></figure>
			</a>
		</div>
        <div class="temiz"></div>
	</div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
