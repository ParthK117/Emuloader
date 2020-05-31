<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class romproperties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(romproperties))
        Me.lbl_properties = New System.Windows.Forms.Label()
        Me.lbl_file_path = New System.Windows.Forms.Label()
        Me.lbl_file_path_identifier = New System.Windows.Forms.Label()
        Me.lbl_rom_name_identifier = New System.Windows.Forms.Label()
        Me.lbl_rom_name = New System.Windows.Forms.Label()
        Me.lbl_platform_identifier = New System.Windows.Forms.Label()
        Me.lbl_platform = New System.Windows.Forms.Label()
        Me.textbox_rom_name = New System.Windows.Forms.TextBox()
        Me.picturebox_boxart = New System.Windows.Forms.PictureBox()
        CType(Me.picturebox_boxart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_properties
        '
        Me.lbl_properties.AutoSize = True
        Me.lbl_properties.Font = New System.Drawing.Font("Gotham Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_properties.Location = New System.Drawing.Point(30, 30)
        Me.lbl_properties.Name = "lbl_properties"
        Me.lbl_properties.Size = New System.Drawing.Size(215, 44)
        Me.lbl_properties.TabIndex = 2
        Me.lbl_properties.Text = "Properties"
        '
        'lbl_file_path
        '
        Me.lbl_file_path.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_file_path.Location = New System.Drawing.Point(36, 111)
        Me.lbl_file_path.Name = "lbl_file_path"
        Me.lbl_file_path.Size = New System.Drawing.Size(524, 71)
        Me.lbl_file_path.TabIndex = 3
        Me.lbl_file_path.Text = "File path c:/"
        '
        'lbl_file_path_identifier
        '
        Me.lbl_file_path_identifier.AutoSize = True
        Me.lbl_file_path_identifier.Font = New System.Drawing.Font("Gotham Bold", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_file_path_identifier.Location = New System.Drawing.Point(37, 90)
        Me.lbl_file_path_identifier.Name = "lbl_file_path_identifier"
        Me.lbl_file_path_identifier.Size = New System.Drawing.Size(77, 16)
        Me.lbl_file_path_identifier.TabIndex = 4
        Me.lbl_file_path_identifier.Text = "FILE PATH"
        '
        'lbl_rom_name_identifier
        '
        Me.lbl_rom_name_identifier.AutoSize = True
        Me.lbl_rom_name_identifier.Font = New System.Drawing.Font("Gotham Bold", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rom_name_identifier.Location = New System.Drawing.Point(37, 194)
        Me.lbl_rom_name_identifier.Name = "lbl_rom_name_identifier"
        Me.lbl_rom_name_identifier.Size = New System.Drawing.Size(48, 16)
        Me.lbl_rom_name_identifier.TabIndex = 6
        Me.lbl_rom_name_identifier.Text = "NAME"
        '
        'lbl_rom_name
        '
        Me.lbl_rom_name.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rom_name.Location = New System.Drawing.Point(37, 215)
        Me.lbl_rom_name.Name = "lbl_rom_name"
        Me.lbl_rom_name.Size = New System.Drawing.Size(524, 71)
        Me.lbl_rom_name.TabIndex = 5
        Me.lbl_rom_name.Text = "name path"
        '
        'lbl_platform_identifier
        '
        Me.lbl_platform_identifier.AutoSize = True
        Me.lbl_platform_identifier.Font = New System.Drawing.Font("Gotham Bold", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_platform_identifier.Location = New System.Drawing.Point(38, 304)
        Me.lbl_platform_identifier.Name = "lbl_platform_identifier"
        Me.lbl_platform_identifier.Size = New System.Drawing.Size(82, 16)
        Me.lbl_platform_identifier.TabIndex = 8
        Me.lbl_platform_identifier.Text = "PLATFORM"
        '
        'lbl_platform
        '
        Me.lbl_platform.AutoSize = True
        Me.lbl_platform.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_platform.Location = New System.Drawing.Point(38, 325)
        Me.lbl_platform.Name = "lbl_platform"
        Me.lbl_platform.Size = New System.Drawing.Size(37, 19)
        Me.lbl_platform.TabIndex = 7
        Me.lbl_platform.Text = "GBA"
        '
        'textbox_rom_name
        '
        Me.textbox_rom_name.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.textbox_rom_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textbox_rom_name.Location = New System.Drawing.Point(42, 219)
        Me.textbox_rom_name.Name = "textbox_rom_name"
        Me.textbox_rom_name.Size = New System.Drawing.Size(518, 19)
        Me.textbox_rom_name.TabIndex = 9
        Me.textbox_rom_name.Visible = False
        '
        'picturebox_boxart
        '
        Me.picturebox_boxart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picturebox_boxart.Location = New System.Drawing.Point(113, 348)
        Me.picturebox_boxart.Name = "picturebox_boxart"
        Me.picturebox_boxart.Size = New System.Drawing.Size(372, 340)
        Me.picturebox_boxart.TabIndex = 10
        Me.picturebox_boxart.TabStop = False
        '
        'romproperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(600, 700)
        Me.Controls.Add(Me.picturebox_boxart)
        Me.Controls.Add(Me.textbox_rom_name)
        Me.Controls.Add(Me.lbl_platform_identifier)
        Me.Controls.Add(Me.lbl_platform)
        Me.Controls.Add(Me.lbl_rom_name_identifier)
        Me.Controls.Add(Me.lbl_rom_name)
        Me.Controls.Add(Me.lbl_file_path_identifier)
        Me.Controls.Add(Me.lbl_file_path)
        Me.Controls.Add(Me.lbl_properties)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "romproperties"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Properties"
        CType(Me.picturebox_boxart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_properties As Label
    Friend WithEvents lbl_file_path As Label
    Friend WithEvents lbl_file_path_identifier As Label
    Friend WithEvents lbl_rom_name_identifier As Label
    Friend WithEvents lbl_rom_name As Label
    Friend WithEvents lbl_platform_identifier As Label
    Friend WithEvents lbl_platform As Label
    Friend WithEvents textbox_rom_name As TextBox
    Friend WithEvents picturebox_boxart As PictureBox
End Class
