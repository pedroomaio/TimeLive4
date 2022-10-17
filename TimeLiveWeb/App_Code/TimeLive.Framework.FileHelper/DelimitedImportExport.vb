Imports Microsoft.VisualBasic

Public Class DelimitedImportExport
    Private m_iColumnCount As Integer
    Private m_dtCSV As DataTable
    Private m_Delimiter
    Public Function PopulateDataTableFromUploadedFile(ByVal FileName As String, ByVal Delimiter As String) As DataTable
        m_Delimiter = Delimiter
        Dim srdr As System.IO.StreamReader = New System.IO.StreamReader(FileName, System.Text.Encoding.Default)
        ' Dim strm As New System.IO.StreamReader(strm)
        Dim strLine As [String] = [String].Empty
        Dim iLineCount As Int32 = 0

        strLine = srdr.ReadLine()
        If strLine Is Nothing Then
            Return Nothing
        End If
        m_dtCSV = Me.CreateDataTableForCSVData(strLine)
        Do
            Dim CurrentLineColumns As Integer = 0
            strLine = srdr.ReadLine()
            While CurrentLineColumns < m_iColumnCount
                If strLine Is Nothing OrElse strLine = String.Empty Then
                    Exit Do
                End If
                CurrentLineColumns = strLine.Split(New Char() {m_Delimiter}).Length
                If CurrentLineColumns < m_iColumnCount Then
                    strLine = strLine & vbCrLf & srdr.ReadLine()
                End If
            End While
            Me.AddDataRowToTable(strLine, m_dtCSV)
        Loop While True
        Return m_dtCSV
    End Function

    Private Function CreateDataTableForCSVData(ByVal strLine As [String]) As DataTable
        Dim dt As New DataTable("CSVTable")
        Dim strVals As [String]() = strLine.Split(New Char() {m_Delimiter})
        m_iColumnCount = strVals.Length
        Dim idx As Integer = 0
        For Each strVal As [String] In strVals
            Dim strColumnName As [String] = strVal
            dt.Columns.Add(strColumnName, Type.[GetType]("System.String"))
        Next
        Return dt
    End Function

    Private Function AddDataRowToTable(ByVal strCSVLine As [String], ByVal dt As DataTable) As DataRow
        Dim strVals As [String]() = strCSVLine.Split(New Char() {m_Delimiter})
        Dim iTotalNumberOfValues As Int32 = strVals.Length
        ' If number of values in this line are more than the columns
        ' currently in table, then we need to add more columns to table.
        Dim idx As Integer = 0
        Dim drow As DataRow = dt.NewRow()
        Dim orig As Integer = 0
        For i As Integer = 0 To strVals.Length - 1
            drow(orig) = strVals(i).Trim()
            If drow(orig).ToString.StartsWith("""") Then
                While True
                    If drow(orig).ToString.EndsWith("""") AndAlso drow(orig).ToString.Length > 1 AndAlso drow(orig).ToString.IndexOf("""", 2) > 0 Then
                        'If strVals(i).ToString.EndsWith("""") And strVals(i).IndexOf("""") > 0 Then
                        ' Remove leading and ending quotes
                        drow(orig) = drow(orig).ToString.Substring(1, drow(orig).ToString.Length - 2)
                        Exit While
                    End If
                    i = i + 1
                    drow(orig) = drow(orig) & m_Delimiter & strVals(i)
                End While

            End If
            orig = orig + 1

        Next
        dt.Rows.Add(drow)
        Return drow
    End Function

End Class
