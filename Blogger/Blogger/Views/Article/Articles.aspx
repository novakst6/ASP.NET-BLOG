<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ import Namespace = "Blogger" %>
<asp:Content ID="ArticlesTitle" ContentPlaceHolderID="TitleContent" runat="server">
	Seznam článků
</asp:Content>

<asp:Content ID="Articles" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Všechny články</h2>
    <% For Each article As BlogArticle In ViewData("articles")%>

     <table>
      <tr class="infoline">
          <%
          Dim d As New RouteValueDictionary()
              d.Add("id", article.articleId)
           %>
          <td><%: Html.RouteLink(article.articleTittle.ToString(), "ArticleRoute", d)%>
          <div style="color: #000000">Kategorie: <%: article.BlogCategory.categoryName %></div></td>
      </tr>
      <tr>
          <% Dim text As String = article.articleText.Substring(0, 200)%>
          <td style="padding-left: 1em; width: 15em" ><%: text.ToString()%>...</td>
      </tr>
    </table>
    <%Next%>
</asp:Content>
