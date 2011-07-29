<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of Blogger.RegisterModel)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Registrace nového uživatele
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Vytvoření nového uživatelského účtu</h2>
    <p>
       Vyplňte následnují formulář pro založení nového účtu. Minimální délka hesla je 6 znaků.
    </p>

    <% Using Html.BeginForm() %>
        <%: Html.ValidationSummary(True, "Vytvoření účtu se nezdařilo. Prosíme opravte chyby ve formuláři a zkuste to znovu.")%>
        <div>
            <fieldset>
                <legend>Informace o účtu</legend>
                
                <div class="editor-label">
                    <%: Html.LabelFor(Function(m) m.UserFirstName)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(Function(m) m.UserFirstName)%>
                    <%: Html.ValidationMessageFor(Function(m) m.UserFirstName)%>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(Function(m) m.UserLastName) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(Function(m) m.UserLastName)%>
                    <%: Html.ValidationMessageFor(Function(m) m.UserLastName)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(Function(m) m.UserEmail)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(Function(m) m.UserEmail)%>
                    <%: Html.ValidationMessageFor(Function(m) m.UserEmail)%>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(Function(m) m.UserName)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(Function(m) m.UserName)%>
                    <%: Html.ValidationMessageFor(Function(m) m.UserName)%>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(Function(m) m.UserPassword)%>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(Function(m) m.UserPassword)%>
                    <%: Html.ValidationMessageFor(Function(m) m.UserPassword)%>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(Function(m) m.UserConfirmPassword)%>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(Function(m) m.UserConfirmPassword)%>
                    <%: Html.ValidationMessageFor(Function(m) m.UserConfirmPassword)%>
                </div>
                
                <p>
                    <input type="submit" value="Registrovat" />
                </p>
            </fieldset>
        </div>
    <% End Using %>

</asp:Content>
