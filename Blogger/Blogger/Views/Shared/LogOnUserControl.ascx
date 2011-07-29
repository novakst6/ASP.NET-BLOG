<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Blogger" %>
<%-- The following line works around an ASP.NET compiler warning --%>
<%: ""%>
<%  Dim user As BlogUser = Session.Item("actualUser")%>
<%  If Request.IsAuthenticated Then%>
        Vítejte <b><%: Page.User.Identity.Name%></b>!
        [ <%: Html.ActionLink("Odhlásit se", "SignOut", "User")%> ]
    <%
    Else
    %>  
        [ <%: Html.ActionLink("Přihlásit se", "SignIn", "User")%> ]
    <%       
    End If
    %>