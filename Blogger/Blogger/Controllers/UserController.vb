Imports System.Diagnostics.CodeAnalysis
Imports System.Security.Principal
Imports System.Web.Routing
Namespace Blogger
    Public Class UserController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /User

        Private formsServiceValue As IFormsAuthenticationService
        Private userValidationValue As IUserValidationService
        Private userServiceValue As IUserService

        Public Property FormsService() As IFormsAuthenticationService
            Get
                Return formsServiceValue
            End Get
            Set(ByVal value As IFormsAuthenticationService)
                formsServiceValue = value
            End Set
        End Property

        Public Property UserService() As IUserService
            Get
                Return userServiceValue
            End Get
            Set(ByVal value As IUserService)
                userServiceValue = value
            End Set
        End Property
        Public Property UserValidationService() As IUserValidationService
            Get
                Return userValidationValue
            End Get
            Set(ByVal value As IUserValidationService)
                userValidationValue = value
            End Set
        End Property

        Protected Overrides Sub Initialize(ByVal requestContext As RequestContext)
            If FormsService Is Nothing Then FormsService = New FormsAuthenticationService()
            If UserService Is Nothing Then UserService = New UserService()
            If UserValidationService Is Nothing Then UserValidationService = New UserValidationService()
            MyBase.Initialize(requestContext)
        End Sub
        Function Register() As ActionResult
            Return View()
        End Function
        Function SignIn() As ActionResult
            Return View()
        End Function

        <HttpPost()> _
        Public Function SignIn(ByVal model As SignInModel, ByVal returnUrl As String) As ActionResult
            If ModelState.IsValid Then
                If UserService.ValidateUser(model.UserName, model.UserPassword) Then
                    FormsService.SignIn(model.UserName, False)
                    If Not String.IsNullOrEmpty(returnUrl) Then
                        Return Redirect(returnUrl)
                    Else
                        Return (RedirectToAction("Index", "Home"))
                    End If
                Else
                    ModelState.AddModelError("", "Uživatelské jméno nebo heslo je nesprávné.")
                End If
            End If

                    ' If we got this far, something failed, redisplay form
                    Return View(model)
        End Function
        Public Function SignOut() As ActionResult
            FormsService.SignOut()
            Return RedirectToAction("Index", "Home")
        End Function

        <HttpPost()> _
        Public Function Register(ByVal model As RegisterModel) As ActionResult
            If ModelState.IsValid Then
                If UserValidationService.validateUserName(model.UserName) Then
                    If UserValidationService.validateEmailForm(model.UserEmail) Then
                        If UserValidationService.validateLongPassword(model.UserPassword) Then
                            If UserValidationService.validateEqualsPassword(model.UserPassword, model.UserConfirmPassword) Then
                                UserService.CreateUser(model.UserName, model.UserPassword, model.UserFirstName, model.UserLastName, model.UserEmail)
                                FormsService.SignIn(model.UserName, False)
                                Return RedirectToAction("Index", "Home")
                            Else
                                ModelState.AddModelError("", "Hesla se neshodují.")
                            End If
                        Else
                            ModelState.AddModelError("", "Heslo je příliž krátké.")
                        End If
                    Else
                        ModelState.AddModelError("", "Emailová adresa je v nesprávném tvaru.")
                    End If
                Else
                    ModelState.AddModelError("", "Uživatelské jméno je již použito, vyberte jiné.")
                End If
            End If

            Return View(model)
        End Function
    End Class
End Namespace