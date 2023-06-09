Imports System.Runtime.Serialization

<DataContract>
Public Class Serie
    <DataMember(Name:="titulo")>
    Public Property Title As String

    <DataMember(Name:="idSerie")>
    Public Property IdSerie As String

    <DataMember(Name:="datos")>
    Public Property Data As DataSerie()
End Class

<DataContract>
Public Class DataSerie
    <DataMember(Name:="fecha")>
    Public Property Fecha As String

    <DataMember(Name:="dato")>
    Public Property Data As String
End Class

<DataContract>
Public Class SeriesResponse
    <DataMember(Name:="series")>
    Public Property Series As Serie()
End Class

<DataContract>
Public Class Response
    <DataMember(Name:="bmx")>
    Public Property SeriesResponse As SeriesResponse
End Class
