Public Class UserManager
    Dim dataContext As New BlogEntitiesDataContext()
    Function addBlogUser(ByVal newBlogUser As BlogUser) As Boolean
        Try
            dataContext.BlogUsers.InsertOnSubmit(newBlogUser)
            dataContext.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function updateBlogUser(ByVal oldBlogUser As BlogUser, ByVal updatedBlogUser As BlogUser) As Boolean
        Try
            dataContext.BlogUsers.Attach(oldBlogUser)
            oldBlogUser.userFirsName = updatedBlogUser.userFirsName
            oldBlogUser.userLastName = updatedBlogUser.userLastName
            oldBlogUser.userEmail = updatedBlogUser.userEmail
            oldBlogUser.userNickName = updatedBlogUser.userNickName
            oldBlogUser.userPassword = updatedBlogUser.userPassword
            oldBlogUser.BlogUserRole = updatedBlogUser.BlogUserRole
            dataContext.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function deleteBlogUser(ByVal userToDelete As BlogUser) As Boolean
        Try
            dataContext.BlogUsers.DeleteOnSubmit(userToDelete)
            dataContext.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function findAll()
        Dim users = From u In dataContext.BlogUsers Select u
        Return users
    End Function

    Function findUserById(ByVal userId As Integer) As BlogUser
        Dim user = (From u In dataContext.BlogUsers Select u Where u.userId = userId).Single()
        Return user
    End Function
    Function findUserByUserName(ByVal userUserName As String) As BlogUser
        Try
            Dim user = (From u In dataContext.BlogUsers Select u Where u.userNickName = userUserName).First()
            Return user
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function containUserNickName(ByVal userNickName As String) As Boolean
        Try
            Dim user = (From u In dataContext.BlogUsers Select u Where u.userNickName = userNickName).Single()
            Return True
        Catch Ex As Exception
            Return False
        End Try

    End Function

    Function findUserForLogin(ByVal userName As String, ByVal password As String) As Boolean
        Try
            Dim user = (From u In dataContext.BlogUsers Where u.userNickName = userName And u.userPassword = password Select u).Single()
            Return True
        Catch Ex As Exception
            Return False
        End Try
    End Function
End Class
