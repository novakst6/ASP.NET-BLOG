<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of Blogger.SignInModel)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Sign In
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Přihlášení</h2>
    <p>Zadejte své přihlašovací jméno a heslo. Pokud ještě nemáte účet, můžete se <%: Html.ActionLink("zaregistrovat.", "Register", "User")%></p>
    <%: Html.ValidationSummary(True, "Přihlášení se nezdařilo. Prosím opravte možné chyby ve formuláři a zkuste to znovu.")%>
    <% Using Html.BeginForm() %>
     <div>
            <fieldset>
                <legend>Přihlašovací údaje</legend>
                
                <div class="editor-label">
                    <%: Html.LabelFor(Function(m) m.UserName)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(Function(m) m.UserName) %>
                    <%: Html.ValidationMessageFor(Function(m) m.UserName) %>
                </div>
                
                <div class="editor-label">              
                 <%: Html.LabelFor(Function(m) m.UserPassword)%>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(Function(m) m.UserPassword)%>
                    <%: Html.ValidationMessageFor(Function(m) m.UserPassword)%>
                </div>
                <p>
                    <input type="submit" value="Přihlásit se" />
                </p>
            </fieldset>
        </div>
    <% End Using %>
</asp:Content>
