<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Log On</h2>
    <p>
        Please enter your username and password. <%--: Html.ActionLink("Register", "Register") --%> if you don't have an account.
    </p>

    <%-- Using Html.BeginForm() --%>
        <%: Html.ValidationSummary(True, "Login was unsuccessful. Please correct the errors and try again.")%>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                
 
                    <input type="submit" value="Log On" />
                </p>
            </fieldset>
        </div>
    <%-- End Using --%>
</asp:Content>
