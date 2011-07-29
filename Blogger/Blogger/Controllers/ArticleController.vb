Namespace Blogger
    Public Class ArticleController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Article
        Function Article(ByVal id As Integer) As ActionResult
            Dim articleManager As New ArticleManager()
            Dim commentaryManager As New CommentaryManager()
            Dim art = articleManager.findArticleById(id)
            Dim comm = commentaryManager.findArticleCommentaryByIdArticle(id)
            ViewData("article") = art
            ViewData("comments") = comm

            Return View()
        End Function
        <HttpPost()> _
        Function Article(ByVal model As ArticleCommentModel) As ActionResult
            Dim articleManager As New ArticleManager()
            Dim commentaryManager As New CommentaryManager()
            If ModelState.IsValid Then
                Dim comment As New BlogArticleCommentary()
                comment.commentaryArticleId = model.ArticleId
                Dim dateComment = Date.UtcNow
                Dim formDateComment = Format(dateComment, "d.M.yyyy")
                comment.commentaryDate = formDateComment
                comment.commentaryText = model.CommentText
                If commentaryManager.addArticleCommentary(comment) Then
                    Dim d As New RouteValueDictionary()
                    d.Add("id", model.ArticleId)
                    Return RedirectToAction("Article", "Article", d)
                Else

                End If

            End If

            Dim art = articleManager.findArticleById(model.ArticleId)
            Dim comm = commentaryManager.findArticleCommentaryByIdArticle(model.ArticleId)
            ViewData("article") = art
            ViewData("comments") = comm
            Return View(model)
        End Function

        Function Articles() As ActionResult
            Dim articlesManager As New ArticleManager()
            ViewData("articles") = articlesManager.findAll()
            Return View()
        End Function

        Function AddArticle() As ActionResult
            Dim categoryManager As New CategoryManager()
            Dim categories = categoryManager.findAll()
            Dim collectionOfItems As New System.Collections.Generic.List(Of SelectListItem)
            For Each c As BlogCategory In categories
                Dim item As New SelectListItem()
                item.Value = c.categoryId
                item.Text = c.categoryName
                collectionOfItems.Add(item)
            Next
            ViewData("categories") = collectionOfItems
            Return View()
        End Function
        <HttpPost()> _
        Function AddArticle(ByVal model As AddArticleModel) As ActionResult

            If ModelState.IsValid Then
                Dim userManager As New UserManager()
                Dim articleManager As New ArticleManager()
                Dim actUserName = HttpContext.User.Identity.Name.ToLower
                Dim user = userManager.findUserByUserName(actUserName)

                Dim article As New BlogArticle()
                article.articleAutorId = user.userId
                article.articleCategoryId = model.ArticleCategory
                article.articleDate = DateAndTime.Now
                article.articleTittle = model.ArticleTittle
                article.articleText = model.ArticleText

                If articleManager.addArticle(article) Then
                    Return RedirectToAction("Articles", "Article")
                End If

            End If
            Dim categoryManager As New CategoryManager()
            Dim categories = categoryManager.findAll()
            Dim collectionOfItems As New System.Collections.Generic.List(Of SelectListItem)
            For Each c As BlogCategory In categories
                Dim item As New SelectListItem()
                item.Value = c.categoryId
                item.Text = c.categoryName
                collectionOfItems.Add(item)
            Next
            ViewData("categories") = collectionOfItems
            Return View(model)
        End Function
        Function EditArticle(ByVal id As Integer) As ActionResult
            Dim articleManager As New ArticleManager()
            Dim article = articleManager.findArticleById(id)
            ViewData("editedArticle") = article
            Dim categoryManager As New CategoryManager()
            Dim categories = categoryManager.findAll()
            Dim collectionOfItems As New System.Collections.Generic.List(Of SelectListItem)
            For Each c As BlogCategory In categories
                Dim item As New SelectListItem()
                item.Value = c.categoryId
                item.Text = c.categoryName
                If article.articleCategoryId = c.categoryId Then
                    item.Selected = True
                End If
                collectionOfItems.Add(item)
            Next
            ViewData("categories") = collectionOfItems
            Return View()
        End Function
        <HttpPost()> _
        Function EditArticle(ByVal model As EditArticleModel) As ActionResult
            Dim userManager As New UserManager()
            Dim articleManager As New ArticleManager()
            If ModelState.IsValid Then

                Dim actUserName = HttpContext.User.Identity.Name.ToLower
                Dim user = userManager.findUserByUserName(actUserName)
                Dim article As New BlogArticle()
                article.articleAutorId = user.userId
                article.articleCategoryId = model.ArticleCategory
                article.articleDate = DateAndTime.Now
                article.articleTittle = model.ArticleTittle
                article.articleText = model.ArticleText
                Dim d As New RouteValueDictionary()
                d.Add("id", model.ArticleId)
                Dim origArticle = articleManager.findArticleById(model.ArticleId)
                If articleManager.updateArticle(model.ArticleId, article) Then
                    Return RedirectToAction("Article", "Article", d)
                End If

            End If
            Dim categoryManager As New CategoryManager()
            Dim categories = categoryManager.findAll()
            Dim collectionOfItems As New System.Collections.Generic.List(Of SelectListItem)
            For Each c As BlogCategory In categories
                Dim item As New SelectListItem()
                item.Value = c.categoryId
                item.Text = c.categoryName
                If model.ArticleCategory = c.categoryId Then
                    item.Selected = True
                End If
                collectionOfItems.Add(item)
            Next
            ViewData("categories") = collectionOfItems

            Dim articleBack = articleManager.findArticleById(model.ArticleId)
            ViewData("editedArticle") = articleBack
            Return View(model)
        End Function
        Function DeleteArticle(ByVal id As Integer) As ActionResult
            Dim articleManager As New ArticleManager()
            Dim article = articleManager.findArticleById(id)
            articleManager.deleteArticle(article)
            Return RedirectToAction("Articles", "Article")
        End Function
    End Class
End Namespace