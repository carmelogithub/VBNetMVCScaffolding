Imports System.Data.Entity

Public Class EscuelaDataBaseContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("EscuelaContext")
    End Sub

    Public Property Estudiantes As DbSet(Of Estudiante)

End Class
