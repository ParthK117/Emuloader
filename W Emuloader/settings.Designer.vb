<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(settings))
        Me.load_boxart_on_startup = New System.Windows.Forms.CheckBox()
        Me.btn_save = New System.Windows.Forms.PictureBox()
        Me.load_skin = New System.Windows.Forms.CheckBox()
        CType(Me.btn_save, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'load_boxart_on_startup
        '
        Me.load_boxart_on_startup.AutoSize = True
        Me.load_boxart_on_startup.Font = New System.Drawing.Font("Spartan MB", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.load_boxart_on_startup.Location = New System.Drawing.Point(13, 13)
        Me.load_boxart_on_startup.Name = "load_boxart_on_startup"
        Me.load_boxart_on_startup.Size = New System.Drawing.Size(386, 30)
        Me.load_boxart_on_startup.TabIndex = 0
        Me.load_boxart_on_startup.Text = "Download boxart automatically if missing"
        Me.load_boxart_on_startup.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.BackgroundImage = CType(resources.GetObject("btn_save.BackgroundImage"), System.Drawing.Image)
        Me.btn_save.Location = New System.Drawing.Point(612, 390)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(176, 48)
        Me.btn_save.TabIndex = 1
        Me.btn_save.TabStop = False
        '
        'load_skin
        '
        Me.load_skin.AutoSize = True
        Me.load_skin.Font = New System.Drawing.Font("Spartan MB", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.load_skin.Location = New System.Drawing.Point(13, 53)
        Me.load_skin.Name = "load_skin"
        Me.load_skin.Size = New System.Drawing.Size(126, 30)
        Me.load_skin.TabIndex = 2
        Me.load_skin.Text = "Dark mode"
        Me.load_skin.UseVisualStyleBackColor = True
        '
        'settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.load_skin)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.load_boxart_on_startup)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "settings"
        Me.Text = "Settings"
        CType(Me.btn_save, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents load_boxart_on_startup As CheckBox
    Friend WithEvents btn_save As PictureBox
    Friend WithEvents load_skin As CheckBox
End Class
