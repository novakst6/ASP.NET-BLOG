Public Class CommentaryManager
    Dim dataContext As New BlogEntitiesDataContext()
    Function addArticleCommentary(ByVal newArticleCommentary As BlogArticleCommentary) As Boolean
        Try
            dataContext.BlogArticleCommentaries.InsertOnSubmit(newArticleCommentary)
            dataContext.SubmitChanges()
            Return True
        Catch Ex As Exception
            Return False
        End Try
    End Function

    Function updateArticleCommentary(ByVal oldArticleCommentary As BlogArticleCommentary, ByVal updatedArticleCommentary As BlogArticleCommentary) As Boolean
        Try
            dataContext.BlogArticleCommentaries.Attach(oldArticleCommentary)
            oldArticleCommentary.commentaryText = updatedArticleCommentary.commentaryText
            dataContext.SubmitChanges()
            Return True
        Catch Ex As Exception
            Return False
        End Try
    End Function

    Function deleteArticleCommentary(ByVal commentaryToDelete As BlogArticleCommentary) As Boolean
        Try
            dataContext.BlogArticleCommentaries.DeleteOnSubmit(commentaryToDelete)
            dataContext.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function findAll()
        Dim commentaries = From c In dataContext.BlogArticleCommentaries Select c
        Return commentaries
    End Function
    Function findArticleCommentaryByIdArticle(ByVal articleId As Integer)
        Dim commentaries = From c In dataContext.BlogArticleCommentaries Select c Where c.commentaryArticleId = articleId
        Return commentaries
    End Function
End Class
