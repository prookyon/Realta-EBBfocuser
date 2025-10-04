<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetupDialogForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.chkTrace = New System.Windows.Forms.CheckBox()
        Me.ComboBoxComPort = New System.Windows.Forms.ComboBox()
        Me.CurrentBox = New System.Windows.Forms.NumericUpDown()
        Me.MotorPos = New System.Windows.Forms.NumericUpDown()
        Me.NoSteps = New System.Windows.Forms.ComboBox()
        Me.HeaterVal = New System.Windows.Forms.TrackBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MotorEngaged = New System.Windows.Forms.CheckBox()
        Me.PulseLen = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrentBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MotorPos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HeaterVal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PulseLen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(225, 296)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.ASCOM.EBB.My.Resources.Resources.ASCOM
        Me.PictureBox1.Location = New System.Drawing.Point(320, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(13, 41)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(58, 13)
        Me.label2.TabIndex = 7
        Me.label2.Text = "Comm Port"
        '
        'chkTrace
        '
        Me.chkTrace.AutoSize = True
        Me.chkTrace.Location = New System.Drawing.Point(76, 65)
        Me.chkTrace.Name = "chkTrace"
        Me.chkTrace.Size = New System.Drawing.Size(69, 17)
        Me.chkTrace.TabIndex = 8
        Me.chkTrace.Text = "Trace on"
        Me.chkTrace.UseVisualStyleBackColor = True
        '
        'ComboBoxComPort
        '
        Me.ComboBoxComPort.FormattingEnabled = True
        Me.ComboBoxComPort.Location = New System.Drawing.Point(76, 38)
        Me.ComboBoxComPort.Name = "ComboBoxComPort"
        Me.ComboBoxComPort.Size = New System.Drawing.Size(84, 21)
        Me.ComboBoxComPort.TabIndex = 9
        '
        'CurrentBox
        '
        Me.CurrentBox.Location = New System.Drawing.Point(76, 87)
        Me.CurrentBox.Margin = New System.Windows.Forms.Padding(2)
        Me.CurrentBox.Maximum = New Decimal(New Integer() {1200, 0, 0, 0})
        Me.CurrentBox.Name = "CurrentBox"
        Me.CurrentBox.Size = New System.Drawing.Size(90, 20)
        Me.CurrentBox.TabIndex = 11
        '
        'MotorPos
        '
        Me.MotorPos.Location = New System.Drawing.Point(76, 120)
        Me.MotorPos.Margin = New System.Windows.Forms.Padding(2)
        Me.MotorPos.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.MotorPos.Name = "MotorPos"
        Me.MotorPos.Size = New System.Drawing.Size(90, 20)
        Me.MotorPos.TabIndex = 12
        '
        'NoSteps
        '
        Me.NoSteps.FormattingEnabled = True
        Me.NoSteps.Items.AddRange(New Object() {"0", "2", "4", "8", "16", "32", "64", "128", "256"})
        Me.NoSteps.Location = New System.Drawing.Point(76, 156)
        Me.NoSteps.Margin = New System.Windows.Forms.Padding(2)
        Me.NoSteps.Name = "NoSteps"
        Me.NoSteps.Size = New System.Drawing.Size(92, 21)
        Me.NoSteps.TabIndex = 13
        '
        'HeaterVal
        '
        Me.HeaterVal.Location = New System.Drawing.Point(76, 233)
        Me.HeaterVal.Margin = New System.Windows.Forms.Padding(2)
        Me.HeaterVal.Maximum = 255
        Me.HeaterVal.Name = "HeaterVal"
        Me.HeaterVal.Size = New System.Drawing.Size(258, 45)
        Me.HeaterVal.TabIndex = 14
        Me.HeaterVal.TickFrequency = 32
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(178, 92)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Current"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(179, 125)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Motor Position"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(179, 164)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Micro steps"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(84, 265)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Heater value"
        '
        'MotorEngaged
        '
        Me.MotorEngaged.AutoSize = True
        Me.MotorEngaged.Location = New System.Drawing.Point(76, 293)
        Me.MotorEngaged.Margin = New System.Windows.Forms.Padding(2)
        Me.MotorEngaged.Name = "MotorEngaged"
        Me.MotorEngaged.Size = New System.Drawing.Size(99, 17)
        Me.MotorEngaged.TabIndex = 19
        Me.MotorEngaged.Text = "Motor Engaged"
        Me.MotorEngaged.UseVisualStyleBackColor = True
        '
        'PulseLen
        '
        Me.PulseLen.Location = New System.Drawing.Point(76, 191)
        Me.PulseLen.Margin = New System.Windows.Forms.Padding(2)
        Me.PulseLen.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.PulseLen.Name = "PulseLen"
        Me.PulseLen.Size = New System.Drawing.Size(90, 20)
        Me.PulseLen.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(178, 193)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Pulse Length"
        '
        'SetupDialogForm
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(383, 337)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PulseLen)
        Me.Controls.Add(Me.MotorEngaged)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.HeaterVal)
        Me.Controls.Add(Me.NoSteps)
        Me.Controls.Add(Me.MotorPos)
        Me.Controls.Add(Me.CurrentBox)
        Me.Controls.Add(Me.ComboBoxComPort)
        Me.Controls.Add(Me.chkTrace)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SetupDialogForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Realta EBB focuser settings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrentBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MotorPos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HeaterVal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PulseLen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents chkTrace As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBoxComPort As System.Windows.Forms.ComboBox
    Friend WithEvents CurrentBox As NumericUpDown
    Friend WithEvents MotorPos As NumericUpDown
    Friend WithEvents NoSteps As ComboBox
    Friend WithEvents HeaterVal As TrackBar
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents MotorEngaged As CheckBox
    Friend WithEvents PulseLen As NumericUpDown
    Friend WithEvents Label1 As Label
End Class
