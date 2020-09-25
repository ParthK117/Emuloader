<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class manage_dropbox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(manage_dropbox))
        Me.panel_settings = New System.Windows.Forms.Panel()
        Me.listbox_cloud = New System.Windows.Forms.ListBox()
        Me.lbl_cloud = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.panel_settings.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel_settings
        '
        Me.panel_settings.Controls.Add(Me.lbl_cloud)
        Me.panel_settings.Location = New System.Drawing.Point(261, 2)
        Me.panel_settings.Name = "panel_settings"
        Me.panel_settings.Size = New System.Drawing.Size(521, 437)
        Me.panel_settings.TabIndex = 0
        '
        'listbox_cloud
        '
        Me.listbox_cloud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listbox_cloud.FormattingEnabled = True
        Me.listbox_cloud.Items.AddRange(New Object() {"Syncing", "Backup", "Restore", "Integration"})
        Me.listbox_cloud.Location = New System.Drawing.Point(3, 2)
        Me.listbox_cloud.Name = "listbox_cloud"
        Me.listbox_cloud.Size = New System.Drawing.Size(255, 106)
        Me.listbox_cloud.TabIndex = 1
        '
        'lbl_cloud
        '
        Me.lbl_cloud.AutoSize = True
        Me.lbl_cloud.Font = New System.Drawing.Font("Gotham Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cloud.Location = New System.Drawing.Point(11, 10)
        Me.lbl_cloud.Name = "lbl_cloud"
        Me.lbl_cloud.Size = New System.Drawing.Size(131, 44)
        Me.lbl_cloud.TabIndex = 3
        Me.lbl_cloud.Text = "Cloud"
        '
        'ListBox1
        '
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Items.AddRange(New Object() {"GBA", "NDS"})
        Me.ListBox1.Location = New System.Drawing.Point(3, 112)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(255, 327)
        Me.ListBox1.TabIndex = 2
        '
        'manage_dropbox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 441)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.listbox_cloud)
        Me.Controls.Add(Me.panel_settings)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "manage_dropbox"
        Me.Text = "Manage Backups"
        Me.panel_settings.ResumeLayout(False)
        Me.panel_settings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panel_settings As Panel
    Friend WithEvents listbox_cloud As ListBox
    Friend WithEvents lbl_cloud As Label
    Friend WithEvents ListBox1 As ListBox
End Class
