<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class connectwithdropbox
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(connectwithdropbox))
        Me.btn_connect = New System.Windows.Forms.PictureBox()
        Me.textbox_code = New System.Windows.Forms.TextBox()
        Me.btn_finish = New System.Windows.Forms.PictureBox()
        CType(Me.btn_connect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_finish, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_connect
        '
        Me.btn_connect.Image = CType(resources.GetObject("btn_connect.Image"), System.Drawing.Image)
        Me.btn_connect.Location = New System.Drawing.Point(417, 385)
        Me.btn_connect.Name = "btn_connect"
        Me.btn_connect.Size = New System.Drawing.Size(176, 48)
        Me.btn_connect.TabIndex = 0
        Me.btn_connect.TabStop = False
        '
        'textbox_code
        '
        Me.textbox_code.BackColor = System.Drawing.Color.White
        Me.textbox_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textbox_code.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textbox_code.Location = New System.Drawing.Point(194, 395)
        Me.textbox_code.Name = "textbox_code"
        Me.textbox_code.Size = New System.Drawing.Size(556, 29)
        Me.textbox_code.TabIndex = 1
        Me.textbox_code.Visible = False
        '
        'btn_finish
        '
        Me.btn_finish.BackgroundImage = CType(resources.GetObject("btn_finish.BackgroundImage"), System.Drawing.Image)
        Me.btn_finish.Location = New System.Drawing.Point(417, 470)
        Me.btn_finish.Name = "btn_finish"
        Me.btn_finish.Size = New System.Drawing.Size(176, 48)
        Me.btn_finish.TabIndex = 2
        Me.btn_finish.TabStop = False
        Me.btn_finish.Visible = False
        '
        'connectwithdropbox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1008, 537)
        Me.Controls.Add(Me.btn_finish)
        Me.Controls.Add(Me.textbox_code)
        Me.Controls.Add(Me.btn_connect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "connectwithdropbox"
        Me.Text = "Connect with Dropbox"
        CType(Me.btn_connect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_finish, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_connect As PictureBox
    Friend WithEvents textbox_code As TextBox
    Friend WithEvents btn_finish As PictureBox
End Class
