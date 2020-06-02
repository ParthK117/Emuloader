<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class newemulator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(newemulator))
        Me.listbox_emulators = New System.Windows.Forms.ListBox()
        Me.textbox_search = New System.Windows.Forms.TextBox()
        Me.emulator_downloader = New System.ComponentModel.BackgroundWorker()
        Me.citra_3ds = New System.ComponentModel.BackgroundWorker()
        Me.desmume = New System.ComponentModel.BackgroundWorker()
        Me.project64 = New System.ComponentModel.BackgroundWorker()
        Me.ppsspp = New System.ComponentModel.BackgroundWorker()
        Me.picturebox_emulogo = New System.Windows.Forms.PictureBox()
        Me.lbl_emulator_name = New System.Windows.Forms.Label()
        Me.lbl_version_number = New System.Windows.Forms.Label()
        Me.lbl_source = New System.Windows.Forms.Label()
        Me.lbl_platform = New System.Windows.Forms.Label()
        Me.btn_install = New System.Windows.Forms.PictureBox()
        CType(Me.picturebox_emulogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_install, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'listbox_emulators
        '
        Me.listbox_emulators.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listbox_emulators.FormattingEnabled = True
        Me.listbox_emulators.ItemHeight = 16
        Me.listbox_emulators.Location = New System.Drawing.Point(7, 40)
        Me.listbox_emulators.Name = "listbox_emulators"
        Me.listbox_emulators.Size = New System.Drawing.Size(414, 356)
        Me.listbox_emulators.TabIndex = 0
        '
        'textbox_search
        '
        Me.textbox_search.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textbox_search.Location = New System.Drawing.Point(7, 12)
        Me.textbox_search.Name = "textbox_search"
        Me.textbox_search.Size = New System.Drawing.Size(414, 22)
        Me.textbox_search.TabIndex = 1
        Me.textbox_search.Text = "Search"
        '
        'emulator_downloader
        '
        Me.emulator_downloader.WorkerReportsProgress = True
        Me.emulator_downloader.WorkerSupportsCancellation = True
        '
        'citra_3ds
        '
        Me.citra_3ds.WorkerReportsProgress = True
        Me.citra_3ds.WorkerSupportsCancellation = True
        '
        'desmume
        '
        Me.desmume.WorkerReportsProgress = True
        Me.desmume.WorkerSupportsCancellation = True
        '
        'project64
        '
        Me.project64.WorkerReportsProgress = True
        Me.project64.WorkerSupportsCancellation = True
        '
        'ppsspp
        '
        Me.ppsspp.WorkerReportsProgress = True
        Me.ppsspp.WorkerSupportsCancellation = True
        '
        'picturebox_emulogo
        '
        Me.picturebox_emulogo.BackgroundImage = CType(resources.GetObject("picturebox_emulogo.BackgroundImage"), System.Drawing.Image)
        Me.picturebox_emulogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picturebox_emulogo.Location = New System.Drawing.Point(432, 12)
        Me.picturebox_emulogo.Name = "picturebox_emulogo"
        Me.picturebox_emulogo.Size = New System.Drawing.Size(356, 193)
        Me.picturebox_emulogo.TabIndex = 3
        Me.picturebox_emulogo.TabStop = False
        '
        'lbl_emulator_name
        '
        Me.lbl_emulator_name.AutoSize = True
        Me.lbl_emulator_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_emulator_name.Location = New System.Drawing.Point(432, 212)
        Me.lbl_emulator_name.Name = "lbl_emulator_name"
        Me.lbl_emulator_name.Size = New System.Drawing.Size(111, 20)
        Me.lbl_emulator_name.TabIndex = 4
        Me.lbl_emulator_name.Text = "emulatorname"
        '
        'lbl_version_number
        '
        Me.lbl_version_number.AutoSize = True
        Me.lbl_version_number.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_version_number.Location = New System.Drawing.Point(432, 252)
        Me.lbl_version_number.Name = "lbl_version_number"
        Me.lbl_version_number.Size = New System.Drawing.Size(113, 20)
        Me.lbl_version_number.TabIndex = 5
        Me.lbl_version_number.Text = "versionnumber"
        '
        'lbl_source
        '
        Me.lbl_source.AutoSize = True
        Me.lbl_source.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_source.Location = New System.Drawing.Point(432, 272)
        Me.lbl_source.Name = "lbl_source"
        Me.lbl_source.Size = New System.Drawing.Size(57, 20)
        Me.lbl_source.TabIndex = 6
        Me.lbl_source.Text = "source"
        '
        'lbl_platform
        '
        Me.lbl_platform.AutoSize = True
        Me.lbl_platform.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_platform.Location = New System.Drawing.Point(432, 232)
        Me.lbl_platform.Name = "lbl_platform"
        Me.lbl_platform.Size = New System.Drawing.Size(67, 20)
        Me.lbl_platform.TabIndex = 7
        Me.lbl_platform.Text = "platform"
        '
        'btn_install
        '
        Me.btn_install.BackgroundImage = CType(resources.GetObject("btn_install.BackgroundImage"), System.Drawing.Image)
        Me.btn_install.Location = New System.Drawing.Point(522, 317)
        Me.btn_install.Name = "btn_install"
        Me.btn_install.Size = New System.Drawing.Size(176, 48)
        Me.btn_install.TabIndex = 8
        Me.btn_install.TabStop = False
        '
        'newemulator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 400)
        Me.Controls.Add(Me.btn_install)
        Me.Controls.Add(Me.lbl_platform)
        Me.Controls.Add(Me.lbl_source)
        Me.Controls.Add(Me.lbl_version_number)
        Me.Controls.Add(Me.lbl_emulator_name)
        Me.Controls.Add(Me.picturebox_emulogo)
        Me.Controls.Add(Me.textbox_search)
        Me.Controls.Add(Me.listbox_emulators)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "newemulator"
        Me.Text = "Add New Emulator"
        CType(Me.picturebox_emulogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_install, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents listbox_emulators As ListBox
    Friend WithEvents textbox_search As TextBox
    Friend WithEvents emulator_downloader As System.ComponentModel.BackgroundWorker
    Friend WithEvents citra_3ds As System.ComponentModel.BackgroundWorker
    Friend WithEvents desmume As System.ComponentModel.BackgroundWorker
    Friend WithEvents project64 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ppsspp As System.ComponentModel.BackgroundWorker
    Friend WithEvents picturebox_emulogo As PictureBox
    Friend WithEvents lbl_emulator_name As Label
    Friend WithEvents lbl_version_number As Label
    Friend WithEvents lbl_source As Label
    Friend WithEvents lbl_platform As Label
    Friend WithEvents btn_install As PictureBox
End Class
