namespace Viewer17
{
    partial class SettingForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlMenu = new System.Windows.Forms.TabControl();
            this.tabPagePanelMenu = new System.Windows.Forms.TabPage();
            this.pictureBoxInclude = new System.Windows.Forms.PictureBox();
            this.labelButton = new System.Windows.Forms.Label();
            this.labelPanel = new System.Windows.Forms.Label();
            this.buttonButtonAdd = new System.Windows.Forms.Button();
            this.buttonButtonDown = new System.Windows.Forms.Button();
            this.buttonButtonUp = new System.Windows.Forms.Button();
            this.dataGridViewButton = new System.Windows.Forms.DataGridView();
            this.buttonPanelAdd = new System.Windows.Forms.Button();
            this.buttonPanelDown = new System.Windows.Forms.Button();
            this.buttonPanelUp = new System.Windows.Forms.Button();
            this.dataGridViewPanel = new System.Windows.Forms.DataGridView();
            this.tabPageEtcMenu = new System.Windows.Forms.TabPage();
            this.buttonButtonSizeReset = new System.Windows.Forms.Button();
            this.labelButtonHeight = new System.Windows.Forms.Label();
            this.numericUpDownButtonHeight = new System.Windows.Forms.NumericUpDown();
            this.labelButtonWidth = new System.Windows.Forms.Label();
            this.numericUpDownButtonWidth = new System.Windows.Forms.NumericUpDown();
            this.labelButtonSize = new System.Windows.Forms.Label();
            this.labelDstDirPath = new System.Windows.Forms.Label();
            this.linkLabelUrl = new System.Windows.Forms.LinkLabel();
            this.buttonDstDirPath = new System.Windows.Forms.Button();
            this.textBoxDstDirPath = new System.Windows.Forms.TextBox();
            this.checkBoxLefty = new System.Windows.Forms.CheckBox();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.radioButtonPanelMenu = new System.Windows.Forms.RadioButton();
            this.radioButtonEtcMenu = new System.Windows.Forms.RadioButton();
            this.bindingSourcePanel = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceButton = new System.Windows.Forms.BindingSource(this.components);
            this.tabControlMenu.SuspendLayout();
            this.tabPagePanelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInclude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPanel)).BeginInit();
            this.tabPageEtcMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownButtonHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownButtonWidth)).BeginInit();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceButton)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMenu
            // 
            resources.ApplyResources(this.tabControlMenu, "tabControlMenu");
            this.tabControlMenu.Controls.Add(this.tabPagePanelMenu);
            this.tabControlMenu.Controls.Add(this.tabPageEtcMenu);
            this.tabControlMenu.Name = "tabControlMenu";
            this.tabControlMenu.SelectedIndex = 0;
            this.tabControlMenu.TabStop = false;
            // 
            // tabPagePanelMenu
            // 
            resources.ApplyResources(this.tabPagePanelMenu, "tabPagePanelMenu");
            this.tabPagePanelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPagePanelMenu.Controls.Add(this.pictureBoxInclude);
            this.tabPagePanelMenu.Controls.Add(this.labelButton);
            this.tabPagePanelMenu.Controls.Add(this.labelPanel);
            this.tabPagePanelMenu.Controls.Add(this.buttonButtonAdd);
            this.tabPagePanelMenu.Controls.Add(this.buttonButtonDown);
            this.tabPagePanelMenu.Controls.Add(this.buttonButtonUp);
            this.tabPagePanelMenu.Controls.Add(this.dataGridViewButton);
            this.tabPagePanelMenu.Controls.Add(this.buttonPanelAdd);
            this.tabPagePanelMenu.Controls.Add(this.buttonPanelDown);
            this.tabPagePanelMenu.Controls.Add(this.buttonPanelUp);
            this.tabPagePanelMenu.Controls.Add(this.dataGridViewPanel);
            this.tabPagePanelMenu.Name = "tabPagePanelMenu";
            // 
            // pictureBoxInclude
            // 
            resources.ApplyResources(this.pictureBoxInclude, "pictureBoxInclude");
            this.pictureBoxInclude.Name = "pictureBoxInclude";
            this.pictureBoxInclude.TabStop = false;
            // 
            // labelButton
            // 
            resources.ApplyResources(this.labelButton, "labelButton");
            this.labelButton.ForeColor = System.Drawing.Color.Silver;
            this.labelButton.Name = "labelButton";
            // 
            // labelPanel
            // 
            resources.ApplyResources(this.labelPanel, "labelPanel");
            this.labelPanel.ForeColor = System.Drawing.Color.Silver;
            this.labelPanel.Name = "labelPanel";
            // 
            // buttonButtonAdd
            // 
            resources.ApplyResources(this.buttonButtonAdd, "buttonButtonAdd");
            this.buttonButtonAdd.BackColor = System.Drawing.Color.Transparent;
            this.buttonButtonAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonButtonAdd.Name = "buttonButtonAdd";
            this.buttonButtonAdd.UseVisualStyleBackColor = false;
            // 
            // buttonButtonDown
            // 
            resources.ApplyResources(this.buttonButtonDown, "buttonButtonDown");
            this.buttonButtonDown.BackColor = System.Drawing.Color.Transparent;
            this.buttonButtonDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonButtonDown.Name = "buttonButtonDown";
            this.buttonButtonDown.UseVisualStyleBackColor = false;
            // 
            // buttonButtonUp
            // 
            resources.ApplyResources(this.buttonButtonUp, "buttonButtonUp");
            this.buttonButtonUp.BackColor = System.Drawing.Color.Transparent;
            this.buttonButtonUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonButtonUp.Name = "buttonButtonUp";
            this.buttonButtonUp.UseVisualStyleBackColor = false;
            // 
            // dataGridViewButton
            // 
            resources.ApplyResources(this.dataGridViewButton, "dataGridViewButton");
            this.dataGridViewButton.AllowUserToAddRows = false;
            this.dataGridViewButton.AllowUserToResizeColumns = false;
            this.dataGridViewButton.AllowUserToResizeRows = false;
            this.dataGridViewButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridViewButton.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewButton.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridViewButton.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewButton.MultiSelect = false;
            this.dataGridViewButton.Name = "dataGridViewButton";
            this.dataGridViewButton.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Silver;
            this.dataGridViewButton.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewButton.RowTemplate.Height = 21;
            this.dataGridViewButton.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // buttonPanelAdd
            // 
            resources.ApplyResources(this.buttonPanelAdd, "buttonPanelAdd");
            this.buttonPanelAdd.BackColor = System.Drawing.Color.Transparent;
            this.buttonPanelAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonPanelAdd.Name = "buttonPanelAdd";
            this.buttonPanelAdd.UseVisualStyleBackColor = false;
            // 
            // buttonPanelDown
            // 
            resources.ApplyResources(this.buttonPanelDown, "buttonPanelDown");
            this.buttonPanelDown.BackColor = System.Drawing.Color.Transparent;
            this.buttonPanelDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonPanelDown.Name = "buttonPanelDown";
            this.buttonPanelDown.UseVisualStyleBackColor = false;
            // 
            // buttonPanelUp
            // 
            resources.ApplyResources(this.buttonPanelUp, "buttonPanelUp");
            this.buttonPanelUp.BackColor = System.Drawing.Color.Transparent;
            this.buttonPanelUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonPanelUp.Name = "buttonPanelUp";
            this.buttonPanelUp.UseVisualStyleBackColor = false;
            // 
            // dataGridViewPanel
            // 
            resources.ApplyResources(this.dataGridViewPanel, "dataGridViewPanel");
            this.dataGridViewPanel.AllowUserToAddRows = false;
            this.dataGridViewPanel.AllowUserToResizeColumns = false;
            this.dataGridViewPanel.AllowUserToResizeRows = false;
            this.dataGridViewPanel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridViewPanel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPanel.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridViewPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPanel.MultiSelect = false;
            this.dataGridViewPanel.Name = "dataGridViewPanel";
            this.dataGridViewPanel.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Silver;
            this.dataGridViewPanel.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewPanel.RowTemplate.Height = 21;
            this.dataGridViewPanel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // tabPageEtcMenu
            // 
            resources.ApplyResources(this.tabPageEtcMenu, "tabPageEtcMenu");
            this.tabPageEtcMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageEtcMenu.Controls.Add(this.buttonButtonSizeReset);
            this.tabPageEtcMenu.Controls.Add(this.labelButtonHeight);
            this.tabPageEtcMenu.Controls.Add(this.numericUpDownButtonHeight);
            this.tabPageEtcMenu.Controls.Add(this.labelButtonWidth);
            this.tabPageEtcMenu.Controls.Add(this.numericUpDownButtonWidth);
            this.tabPageEtcMenu.Controls.Add(this.labelButtonSize);
            this.tabPageEtcMenu.Controls.Add(this.labelDstDirPath);
            this.tabPageEtcMenu.Controls.Add(this.linkLabelUrl);
            this.tabPageEtcMenu.Controls.Add(this.buttonDstDirPath);
            this.tabPageEtcMenu.Controls.Add(this.textBoxDstDirPath);
            this.tabPageEtcMenu.Controls.Add(this.checkBoxLefty);
            this.tabPageEtcMenu.Name = "tabPageEtcMenu";
            // 
            // buttonButtonSizeReset
            // 
            resources.ApplyResources(this.buttonButtonSizeReset, "buttonButtonSizeReset");
            this.buttonButtonSizeReset.BackColor = System.Drawing.Color.Transparent;
            this.buttonButtonSizeReset.ForeColor = System.Drawing.Color.Gray;
            this.buttonButtonSizeReset.Name = "buttonButtonSizeReset";
            this.buttonButtonSizeReset.UseVisualStyleBackColor = false;
            this.buttonButtonSizeReset.Click += new System.EventHandler(this.buttonButtonSizeReset_Click);
            // 
            // labelButtonHeight
            // 
            resources.ApplyResources(this.labelButtonHeight, "labelButtonHeight");
            this.labelButtonHeight.ForeColor = System.Drawing.Color.Silver;
            this.labelButtonHeight.Name = "labelButtonHeight";
            // 
            // numericUpDownButtonHeight
            // 
            resources.ApplyResources(this.numericUpDownButtonHeight, "numericUpDownButtonHeight");
            this.numericUpDownButtonHeight.BackColor = System.Drawing.Color.Silver;
            this.numericUpDownButtonHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownButtonHeight.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownButtonHeight.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownButtonHeight.Name = "numericUpDownButtonHeight";
            this.numericUpDownButtonHeight.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // labelButtonWidth
            // 
            resources.ApplyResources(this.labelButtonWidth, "labelButtonWidth");
            this.labelButtonWidth.ForeColor = System.Drawing.Color.Silver;
            this.labelButtonWidth.Name = "labelButtonWidth";
            // 
            // numericUpDownButtonWidth
            // 
            resources.ApplyResources(this.numericUpDownButtonWidth, "numericUpDownButtonWidth");
            this.numericUpDownButtonWidth.BackColor = System.Drawing.Color.Silver;
            this.numericUpDownButtonWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownButtonWidth.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownButtonWidth.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownButtonWidth.Name = "numericUpDownButtonWidth";
            this.numericUpDownButtonWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // labelButtonSize
            // 
            resources.ApplyResources(this.labelButtonSize, "labelButtonSize");
            this.labelButtonSize.ForeColor = System.Drawing.Color.Silver;
            this.labelButtonSize.Name = "labelButtonSize";
            // 
            // labelDstDirPath
            // 
            resources.ApplyResources(this.labelDstDirPath, "labelDstDirPath");
            this.labelDstDirPath.ForeColor = System.Drawing.Color.Silver;
            this.labelDstDirPath.Name = "labelDstDirPath";
            // 
            // linkLabelUrl
            // 
            resources.ApplyResources(this.linkLabelUrl, "linkLabelUrl");
            this.linkLabelUrl.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkLabelUrl.LinkColor = System.Drawing.Color.Silver;
            this.linkLabelUrl.Name = "linkLabelUrl";
            this.linkLabelUrl.TabStop = true;
            this.linkLabelUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUrl_LinkClicked);
            // 
            // buttonDstDirPath
            // 
            resources.ApplyResources(this.buttonDstDirPath, "buttonDstDirPath");
            this.buttonDstDirPath.BackColor = System.Drawing.Color.Transparent;
            this.buttonDstDirPath.ForeColor = System.Drawing.Color.Gray;
            this.buttonDstDirPath.Name = "buttonDstDirPath";
            this.buttonDstDirPath.UseVisualStyleBackColor = false;
            this.buttonDstDirPath.Click += new System.EventHandler(this.buttonDstDirPath_Click);
            // 
            // textBoxDstDirPath
            // 
            resources.ApplyResources(this.textBoxDstDirPath, "textBoxDstDirPath");
            this.textBoxDstDirPath.BackColor = System.Drawing.Color.Silver;
            this.textBoxDstDirPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDstDirPath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxDstDirPath.Name = "textBoxDstDirPath";
            // 
            // checkBoxLefty
            // 
            resources.ApplyResources(this.checkBoxLefty, "checkBoxLefty");
            this.checkBoxLefty.ForeColor = System.Drawing.Color.Silver;
            this.checkBoxLefty.Name = "checkBoxLefty";
            this.checkBoxLefty.UseVisualStyleBackColor = true;
            // 
            // panelFooter
            // 
            resources.ApplyResources(this.panelFooter, "panelFooter");
            this.panelFooter.BackColor = System.Drawing.Color.Transparent;
            this.panelFooter.Controls.Add(this.buttonCancel);
            this.panelFooter.Controls.Add(this.buttonOk);
            this.panelFooter.Name = "panelFooter";
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.ForeColor = System.Drawing.Color.Gray;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            resources.ApplyResources(this.buttonOk, "buttonOk");
            this.buttonOk.BackColor = System.Drawing.Color.Transparent;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.ForeColor = System.Drawing.Color.Gray;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // radioButtonPanelMenu
            // 
            resources.ApplyResources(this.radioButtonPanelMenu, "radioButtonPanelMenu");
            this.radioButtonPanelMenu.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonPanelMenu.ForeColor = System.Drawing.Color.Gray;
            this.radioButtonPanelMenu.Name = "radioButtonPanelMenu";
            this.radioButtonPanelMenu.TabStop = true;
            this.radioButtonPanelMenu.UseVisualStyleBackColor = false;
            this.radioButtonPanelMenu.CheckedChanged += new System.EventHandler(this.radioButtonPanelMenu_CheckedChanged);
            // 
            // radioButtonEtcMenu
            // 
            resources.ApplyResources(this.radioButtonEtcMenu, "radioButtonEtcMenu");
            this.radioButtonEtcMenu.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonEtcMenu.ForeColor = System.Drawing.Color.Gray;
            this.radioButtonEtcMenu.Name = "radioButtonEtcMenu";
            this.radioButtonEtcMenu.TabStop = true;
            this.radioButtonEtcMenu.UseVisualStyleBackColor = false;
            this.radioButtonEtcMenu.CheckedChanged += new System.EventHandler(this.radioButtonEtcMenu_CheckedChanged);
            // 
            // SettingForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.radioButtonPanelMenu);
            this.Controls.Add(this.radioButtonEtcMenu);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.tabControlMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.tabControlMenu.ResumeLayout(false);
            this.tabPagePanelMenu.ResumeLayout(false);
            this.tabPagePanelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInclude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPanel)).EndInit();
            this.tabPageEtcMenu.ResumeLayout(false);
            this.tabPageEtcMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownButtonHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownButtonWidth)).EndInit();
            this.panelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourcePanel;
        private System.Windows.Forms.TabControl tabControlMenu;
        private System.Windows.Forms.TabPage tabPagePanelMenu;
        private System.Windows.Forms.TabPage tabPageEtcMenu;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.RadioButton radioButtonPanelMenu;
        private System.Windows.Forms.RadioButton radioButtonEtcMenu;
        private System.Windows.Forms.BindingSource bindingSourceButton;
        private System.Windows.Forms.Label labelButton;
        private System.Windows.Forms.Label labelPanel;
        private System.Windows.Forms.Button buttonButtonAdd;
        private System.Windows.Forms.Button buttonButtonDown;
        private System.Windows.Forms.Button buttonButtonUp;
        private System.Windows.Forms.DataGridView dataGridViewButton;
        private System.Windows.Forms.Button buttonPanelAdd;
        private System.Windows.Forms.Button buttonPanelDown;
        private System.Windows.Forms.Button buttonPanelUp;
        private System.Windows.Forms.DataGridView dataGridViewPanel;
        private System.Windows.Forms.PictureBox pictureBoxInclude;
        private System.Windows.Forms.LinkLabel linkLabelUrl;
        private System.Windows.Forms.Button buttonDstDirPath;
        private System.Windows.Forms.TextBox textBoxDstDirPath;
        private System.Windows.Forms.CheckBox checkBoxLefty;
        private System.Windows.Forms.Label labelDstDirPath;
        private System.Windows.Forms.Button buttonButtonSizeReset;
        private System.Windows.Forms.Label labelButtonHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownButtonHeight;
        private System.Windows.Forms.Label labelButtonWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownButtonWidth;
        private System.Windows.Forms.Label labelButtonSize;
    }
}

