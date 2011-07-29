Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Globalization
Imports System.Text.RegularExpressions

#Region "Models"
Public Class SignInModel
    Private userNameValue As String
    Private userPasswordValue As String

    <Required()> _
    <DisplayName("Uživatelské jméno")> _
    Public Property UserName() As String
        Get
            Return userNameValue
        End Get
        Set(ByVal value As String)
            userNameValue = value
        End Set
    End Property

    <Required()> _
    <DisplayName("Heslo")> _
    Public Property UserPassword() As String
        Get
            Return userPasswordValue
        End Get
        Set(ByVal value As String)
            userPasswordValue = value
        End Set
    End Property
End Class

Public Class RegisterModel
    Private userFirstNameValue As String
    Private userLastNameValue As String
    Private userEmailValue As String
    Private userUserNameValue As String
    Private userPasswordValue As String
    Private userConfirmPasswordValue As String

    <Required()> _
    <DisplayName("Jméno")> _
    Public Property UserFirstName() As String
        Get
            Return userFirstNameValue
        End Get
        Set(ByVal value As String)
            userFirstNameValue = value
        End Set
    End Property

    <Required()> _
    <DisplayName("Příjmení")> _
    Public Property UserLastName() As String
        Get
            Return userLastNameValue
        End Get
        Set(ByVal value As String)
            userLastNameValue = value
        End Set
    End Property

    <Required()> _
    <DisplayName("Email")> _
    Public Property UserEmail() As String
        Get
            Return userEmailValue
        End Get
        Set(ByVal value As String)
            userEmailValue = value
        End Set
    End Property

    <Required()> _
    <DisplayName("Uživatelské jméno")> _
    Public Property UserName() As String
        Get
            Return userUserNameValue
        End Get
        Set(ByVal value As String)
            userUserNameValue = value
        End Set
    End Property

    <Required()> _
    <DisplayName("Heslo")> _
    Public Property UserPassword() As String
        Get
            Return userPasswordValue
        End Get
        Set(ByVal value As String)
            userPasswordValue = value
        End Set
    End Property

    <Required()> _
<DisplayName("Potvrzení hesla")> _
    Public Property UserConfirmPassword() As String
        Get
            Return userConfirmPasswordValue
        End Get
        Set(ByVal value As String)
            userConfirmPasswordValue = value
        End Set
    End Property

End Class
#End Region

#Region "Services"
Public Interface IUserService
    Function ValidateUser(ByVal userName As String, ByVal password As String) As Boolean
    Function CreateUser(ByVal userName As String, ByVal password As String, ByVal userFirsName As String, ByVal userLastName As String, ByVal email As String) As Boolean
End Interface

Public Class UserService
    Implements IUserService

    Function CreateUser(ByVal userName As String, ByVal password As String, ByVal userFirsName As String, ByVal userLastName As String, ByVal email As String) As Boolean Implements IUserService.CreateUser
        If String.IsNullOrEmpty(userName) Then Throw New ArgumentException("Není vyplněna hodnota.", "userName")
        If String.IsNullOrEmpty(password) Then Throw New ArgumentException("Není vyplněna hodnota.", "userPassword")
        If String.IsNullOrEmpty(userFirsName) Then Throw New ArgumentException("Není vyplněna hodnota.", "userFirsName")
        If String.IsNullOrEmpty(userLastName) Then Throw New ArgumentException("Není vyplněna hodnota.", "userLastName")
        If String.IsNullOrEmpty(email) Then Throw New ArgumentException("Není vyplněna hodnota.", "email")

        Dim um As New UserManager()
        Dim urm As New UserRoleManager()
        Dim newUserRole = urm.findByName("USER")
        Dim newUser As New BlogUser()
        newUser.userFirsName = userFirsName
        newUser.userLastName = userLastName
        newUser.userEmail = email
        newUser.userNickName = userName
        newUser.userPassword = password
        newUser.userRoleId = newUserRole.roleId
        um.addBlogUser(newUser)
        Return True
    End Function

    Function ValidateUser(ByVal userName As String, ByVal password As String) As Boolean Implements IUserService.ValidateUser
        If String.IsNullOrEmpty(userName) Then Throw New ArgumentException("Není vyplněna hodnota.", "userName")
        If String.IsNullOrEmpty(password) Then Throw New ArgumentException("Není vyplněna hodnota.", "userPassword")

        Dim um As New UserManager()
        If um.findUserForLogin(userName, password) Then
            Return True
        Else
            Return False
        End If
    End Function

End Class

#End Region

#Region "Validation"
Public Interface IUserValidationService
    Function validateUserName(ByVal userName As String) As Boolean
    Function validateEmailForm(ByVal email As String) As Boolean
    Function validateEqualsPassword(ByVal pass As String, ByVal confPass As String) As Boolean
    Function validateLongPassword(ByVal pass As String) As Boolean
End Interface

Public Class UserValidationService
    Implements IUserValidationService

    Public Function validateEmailForm(ByVal email As String) As Boolean Implements IUserValidationService.validateEmailForm
        Dim EmailRegex As Regex = New Regex("(?<user>[^@]+)@(?<host>.+)")
        Dim M As Match = EmailRegex.Match(email)
        If M.Success Then
            Return True
        End If
        Return False
    End Function

    Public Function validateEqualsPassword(ByVal pass As String, ByVal confPass As String) As Boolean Implements IUserValidationService.validateEqualsPassword
        Return pass.Equals(confPass)
    End Function

    Public Function validateLongPassword(ByVal pass As String) As Boolean Implements IUserValidationService.validateLongPassword
        If pass.Length > 5 Then
            Return True
        End If
        Return False
    End Function

    Public Function validateUserName(ByVal userName As String) As Boolean Implements IUserValidationService.validateUserName
        Dim um As New UserManager()
        If um.containUserNickName(userName) Then
            Return False
        End If
        Return True
    End Function
End Class
#End Region

Public Interface IFormsAuthenticationService
    Sub SignIn(ByVal userName As String, ByVal createPersistentCookie As Boolean)
    Sub SignOut()
End Interface

Public Class FormsAuthenticationService
    Implements IFormsAuthenticationService

    Public Sub SignIn(ByVal userName As String, ByVal createPersistentCookie As Boolean) Implements IFormsAuthenticationService.SignIn
        If String.IsNullOrEmpty(userName) Then Throw New ArgumentException("Value cannot be null or empty.", "userName")

        FormsAuthentication.SetAuthCookie(userName, createPersistentCookie)

    End Sub

    Public Sub SignOut() Implements IFormsAuthenticationService.SignOut
        FormsAuthentication.SignOut()
    End Sub
End Class