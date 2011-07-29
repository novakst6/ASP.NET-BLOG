<HandleError()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Session.Add("actualUser", Nothing)
        Dim roles As New BlogEntitiesDataContext()
        Dim rls = From r In roles.BlogUserRoles Select r
        ViewData("roles") = rls
        Dim category As New BlogCategory()
        category.categoryName = "Category 1"
        category.categoryDescription = "A zde je kecani o teto kategorii"
        Dim categoryManager As New CategoryManager()
        Dim values = categoryManager.findAll()
        Dim choose = categoryManager.findCategoryById(13)
        ViewData("ff") = choose
        ViewData("categoryId") = values
        Dim AdminRole = (From r In roles.BlogUserRoles Where r.roleName = "ADMINISTRATOR" Select r).Single()
        Dim AdminUser As New BlogUser
        AdminUser.userRoleId = AdminRole.roleId
        AdminUser.userFirsName = "admin2"
        AdminUser.userLastName = "admin2"
        AdminUser.userNickName = "admin2"
        AdminUser.userPassword = "admin2"
        AdminUser.userEmail = "stenlik@gmail.com"
        Session.Add("actualUser", AdminUser)
        Dim um As New UserManager()
        'um.addBlogUser(AdminUser)
        Return View()
    End Function

    Function About() As ActionResult
        Return View()
    End Function
End Class
