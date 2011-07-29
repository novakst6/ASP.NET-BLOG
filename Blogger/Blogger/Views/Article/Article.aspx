<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of Blogger.ArticleCommentModel)" %>
<%@ Import Namespace = "Blogger" %>
<asp:Content ID="titleArticle" ContentPlaceHolderID="TitleContent" runat="server">
	Článek
</asp:Content>

<asp:Content ID="contentArticle" ContentPlaceHolderID="MainContent" runat="server">
    <% Dim article As BlogArticle = ViewData("article")%>
    <h2><%: article.articleTittle.ToString()%></h2>
    <div id="categoryOfArticle" style="padding-left: 1em; color: Black"><b>Kategorie článku: <%: article.BlogCategory.categoryName.ToString()%></b></div>
    <br />
    <div id="articleInfo" style="padding-left: 1em;">Autor článku: <%: article.BlogUser.userNickName.ToString()%> | Datum vložení: <%: article.articleDate.Day.ToString%>.<%: article.articleDate.Month.ToString%>.<%: article.articleDate.Year.ToString%></div>
    <% If Page.User.Identity.Name.ToLower = article.BlogUser.userNickName Then%>
    <div id="articleEdits" style="position: relative; text-align: right; top: -14px; left: 952px; width: 124px; padding-right: 1em;">
    <%
          Dim d As New RouteValueDictionary()
              d.Add("id", article.articleId)
    %>
    <%: Html.ActionLink("EDIT", "EditArticle", d)%> | <%: Html.ActionLink("DEL", "DeleteArticle", d)%>
    </div>
    <% End If %>
    <div id="articleContent" style="color: #000000; margin-left: 2em;">
        <p>
        <%: article.articleText.ToString()%>
        </p>
    </div>
    <h2>Komentáře</h2>
     <%: Html.ValidationSummary(True, "Přidání komentáře se nezdařilo. Prosím opravte možné chyby ve formuláři a zkuste to znovu.")%>
    <% Using Html.BeginForm() %>
     <div>
            <fieldset>
                <legend>Komentář</legend>

                <div class="editor-label">
                    <%: Html.LabelFor(Function(m) m.CommentText)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(Function(m) m.CommentText)%>
                    <%: Html.ValidationMessageFor(Function(m) m.CommentText)%>

                   <input id="ArticleId" name="ArticleId" type="hidden" value="<%: article.articleId %>" />
                    
                    
                    <% 
                        
                        Dim cislo As Integer = article.articleId
                       
                    %>
                </div>
                <p>
                    <input type="submit" value="Odeslat" />
                </p>
            </fieldset>
        </div>
    <% End Using %>
     <% Dim comments = ViewData("comments")%>
     <% If Not comments Is Nothing Then%>
          <% For Each comment As BlogArticleCommentary In comments%>
     <table>
      <tr class="infoline">
          <td><div style="color: #000000">Datum vložení: <%: comment.commentaryDate.Day.ToString%>.<%: comment.commentaryDate.Month.ToString%>.<%: comment.commentaryDate.Year.ToString%></div></td>
      </tr>
      <tr>
          <td style="padding-left: 1em; width: 15em" ><%: comment.commentaryText%></td>
      </tr>
    </table>
    <%Next%>
     <% End If%>
</asp:Content>
