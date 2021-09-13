Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports WebAppCRUDMVC

Namespace Controllers
    Public Class EstudiantesController
        Inherits System.Web.Mvc.Controller

        Private db As New EscuelaDataBaseContext

        ' GET: Estudiantes
        Function Index() As ActionResult
            Return View(db.Estudiantes.ToList())
        End Function

        ' GET: Estudiantes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim estudiante As Estudiante = db.Estudiantes.Find(id)
            If IsNothing(estudiante) Then
                Return HttpNotFound()
            End If
            Return View(estudiante)
        End Function

        ' GET: Estudiantes/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Estudiantes/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Nombre,Apellido,Curso,FechaInicio")> ByVal estudiante As Estudiante) As ActionResult
            If ModelState.IsValid Then
                db.Estudiantes.Add(estudiante)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(estudiante)
        End Function

        ' GET: Estudiantes/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim estudiante As Estudiante = db.Estudiantes.Find(id)
            If IsNothing(estudiante) Then
                Return HttpNotFound()
            End If
            Return View(estudiante)
        End Function

        ' POST: Estudiantes/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Nombre,Apellido,Curso,FechaInicio")> ByVal estudiante As Estudiante) As ActionResult
            If ModelState.IsValid Then
                db.Entry(estudiante).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(estudiante)
        End Function

        ' GET: Estudiantes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim estudiante As Estudiante = db.Estudiantes.Find(id)
            If IsNothing(estudiante) Then
                Return HttpNotFound()
            End If
            Return View(estudiante)
        End Function

        ' POST: Estudiantes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim estudiante As Estudiante = db.Estudiantes.Find(id)
            db.Estudiantes.Remove(estudiante)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
