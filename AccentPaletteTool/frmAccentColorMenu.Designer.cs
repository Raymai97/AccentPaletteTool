namespace AccentPaletteTool
{
    partial class frmAccentColorMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccentColorMenu));
            this.lblInfo = new System.Windows.Forms.Label();
            this.pActive = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnActiveFollow = new System.Windows.Forms.Button();
            this.btnActiveDefault = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkInactiveEnabled = new System.Windows.Forms.CheckBox();
            this.btnInactiveDefault = new System.Windows.Forms.Button();
            this.pInactive = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(369, 90);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = resources.GetString("lblInfo.Text");
            // 
            // pActive
            // 
            this.pActive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pActive.Location = new System.Drawing.Point(25, 22);
            this.pActive.Name = "pActive";
            this.pActive.Size = new System.Drawing.Size(80, 50);
            this.pActive.TabIndex = 2;
            this.pActive.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorPanel_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnActiveFollow);
            this.groupBox2.Controls.Add(this.btnActiveDefault);
            this.groupBox2.Controls.Add(this.pActive);
            this.groupBox2.Location = new System.Drawing.Point(15, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 140);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Active ...";
            // 
            // btnActiveFollow
            // 
            this.btnActiveFollow.Location = new System.Drawing.Point(25, 107);
            this.btnActiveFollow.Name = "btnActiveFollow";
            this.btnActiveFollow.Size = new System.Drawing.Size(80, 23);
            this.btnActiveFollow.TabIndex = 1;
            this.btnActiveFollow.Text = "Follow";
            this.btnActiveFollow.UseVisualStyleBackColor = true;
            this.btnActiveFollow.Click += new System.EventHandler(this.btnActiveFollow_Click);
            // 
            // btnActiveDefault
            // 
            this.btnActiveDefault.Location = new System.Drawing.Point(25, 78);
            this.btnActiveDefault.Name = "btnActiveDefault";
            this.btnActiveDefault.Size = new System.Drawing.Size(80, 23);
            this.btnActiveDefault.TabIndex = 0;
            this.btnActiveDefault.Text = "Default";
            this.btnActiveDefault.UseVisualStyleBackColor = true;
            this.btnActiveDefault.Click += new System.EventHandler(this.btnActiveDefault_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkInactiveEnabled);
            this.groupBox1.Controls.Add(this.btnInactiveDefault);
            this.groupBox1.Controls.Add(this.pInactive);
            this.groupBox1.Location = new System.Drawing.Point(151, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 140);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inactive ...";
            // 
            // chkInactiveEnabled
            // 
            this.chkInactiveEnabled.AutoSize = true;
            this.chkInactiveEnabled.Location = new System.Drawing.Point(25, 111);
            this.chkInactiveEnabled.Name = "chkInactiveEnabled";
            this.chkInactiveEnabled.Size = new System.Drawing.Size(68, 19);
            this.chkInactiveEnabled.TabIndex = 1;
            this.chkInactiveEnabled.Text = "Enabled";
            this.chkInactiveEnabled.UseVisualStyleBackColor = true;
            this.chkInactiveEnabled.CheckedChanged += new System.EventHandler(this.chkInactiveEnabled_CheckedChanged);
            // 
            // btnInactiveDefault
            // 
            this.btnInactiveDefault.Location = new System.Drawing.Point(25, 78);
            this.btnInactiveDefault.Name = "btnInactiveDefault";
            this.btnInactiveDefault.Size = new System.Drawing.Size(80, 23);
            this.btnInactiveDefault.TabIndex = 0;
            this.btnInactiveDefault.Text = "Default";
            this.btnInactiveDefault.UseVisualStyleBackColor = true;
            this.btnInactiveDefault.Click += new System.EventHandler(this.btnInactiveDefault_Click);
            // 
            // pInactive
            // 
            this.pInactive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pInactive.Location = new System.Drawing.Point(25, 22);
            this.pInactive.Name = "pInactive";
            this.pInactive.Size = new System.Drawing.Size(80, 50);
            this.pInactive.TabIndex = 2;
            this.pInactive.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorPanel_MouseClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(303, 194);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(303, 223);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmAccentColorMenu
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(400, 260);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAccentColorMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AccentColorMenu";
            this.Load += new System.EventHandler(this.frmAccentColorMenu_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel pActive;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnActiveFollow;
        private System.Windows.Forms.Button btnActiveDefault;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkInactiveEnabled;
        private System.Windows.Forms.Button btnInactiveDefault;
        private System.Windows.Forms.Panel pInactive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}