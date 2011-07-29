<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="false"  %>
<%@ Import Namespace="Blogger" %>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Blogger
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Vítejte na blogu!</h2>
    <p>
        V aplikaci Blogger můžete napsat svůj článek a potom ho publikovat na našem 
        webu. K tomu, abyste mohli začít psát své články je potřeba se
        <%  If Request.IsAuthenticated Then%> 
        přihlásit.
        <%
        Else
        %>  
        <%: Html.ActionLink("přihlásit", "SignIn", "User")%>
        , pokud nemáte ještě u nás účet, můžete si ho založit pomocí
        <%: Html.ActionLink("registrace", "Register")%>.
        <%       
        End If
         %> 
    </p>

</asp:Content>
