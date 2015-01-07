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
Imports System.Xml
Imports System.Drawing.Imaging


Public Class frmMain

    Private Const UNDEFINED As Integer = 0
    Private Const TREE_VIEW As Integer = 1
    Private Const LIST_VIEW As Integer = 2
    Private Const LOG_TEXT As Integer = 3

    ' Structure to hold imported xml data to build a saved tree
    Private xmlTree As New XmlDocument

    ' Class to hold mouse data
    Private WithEvents mdMouse As MouseData

    ' Begin capture of mouse data
    Private blnIsMultClicks As Boolean = False
    Private blnIsCapturing As Boolean = False
    Private blnIsDoubleClick As Boolean = False
    Private blnIsStatic As Boolean = False
    Private blnIsFile As Boolean = False
    Public blnIsLoop As Boolean = False

    Public intDefaultRepeat As Integer = 1

    Private intTestNumber As Integer = 0

    ' Log file
    Public blnIsAutoSave As Boolean = False
    Public strLogFile As String = ""
    Private swResultFile As StreamWriter

    ' Event data
    Private strNewData As String = ""
    Public NewLoopData As New LoopEvent     ' Needs to be public as its values will be passed from the Loop Event form

    ' Pause between mouse events - necessary to allow copy/pasting to function
    Public intPause As Integer = 0

    ' Select or deselect all before every single event
    Public blnIsGlobalSelectAll As Boolean = False
    Public blnIsGlobalDeselectAll As Boolean = False

    ' Class to control mouse and send data to GUI
    Private mcMouseController As New MouseController

    ' Has 'Cancel' button been clicked?
    Private blnIsCancelled As Boolean = False
    Private blnIsPaused As Boolean = True

    ' Data to be copy/pasted
    Private dicCopiedItems As New Dictionary(Of String, String)

    ' Used to indicate data should be removed after cut/paste has taken place
    Private arlCutList As New ArrayList

    'Dictionary to hold data from OCR of snips
    Public ScreenSnips As New Dictionary(Of Integer, TextArea)
    Public SnipCount As Integer = 0
    Private snSnipper As Snipper


    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Initaiate data, instantiate objects and obtain registry settings
        '=================================================================

        ' Create new MouseData instance to read mouse details
        mdMouse = New MouseData

        tvEvent.Nodes.Add("0", "NewTest", 4)

        ' Get previous window settings from registry
        Me.Top = GetSetting("WindowClicker", "FormLocation", "Top", "50")
        Me.Left = GetSetting("WindowClicker", "FormLocation", "Left", "100")
        Me.Height = GetSetting("WindowClicker", "FormSize", "Height", "515")
        Me.Width = GetSetting("WindowClicker", "FormSize", "Width", "835")
        Me.tvEvent.Width = GetSetting("WindowClicker", "TreeViewSize", "Width", "260")
        Me.lvDetail.Height = GetSetting("WindowClicker", "ListViewSize", "Height", "200")

        ' Reset any bad/corrupted registry entries
        If (Me.Top < 0) Or (Me.Top > Screen.PrimaryScreen.Bounds.Height - 50) Then Me.Top = 50
        If (Me.Left < 0) Or (Me.Left > Screen.PrimaryScreen.Bounds.Width - 50) Then Me.Left = 100

        ' Get general settings from Registry
        OCRReminder = GetSetting("WindowClicker", "Settings", "OCRReminder", "1")

        ' Initiate Tesseract
        trTextReader = New TextReader()

        ' Get OCR details from registry
        trTextReader.ImageDirectory = GetSetting("WindowClicker", "OCR", "TempImgStore", Path.GetTempPath & "WCScans")
        trTextReader.TesseractLocation = GetSetting("WindowClicker", "OCR", "TesseractPath", "C:\tesseract\tesseract.exe")
        trTextReader.TesseractArgs = GetSetting("WindowClicker", "OCR", "TesseractParams", "-l eng")

        CheckOCRExists()

        ' Assign context menus
        tvEvent.ContextMenuStrip = cmTreeView
        lvDetail.ContextMenuStrip = cmListView

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Save settings to registry
        '==========================

        ' Save window size and location to Registry
        SaveSetting("WindowClicker", "FormLocation", "Top", Me.Top)
        SaveSetting("WindowClicker", "FormLocation", "Left", Me.Left)
        SaveSetting("WindowClicker", "FormSize", "Height", Me.Height)
        SaveSetting("WindowClicker", "FormSize", "Width", Me.Width)

        ' Save control sizes to Registry
        SaveSetting("WindowClicker", "TreeViewSize", "Width", Me.tvEvent.Width)
        SaveSetting("WindowClicker", "ListViewSize", "Height", Me.lvDetail.Height)

        ' Save OCR details to registry
        SaveSetting("WindowClicker", "OCR", "TempImgStore", trTextReader.ImageDirectory)
        SaveSetting("WindowClicker", "OCR", "TesseractPath", trTextReader.TesseractLocation)
        SaveSetting("WindowClicker", "OCR", "TesseractParams", trTextReader.TesseractArgs)

        ' Save general settings to Registry
        SaveSetting("WindowClicker", "Settings", "OCRReminder", OCRReminder)

    End Sub

    Private Sub frmMain_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        'Cleanly dispose of objects and tidy up
        '======================================

        ' Cleanly dispose of global objects and global data
        RemoveHandler mdMouse.LeftButtonClick, AddressOf MouseData_MouseLeftButtonClick
        RemoveHandler mdMouse.RightButtonClick, AddressOf MouseData_MouseRightButtonClick

        mdMouse.Dispose()

    End Sub

    Private Sub frmMain_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        ' Size the progress bar to the form
        '==================================
        'On Error Resume Next

        'tslProgressBar.Width = Me.Width - 65

    End Sub

    Private Sub MouseData_MouseLeftButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mdMouse.LeftButtonClick
        ' Collect data for left mouse click
        '==================================
        Dim geEvent As New GuiEvent

        If (blnIsCapturing = False And blnIsMultClicks = False) Then Exit Sub

        geEvent.X = e.X
        geEvent.Y = e.Y

        AddNewEvent(geEvent)

    End Sub
    Private Sub MouseData_MouseRightButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mdMouse.RightButtonClick
        ' Collect data for right mouse click
        '==================================
        Dim geEvent As New GuiEvent

        If (blnIsCapturing = False And blnIsMultClicks = False) Then Exit Sub

        geEvent.X = e.X
        geEvent.Y = e.Y
        geEvent.EventType = GuiEvent.RIGHT_CLICK

        AddNewEvent(geEvent)

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        ' Show about box
        '===============
        frmAbout.ShowDialog()
    End Sub

    Private Sub btnClick_Click(sender As System.Object, e As System.EventArgs) Handles btnClick.Click
        ' Collect data: type of click (left or right) and position
        '=========================================================

        '== Set the mouse hook listener to active status ==
        blnIsCapturing = True

    End Sub

    Private Sub AddNewEvent(ByVal NewEvent As GuiEvent)
        ' Add new event to collection and to gui
        '=======================================
        Dim strNodeName As String = ""
        Dim strImageTag As String = "imgClick"    ' Click image


        'Add any extra data to the event
        If blnIsDoubleClick Then
            NewEvent.EventType = GuiEvent.DOUBLE_CLICK
        ElseIf blnIsFile Then
            NewEvent.DataFile = strNewData
            NewEvent.EventType = GuiEvent.PASTE_FILE_DATA
            strImageTag = "imgFile"
        ElseIf blnIsStatic Then
            NewEvent.StaticText = strNewData
            NewEvent.EventType = GuiEvent.PASTE_STATIC_TEXT
            strImageTag = "imgText"
        ElseIf blnIsLoop Then
            NewEvent.LoopData = NewLoopData
            NewEvent.EventType = GuiEvent.PASTE_LOOP_NUMBER
            strImageTag = "imgLoop"
        End If

        strNodeName = "Event" & EventIndex

        ' Add the event to the collection
        GuiEvents.Add(strNodeName, NewEvent)

        ResetDataCapture()

        ' Add the event into the gui
        AddNewNode(strNodeName, strImageTag)

    End Sub

    Private Sub AddNewNode(ByVal NodeName As String, ByVal ImageTag As String)
        ' Add the new node into the treeview
        '===================================

        If tvEvent.SelectedNode Is Nothing Then
            tvEvent.Nodes(0).Nodes.Add(CStr(EventIndex), NodeName, ImageTag)
            tvEvent.Nodes(0).Expand()
        Else
            tvEvent.SelectedNode.Nodes.Add(CStr(EventIndex), NodeName, ImageTag)
            tvEvent.SelectedNode.Expand()
            AddListNode(CStr(EventIndex), NodeName)
        End If

        tslStatus.Text = "Events: " & EventIndex
        EventIndex += 1

    End Sub

    Private Sub btnStatic_Click(sender As System.Object, e As System.EventArgs) Handles btnStatic.Click
        ' Collect data: static text to copy and for left mouse click (position to copy to)
        '================================================================================

        '== Obtain a string from user ==
        strNewData = InputBox("Enter the static text to be pasted into the client and choose a location to paste to.")

        '== Small pause to prevent any accidental extra click being recorded ==
        System.Threading.Thread.Sleep(200)

        '== Set the mouse hook listener to active status ==
        blnIsCapturing = True
        blnIsStatic = True

    End Sub

    Private Sub btnFile_Click(sender As System.Object, e As System.EventArgs) Handles btnFile.Click
        ' Collect data: static text to copy and for left mouse click (position to copy to)
        '================================================================================

        '== Get filename from user ==
        With ofdOpenFileDialog
            .Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"

            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                strNewData = .FileName
                If Not (IO.File.Exists(strNewData)) Then
                    strNewData = ""
                    Exit Sub
                End If
            End If

            If strNewData.Trim = "" Then Exit Sub
        End With

        '== Small pause to prevent any accidental extra click being recorded ==
        System.Threading.Thread.Sleep(200)

        '== Set the mouse hook listener to active status ==
        blnIsCapturing = True
        blnIsFile = True

    End Sub

    Private Sub btnLoop_Click(sender As System.Object, e As System.EventArgs) Handles btnLoop.Click
        ' Create a new loop event
        '========================

        ' Display loop dialog to obtain results
        frmLoopEvent.ShowDialog(Me)

        '== Small pause to prevent any accidental extra click beinmg recorded ==
        System.Threading.Thread.Sleep(200)

        '== Set the mouse hook listener to active status ==
        If blnIsLoop = True Then blnIsCapturing = True

    End Sub

    Private Sub ResetDataCapture()
        ' Clear all data capture variables
        '=================================

        'Reset booleans
        blnIsCapturing = False
        blnIsDoubleClick = False
        blnIsStatic = False
        blnIsLoop = False
        blnIsFile = False

        ' Event data
        strNewData = ""
        NewLoopData = New LoopEvent

    End Sub

    Private Sub btnGo_Click(sender As System.Object, e As System.EventArgs) Handles btnGo.Click
        ' Recreate test events in order determined by tree
        '=================================================
        Dim intLogReply As Integer


        If blnIsPaused Then
            ' Set variables
            blnIsPaused = False
            blnIsCancelled = False

            ' Change button titles, etc.
            btnCancel.Enabled = True
            btnGo.Text = "Pause"
            Me.Refresh()

            'Clear log
            If intTestNumber = 0 Then

                tslProgressBar.Value = 0
                tslProgressBar.Maximum = GuiEvents.Count
                txtLog.Text = ""

                ' Switch TextReader to Compare mode 
                trTextReader.Compare = True

                ChangedWindows.Clear()
                CreatedWindows.Clear()

                '== If logs are to be written to file check we have a filename ==
                If blnIsAutoSave = True And strLogFile.Trim = "" Then

                    '== Get filename from user ==
                    sfdSaveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"

                    If sfdSaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        strLogFile = sfdSaveFileDialog.FileName
                    End If
                    If strLogFile.Trim = "" Then
                        intLogReply = MsgBox("No log file path has been provided. Do you wish to write logs to file?", MsgBoxStyle.YesNoCancel, "No Log File!")
                        If intLogReply = vbNo Then
                            blnIsAutoSave = False
                        Else
                            Exit Sub
                        End If
                    End If
                End If

                ' Open log file if necessary
                If blnIsLogSaved Then
                    Try
                        '== Open file ==
                        swResultFile = New StreamWriter(strLogFile)
                    Catch exError As Exception
                        MsgBox(exError.Message, MsgBoxStyle.Critical, "Error")
                        tslProgress.Text = ""
                    End Try
                End If
            End If

            ' Run tests
            RunTest(tvEvent.Nodes(0))
        Else
            blnIsPaused = True
            btnGo.Text = "Go"
            Me.Refresh()
        End If

    End Sub

    Private Sub RunTest(ByVal TestNode As TreeNode)
        ' Recurse through the tree until all events have been executed.
        ' This function calls ProcessNodeChildren which recursively calls  
        ' this function until all node children have been processed.
        '=============================================================
        Dim intChildren As Integer = 0
        Dim intIndex As Integer = 0
        Dim geEvent As New GuiEvent


        '== Get number of child nodes ==
        intChildren = TestNode.Nodes.Count

        '== Pause, if required ==
        System.Threading.Thread.Sleep(intPause)

        '== Terminate proccess? ==
        If blnIsCancelled Then
            btnCancel.Enabled = False
            trTextReader.Compare = False
            Exit Sub
        End If

        '== Perform action for current node, as long as it's not the root ==
        If TestNode.Level > 0 Then
            geEvent = GuiEvents(TestNode.Text)
            tslProgressBar.Value += 1

            Select Case geEvent.EventType

                Case GuiEvent.PASTE_LOOP_NUMBER
                    ' == Set up a loop using user-supplied data ==
                    For intIndex = geEvent.LoopData.StartVal To geEvent.LoopData.EndVal Step geEvent.LoopData.StepVal
                        DoGuiEvent(TestNode.Text, "Paste Loop Number", CStr(intIndex))
                        '== Recurse through all available subnodes while inside the loop ==
                        If intChildren > 0 Then
                            ProcessNodeChildren(TestNode)
                        End If
                    Next

                Case GuiEvent.PASTE_FILE_DATA
                    '== Get each line from file ==
                    For Each strLine In File.ReadAllLines(geEvent.DataFile)
                        DoGuiEvent(TestNode.Text, "Paste Data From File", strLine)
                        '== Recurse through all available subnodes while inside the loop ==
                        If intChildren > 0 Then
                            ProcessNodeChildren(TestNode)
                        End If
                    Next

                Case Else
                    DoGuiEvent(TestNode.Text)
                    '== Recurse through all available subnodes ==
                    If intChildren > 0 Then
                        ProcessNodeChildren(TestNode)
                    End If
            End Select

        Else
            '== Recurse through all available subnodes ==
            If intChildren > 0 Then
                ProcessNodeChildren(TestNode)
            End If
        End If

        blnIsPaused = True
        btnGo.Text = "Go"
        btnCancel.Enabled = False
        intTestNumber = 0

        '== Close log file if necessary ==
        If blnIsAutoSave = True Then swResultFile.Close()

    End Sub

    Private Sub ProcessNodeChildren(ByVal TestNode As TreeNode)
        ' Iterate through a node's children and process each one
        '=======================================================

        For Each tnNode As TreeNode In TestNode.Nodes
            RunTest(tnNode)
            If blnIsCancelled Then
                btnCancel.Enabled = False
                Exit Sub
            End If
            Application.DoEvents()
        Next

    End Sub

    Private Sub DoGuiEvent(ByVal NodeName As String, Optional ByVal TestType As String = "Click", Optional ByVal TestData As String = "")
        ' Perform action for relevant node
        '=================================
        Dim intIndex As Integer = 0
        Dim geEvent As New GuiEvent
        Dim strLogText As String = ""


        '== Identify the event ==
        geEvent = GuiEvents(NodeName)

        If (geEvent.EventType = GuiEvent.DOUBLE_CLICK Or geEvent.EventType = GuiEvent.RIGHT_CLICK Or geEvent.EventType = GuiEvent.PASTE_STATIC_TEXT) Then
            Select Case geEvent.EventType
                Case GuiEvent.DOUBLE_CLICK
                    TestType = "Double-Click"
                Case (GuiEvent.RIGHT_CLICK)
                    TestType = "Right-Click"
                Case GuiEvent.PASTE_STATIC_TEXT
                    TestType = "Paste Static Text"
            End Select
        End If

        '== Log the test details ==
        intTestNumber += 1
        strLogText &= "Executing Test No. " & intTestNumber & vbNewLine & "Node Name: " & NodeName & vbNewLine
        strLogText &= "Action: " & TestType & vbNewLine
        If TestData <> "" Then strLogText &= "Test Data: " & TestData & vbNewLine
        strLogText &= "Time: " & DateTime.Now.ToString() & vbNewLine
        strLogText &= vbNewLine

        txtLog.Text &= strLogText
        If blnIsAutoSave = True Then swResultFile.Write(strLogText)


        '== Carry out the required action ==
        While intIndex < geEvent.Repeat

            Select Case geEvent.EventType
                Case GuiEvent.LEFT_CLICK
                    mcMouseController.LeftClick(Me, geEvent.X, geEvent.Y)

                Case GuiEvent.DOUBLE_CLICK
                    mcMouseController.LeftClick(Me, geEvent.X, geEvent.Y)
                    mcMouseController.LeftClick(Me, geEvent.X, geEvent.Y)

                Case (GuiEvent.RIGHT_CLICK)
                    mcMouseController.RightClick(Me, geEvent.X, geEvent.Y)

                Case GuiEvent.PASTE_LOOP_NUMBER, GuiEvent.PASTE_FILE_DATA
                    mcMouseController.LeftClick(Me, geEvent.X, geEvent.Y)
                    PasteData(TestData, geEvent.SelectAll, geEvent.DeselectAll)

                Case GuiEvent.PASTE_STATIC_TEXT
                    mcMouseController.LeftClick(Me, geEvent.X, geEvent.Y)
                    PasteData(geEvent.StaticText, geEvent.SelectAll, geEvent.DeselectAll)
            End Select

            System.Threading.Thread.Sleep(10)
            intIndex += 1
        End While

    End Sub

    Private Sub PasteData(ByVal ItemData As String, ByVal SelectAll As Boolean, ByVal DeSelectAll As Boolean)
        ' Send appropriate keyboard shortcuts to select or deselect text in desired location
        ' and post the data which has been provided. The sleep between steps is necessary to
        ' ensure things happen in the correct order.
        ' Different actions are required depending on whether the line from the file is blank
        ' or not as clipboard data cannot be set to a null string.
        '===================================================================================

        ' Place data on clipboard
        System.Threading.Thread.Sleep(40)
        If ItemData <> vbNullString And ItemData <> "" Then
            Clipboard.SetText(ItemData)
            System.Threading.Thread.Sleep(40)
        End If

        ' Is data currently in the location to be removed or preserved?
        If SelectAll Or blnIsGlobalSelectAll Then
            SendKeys.Send("^a")
        ElseIf DeSelectAll Or blnIsGlobalDeselectAll Then
            SendKeys.Send("^a")
            SendKeys.Send("{LEFT}")
            SendKeys.Send("{RIGHT}")
        End If

        ' Paste data
        System.Threading.Thread.Sleep(40)
        If ItemData <> vbNullString And ItemData <> "" Then
            SendKeys.Send("^v")
        Else
            SendKeys.Send("{DELETE}")
        End If


    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        ' Set cancelled status to true - this will set a trigger to break out of current test
        '====================================================================================
        blnIsCancelled = True
    End Sub

    Private Sub tvEvent_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvEvent.AfterSelect
        ' Show the node's children in the list view
        '==========================================

        '== Clear previous nodes from the listview ==
        lvDetail.Items.Clear()

        '== Add children of newly selected node to listview ==
        For Each tnNode In e.Node.Nodes
            AddListNode(tnNode.Name, tnNode.Text)
        Next

    End Sub

    Private Sub AddListNode(ByVal NodeName As String, ByVal NodeText As String)
        ' Add all details of latest node into listview
        '=============================================
        Dim geEvent As New GuiEvent
        Dim lviItem As ListViewItem
        Dim strImageKey As String = "imgClick"    ' Click image

        geEvent = GuiEvents.Item(NodeText)

        '== Add to listview ==
        lviItem = New ListViewItem
        lviItem.Name = NodeName
        lviItem.Text = NodeText

        Select Case geEvent.EventType
            Case GuiEvent.LEFT_CLICK
                lviItem.SubItems.Add("Left Click")
                lviItem.SubItems.Add(geEvent.Repeat)
            Case GuiEvent.DOUBLE_CLICK
                lviItem.SubItems.Add("Double Click")
                lviItem.SubItems.Add(geEvent.Repeat)
            Case GuiEvent.RIGHT_CLICK
                lviItem.SubItems.Add("Right Click")
                lviItem.SubItems.Add(geEvent.Repeat)
            Case GuiEvent.PASTE_LOOP_NUMBER
                lviItem.SubItems.Add("Loop")
                lviItem.SubItems.Add(geEvent.Repeat)
                lviItem.SubItems.Add("Start: " & geEvent.LoopData.StartVal & "  End: " & geEvent.LoopData.EndVal & "  Step: " & geEvent.LoopData.StepVal)
                strImageKey = "imgLoop"
            Case GuiEvent.PASTE_FILE_DATA
                lviItem.SubItems.Add("File Content")
                lviItem.SubItems.Add(geEvent.Repeat)
                lviItem.SubItems.Add(geEvent.DataFile)
                strImageKey = "imgFile"
            Case GuiEvent.PASTE_STATIC_TEXT
                lviItem.SubItems.Add("Static Text")
                lviItem.SubItems.Add(geEvent.Repeat)
                lviItem.SubItems.Add(geEvent.StaticText)
                strImageKey = "imgText"
        End Select

        lviItem.ImageKey = strImageKey
        lvDetail.Items.Add(lviItem)

    End Sub

    Private Sub btnDoubleClick_Click(sender As System.Object, e As System.EventArgs) Handles btnDoubleClick.Click
        ' Collect data: double-click (left) and position
        '===============================================

        '== Set the mouse hook listener to active status ==
        blnIsCapturing = True
        blnIsDoubleClick = True

    End Sub

    Private Sub btnClickSequence_Click(sender As System.Object, e As System.EventArgs) Handles btnClickSequence.Click
        ' Collect a series of mouse clicks until this button is pressed again
        '====================================================================
        Dim nodLastNode As TreeNode
        Dim arrNodes As TreeNode()

        blnIsMultClicks = Not blnIsMultClicks

        If blnIsMultClicks Then
            btnClickSequence.Text = "Stop"
        Else
            '== Extra action to prevent recording of the 'Multi Clicks' button off-click ==
            arrNodes = tvEvent.Nodes.Find(EventIndex - 1, True)
            nodLastNode = arrNodes(0)
            nodLastNode.Remove()

            btnClickSequence.Text = "Mult Clicks"
        End If

    End Sub

    Private Sub LargeIconsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LargeIconsToolStripMenuItem.Click
        ' Set view for list box and ensure menus are appropriately checked
        '=================================================================

        If LargeIconsToolStripMenuItem.Checked Then
            '== Uncheck other menus ==
            SmallIconsToolStripMenuItem.Checked = False
            ListToolStripMenuItem.Checked = False
            DetailsToolStripMenuItem.Checked = False

            '== Set view ==
            lvDetail.View = View.LargeIcon
        End If

    End Sub

    Private Sub SmallIconsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SmallIconsToolStripMenuItem.Click
        ' Set view for list box and ensure menus are appropriately checked
        '=================================================================

        If SmallIconsToolStripMenuItem.Checked Then
            '== Uncheck other menus ==
            LargeIconsToolStripMenuItem.Checked = False
            ListToolStripMenuItem.Checked = False
            DetailsToolStripMenuItem.Checked = False

            '== Set view ==
            lvDetail.View = View.SmallIcon
        End If

    End Sub

    Private Sub ListToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ListToolStripMenuItem.Click
        ' Set view for list box and ensure menus are appropriately checked
        '=================================================================

        If ListToolStripMenuItem.Checked Then
            '== Uncheck other menus ==
            LargeIconsToolStripMenuItem.Checked = False
            SmallIconsToolStripMenuItem.Checked = False
            DetailsToolStripMenuItem.Checked = False

            '== Set view ==
            lvDetail.View = View.List
        End If

    End Sub

    Private Sub DetailsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DetailsToolStripMenuItem.Click
        ' Set view for list box and ensure menus are appropriately checked
        '=================================================================

        If DetailsToolStripMenuItem.Checked Then
            '== Uncheck other menus ==
            LargeIconsToolStripMenuItem.Checked = False
            SmallIconsToolStripMenuItem.Checked = False
            ListToolStripMenuItem.Checked = False

            '== Set view ==
            lvDetail.View = View.Details
        End If

    End Sub

    Private Sub SaveLogToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveLogToolStripMenuItem.Click
        ' Save log details to file
        '=========================
        Dim strResultsFile As String = ""
        Dim strResults As String = ""

        Dim intIndex As Integer = 0


        '== Get filename from user ==
        sfdSaveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"

        If sfdSaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            strResultsFile = sfdSaveFileDialog.FileName
        End If
        If strResultsFile.Trim = "" Then Exit Sub


        Try
            '== Open file ==
            swResultFile = New StreamWriter(strResultsFile)

            tslProgressBar.Maximum = txtLog.Lines.Count

            '== Write results ==
            For Each strLine In txtLog.Lines
                swResultFile.WriteLine(strLine)
                intIndex += 1
                tslProgress.Text = "Saving line: " & intIndex
                tslProgressBar.Value = intIndex
            Next

            '== Close file ==
            swResultFile.Close()
            tslProgress.Text = ""

        Catch exError As Exception
            MsgBox(exError.Message, MsgBoxStyle.Critical, "Error")
            tslProgress.Text = ""
        End Try

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NewTestToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewTestToolStripMenuItem.Click
        ' Wipe all previous data and await new entries
        '=============================================
        NewData()
    End Sub

    Private Sub OpenPreviousTestToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenPreviousTestToolStripMenuItem.Click
        ' Wipe all previous data and load new tests
        '==========================================
        Dim strResultsFile As String = ""
        Dim strName As String = ""
        Dim strCopiedNode As String = ""
        Dim intCopies As Integer = 0
        Dim intIndex As Integer = 0
        Dim intPointer As Integer = 0

        Dim xrReader As XmlTextReader
        Dim xntNodeType As XmlNodeType
        Dim geEvent As New GuiEvent
        Dim nwNewWindow As New NewWindow("", True)
        Dim mwMonitoredWindow As New MonitoredWindow("", 0)


        '== Get filename from user ==
        With ofdOpenFileDialog
            .Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"

            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                strResultsFile = .FileName
                If Not (IO.File.Exists(strResultsFile)) Then Exit Sub
            End If

            If strResultsFile.Trim = "" Then Exit Sub
        End With


        '== Remove any previous results ==
        NewData()

        '== Load results from file ==
        Try

            xrReader = New XmlTextReader(strResultsFile)

            Dim fiFileInfo As New FileInfo(strResultsFile)

            '== Display progress to screen as appropriate ==
            tslProgress.Text = "Importing tests from XML file."
            tslProgressBar.Maximum = fiFileInfo.Length


            '== Loop through each XML element
            While (xrReader.Read())

                xntNodeType = xrReader.NodeType

                'if node type was element
                If (xntNodeType = XmlNodeType.Element) Then

                    With xrReader

                        '== If we have a new event element, renew the GuiEvent object ==
                        If .NodeType <> XmlNodeType.EndElement And .Name = "Event" Then geEvent = New GuiEvent

                        '== Populate data from each tag ==
                        If (.Name = "Name") Then strName = .ReadInnerXml.ToString()
                        If (.Name = "EventType") Then geEvent.EventType = CInt(.ReadInnerXml.ToString())
                        If (.Name = "X") Then geEvent.X = CInt(.ReadInnerXml.ToString())
                        If (.Name = "Y") Then geEvent.Y = CInt(.ReadInnerXml.ToString())

                        If (.Name = "StaticText") Then geEvent.StaticText = .ReadInnerXml.ToString()
                        If (.Name = "Filename") Then geEvent.DataFile = .ReadInnerXml.ToString()

                        If (.Name = "Start") Then geEvent.LoopData.StartVal = CInt(.ReadInnerXml.ToString())
                        If (.Name = "End") Then geEvent.LoopData.EndVal = CInt(.ReadInnerXml.ToString())
                        If (.Name = "Step") Then geEvent.LoopData.StepVal = CInt(.ReadInnerXml.ToString())

                        If (.Name = "Repeat") Then geEvent.Repeat = CInt(.ReadInnerXml.ToString())
                        If (.Name = "Select") Then geEvent.SelectAll = CBool(.ReadInnerXml.ToString())
                        If (.Name = "Deselect") Then geEvent.DeselectAll = CBool(.ReadInnerXml.ToString())

                        '== Add the GuiEvent to the dictionary
                        If .NodeType = XmlNodeType.EndElement And .Name = "Event" Then
                            If strName.Trim <> "" Then GuiEvents.Add(strName, geEvent)
                        End If

                        '== Build array of copied nodes ==
                        If (.Name = "NodeName") Then
                            strCopiedNode = .ReadInnerXml.ToString
                        End If
                        If (.Name = "Copies") Then
                            intCopies = CInt(.ReadInnerXml.ToString)
                            If strCopiedNode.Trim <> "" Then CopiedEvents.Add(strCopiedNode, intCopies)
                        End If

                        '== Build tree structure from remaining XML ==
                        If (.Name = "Node") Then
                            tvEvent.Nodes.Clear()
                            BuildTreeFromXML(.ReadSubtree)
                        End If

                        '== Restore any monitored windows to the GUI monitor ==
                        '== If we have a new NewWindow element, renew the NewWindow object ==
                        If .NodeType <> XmlNodeType.EndElement And .Name = "NewWindow" Then nwNewWindow = New NewWindow("", True)
                        If (.Name = "WindowTitle") Then nwNewWindow.WindowTitle = .ReadInnerXml.ToString()
                        If (.Name = "MatchFullTitle") Then nwNewWindow.IsFullTitle = CBool(.ReadInnerXml.ToString())

                        '== If we have a new MonitoredWindow element, renew the MonitoredWindow object ==
                        If .NodeType <> XmlNodeType.EndElement And .Name = "ExistingWindow" Then mwMonitoredWindow = New MonitoredWindow("", 0)
                        If (.Name = "hWnd") Then
                            intPointer = CInt(.ReadInnerXml.ToString())
                            mwMonitoredWindow.hWnd = New IntPtr(intPointer)
                        End If
                        If (.Name = "CurrentTitle") Then mwMonitoredWindow.OriginalText = .ReadInnerXml.ToString()

                    End With

                    intIndex += 10
                    tslProgress.Text = "Importing tests: " & strName
                    tslProgressBar.Value = intIndex
                End If

            End While

            xrReader.Close()

            ' If the file had no nodes at all then provide a root node
            If tvEvent.GetNodeCount(True) < 1 Then tvEvent.Nodes.Add(0, "NewTest")

            '== Notify user of success ==
            tslProgress.Text = "Events: " & GuiEvents.Count
            tslProgressBar.Value = 0

        Catch exError As Exception
            MsgBox(exError.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub BuildTreeFromXML(ByVal ChildNodeXML As XmlReader, Optional ByVal NodeKey As String = "0")
        ' Recursively build tree from nested XML elements
        '================================================
        Dim xntNodeType As XmlNodeType
        Dim nodParentNodeArray As TreeNode()

        Dim strKey As String = ""
        Dim strName As String = ""
        Dim intImageIndex As Integer = 0

        '== Skip over the first node as this the root 'Node' node ==
        ChildNodeXML.Read()

        '== Loop through each XML element
        While (ChildNodeXML.Read())

            xntNodeType = ChildNodeXML.NodeType

            ' Check if node type is element
            If (xntNodeType = XmlNodeType.Element) Then

                With ChildNodeXML

                    If (.Name = "NodeKey") Then strKey = .ReadInnerXml.ToString()
                    If (.Name = "NodeName") Then strName = .ReadInnerXml.ToString()

                    If .NodeType = XmlNodeType.EndElement And .Name = "NodeData" Then
                        If strKey = "0" Then
                            tvEvent.Nodes.Add(strKey, strName, 4)
                        Else
                            ' Set the image type for this node
                            Select Case GuiEvents.Item(strName).EventType
                                Case GuiEvent.PASTE_LOOP_NUMBER
                                    intImageIndex = 1
                                Case GuiEvent.PASTE_FILE_DATA
                                    intImageIndex = 2
                                Case GuiEvent.PASTE_STATIC_TEXT
                                    intImageIndex = 3
                            End Select

                            ' Locate the parent node which has been passed in and add the next node as its child
                            nodParentNodeArray = tvEvent.Nodes.Find(NodeKey, True)
                            nodParentNodeArray(0).Nodes.Add(strKey, strName, intImageIndex)
                        End If
                        ' Update event count
                        EventIndex += 1
                    End If

                    If .NodeType <> XmlNodeType.EndElement And (.Name = "Node") Then BuildTreeFromXML(.ReadSubtree, strKey)

                End With
            End If
        End While

    End Sub

    Private Sub SaveTestToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveTestToolStripMenuItem.Click
        ' Save the current test data and structure
        '=========================================
        Dim xwsSettings As New XmlWriterSettings()
        Dim xwWriter As XmlWriter

        Dim intIndex As Integer = 0
        Dim strResultsFile As String = ""


        '== Exit if tests ==
        If tvEvent.Nodes.Count < 1 Then Exit Sub


        '== Get filename from user ==
        With sfdSaveFileDialog
            .Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"

            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                strResultsFile = .FileName
            End If

            If strResultsFile.Trim = "" Then Exit Sub
        End With



        '== Create file and write output ==
        Try
            xwWriter = XmlWriter.Create(strResultsFile, xwsSettings)


            ' Use indention for the xml output
            xwsSettings.Indent = True

            With xwWriter

                ' Begin document with Xml declaration
                .WriteStartDocument()

                ' Write a comment.
                .WriteComment("XML Export of WindowClicker test structure: " & tvEvent.Nodes.Count - 1 & " test events.")

                ' Write the root element
                .WriteStartElement("WindowClickerData")
                ' Write the start element for the event collection
                .WriteStartElement("EventCollection")

                '== Display progress to screen as appropriate ==
                tslProgress.Text = "Exporting tests to XML."
                tslProgressBar.Value = 0
                tslProgressBar.Maximum = GuiEvents.Count


                ' Loop through events and write data for each one
                For Each itmItem As KeyValuePair(Of String, GuiEvent) In GuiEvents

                    '== Get the test event and its key ==
                    Dim strKey As String = itmItem.Key
                    Dim geEvent As GuiEvent = itmItem.Value

                    .WriteStartElement("Event")

                    .WriteStartElement("Name")
                    .WriteString(itmItem.Key)
                    .WriteEndElement()

                    .WriteStartElement("EventType")
                    .WriteString(geEvent.EventType)
                    .WriteEndElement()
                    .WriteStartElement("X")
                    .WriteString(geEvent.X)
                    .WriteEndElement()
                    .WriteStartElement("Y")
                    .WriteString(geEvent.Y)
                    .WriteEndElement()

                    .WriteStartElement("StaticText")
                    .WriteString(geEvent.StaticText)
                    .WriteEndElement()
                    .WriteStartElement("Filename")
                    .WriteString(geEvent.DataFile)
                    .WriteEndElement()

                    .WriteStartElement("LoopData")
                    .WriteStartElement("Start")
                    .WriteString(geEvent.LoopData.StartVal)
                    .WriteEndElement()
                    .WriteStartElement("End")
                    .WriteString(geEvent.LoopData.EndVal)
                    .WriteEndElement()
                    .WriteStartElement("Step")
                    .WriteString(geEvent.LoopData.StepVal)
                    .WriteEndElement()  ' End step
                    .WriteEndElement()  ' End LoopData

                    .WriteStartElement("Repeat")
                    .WriteString(geEvent.Repeat)
                    .WriteEndElement()
                    .WriteStartElement("Select")
                    .WriteString(geEvent.SelectAll)
                    .WriteEndElement()
                    .WriteStartElement("Deselect")
                    .WriteString(geEvent.DeselectAll)
                    .WriteEndElement()

                    ' End of this data item
                    .WriteEndElement()  ' End Event

                    intIndex += 1
                    tslProgress.Text = "Saving event: " & intIndex
                    tslProgressBar.Value = intIndex
                Next

                .WriteEndElement()  ' End EventCollection
                intIndex = 0

                '== Write XML for copied nodes ==
                .WriteStartElement("CopiedEvents")

                For Each objEvent As KeyValuePair(Of String, Integer) In CopiedEvents
                    .WriteStartElement("NodeName")
                    .WriteString(objEvent.Key)
                    .WriteEndElement()
                    .WriteStartElement("Copies")
                    .WriteString(objEvent.Value)
                    .WriteEndElement()
                Next
                .WriteEndElement()  ' End CopiedEvents

                '== Write XML for GUI Monitor ==
                .WriteStartElement("GUIMonitor")

                .WriteStartElement("NewWindows")
                For Each objWindow As NewWindow In NewWindows.Values
                    .WriteStartElement("NewWindow")
                    .WriteStartElement("WindowTitle")
                    .WriteString(objWindow.WindowTitle)
                    .WriteEndElement()
                    .WriteStartElement("MatchFullTitle")
                    .WriteString(objWindow.IsFullTitle)
                    .WriteEndElement()
                    .WriteEndElement()
                Next
                .WriteEndElement()  ' End NewWindows

                .WriteStartElement("ExistingWindows")
                For Each objWindow As MonitoredWindow In MonitoredWindows.Values
                    .WriteStartElement("ExistingWindow")
                    .WriteStartElement("hWnd")
                    .WriteString(objWindow.hWnd)
                    .WriteEndElement()
                    .WriteStartElement("CurrentTitle")
                    .WriteString(objWindow.OriginalText)
                    .WriteEndElement()
                    .WriteEndElement()
                Next
                .WriteEndElement()  ' End ExistingWindows
                .WriteEndElement()  ' End GUIMonitor


                '== Display progress to screen as appropriate ==
                tslProgress.Text = "Exporting tree nodes to XML."
                tslProgressBar.Value = 0
                tslProgressBar.Maximum = tvEvent.GetNodeCount(True)

                ' Write the root element for the tree view
                .WriteStartElement("EventTree")

                ' Recursively write any childnodes
                WriteChildNodeXML(xwWriter, tvEvent.Nodes(0), 1)

                ' End of this data item (EventTree)
                .WriteEndElement()  ' End EventTree

                ' Write ending root node and ending for document, close XmlTextWriter
                .WriteEndElement()  ' End WindowClickerData
                .WriteEndDocument()
                .Close()

            End With

            xwWriter.Close()
            tslProgressBar.Value = 0

        Catch exError As Exception
            MsgBox(exError.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub WriteChildNodeXML(ByRef NodeXmlWriter As XmlWriter, ByVal CurrentNode As TreeNode, ByVal Index As Integer)
        ' Recursively write child nodes
        ' These will be nested within each parent node
        '=============================================

        Try
            With NodeXmlWriter
                .WriteStartElement("Node")

                .WriteStartElement("NodeData")

                .WriteStartElement("NodeKey")
                .WriteString(CurrentNode.Name)
                .WriteEndElement()
                .WriteStartElement("NodeName")
                .WriteString(CurrentNode.Text)
                .WriteEndElement()

                .WriteEndElement()  ' End NodeData

                For Each nodChild As TreeNode In CurrentNode.Nodes
                    'Write any childnodes
                    WriteChildNodeXML(NodeXmlWriter, nodChild, Index)
                    Index += 1
                    tslProgress.Text = "Saving tree node: " & Index
                    tslProgressBar.Value = Index
                Next

                ' End of Node
                .WriteEndElement()  ' End Node

            End With
        Catch exError As Exception
            MsgBox(exError.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub NewData()
        ' Wipe existing data if user verifies decision
        '=============================================
        Dim intAnswer As Integer = 0

        '== If not saved then give prompt ==
        If ((blnIsEventsSaved = False Or blnIsLogSaved = False) And EventIndex > 1) Then
            intAnswer = MsgBox("Wipe everything without saving tests and/or data?", MsgBoxStyle.YesNoCancel)
            If intAnswer <> vbYes Then Exit Sub
        End If

        '== Wipe previous data ==
        GuiEvents.Clear()
        EventIndex = 1
        tvEvent.Nodes.Clear()
        lvDetail.Items.Clear()
        txtLog.Text = ""

        arlCutList.Clear()
        dicCopiedItems.Clear()

        blnIsEventsSaved = False
        blnIsLogSaved = False

        tvEvent.Nodes.Add("0", "NewTest", 4)

        ' Switch TextReader from Compare mode to Read mode
        trTextReader.Compare = False

    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        ' Show the Options dialog and check that user has specified a valid OCR directory
        '================================================================================

        ' Show dialog
        frmOptions.ShowDialog(Me)

        ' Check for valid OCR app
        CheckOCRExists()

    End Sub

    Private Sub PropertiesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PropertiesToolStripMenuItem.Click
        ShowProperties(UNDEFINED)
    End Sub

    Private Sub lvDetail_DoubleClick(sender As Object, e As System.EventArgs) Handles lvDetail.DoubleClick
        ' Show properties for selected item
        '==================================

        ShowProperties(LIST_VIEW)

    End Sub

    Private Sub ContextCutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContextCutToolStripMenuItem.Click
        CutItem(LIST_VIEW)
    End Sub

    Private Sub ContextCopyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContextCopyToolStripMenuItem.Click
        CopyItem(LIST_VIEW)
    End Sub

    Private Sub ContextPasteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContextPasteToolStripMenuItem.Click
        PasteItem(LIST_VIEW)
    End Sub

    Private Sub ContextDeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContextDeleteToolStripMenuItem.Click
        DeleteItem(LIST_VIEW)
    End Sub

    Private Sub ContextSelectAllToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContextSelectAllToolStripMenuItem.Click
        SelectAll(LIST_VIEW)
    End Sub

    Private Sub ContextPropertiesToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ContextPropertiesToolStripMenuItem1.Click
        ShowProperties(LIST_VIEW)
    End Sub

    Private Sub ShowProperties(Optional ContextLocation As Integer = TREE_VIEW)
        ' Show properties for selected for selected GuiEvent
        '===================================================

        '== Check that it's possible to show properties (i.e. we have child nodes) ==
        If tvEvent.GetNodeCount(True) < 2 Then Exit Sub

        '== Find the control with focus ==
        If ContextLocation = UNDEFINED Then
            If tvEvent.Focused = True Then
                ContextLocation = TREE_VIEW
            ElseIf lvDetail.Focused = True Then
                ContextLocation = LIST_VIEW
            End If
        End If

        '== Exit if nothing selected ==
        If (ContextLocation = TREE_VIEW And tvEvent.SelectedNode Is Nothing) Or (ContextLocation = LIST_VIEW And lvDetail.SelectedItems Is Nothing) Then Exit Sub

        frmProperties.intContext = ContextLocation

        If ContextLocation = TREE_VIEW Then
            frmProperties.strOriginalName = tvEvent.SelectedNode.Text
            frmProperties.strKey = tvEvent.SelectedNode.Name
            frmProperties.ShowDialog(Me)
        ElseIf ContextLocation = LIST_VIEW Then
            frmProperties.strOriginalName = lvDetail.SelectedItems(0).Text
            frmProperties.strKey = lvDetail.SelectedItems(0).Name
            frmProperties.ShowDialog(Me)
        End If

    End Sub

    Private Sub TreeCutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TreeCutToolStripMenuItem.Click
        CutItem(TREE_VIEW)
    End Sub

    Private Sub TreeCopyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TreeCopyToolStripMenuItem.Click
        CopyItem(TREE_VIEW)
    End Sub

    Private Sub TreePasteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TreePasteToolStripMenuItem.Click
        PasteItem(TREE_VIEW)
    End Sub

    Private Sub TreeDeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TreeDeleteToolStripMenuItem.Click
        DeleteItem(TREE_VIEW)
    End Sub

    Private Sub TreePropertiesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TreePropertiesToolStripMenuItem.Click
        ShowProperties()
    End Sub

    Private Sub CutItem(Optional ContextLocation As Integer = UNDEFINED)
        ' Find which control has focus and apply actions
        '===============================================

        If ContextLocation = UNDEFINED Then ContextLocation = GetControlContext()
        '== Mark the copied items as 'pending deletion' - They will be removed after pasting ==
        CopyItem(ContextLocation, True)

    End Sub

    Private Sub CopyItem(Optional ContextLocation As Integer = UNDEFINED, Optional IsCut As Boolean = False)
        ' Find which control has focus and apply actions
        '===============================================

        If ContextLocation = UNDEFINED Then ContextLocation = GetControlContext()

        ' Clear the lists of any items which are being 'cut' and 'copied'
        arlCutList.Clear()
        dicCopiedItems.Clear()

        '== Get selected item from control and place on clipboard ==
        Select Case ContextLocation
            Case TREE_VIEW

                ' Check for valid content
                If tvEvent.SelectedNode Is Nothing Then Exit Sub
                If tvEvent.SelectedNode.Index = 0 Then Exit Sub

                ' Mark node as copied
                dicCopiedItems.Add(tvEvent.SelectedNode.Name, tvEvent.SelectedNode.Text)

                ' If a cut is taking place then mark the original items for deletion
                If IsCut Then arlCutList.Add(tvEvent.SelectedNode.Name)

            Case LIST_VIEW

                ' Check for valid content
                If lvDetail.SelectedItems.Count = 0 Then Exit Sub

                ' Mark item as copied
                For Each itmItem As ListViewItem In lvDetail.SelectedItems
                    dicCopiedItems.Add(itmItem.Name, itmItem.Text)

                    ' If a cut is taking place then mark the original items for deletion
                    If IsCut Then arlCutList.Add(itmItem.Name)
                Next

            Case LOG_TEXT
                If txtLog.SelectedText <> "" Then
                    Clipboard.SetText(txtLog.SelectedText)
                    If IsCut Then txtLog.SelectedText = ""
                End If
        End Select

    End Sub

    Private Sub PasteItem(Optional ContextLocation As Integer = UNDEFINED)
        ' Find which control has focus and apply actions
        '===============================================
        Dim nodSelected As New TreeNode
        Dim nodCopied As New TreeNode
        Dim arrNodeArray As TreeNode()

        If ContextLocation = UNDEFINED Then ContextLocation = GetControlContext()

        ' Check for data before proceeding
        If dicCopiedItems.Count < 1 Then Exit Sub

        '== Get selected item from control and place on clipboard ==
        Select Case ContextLocation
            Case TREE_VIEW, LIST_VIEW

                ' Check for valid location
                If tvEvent.SelectedNode Is Nothing Then Exit Sub

                nodSelected = tvEvent.SelectedNode

                ' Protect against infinite recursion
                For Each itmItem As KeyValuePair(Of String, String) In dicCopiedItems
                    If nodSelected.Name = itmItem.Key Then
                        MsgBox("You cannot copy a branch into itself or one of its sub-branches. Please go and Google 'infinite recursion'.", MsgBoxStyle.Exclamation, "Error")
                        Exit Sub
                    End If
                    If Not (nodSelected.Nodes Is Nothing) Then
                        If nodSelected.Nodes.Find(itmItem.Key, True).Length > 0 Then
                            MsgBox("You cannot copy a branch into itself or one of its sub-branches. Please go and Google 'infinite recursion'.", MsgBoxStyle.Exclamation, "Error")
                            Exit Sub
                        End If
                    End If
                    arrNodeArray = tvEvent.Nodes.Find(itmItem.Key, True)
                    nodCopied = arrNodeArray(0)
                    If Not (nodCopied.Nodes Is Nothing) Then
                        If nodCopied.Nodes.Find(nodSelected.Name, True).Length > 0 Then
                            MsgBox("You cannot copy a branch into itself or one of its sub-branches. Please go and Google 'infinite recursion'.", MsgBoxStyle.Exclamation, "Error")
                            Exit Sub
                        End If
                    End If
                Next

                ' Paste items to new location
                For Each itmItem As KeyValuePair(Of String, String) In dicCopiedItems
                    PasteNode(itmItem.Key, nodSelected)
                Next

                If arlCutList.Count > 0 Then
                    ' If a cut is taking place then delete the original items
                    For Each itmItem In arlCutList
                        DeleteEvent(itmItem)
                        tvEvent.Nodes(itmItem).Remove()
                    Next
                    arlCutList.Clear()
                End If

                dicCopiedItems.Clear()

            Case LOG_TEXT
                If Clipboard.GetText <> "" Then txtLog.SelectedText = Clipboard.GetText
        End Select

    End Sub

    Private Sub PasteNode(ByVal NodeKey As String, ByVal ParentNode As TreeNode)
        ' Recurse down tree branch, copying each node into its new position
        '==================================================================
        Dim arrNodes As Array
        Dim arrChildNodes As Array

        Dim nodCurrentNode As New TreeNode
        Dim nodChildNode As New TreeNode

        Dim strImageTag As String = "imgClick"    ' Click image
        Dim intEventType As Integer


        '== Obtain data required for the new node ==
        arrNodes = tvEvent.Nodes.Find(NodeKey, True)
        If arrNodes.Length < 1 Then Exit Sub

        '== There should only be one node in the collection as each key is unique ==
        nodCurrentNode = arrNodes(0)

        ' Get an appropriate image for the node
        intEventType = GuiEvents(nodCurrentNode.Text).EventType
        Select intEventType
            Case GuiEvent.PASTE_FILE_DATA
                strImageTag = "imgFile"
            Case GuiEvent.PASTE_STATIC_TEXT
                strImageTag = "imgText"
            Case GuiEvent.PASTE_LOOP_NUMBER
                strImageTag = "imgLoop"
        End Select

        tvEvent.SelectedNode = ParentNode
        AddNewNode(nodCurrentNode.Text, strImageTag)

        '== If the node has children then copy those too ==
        For Each nodChild As TreeNode In nodCurrentNode.Nodes

            '== Get new parent location ==
            arrChildNodes = tvEvent.Nodes.Find(EventIndex - 1, True)
            If arrChildNodes.Length < 1 Then Exit Sub

            '== There should only be one node in the collection as each key is unique ==
            nodChildNode = arrChildNodes(0)
            tvEvent.SelectedNode = nodChildNode

            PasteNode(nodChild.Name, nodChildNode)
            arrChildNodes = Nothing
        Next

        ' If a copy is taking place then add to the dictionary of copied items
        If CopiedEvents.ContainsKey(nodCurrentNode.Text) Then
            CopiedEvents.Item(nodCurrentNode.Text) += 1
        Else
            CopiedEvents.Add(nodCurrentNode.Text, 1)
        End If


    End Sub

    Private Sub DeleteItem(Optional ContextLocation As Integer = UNDEFINED)
        ' Find which control has focus and apply actions
        '===============================================
        Dim strNameTag As String = ""
        Dim arrNodes As TreeNode()
        Dim nodNode As TreeNode


        If ContextLocation = UNDEFINED Then ContextLocation = GetControlContext()

        '== Get selected item from control and delete ==
        Select Case ContextLocation
            Case TREE_VIEW
                ' Top level node cannot be deleted
                If tvEvent.Nodes(0).IsSelected = True Then Exit Sub

                ' Remove associated item(s) from the tree and dictionary
                DeleteEvent(tvEvent.SelectedNode.Name)

                ' Remove associated node
                tvEvent.SelectedNode.Remove()

            Case LIST_VIEW
                For Each lviItem As ListViewItem In lvDetail.SelectedItems

                    ' Remove associated item(s) from the tree and dictionary
                    DeleteEvent(lviItem.Name)
                    arrNodes = tvEvent.Nodes.Find(lviItem.Name, True)
                    nodNode = arrNodes(0)
                    nodNode.Remove()

                    ' Remove the ListView item
                    lviItem.Remove()

                Next
            Case LOG_TEXT
                If txtLog.SelectedText <> "" Then txtLog.SelectedText = ""
        End Select

    End Sub

    Private Sub SelectAll(Optional ContextLocation As Integer = UNDEFINED)
        ' Find which control has focus and apply actions
        '===============================================

        If ContextLocation = UNDEFINED Then ContextLocation = GetControlContext()

        '== Get selected item from control and place on clipboard ==
        Select Case ContextLocation
            Case TREE_VIEW
                Exit Sub
            Case LIST_VIEW
                For Each itmItem As ListViewItem In lvDetail.Items
                    itmItem.Selected = True
                Next
            Case LOG_TEXT
                txtLog.SelectAll()
        End Select

    End Sub

    Private Sub FindItem(Optional ContextLocation As Integer = UNDEFINED)
        ' Show dialog and find selected item
        '===================================
        Dim strSearchText As String = ""
        Dim intPos As Integer = 0


        strSearchText = InputBox("Search for: ", "Find")

        strSearchText = strSearchText.Trim
        If strSearchText = "" Then Exit Sub

        If ContextLocation = UNDEFINED Then ContextLocation = GetControlContext()

        '== Get named item from control and select first located instance of it ==
        Select Case ContextLocation
            Case TREE_VIEW
                For Each nodNode As TreeNode In tvEvent.Nodes
                    If nodNode.Name = strSearchText Then
                        tvEvent.SelectedNode = nodNode
                        Exit For
                    End If
                Next
            Case LIST_VIEW
                For Each itmItem As ListViewItem In lvDetail.Items
                    If itmItem.Name = strSearchText Then
                        lvDetail.SelectedItems.Clear()
                        lvDetail.Items(itmItem.Index).Selected = True
                        Exit For
                    End If
                Next
            Case LOG_TEXT
                If txtLog.Text.Contains(strSearchText) Then
                    intPos = InStr(txtLog.Text, strSearchText)
                    txtLog.SelectionStart = intPos
                    txtLog.SelectionLength = strSearchText.Length
                End If
        End Select

    End Sub

    Private Sub DeleteEvent(NodeKey As String)
        ' If this GuiEvent has not been copied then it can be removed from the array of events
        ' Recurse down tree branch, removing the GuiEvent associated with each node that is encountered
        '==============================================================================================
        Dim arrNodes As Array
        Dim arrChildNodes As Array

        Dim nodCurrentNode As New TreeNode
        Dim nodChildNode As New TreeNode



        '== Locate node to be deleted ==
        arrNodes = tvEvent.Nodes.Find(NodeKey, True)
        If arrNodes.Length < 1 Then Exit Sub

        '== There should only be one node in the collection as each key is unique ==
        nodCurrentNode = arrNodes(0)

        '== If the node has children then delete those too ==
        For Each nodChild As TreeNode In nodCurrentNode.Nodes

            '== Get new parent location ==
            arrChildNodes = tvEvent.Nodes.Find(EventIndex - 1, True)
            If arrChildNodes.Length > 0 Then
                '== There should only be one node in the collection as each key is unique ==
                nodChildNode = arrChildNodes(0)

                DeleteEvent(nodChildNode.Name)
            End If
        Next

        '== Delete the event from the dictionary if it's no longer present in the GUI ==
        If Not CopiedEvents.ContainsKey(nodCurrentNode.Text) Then GuiEvents.Remove(nodCurrentNode.Text)

        '== Adjust the numbers of any copied items that are now being deleted ==
        If CopiedEvents.ContainsKey(nodCurrentNode.Text) Then
            CopiedEvents.Item(nodCurrentNode.Text) -= 1
            If CopiedEvents(nodCurrentNode.Text) < 1 Then CopiedEvents.Remove(nodCurrentNode.Text)
        End If

    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CutToolStripMenuItem.Click
        CutItem()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        CopyItem()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        PasteItem()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteItem()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        SelectAll()
    End Sub

    Private Sub FindToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FindToolStripMenuItem.Click
        FindItem()
    End Sub

    Private Function GetControlContext(Optional ByVal RequiresNodes As Boolean = True) As Integer
        ' Determine which control has focus in order to proceed with operation correctly
        '===============================================================================
        Dim ContextLocation As Integer = UNDEFINED

        '== Find which control has focus ==
        If txtLog.Focused = True Then
            ContextLocation = LOG_TEXT
        ElseIf tvEvent.Focused = True Then
            ContextLocation = TREE_VIEW
        ElseIf lvDetail.Focused = True Then
            ContextLocation = LIST_VIEW
        End If

        '== If operation requires nodes, then check that we have some ==
        If RequiresNodes = True Then
            If ((ContextLocation = TREE_VIEW Or ContextLocation = LIST_VIEW) And (tvEvent.GetNodeCount(True) < 2)) Then ContextLocation = UNDEFINED
        End If

        Return ContextLocation

    End Function

    Private Sub tvEvent_NodeMouseClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvEvent.NodeMouseClick
        ' Forcibly ensure that a right-click results in selection of clicked node
        '========================================================================

        If e.Button = Windows.Forms.MouseButtons.Right Then
            tvEvent.SelectedNode = e.Node
        End If

    End Sub

    Private Sub tvEvent_NodeMouseDoubleClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvEvent.NodeMouseDoubleClick
        ' Show properties for selected item
        '==================================

        ShowProperties()

    End Sub

    Private Sub ExistingWindowsControlsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExistingWindowsControlsToolStripMenuItem.Click
        frmCurrentWindows.ShowDialog(Me)
    End Sub

    Private Sub NewWindowTitlesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewWindowTitlesToolStripMenuItem.Click
        frmNewWindows.ShowDialog(Me)
    End Sub

    Private Sub AddNewWindowTitleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddNewWindowTitleToolStripMenuItem.Click
        frmAddWindow.ShowDialog(Me)
    End Sub

    Private Sub timTimer_Tick(sender As System.Object, e As System.EventArgs) Handles timTimer.Tick
        ' On each tick event carry out GUI monitoring
        '============================================

        If IsGuiMonitor Then CheckGUI()

    End Sub

    Private Sub CheckGUI()
        ' Check for any GUI changes specified by the user
        '================================================
        Dim arlCurrentWindows As New ArrayList
        Dim blnIsChanged As Boolean = False
        Dim strLogText As String = ""
        Dim strTitle As String = ""
        Dim strTerminate As String = "Testing completed, objectives met. Terminating test sequence..." & vbNewLine


        '== Changes to window and control text (including closure) ==
        For Each mwWindow As MonitoredWindow In MonitoredWindows.Values
            strTitle = GetTextForHandle(mwWindow.hWnd)

            If mwWindow.OriginalText <> strTitle Then

                '== Record details ready for later processing ==
                blnIsChanged = True

                strLogText &= "Window Title Changed For Handle: " & mwWindow.hWnd.ToString & vbNewLine
                strLogText &= "Original Window Title: " & mwWindow.OriginalText & vbNewLine
                strLogText &= "New Window Title: " & strTitle & vbNewLine
                strLogText &= "Time: " & DateAndTime.Now.ToString & vbNewLine
                strLogText &= vbNewLine

                If Not ChangedWindows.ContainsKey(mwWindow.hWnd) Then ChangedWindows.Add(mwWindow.hWnd, mwWindow)
            End If

        Next


        '== Changes to existing on-screen text ==
        If SnipCount > 0 Then
            For Each dicItem In trTextReader.ChangedTextSnips

                '== Record details ready for later processing ==
                blnIsChanged = True

                strLogText &= "Text Changed. Original Text: " & trTextReader.OriginalTextSnips.Item(dicItem.Key) & vbNewLine
                strLogText &= "New Text: " & dicItem.Value & vbNewLine
                strLogText &= "Time: " & DateAndTime.Now.ToString & vbNewLine
                strLogText &= vbNewLine
            Next
        End If


        '== Appearance of new windows ==
        If NewWindows.Count > 0 Then

            '== Update current windows ==
            EnumerateWindows()

            '== Get a full list of visible windows to use for case-insensitive or partial text checks ==
            For Each nwWindow As NewWindow In NewWindows.Values

                If nwWindow.IsFullTitle Then
                    '== Exact match required ==
                    If FindWindow(vbNullString, nwWindow.WindowTitle) <> 0 Then

                        '== Record details ready for later processing ==
                        blnIsChanged = True

                        strLogText &= "New Window Found: " & nwWindow.WindowTitle & vbNewLine
                        strLogText &= "Time: " & DateAndTime.Now.ToString & vbNewLine
                        strLogText &= vbNewLine

                        If Not CreatedWindows.ContainsKey(nwWindow.WindowTitle) Then CreatedWindows.Add(nwWindow.WindowTitle, nwWindow)
                    End If
                Else
                    '== Partial title ==
                    For Each itmItem As ExistingWindow In ExistingWindows.Values
                        If itmItem.WindowTitle.ToLower.Contains(nwWindow.WindowTitle.ToLower) Then

                            '== Record details ready for later processing ==
                            blnIsChanged = True

                            strLogText &= "New Window Found: " & itmItem.WindowTitle & vbNewLine
                            strLogText &= "Contains Text: " & nwWindow.WindowTitle & vbNewLine
                            strLogText &= "Time: " & DateAndTime.Now.ToString & vbNewLine
                            strLogText &= vbNewLine

                            If Not CreatedWindows.ContainsKey(nwWindow.WindowTitle) Then CreatedWindows.Add(nwWindow.WindowTitle, nwWindow)
                            Exit For
                        End If
                    Next
                End If
            Next
        End If


        '== Does testing need to stop? ==
        If blnIsChanged Then

            '== Log the test details ==
            txtLog.Text &= strLogText
            If blnIsAutoSave = True Then swResultFile.Write(strLogText)

            '== Do we need to terminate the test? ==
            If TerminateOnFirstChange Or (TerminateOnAllChange And _
                                          ((MonitoredWindows.Count = ChangedWindows.Count) And (trTextReader.OriginalTextSnips.Count = trTextReader.ChangedTextSnips.Count) And (NewWindows.Count = CreatedWindows.Count))) Then

                '== Notify user that test is ending ==
                txtLog.Text &= strTerminate
                If blnIsAutoSave = True Then swResultFile.Write(strTerminate)

                '== Terminate test ==
                blnIsCancelled = True
                IsGuiMonitor = False

                timTimer.Enabled = IsGuiMonitor
                ActivateGUIMonitorToolStripMenuItem.Checked = IsGuiMonitor
            End If
        End If

    End Sub

    Private Sub CheckOCRExists()
        ' Determine whether the specified OCR app exists on this machine or not
        '======================================================================

        If OCRReminder = "0" Then Exit Sub

        If Not File.Exists(trTextReader.TesseractLocation) Then
            frmReminder.ShowDialog(Me)
        End If

    End Sub

    Private Sub ExistingTextToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExistingTextToolStripMenuItem.Click
        ' Allow user to select a screen area for OCR
        '===========================================

        CheckOCRExists()
        AddTextArea()

    End Sub

    Private Sub ActivateGUIMonitorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ActivateGUIMonitorToolStripMenuItem.Click
        ' Switch the GUI monitor on or off
        '=================================

        IsGuiMonitor = ActivateGUIMonitorToolStripMenuItem.Checked
        If IsGuiMonitor Then timTimer.Enabled = True

    End Sub

    Private Sub MonitoredTextToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MonitoredTextToolStripMenuItem.Click
        ' Show dialog with list of currently monitored text areas
        '========================================================

        CheckOCRExists()
        frmTextFields.ShowDialog(Me)

    End Sub

    Public Sub AddTextArea()
        ' Use GUI monitor and OCR to check for text changes
        '==================================================
        Dim taTextArea As TextArea
        Dim strFileName As String = ""
        Dim strOutFileName As String = ""
        Dim strText As String = ""

        '== Get text area from user ==
        taTextArea = Snipper.Snip()

        '== If we have an image then extract the text and add it to the list ==
        If Not taTextArea Is Nothing Then

            '== update number of Snips ==
            SnipCount += 1      ' SnipCount functions as ID for item and also identifies the file holding the image and text
            taTextArea.ID = SnipCount

            '== Save image for OCR processing ==
            If Not Directory.Exists(trTextReader.ImageDirectory) Then Directory.CreateDirectory(trTextReader.ImageDirectory)
            strFileName = trTextReader.ImageDirectory & "\screenshot" & CStr(SnipCount) & ".tif"
            taTextArea.SelectedImage.Save(strFileName, ImageFormat.Tiff)
            trTextReader.ImageCount += 1

            '== OCR the area ==
            trTextReader.ReadImageText()
            strOutFileName = strFileName & ".txt"
            strText = trTextReader.OriginalTextSnips(strOutFileName)

            '== Update TextArea object ==
            'taTextArea = New TextArea()
            taTextArea.ID = SnipCount
            taTextArea.ImageFile = strFileName
            taTextArea.ClippedText = strText

            '== Add to dictionary of saved text areas ==
            ScreenSnips.Add(SnipCount, taTextArea)
        End If

    End Sub

End Class
