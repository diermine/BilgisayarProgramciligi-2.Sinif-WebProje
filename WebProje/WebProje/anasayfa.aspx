<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="WebProje.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>

                <div class="urun">
                    <h1><%# Eval("urun_ad") %></h1>
                    <a href="#"><figure>
                        <img src="images/oyun/<%# Eval("urun_resim") %>" alt='Yazı Başlığı' width="170" height="170"/></figure>
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

    <div class="sayfaa">
        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="9">
            <Fields>
                <asp:NumericPagerField ButtonCount="9" />
            </Fields>
        </asp:DataPager>
    </div>


</asp:Content>
