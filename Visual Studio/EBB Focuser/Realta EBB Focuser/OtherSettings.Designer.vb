<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OtherSettings
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
        Me.MotorEngaged = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.HeaterVal = New System.Windows.Forms.TrackBar()
        Me.NoSteps = New System.Windows.Forms.ComboBox()
        Me.MotorPos = New System.Windows.Forms.NumericUpDown()
        Me.CurrentBox = New System.Windows.Forms.NumericUpDown()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PulseLen = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.HeaterVal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MotorPos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrentBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PulseLen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MotorEngaged
        '
        Me.MotorEngaged.AutoSize = True
        Me.MotorEngaged.Location = New System.Drawing.Point(45, 226)
        Me.MotorEngaged.Margin = New System.Windows.Forms.Padding(2)
        Me.MotorEngaged.Name = "MotorEngaged"
        Me.MotorEngaged.Size = New System.Drawing.Size(99, 17)
        Me.MotorEngaged.TabIndex = 27
        Me.MotorEngaged.Text = "Motor Engaged"
        Me.MotorEngaged.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(147, 100)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Micro steps"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(148, 62)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Motor Position"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(147, 29)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Current"
        '
        'HeaterVal
        '
        Me.HeaterVal.Location = New System.Drawing.Point(45, 166)
        Me.HeaterVal.Margin = New System.Windows.Forms.Padding(2)
        Me.HeaterVal.Maximum = 255
        Me.HeaterVal.Name = "HeaterVal"
        Me.HeaterVal.Size = New System.Drawing.Size(258, 45)
        Me.HeaterVal.TabIndex = 23
        Me.HeaterVal.TickFrequency = 32
        '
        'NoSteps
        '
        Me.NoSteps.FormattingEnabled = True
        Me.NoSteps.Items.AddRange(New Object() {"0", "2", "4", "8", "16", "32", "64", "128", "256"})
        Me.NoSteps.Location = New System.Drawing.Point(45, 92)
        Me.NoSteps.Margin = New System.Windows.Forms.Padding(2)
        Me.NoSteps.Name = "NoSteps"
        Me.NoSteps.Size = New System.Drawing.Size(92, 21)
        Me.NoSteps.TabIndex = 22
        '
        'MotorPos
        '
        Me.MotorPos.Location = New System.Drawing.Point(45, 57)
        Me.MotorPos.Margin = New System.Windows.Forms.Padding(2)
        Me.MotorPos.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.MotorPos.Name = "MotorPos"
        Me.MotorPos.Size = New System.Drawing.Size(90, 20)
        Me.MotorPos.TabIndex = 21
        '
        'CurrentBox
        '
        Me.CurrentBox.Location = New System.Drawing.Point(45, 24)
        Me.CurrentBox.Margin = New System.Windows.Forms.Padding(2)
        Me.CurrentBox.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.CurrentBox.Name = "CurrentBox"
        Me.CurrentBox.Size = New System.Drawing.Size(90, 20)
        Me.CurrentBox.TabIndex = 20
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(161, 226)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(191, 52)
        Me.btnSave.TabIndex = 28
        Me.btnSave.Text = "Save settings"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(57, 198)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Heater value"
        '
        'PulseLen
        '
        Me.PulseLen.Location = New System.Drawing.Point(45, 128)
        Me.PulseLen.Margin = New System.Windows.Forms.Padding(2)
        Me.PulseLen.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.PulseLen.Name = "PulseLen"
        Me.PulseLen.Size = New System.Drawing.Size(90, 20)
        Me.PulseLen.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(147, 130)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Pulse Length"
        '
        'OtherSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 291)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PulseLen)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.MotorEngaged)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.HeaterVal)
        Me.Controls.Add(Me.NoSteps)
        Me.Controls.Add(Me.MotorPos)
        Me.Controls.Add(Me.CurrentBox)
        Me.Name = "OtherSettings"
        Me.Text = "Realta focuser additonal settings"
        CType(Me.HeaterVal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MotorPos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrentBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PulseLen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MotorEngaged As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents HeaterVal As TrackBar
    Friend WithEvents NoSteps As ComboBox
    Friend WithEvents MotorPos As NumericUpDown
    Friend WithEvents CurrentBox As NumericUpDown
    Friend WithEvents btnSave As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents PulseLen As NumericUpDown
    Friend WithEvents Label1 As Label
End Class
