Imports System.Web.Optimization
Imports System.Data.Entity

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        RegisterOpenAuth()
        Database.SetInitializer(New ProductDatabaseInitializer())

        ' Add Administrator.
        If Not Roles.RoleExists("Administrator") Then
            Roles.CreateRole("Administrator")
        End If

        If Membership.GetUser("Admin") Is Nothing Then
            Membership.CreateUser("Admin", "Pa$$word", "Admin@contoso.com")
            Roles.AddUserToRole("Admin", "Administrator")
        End If

        ' Add Routes.
        RegisterRoutes(RouteTable.Routes)
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Get last error from the server
        Dim exc As Exception = Server.GetLastError()

        If TypeOf exc Is HttpUnhandledException Then
            If exc.InnerException IsNot Nothing Then
                exc = New Exception(exc.InnerException.Message)
                Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", True)
            End If
        End If
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

    Private Sub RegisterRoutes(routes As RouteCollection)
        routes.MapPageRoute("HomeRoute", "Home", "~/Default.aspx")
        routes.MapPageRoute("AboutRoute", "About", "~/About.aspx")
        routes.MapPageRoute("ContactRoute", "Contact", "~/Contact.aspx")
        routes.MapPageRoute("ProductListRoute", "ProductList", "~/ProductList.aspx")

        routes.MapPageRoute("ProductsByCategoryRoute", "ProductList/{categoryName}", "~/ProductList.aspx")
        routes.MapPageRoute("ProductByNameRoute", "Product/{productName}", "~/ProductDetails.aspx")
    End Sub

End Class