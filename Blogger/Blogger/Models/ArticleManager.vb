Public Class ArticleManager
    Dim dataContext As New BlogEntitiesDataContext()
    Function addArticle(ByVal newArticle As BlogArticle) As Boolean
        Try
            dataContext.BlogArticles.InsertOnSubmit(newArticle)
            dataContext.SubmitChanges()
            Return True
        Catch Ex As Exception
            Return False
        End Try
    End Function

    Function updateArticle(ByVal upArticleId As Integer, ByVal updatedArticle As BlogArticle) As Boolean
        Try
            Dim oldArticle As BlogArticle = (From a As BlogArticle In dataContext.BlogArticles Where a.articleId = upArticleId Select a).Single()
            oldArticle.articleTittle = updatedArticle.articleTittle
            oldArticle.articleText = updatedArticle.articleText
            oldArticle.articleCategoryId = updatedArticle.articleCategoryId
            dataContext.SubmitChanges()
            Return True
        Catch Ex As Exception
            Return False
        End Try

    End Function

    Function deleteArticle(ByVal articleToDelete As BlogArticle) As Boolean
        Try
            dataContext.BlogArticles.DeleteOnSubmit(articleToDelete)
            dataContext.SubmitChanges()
            Return True
        Catch Ex As Exception
            Return False
        End Try
    End Function

    Function findAll()
        Dim articles = From a In dataContext.BlogArticles Select a
        Return articles
    End Function

    Function findArticleById(ByVal articleId As Integer) As BlogArticle
        Try
            Dim articles = (From a In dataContext.BlogArticles Select a Where a.articleId = articleId).First()
            Return articles
        Catch ex As Exception
            Return Nothing
        End Try
        
    End Function
End Class
