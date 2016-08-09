using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Viewer17
{
    public partial class SettingForm : Form
    {
        private Setting _setting;
        private BindingList<ConsolePanel> _panels;
        private BindingList<ConsoleButton> _buttons;

        private GridCtrl _gridCtrl;

        public SettingForm(Setting setting)
        {
            _panels = new BindingList<ConsolePanel>();
            _buttons = new BindingList<ConsoleButton>();

            _setting = setting;
            if (_setting.load())
            {
                _panels = new BindingList<ConsolePanel>(_setting.panels);
            }

            _gridCtrl = null;

            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            _gridCtrl = new GridCtrl(_setting, this, dataGridViewPanel, buttonPanelAdd, buttonPanelUp, buttonPanelDown, dataGridViewButton, buttonButtonAdd, buttonButtonUp, buttonButtonDown);

            // 
            radioButtonPanelMenu.Checked = true;

            // 
            _gridCtrl.initControls(dataGridViewPanel);
            _gridCtrl.initControls(dataGridViewButton);

            textBoxDstDirPath.Text = _setting.dstDirPath;

            if (_setting.buttonSize.Width > numericUpDownButtonWidth.Maximum)
            {
                numericUpDownButtonWidth.Value = numericUpDownButtonWidth.Maximum;
            }
            else if (_setting.buttonSize.Width < numericUpDownButtonWidth.Minimum)
            {
                numericUpDownButtonWidth.Value = numericUpDownButtonWidth.Minimum;
            }
            else
            {
                numericUpDownButtonWidth.Value = _setting.buttonSize.Width;
            }

            if (_setting.buttonSize.Height > numericUpDownButtonHeight.Maximum)
            {
                numericUpDownButtonHeight.Value = numericUpDownButtonHeight.Maximum;
            }
            else if (_setting.buttonSize.Height < numericUpDownButtonHeight.Minimum)
            {
                numericUpDownButtonHeight.Value = numericUpDownButtonHeight.Minimum;
            }
            else
            {
                numericUpDownButtonHeight.Value = _setting.buttonSize.Height;
            }

            checkBoxLefty.Checked = _setting.lefty;

            this.updateControls();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            _setting.panels = new List<ConsolePanel>(_panels);

            _setting.dstDirPath = textBoxDstDirPath.Text;
            _setting.buttonSize = new Size((int)numericUpDownButtonWidth.Value, (int)numericUpDownButtonHeight.Value);
            _setting.lefty = checkBoxLefty.Checked;

            _setting.save();
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _setting = new Setting();
            if (_setting.load())
            {
                _panels = new BindingList<ConsolePanel>(_setting.panels);
            }

            this.Close();
        }

        private void radioButtonPanelMenu_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPanelMenu.Checked)
            {
                this.updateControls();
            }
        }

        private void radioButtonEtcMenu_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEtcMenu.Checked)
            {
                this.updateControls();
            }
        }

        private void buttonDstDirPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                textBoxDstDirPath.Text = dlg.SelectedPath;
            }
        }

        private void buttonButtonSizeReset_Click(object sender, EventArgs e)
        {
            numericUpDownButtonWidth.Value = 150;
            numericUpDownButtonHeight.Value = 30;
        }

        private void linkLabelUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://jpico.info");
        }

        private void updateControls()
        {
            if (radioButtonPanelMenu.Checked == true)
            {
                tabControlMenu.SelectedTab = tabPagePanelMenu;

                _gridCtrl.updateControls();
            }

            if (radioButtonEtcMenu.Checked == true)
            {
                tabControlMenu.SelectedTab = tabPageEtcMenu;

                textBoxDstDirPath.Show();
                buttonDstDirPath.Show();

                if (_setting.level >= 17)
                {
                    labelButtonSize.Show();
                    labelButtonWidth.Show();
                    numericUpDownButtonWidth.Show();
                    labelButtonHeight.Show();
                    numericUpDownButtonHeight.Show();
                    buttonButtonSizeReset.Show();
                }
                else
                {
                    labelButtonSize.Hide();
                    labelButtonWidth.Hide();
                    numericUpDownButtonWidth.Hide();
                    labelButtonHeight.Hide();
                    numericUpDownButtonHeight.Hide();
                    buttonButtonSizeReset.Hide();
                }

                if (_setting.level >= 170)
                {
                    checkBoxLefty.Show();
                }
                else
                {
                    checkBoxLefty.Checked = false;
                    checkBoxLefty.Hide();
                }
            }
        }
    }
}
