Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Globalization
#Region "Models"
Public Class AddArticleModel
    Private articleTittleValue As String
    Private articleCategoryValue As Integer

    Private articleTextValue As String
    <Required()> _
    <DisplayName("Titul článku")> _
    Public Property ArticleTittle() As String
        Get
            Return articleTittleValue
        End Get
        Set(ByVal value As String)
            articleTittleValue = value
        End Set
    End Property
    <Required()> _
    <DisplayName("Kategorie článku")> _
    Public Property ArticleCategory() As Integer
        'IEnumerable(Of SelectListItem)
        Get
            Return articleCategoryValue
        End Get
        Set(ByVal value As Integer)
            'IEnumerable(Of SelectListItem))
            articleCategoryValue = value
        End Set
    End Property
    <DisplayName("Text článku")> _
    Public Property ArticleText() As String
        Get
            Return articleTextValue
        End Get
        Set(ByVal value As String)
            articleTextValue = value
        End Set
    End Property
End Class
Public Class EditArticleModel
    Private articleTittleValue As String
    Private articleCategoryValue As Integer
    Private idArticlevalue As Integer
    Private articleTextValue As String
    <Required()> _
    <DisplayName("Titul článku")> _
    Public Property ArticleTittle() As String
        Get
            Return articleTittleValue
        End Get
        Set(ByVal value As String)
            articleTittleValue = value
        End Set
    End Property
    <Required()> _
    <DisplayName("Kategorie článku")> _
    Public Property ArticleCategory() As Integer
        'IEnumerable(Of SelectListItem)
        Get
            Return articleCategoryValue
        End Get
        Set(ByVal value As Integer)
            'IEnumerable(Of SelectListItem))
            articleCategoryValue = value
        End Set
    End Property
    <DisplayName("Text článku")> _
    Public Property ArticleText() As String
        Get
            Return articleTextValue
        End Get
        Set(ByVal value As String)
            articleTextValue = value
        End Set
    End Property
    Public Property ArticleId() As Integer
        Get
            Return idArticlevalue
        End Get
        Set(ByVal value As Integer)
            idArticlevalue = value
        End Set
    End Property
End Class
Public Class ArticleCommentModel
    Private idArticlevalue As Integer
    Private commentTextvalue As String
    Public Property ArticleId() As Integer
        Get
            Return idArticlevalue
        End Get
        Set(ByVal value As Integer)
            idArticlevalue = value
        End Set
    End Property

    <DisplayName("Text Komentáře")> _
    Public Property CommentText() As String
        Get
            Return commentTextvalue
        End Get
        Set(ByVal value As String)
            commentTextvalue = value
        End Set
    End Property
    <DisplayName("Jméno")> _
    Public Property CommentUserName() As String
        Get
            Return commentTextvalue
        End Get
        Set(ByVal value As String)
            commentTextvalue = value
        End Set
    End Property
End Class
#End Region

