Public Class UserRoleManager
    Dim dataContext As New BlogEntitiesDataContext()
    Function addUserRole(ByVal newUserRole As BlogUserRole) As Boolean
        Try
            dataContext.BlogUserRoles.InsertOnSubmit(newUserRole)
            dataContext.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function updateUserRole(ByVal oldUserRole As BlogUserRole, ByVal updatedUserRole As BlogUserRole) As Boolean
        Try
            dataContext.BlogUserRoles.Attach(oldUserRole)
            oldUserRole.roleName = updatedUserRole.roleName
            dataContext.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function deleteUserRole(ByVal userRoleToDelete As BlogUserRole) As Boolean
        Try
            dataContext.BlogUserRoles.DeleteOnSubmit(userRoleToDelete)
            dataContext.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Function findAll()
        Dim roles = From r In dataContext.BlogUserRoles Select r
        Return roles
    End Function

    Function findByName(ByVal name As String) As BlogUserRole
        Dim role = (From r In dataContext.BlogUserRoles Where r.roleName = name Select r).Single()
        Return role
    End Function
End Class
