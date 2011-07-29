' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults
        routes.MapRoute( _
            "Default", _
            "{controller}/{action}/{id}", _
            New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional} _
        )
        routes.MapRoute( _
                        "ArticleRoute", _
                        "Article/Article/{id}", _
                        New With {.controller = "Article", .action = "Article", .id = UrlParameter.Optional} _
                        )
        routes.MapRoute( _
                "EditArticleRoute", _
                "Article/EditArticle/{id}", _
                New With {.controller = "Article", .action = "EditArticle", .id = UrlParameter.Optional} _
                )
        routes.MapRoute( _
        "deleteArticleRoute", _
        "Article/DeleteArticle/{id}", _
        New With {.controller = "Article", .action = "DeleteArticle", .id = UrlParameter.Optional} _
        )

    End Sub

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()

        RegisterRoutes(RouteTable.Routes)
    End Sub
End Class
