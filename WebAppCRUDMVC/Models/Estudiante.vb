Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema


Public Class Estudiante

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    Public Property Nombre As String
    Public Property Apellido As String
    Public Property Curso As Curso
    Public Property FechaInicio As DateTime


End Class

Public Enum Curso
    DAM
    DAW
    SMIR
    ASIR
End Enum


