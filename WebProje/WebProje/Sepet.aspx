<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Sepet.aspx.cs" Inherits="WebProje.Sepet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
           <div id="spt">

                       <img src="images/oyun/<%# Eval("urun_resim") %>" width="166" height="166" >
                       <p><h2><%# Eval("urun_ad") %> </h2> <h4><%# Eval("urun_aciklama") %></h4> <h4>Adet Sayısı : <%# Eval("adet") %> Adet </h4> <h4>Fiyatı :  <%# Eval("urun_fiyat") %> TL</h4></p>
                        <img id="cali" src="images/calidad.png" /><h3>Paranız %100 GameStore güvencesi altındadır.</h3>
                        <asp:Button ID="Button2" runat="server" Text="Sepeti Temizle" CssClass="butt" OnClick="Button2_Click" style="background:#212630; color:whitesmoke; border-color:white; border-radius:15px; "/>
                         <asp:Button ID="Button1" runat="server" Text="Satın Al" CssClass="butt" OnClick="Button1_Click" style="background:#212630; color:whitesmoke; border-color:white; border-radius:15px; "/>
           </div>
       </ItemTemplate>
    </asp:ListView><div id="spt2">Sepet Toplamı : <asp:Label ID="sptlbl" runat="server" Text="Label"></asp:Label> TL</div>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:baglanti %>" SelectCommand="SELECT * FROM [Sepet] WHERE ([uye_id] = @uye_id)">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="0" Name="uye_id" SessionField="uye_id" Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>
</asp:Content>
