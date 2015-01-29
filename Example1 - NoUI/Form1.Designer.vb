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
        Me.panelControls = New System.Windows.Forms.Panel()
        Me.RichTextBoxOutput = New System.Windows.Forms.RichTextBox()
        Me.PanelRunScript = New System.Windows.Forms.Panel()
        Me.ListBoxScripts = New System.Windows.Forms.ListBox()
        Me.ButtonRunScript = New System.Windows.Forms.Button()
        Me.TextBoxScript = New System.Windows.Forms.TextBox()
        Me.panelControls.SuspendLayout()
        Me.PanelRunScript.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelControls
        '
        Me.panelControls.Controls.Add(Me.RichTextBoxOutput)
        Me.panelControls.Controls.Add(Me.PanelRunScript)
        Me.panelControls.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelControls.Location = New System.Drawing.Point(0, 0)
        Me.panelControls.Margin = New System.Windows.Forms.Padding(2)
        Me.panelControls.Name = "panelControls"
        Me.panelControls.Size = New System.Drawing.Size(514, 123)
        Me.panelControls.TabIndex = 4
        '
        'RichTextBoxOutput
        '
        Me.RichTextBoxOutput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBoxOutput.Location = New System.Drawing.Point(164, 0)
        Me.RichTextBoxOutput.Margin = New System.Windows.Forms.Padding(2)
        Me.RichTextBoxOutput.Name = "RichTextBoxOutput"
        Me.RichTextBoxOutput.Size = New System.Drawing.Size(350, 123)
        Me.RichTextBoxOutput.TabIndex = 1
        Me.RichTextBoxOutput.Text = ""
        '
        'PanelRunScript
        '
        Me.PanelRunScript.Controls.Add(Me.ListBoxScripts)
        Me.PanelRunScript.Controls.Add(Me.ButtonRunScript)
        Me.PanelRunScript.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelRunScript.Location = New System.Drawing.Point(0, 0)
        Me.PanelRunScript.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelRunScript.Name = "PanelRunScript"
        Me.PanelRunScript.Size = New System.Drawing.Size(164, 123)
        Me.PanelRunScript.TabIndex = 0
        '
        'ListBoxScripts
        '
        Me.ListBoxScripts.FormattingEnabled = True
        Me.ListBoxScripts.Location = New System.Drawing.Point(9, 32)
        Me.ListBoxScripts.Margin = New System.Windows.Forms.Padding(2)
        Me.ListBoxScripts.Name = "ListBoxScripts"
        Me.ListBoxScripts.Size = New System.Drawing.Size(146, 82)
        Me.ListBoxScripts.TabIndex = 1
        '
        'ButtonRunScript
        '
        Me.ButtonRunScript.Location = New System.Drawing.Point(9, 9)
        Me.ButtonRunScript.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonRunScript.Name = "ButtonRunScript"
        Me.ButtonRunScript.Size = New System.Drawing.Size(146, 19)
        Me.ButtonRunScript.TabIndex = 0
        Me.ButtonRunScript.Text = "Run Script"
        Me.ButtonRunScript.UseVisualStyleBackColor = True
        '
        'TextBoxScript
        '
        Me.TextBoxScript.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxScript.Location = New System.Drawing.Point(0, 127)
        Me.TextBoxScript.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxScript.Multiline = True
        Me.TextBoxScript.Name = "TextBoxScript"
        Me.TextBoxScript.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxScript.Size = New System.Drawing.Size(514, 186)
        Me.TextBoxScript.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 314)
        Me.Controls.Add(Me.panelControls)
        Me.Controls.Add(Me.TextBoxScript)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.panelControls.ResumeLayout(False)
        Me.PanelRunScript.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panelControls As System.Windows.Forms.Panel
    Private WithEvents RichTextBoxOutput As System.Windows.Forms.RichTextBox
    Private WithEvents PanelRunScript As System.Windows.Forms.Panel
    Private WithEvents ListBoxScripts As System.Windows.Forms.ListBox
    Private WithEvents ButtonRunScript As System.Windows.Forms.Button
    Private WithEvents TextBoxScript As System.Windows.Forms.TextBox

End Class
