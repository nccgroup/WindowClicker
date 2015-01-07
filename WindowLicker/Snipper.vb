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

Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class Snipper
    ' The class inherits from form in order to track mouse pointer and display selected area.
    ' It exists as a maximized invisible form which tracks the mouse position and displays the
    ' selected area back to the user.
    '=========================================================================================

    Inherits Form

    Private imgSnipImage As Image
    Private rctSelectedArea As New Rectangle()
    Private pntStart As Point


    Public Sub New(ScreenShot As Image)
        ' Initialise object with default values 
        ' Snipper will display an invisible window covering entire screen area
        ' Co-ords of selected area will be obtained when user moves mouse 
        ' across this invisible window
        '======================================

        Me.BackgroundImage = ScreenShot
        Me.ShowInTaskbar = False
        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        Me.DoubleBuffered = True

    End Sub

    Public Sub CopyWithoutUser()
        ' Copy a text area without user interaction
        '==========================================

        If rctSelectedArea.Width <= 0 OrElse rctSelectedArea.Height <= 0 Then Return

        Image = New Bitmap(rctSelectedArea.Width, rctSelectedArea.Height)

        Using grGraphics As Graphics = Graphics.FromImage(Image)
            grGraphics.DrawImage(Me.BackgroundImage, New Rectangle(0, 0, Image.Width, Image.Height), rctSelectedArea, GraphicsUnit.Pixel)
        End Using

        DialogResult = DialogResult.OK

    End Sub

    Public Shared Function Snip() As TextArea 'Image
        ' Obtain the screen area highlighted by the user as an image
        '===========================================================
        Dim rctScreenRect = Screen.PrimaryScreen.Bounds
        Dim imgRetVal As Image = Nothing
        Dim taRetVal As TextArea = Nothing


        '== Get screen area as bitmap ==
        Using bmpScreenArea As New Bitmap(rctScreenRect.Width, rctScreenRect.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb)

            '== Copy screen area ==
            Using grGraphics As Graphics = Graphics.FromImage(bmpScreenArea)
                grGraphics.CopyFromScreen(0, 0, 0, 0, bmpScreenArea.Size)
            End Using

            '== Set copied area to image, depending on user action (ie. user did not press escape) ==
            Using snpSnipper = New Snipper(bmpScreenArea)
                If snpSnipper.ShowDialog() = DialogResult.OK Then imgRetVal = snpSnipper.Image
                taRetVal = New TextArea(0, snpSnipper.rctSelectedArea, imgRetVal)
            End Using
        End Using

        Return taRetVal
        'Return imgRetVal

    End Function

    Public Property Image() As Image
        ' Property to hold screenshot as image
        '=====================================

        Get
            Return imgSnipImage
        End Get

        Set(NewImage As Image)
            imgSnipImage = NewImage
        End Set

    End Property

    Public Property SelectedArea() As Rectangle
        ' Property to hold screen area which holds image
        '===============================================

        Get
            Return rctSelectedArea
        End Get

        Set(NewSelectedArea As Rectangle)
            rctSelectedArea = NewSelectedArea
        End Set

    End property

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        ' Start snip on mouse-down event
        '===============================

        '== Exit if mouse button is not down ==
        If e.Button <> MouseButtons.Left Then Return

        pntStart = e.Location
        rctSelectedArea = New Rectangle(e.Location, New Size(0, 0))
        Me.Invalidate()

    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        ' Modify selection on mouse-move event
        '=====================================
        Dim intXLeft As Integer
        Dim intYTop As Integer
        Dim intXRight As Integer
        Dim intYBottom As Integer


        '== Exit if mouse button is not down ==
        If e.Button <> MouseButtons.Left Then Return

        '== Set selected area according to mouse position ==
        intXLeft = Math.Min(e.X, pntStart.X)
        intXRight = Math.Max(e.X, pntStart.X)
        intYTop = Math.Min(e.Y, pntStart.Y)
        intYBottom = Math.Max(e.Y, pntStart.Y)

        rctSelectedArea = New Rectangle(intXLeft, intYTop, intXRight - intXLeft, intYBottom - intYTop)

        Me.Invalidate()

    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        ' Complete snipping on mouse-up event
        '====================================

        CopyWithoutUser()

    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        ' Draw current selection
        '=======================
        Dim intXLeft As Integer
        Dim intXRight As Integer
        Dim intYTop As Integer
        Dim intYBottom As Integer


        '== Set co-ordinates ==
        intXLeft = rctSelectedArea.X
        intXRight = rctSelectedArea.X + rctSelectedArea.Width
        intYTop = rctSelectedArea.Y
        intYBottom = rctSelectedArea.Y + rctSelectedArea.Height

        '== Highlight selected area ==
        Using brBrush As Brush = New SolidBrush(Color.FromArgb(120, Color.White))
            e.Graphics.FillRectangle(brBrush, New Rectangle(0, 0, intXLeft, Me.Height))
            e.Graphics.FillRectangle(brBrush, New Rectangle(intXRight, 0, Me.Width - intXRight, Me.Height))
            e.Graphics.FillRectangle(brBrush, New Rectangle(intXLeft, 0, intXRight - intXLeft, intYTop))
            e.Graphics.FillRectangle(brBrush, New Rectangle(intXLeft, intYBottom, intXRight - intXLeft, Me.Height - intYBottom))
        End Using

        '== Draw outline ==
        Using penRectangle As New Pen(Color.Red, 3)
            e.Graphics.DrawRectangle(penRectangle, rctSelectedArea)
        End Using

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        ' Allow user to cancel snip with Escape key
        '==========================================

        If keyData = Keys.Escape Then Me.DialogResult = DialogResult.Cancel
        Return MyBase.ProcessCmdKey(msg, keyData)

    End Function

End Class
