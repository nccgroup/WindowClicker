Public Class MonitoredWindow

    Public OriginalText As String = ""  ' The text being checked
    Public hWnd As IntPtr               ' The handle of the Main Window
    Public IsChanged As Boolean = False ' Has test completed?

    Sub New(WindowText As String, NewHwnd As IntPtr)
        OriginalText = WindowText
        hWnd = NewHwnd
    End Sub

End Class
