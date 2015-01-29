<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonRun = New System.Windows.Forms.Button()
        Me.ButtonEdit = New System.Windows.Forms.Button()
        Me.ListBoxScripts = New System.Windows.Forms.ListBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.BasicIdeCtl1 = New WinWrap.Basic.BasicIdeCtl()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(424, 292)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Size = New System.Drawing.Size(416, 266)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Example7"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(2, 152)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(412, 112)
        Me.TextBox1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonRun)
        Me.Panel1.Controls.Add(Me.ButtonEdit)
        Me.Panel1.Controls.Add(Me.ListBoxScripts)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(412, 150)
        Me.Panel1.TabIndex = 0
        '
        'ButtonRun
        '
        Me.ButtonRun.Location = New System.Drawing.Point(196, 111)
        Me.ButtonRun.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonRun.Name = "ButtonRun"
        Me.ButtonRun.Size = New System.Drawing.Size(135, 19)
        Me.ButtonRun.TabIndex = 10
        Me.ButtonRun.Text = "Run Script"
        Me.ButtonRun.UseVisualStyleBackColor = True
        '
        'ButtonEdit
        '
        Me.ButtonEdit.Location = New System.Drawing.Point(196, 79)
        Me.ButtonEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonEdit.Name = "ButtonEdit"
        Me.ButtonEdit.Size = New System.Drawing.Size(135, 19)
        Me.ButtonEdit.TabIndex = 9
        Me.ButtonEdit.Text = "Edit Script"
        Me.ButtonEdit.UseVisualStyleBackColor = True
        '
        'ListBoxScripts
        '
        Me.ListBoxScripts.FormattingEnabled = True
        Me.ListBoxScripts.Location = New System.Drawing.Point(46, 13)
        Me.ListBoxScripts.Margin = New System.Windows.Forms.Padding(2)
        Me.ListBoxScripts.Name = "ListBoxScripts"
        Me.ListBoxScripts.Size = New System.Drawing.Size(126, 121)
        Me.ListBoxScripts.TabIndex = 8
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.BasicIdeCtl1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Size = New System.Drawing.Size(416, 266)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Scripts"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'BasicIdeCtl1
        '
        Me.BasicIdeCtl1.BackColor = System.Drawing.Color.White
        Me.BasicIdeCtl1.DefaultMacroName = "Script"
        Me.BasicIdeCtl1.DefaultObjectName = "Object.obm|Object"
        Me.BasicIdeCtl1.DefaultProjectName = "Project.wbp|wbm"
        Me.BasicIdeCtl1.DesignModeVisible = True
        Me.BasicIdeCtl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BasicIdeCtl1.FileChangeDir = False
        Me.BasicIdeCtl1.ForeColor = System.Drawing.Color.Black
        Me.BasicIdeCtl1.LargeIcon = CType(resources.GetObject("BasicIdeCtl1.LargeIcon"), System.Drawing.Icon)
        Me.BasicIdeCtl1.Location = New System.Drawing.Point(2, 2)
        Me.BasicIdeCtl1.Margin = New System.Windows.Forms.Padding(2)
        Me.BasicIdeCtl1.Name = "BasicIdeCtl1"
        Me.BasicIdeCtl1.NegotiateMenus = False
        Me.BasicIdeCtl1.Secret = New System.Guid("00000000-0000-0000-0000-000000000000")
        Me.BasicIdeCtl1.SelBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BasicIdeCtl1.SelForeColor = System.Drawing.Color.White
        Me.BasicIdeCtl1.Size = New System.Drawing.Size(412, 262)
        Me.BasicIdeCtl1.SmallIcon = CType(resources.GetObject("BasicIdeCtl1.SmallIcon"), System.Drawing.Icon)
        Me.BasicIdeCtl1.TabIndex = 1
        Me.BasicIdeCtl1.TaskbarIcon = CType(resources.GetObject("BasicIdeCtl1.TaskbarIcon"), System.Drawing.Icon)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 292)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents TabControl1 As System.Windows.Forms.TabControl
    Private WithEvents TabPage1 As System.Windows.Forms.TabPage
    Private WithEvents TextBox1 As System.Windows.Forms.TextBox
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents ButtonRun As System.Windows.Forms.Button
    Private WithEvents ButtonEdit As System.Windows.Forms.Button
    Private WithEvents ListBoxScripts As System.Windows.Forms.ListBox
    Private WithEvents TabPage2 As System.Windows.Forms.TabPage
    Private WithEvents BasicIdeCtl1 As WinWrap.Basic.BasicIdeCtl

End Class
