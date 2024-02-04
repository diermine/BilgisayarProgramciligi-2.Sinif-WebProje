<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="hakkimizda.aspx.cs" Inherits="WebProje.hakkimizda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <p id="randomText" runat="server" style="margin-left:200px; font-weight:bold; font-size:70px;">Baran Alyar <br /><br />1226706039<br /><br />Bilgisayar Programcılığı</p>
    </div>
    <audio id="audioPlayer" controls autoplay loop style="margin-left:250px; visibility:hidden;">
    <source src="/muzik/muzik.mp3" type="audio/mp3">
</audio>

    <script type="text/javascript">
        function changeColor() {
            var colors = <%= ColorsJson %> || []; 
            var randomColor = colors[Math.floor(Math.random() * colors.length)];
            
            var h1Element = document.getElementById("<%= randomText.ClientID %>");
            if (h1Element) {
                h1Element.style.color = randomColor;
            }
        }

        setInterval(changeColor, 200);
    </script>
	    <script src="Scripts/site.js" type="text/javascript"></script>
    <script src="https://cdn.elinsoft.com/kar.js" type="text/javascript"></script>

</asp:Content>