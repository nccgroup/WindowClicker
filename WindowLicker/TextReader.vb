' WindowClicker - GUI Automater
' Copyright (C) 2014 Nick Dunn
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Option Explicit On

Imports System.IO
Imports System.Threading
Imports System.Collections.Specialized


Public Class TextReader

    Public ImageDirectory As String = ""
    Public TesseractLocation As String = ""
    Public TesseractArgs As String = "-l eng"

    Public ImageCount As Integer = 0

    Public Compare As Boolean = False

    Public OriginalTextSnips As New Dictionary(Of String, String)
    Public ChangedTextSnips As New Dictionary(Of String, String)

    Private dicProcessList As New Dictionary(Of String, String)
    Private procOCR As Process = New Process()


    Public Sub New(Optional ByVal ImagesLocation As String = "", Optional ByVal OCRReader As String = "C:\tesseract\tesseract.exe", Optional ByVal OCRArgs As String = "-l eng")
        ' Instantiate object and provide locations for Tesseract exe and image files
        '===========================================================================

        '== If no images location provided then use temp folder ==
        If ImagesLocation.Trim = "" Then ImagesLocation = Path.GetTempPath & "\WCScans"

        '== Set file and directory details ==
        ImageDirectory = ImagesLocation.TrimEnd("\")
        TesseractLocation = OCRReader
        TesseractArgs = OCRArgs

        procOCR.StartInfo.FileName = TesseractLocation

        '== Reset image count ==
        ImageCount = 0

    End Sub

    Public Sub ReadImageText()
        ' Pass each image to Tesseract and write extracted text to file
        '==============================================================
        Dim intIndex As Integer = 1
        Dim strImageFile As String = ""


        If ImageCount = 0 Then Exit Sub

        dicProcessList.Clear()

        Try
            '== Process file for each screenshot ==
            Do While intIndex <= ImageCount

                ' Set filename for correct image
                strImageFile = ImageDirectory & "\screenshot" & CStr(intIndex) & ".tif"

                ' Create arguments for Tesseract process
                procOCR.StartInfo.Arguments = strImageFile & " " & strImageFile & " " & TesseractArgs
                procOCR.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                procOCR.StartInfo.CreateNoWindow = True
                procOCR.EnableRaisingEvents = True

                ' Send image to Tesseract
                AddHandler procOCR.Exited, AddressOf Me.ProcessExited
                procOCR.Start()
                dicProcessList.Add(procOCR.Id.ToString, strImageFile & ".txt")

                Do While Not procOCR.HasExited
                    Application.DoEvents()
                Loop
                intIndex += 1
            Loop
        Catch ex As Exception
            MsgBox("OCR application error: " & ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Friend Sub ProcessExited(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Handle exit from process and return value from processed image
        '===============================================================
        Dim srInputFile As StreamReader
        Dim strTextEntry As String = ""


        '== Iterate through current Tesseract processes and store or compare results ==
        For Each deProcess In dicProcessList

            '== Valid process ==
            If (sender.id.ToString = deProcess.Key) Then

                '== Extract content ==
                srInputFile = File.OpenText(deProcess.Value)
                strTextEntry = srInputFile.ReadToEnd()

                '== Process value as appropriate ==
                If Not Compare Then
                    '== First run so add to list of values ==
                    If OriginalTextSnips.ContainsValue(deProcess.Value) Then
                        OriginalTextSnips.Item(deProcess.Value) = strTextEntry
                    Else
                        OriginalTextSnips.Add(deProcess.Value, strTextEntry)
                    End If
                Else
                    '== Subsequent run so compare new value to old value ==
                    If strTextEntry <> OriginalTextSnips.Item(deProcess.Value) Then
                        If ChangedTextSnips.ContainsValue(deProcess.Value) Then
                            ChangedTextSnips.Item(deProcess.Value) = strTextEntry
                        Else
                            ChangedTextSnips.Add(deProcess.Value, strTextEntry)
                        End If
                    End If
                End If
            End If
        Next

    End Sub

End Class
