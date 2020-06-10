<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class parameters
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(parameters))
        Me.lbl_params_title = New System.Windows.Forms.Label()
        Me.btn_save = New System.Windows.Forms.PictureBox()
        Me.textbox_parameters = New System.Windows.Forms.TextBox()
        CType(Me.btn_save, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_params_title
        '
        Me.lbl_params_title.AutoSize = True
        Me.lbl_params_title.Font = New System.Drawing.Font("Gotham Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_params_title.Location = New System.Drawing.Point(12, 9)
        Me.lbl_params_title.Name = "lbl_params_title"
        Me.lbl_params_title.Size = New System.Drawing.Size(378, 44)
        Me.lbl_params_title.TabIndex = 8
        Me.lbl_params_title.Text = "Launch Parameters"
        '
        'btn_save
        '
        Me.btn_save.BackgroundImage = CType(resources.GetObject("btn_save.BackgroundImage"), System.Drawing.Image)
        Me.btn_save.Location = New System.Drawing.Point(590, 95)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(176, 48)
        Me.btn_save.TabIndex = 9
        Me.btn_save.TabStop = False
        '
        'textbox_parameters
        '
        Me.textbox_parameters.Location = New System.Drawing.Point(20, 57)
        Me.textbox_parameters.Name = "textbox_parameters"
        Me.textbox_parameters.Size = New System.Drawing.Size(746, 20)
        Me.textbox_parameters.TabIndex = 10
        '
        'parameters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(778, 155)
        Me.Controls.Add(Me.textbox_parameters)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.lbl_params_title)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "parameters"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Launch Parameters"
        CType(Me.btn_save, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_params_title As Label
    Friend WithEvents btn_save As PictureBox
    Friend WithEvents textbox_parameters As TextBox
End Class
