namespace EVEMon.Updater
{
    partial class UpdateNotifyForm
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnLater = new System.Windows.Forms.Button();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.updateNotesTextBox = new System.Windows.Forms.RichTextBox();
            this.cbAutoInstall = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(297, 426);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update...";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnLater
            // 
            this.btnLater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLater.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLater.Location = new System.Drawing.Point(171, 426);
            this.btnLater.Name = "btnLater";
            this.btnLater.Size = new System.Drawing.Size(120, 23);
            this.btnLater.TabIndex = 1;
            this.btnLater.Text = "Remind Me Later";
            this.btnLater.UseVisualStyleBackColor = true;
            this.btnLater.Click += new System.EventHandler(this.btnLater_Click);
            // 
            // btnIgnore
            // 
            this.btnIgnore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIgnore.Location = new System.Drawing.Point(50, 426);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(115, 23);
            this.btnIgnore.TabIndex = 2;
            this.btnIgnore.Text = "Ignore This Update";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelInfo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.updateNotesTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbAutoInstall, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 408);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(3, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(226, 78);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "An EVEMon update is available.\r\n\r\nCurrent version: {0}\r\nNewest version: {1}\r\n\r\nTh" +
    "e newest version has the following updates:";
            // 
            // updateNotesTextBox
            // 
            this.updateNotesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateNotesTextBox.Location = new System.Drawing.Point(3, 81);
            this.updateNotesTextBox.Name = "updateNotesTextBox";
            this.updateNotesTextBox.Size = new System.Drawing.Size(354, 301);
            this.updateNotesTextBox.TabIndex = 1;
            this.updateNotesTextBox.Text = "";
            // 
            // cbAutoInstall
            // 
            this.cbAutoInstall.AutoSize = true;
            this.cbAutoInstall.Location = new System.Drawing.Point(3, 388);
            this.cbAutoInstall.Name = "cbAutoInstall";
            this.cbAutoInstall.Size = new System.Drawing.Size(172, 17);
            this.cbAutoInstall.TabIndex = 2;
            this.cbAutoInstall.Text = "Automatically install this update";
            this.cbAutoInstall.UseVisualStyleBackColor = true;
            // 
            // UpdateNotifyForm
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnLater;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.btnLater);
            this.Controls.Add(this.btnUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateNotifyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Available";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnLater;
        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.RichTextBox updateNotesTextBox;
        private System.Windows.Forms.CheckBox cbAutoInstall;



    }
}