Public Class CategoryManager
    Dim dataContext As New BlogEntitiesDataContext()
    Function addCategory(ByVal newCategory As BlogCategory) As Boolean
        Try
            dataContext.BlogCategories.InsertOnSubmit(newCategory)
            dataContext.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function updateCategory(ByVal oldCategory As BlogCategory, ByVal updatedCategory As BlogCategory) As Boolean
        Try
            dataContext.BlogCategories.Attach(oldCategory)
            oldCategory.categoryName = updatedCategory.categoryName
            oldCategory.categoryDescription = updatedCategory.categoryDescription
            dataContext.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function deleteCategory(ByVal categoryToDelete As BlogCategory) As Boolean
        Try
            dataContext.BlogCategories.DeleteOnSubmit(categoryToDelete)
            dataContext.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function findAll() As IQueryable(Of BlogCategory)
        Dim categories = From c In dataContext.BlogCategories Select c
        Return categories
    End Function

    Function findCategoryById(ByVal categoryId As Integer)
        Dim categories = From c In dataContext.BlogCategories Select c Where c.categoryId = categoryId
        Return categories
    End Function
End Class
