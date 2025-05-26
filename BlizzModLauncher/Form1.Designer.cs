namespace BlizzModLauncher
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckBox checkBoxLaunchWatcher;
        private System.Windows.Forms.Label labelStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.checkBoxLaunchWatcher = new System.Windows.Forms.CheckBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxLaunchWatcher
            // 
            this.checkBoxLaunchWatcher.AutoSize = true;
            this.checkBoxLaunchWatcher.Location = new System.Drawing.Point(25, 25);
            this.checkBoxLaunchWatcher.Name = "checkBoxLaunchWatcher";
            this.checkBoxLaunchWatcher.Size = new System.Drawing.Size(106, 17);
            this.checkBoxLaunchWatcher.TabIndex = 0;
            this.checkBoxLaunchWatcher.Text = "Launch Watcher";
            this.checkBoxLaunchWatcher.UseVisualStyleBackColor = true;
            this.checkBoxLaunchWatcher.CheckedChanged += new System.EventHandler(this.checkBoxLaunchWatcher_CheckedChanged);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(25, 60);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(67, 13);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Not Running";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(250, 120);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.checkBoxLaunchWatcher);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Watcher Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
