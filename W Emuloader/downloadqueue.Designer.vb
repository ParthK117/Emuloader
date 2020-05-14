<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class downloadqueue
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(downloadqueue))
        Me.listbox_queue = New System.Windows.Forms.ListView()
        Me.column_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.column_size = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.column_platform = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.column_source = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.column_url = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.downloader = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'listbox_queue
        '
        Me.listbox_queue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.listbox_queue.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.column_name, Me.column_size, Me.column_platform, Me.column_source, Me.column_url})
        Me.listbox_queue.Font = New System.Drawing.Font("Gotham Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listbox_queue.ForeColor = System.Drawing.Color.Black
        Me.listbox_queue.HideSelection = False
        Me.listbox_queue.Location = New System.Drawing.Point(0, 0)
        Me.listbox_queue.Name = "listbox_queue"
        Me.listbox_queue.Size = New System.Drawing.Size(800, 482)
        Me.listbox_queue.TabIndex = 4
        Me.listbox_queue.UseCompatibleStateImageBehavior = False
        Me.listbox_queue.View = System.Windows.Forms.View.Details
        '
        'column_name
        '
        Me.column_name.Text = "Name"
        Me.column_name.Width = 120
        '
        'column_size
        '
        Me.column_size.Tag = ""
        Me.column_size.Text = "Size"
        Me.column_size.Width = 120
        '
        'column_platform
        '
        Me.column_platform.Text = "Platform"
        Me.column_platform.Width = 120
        '
        'column_source
        '
        Me.column_source.Text = "Source"
        Me.column_source.Width = 120
        '
        'column_url
        '
        Me.column_url.Text = ""
        Me.column_url.Width = 0
        '
        'downloader
        '
        Me.downloader.WorkerReportsProgress = True
        Me.downloader.WorkerSupportsCancellation = True
        '
        'downloadqueue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 482)
        Me.ControlBox = False
        Me.Controls.Add(Me.listbox_queue)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "downloadqueue"
        Me.Text = "Download Queue"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents listbox_queue As ListView
    Friend WithEvents column_name As ColumnHeader
    Friend WithEvents column_size As ColumnHeader
    Friend WithEvents column_platform As ColumnHeader
    Friend WithEvents column_source As ColumnHeader
    Friend WithEvents column_url As ColumnHeader
    Friend WithEvents downloader As System.ComponentModel.BackgroundWorker
End Class
