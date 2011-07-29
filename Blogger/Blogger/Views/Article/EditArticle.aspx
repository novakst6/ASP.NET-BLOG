<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of Blogger.EditArticleModel)" %>
<%@ Import Namespace="Blogger" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Editace článku
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%  Dim article As BlogArticle = ViewData("editedArticle")%>
    <h2>Editace článku [ <%: article.articleTittle.Substring(0, 20)%>... ]</h2>
    <%: Html.ValidationSummary(True, "Uložení změn článku se nezdařilo, opravte chyby a zkuste to znovu.")%>
    <% Using Html.BeginForm() %>
     <div>
            <fieldset>
                <legend>Editace článku</legend>
                
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
                    <input id="ArticleTittle" name="ArticleTittle" type="text" value="<%: article.articleTittle %>" />
                    <%: Html.ValidationMessageFor(Function(m) m.ArticleTittle)%>
                </div>
                 <div class="editor-label">              
                 <%: Html.LabelFor(Function(m) m.ArticleText)%>
                </div>
                <div class="editor-field">
                    <textarea cols="20" id="ArticleText" name="ArticleText" rows="2"><%: article.articleText %></textarea>
                    <%: Html.ValidationMessageFor(Function(m) m.ArticleText)%>
                    <input id="ArticleId" name="ArticleId" type="hidden" value="<%: article.articleId %>" />
                </div>

                <p>
                    <input type="submit" value="Uložit" />
                </p>
            </fieldset>
        </div>
    <% End Using %>
</asp:Content>
