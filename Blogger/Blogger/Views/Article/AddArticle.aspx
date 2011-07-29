<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of Blogger.AddArticleModel)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Nový článek
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Nový článek</h2>
    <%: Html.ValidationSummary(True, "Přidání nového článku se nezdařilo, opravte chyby a zkuste to znovu.")%>
    <% Using Html.BeginForm() %>
     <div>
            <fieldset>
                <legend>Přidání nového článku</legend>
                
                <div class="editor-label">
                    <%: Html.LabelFor(Function(m) m.ArticleCategory)%>
                </div>
                <div class="editor-field">
                    <%: Html.DropDownListFor(Function(m) m.ArticleCategory, ViewData("categories"))%>
                    <%: Html.ValidationMessageFor(Function(m) m.ArticleCategory)%>
                </div>
                
                <div class="editor-label">              
                 <%: Html.LabelFor(Function(m) m.ArticleTittle)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(Function(m) m.ArticleTittle)%>
                    <%: Html.ValidationMessageFor(Function(m) m.ArticleTittle)%>
                </div>
                 <div class="editor-label">              
                 <%: Html.LabelFor(Function(m) m.ArticleText)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(Function(m) m.ArticleText)%>
                    <%: Html.ValidationMessageFor(Function(m) m.ArticleText)%>
                </div>
                <p>
                    <input type="submit" value="Publikovat" />
                </p>
            </fieldset>
        </div>
    <% End Using %>
</asp:Content>
