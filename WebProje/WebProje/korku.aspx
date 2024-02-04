<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="korku.aspx.cs" Inherits="WebProje.korku" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>

                <div class="urun">
                    <h1><%# Eval("urun_ad") %></h1>
                    <a href="#"><figure>
                        <img src="images/oyun/<%# Eval("urun_resim") %>" alt='Yazı Başlığı' width="166" height="166"/></figure>
                    </a>
                <div class="fiyatKismi">
                <div class="fiyat">
                <span>Türü  :</span>
             <br /><p><%# Eval("urun_turu") %></p>
                <h4><%# Eval("urun_fiyat") %> TL</h4>
                </div>

                <div class="detay">
          	    <span>Detay</span>
                    <a href="detay.aspx?urunID=<%# Eval("urun_id") %>" ><div id='uincele'>İncele</div></a>
                </div>
                </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
</asp:Content>
