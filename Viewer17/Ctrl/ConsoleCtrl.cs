using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;

namespace Viewer17
{
    internal class ConsoleCtrl
    {
        private Setting _setting;
        private MainForm _form;

        private Label _labelOpe;
        private Label _labelSrc;
        private Label _labelDst;

        List<Panel> _panels;
        List<Label> _labels;
        List<Button> _buttons;

        private string _filePath;
        public string filePath { set { _filePath = value; } }

        // Undo用の配列
        private List<KeyValuePair<string, string>> _histories;

        private ImageCtrl _imageCtrl;
        public ImageCtrl imageCtrl { set { _imageCtrl = value; } }

        public ConsoleCtrl(Setting setting, MainForm form, Label labelOpe, Label labelSrc, Label labelDst)
        {
            _setting = setting;
            _form = form;

            _labelOpe = labelOpe;
            _labelSrc = labelSrc;
            _labelDst = labelDst;

            _panels = new List<Panel>();
            _labels = new List<Label>();
            _buttons = new List<Button>();

            _filePath = "";
            _histories = new List<KeyValuePair<string, string>>();

            _imageCtrl = null;
        }

        public void initControls(List<ConsolePanel> panels)
        {
            _labelOpe.Text = "";
            _labelSrc.Text = "";
            _labelDst.Text = "";

            // 後始末
            foreach (Panel panel in _panels)
            {
                panel.Controls.Clear();
                _form.Controls.Remove(panel);
            }

            _panels.Clear();
            _labels.Clear();
            _buttons.Clear();

            // 
            foreach (ConsolePanel panel in panels)
            {
                // 
                if (panel.title != "")
                {
                    Panel newPanel = new Panel();
                    newPanel.Tag = panel;
                    newPanel.Visible = false;
                    newPanel.Width = _setting.buttonSize.Width + 30;    // 180

                    int buttonCount = 0;
                    foreach (ConsoleButton button in panel.buttons)
                    {
                        if (button.title != "")
                        {
                            buttonCount++;
                        }
                    }

                    newPanel.Height = 40 + (_setting.buttonSize.Height + 10) * buttonCount;  // 40
                    newPanel.BackColor = panel.bgColor;

                    _form.Controls.Add(newPanel);
                    _panels.Add(newPanel);

                    Label newLabel = new Label();
                    //newLabel.Visible = false;
                    newLabel.Text = panel.title;
                    newLabel.ForeColor = panel.fgColor;

                    newLabel.Top = 10;
                    newLabel.Left = 10;
                    newLabel.Width = _setting.buttonSize.Width + 20;    // 170

                    newPanel.Controls.Add(newLabel);

                    // 
                    int i = 0;
                    foreach (ConsoleButton button in panel.buttons)
                    {
                        if (button.title != "")
                        {
                            Button newButton = new Button();
                            newButton.Tag = button;
                            //newButton.Visible = false;
                            newButton.Width = _setting.buttonSize.Width;    // 150
                            newButton.Height = _setting.buttonSize.Height;  // 30;
                            newButton.Text = button.title;
                            newButton.BackColor = Color.Transparent;
                            newButton.ForeColor = panel.fgColor;
                            newButton.FlatStyle = FlatStyle.Flat;

                            if (button.iconPath != null && button.iconPath != "")
                            {
                                string iconPath = button.iconPath;
                                if (System.IO.Path.IsPathRooted(iconPath) == false)
                                {
                                    iconPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + iconPath;
                                }

                                try
                                {
                                    newButton.Image = new Bitmap(iconPath);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }

                            newButton.ImageAlign = ContentAlignment.MiddleLeft;

                            newButton.Top = 40 + ((_setting.buttonSize.Height + 10) * i);   // 40
                            newButton.Left = 15;

                            newButton.Click += new EventHandler(this.button_Click);

                            newPanel.Controls.Add(newButton);
                            _buttons.Add(newButton);
                            i++;
                        }
                    }
                }
            }

            //if (_imageCtrl != null)
            //{
            //    _imageCtrl.sendControlsToBack();
            //}
        }

        public void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    {
                        bool next = false;

                        // UnDo
                        this.deleteFile(_filePath, ref next);

                        if (next)
                        {
                            this.updateControls(_setting.act, true);
                        }
                        else
                        {
                            this.updateControls(_setting.act, false);
                        }
                    }
                    break;

                case Keys.Z:
                    if (e.Modifiers == Keys.Control)
                    {
                        if (_histories.Count > 0)
                        {
                            bool next = false;

                            // UnDo
                            this.undo(ref next);

                            if (next)
                            {
                                this.updateControls(_setting.act, true);
                            }
                            else
                            {
                                this.updateControls(_setting.act, false);
                            }
                        }
                    }
                    break;

                default:
                    break;
            }

            // 
            foreach (Button button in _buttons)
            {
                ConsoleButton consoleButton = (ConsoleButton)button.Tag;

                if (consoleButton.key != ConsoleButton.Key.None)
                {
                    if (consoleButton.key.ToString() == e.KeyCode.ToString())
                    {
                        this.button_Click(button, null);
                    }
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ConsoleButton consoleButton = (ConsoleButton)button.Tag;

            bool next = false;
            switch (consoleButton.ope)
            {
                case ConsoleButton.Ope.Move:
                    if (consoleButton.dirName != "")
                    {
                        this.moveOrCopyFile(_filePath, consoleButton.dirName, true, ref next);
                    }
                    else
                    {
                        this.moveOrCopyFile(_filePath, consoleButton.title, true, ref next);
                    }
                    break;

                case ConsoleButton.Ope.Copy:
                    if (consoleButton.dirName != "")
                    {
                        this.moveOrCopyFile(_filePath, consoleButton.dirName, false, ref next);
                    }
                    else
                    {
                        this.moveOrCopyFile(_filePath, consoleButton.title, false, ref next);
                    }
                    break;

                case ConsoleButton.Ope.Delete:
                    this.deleteFile(_filePath, ref next);
                    break;

                case ConsoleButton.Ope.Undo:
                    this.undo(ref next);
                    break;

                default:
                    break;
            }

            if (next)
            {
                this.updateControls(_setting.act, true);
            }
            else
            {
                this.updateControls(_setting.act, false);
            }
        }

        private void moveOrCopyFile(string filePath, string dirName, bool move, ref bool next)
        {
            next = false;

            if (filePath == "")
            {
                return;
            }

            if (dirName == "")
            {
                return;
            }

            string dstFilePath = "";
            System.IO.FileInfo fi = new System.IO.FileInfo(filePath);

            if (_setting.dstDirPath == "")
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + dirName);
                dstFilePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + dirName + @"\" + fi.Name;
            }
            else
            {
                System.IO.Directory.CreateDirectory(_setting.dstDirPath + @"\" + dirName);
                dstFilePath = _setting.dstDirPath + @"\" + dirName + @"\" + fi.Name;
            }

            try
            {
                if (move)
                {
                    System.IO.File.Move(filePath, dstFilePath);

                    KeyValuePair<string, string> history = new KeyValuePair<string, string>(filePath, dstFilePath);
                    _histories.Add(history);

                    _imageCtrl.removeCurImage(ref next);

                    _labelOpe.Text = "Moved";
                    _labelSrc.Text = filePath;
                    _labelDst.Text = "-> " + dstFilePath;
                }
                else
                {
                    System.IO.File.Copy(filePath, dstFilePath);
                    next = true;

                    _labelOpe.Text = "Copied";
                    _labelSrc.Text = filePath;
                    _labelDst.Text = "-> " + dstFilePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                // すでに存在している
                _labelOpe.Text = "Nothing to do.";
                _labelSrc.Text = "";
                _labelDst.Text = "";
                next = true;
                return;
            }
        }

        private void deleteFile(string filePath, ref bool next)
        {
            next = false;

            if (filePath == "")
            {
                return;
            }

            try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(filePath, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);

                _imageCtrl.removeCurImage(ref next);

                _labelOpe.Text = "Deleted";
                _labelSrc.Text = filePath;
                _labelDst.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                _labelOpe.Text = "Nothing to do.";
                _labelSrc.Text = "";
                _labelDst.Text = "";
                next = true;
                return;
            }
        }

        private void undo(ref bool next)
        {
            if (_histories.Count == 0)
            {
                return;
            }

            KeyValuePair<string, string> histrory = _histories[_histories.Count - 1];

            try
            {
                System.IO.File.Move(histrory.Value, histrory.Key);

                _imageCtrl.addImage(histrory.Key, ref next);

                _histories.RemoveAt(_histories.Count - 1);

                _labelOpe.Text = "Moved";
                _labelSrc.Text = histrory.Value;
                _labelDst.Text = "-> " + histrory.Key;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                // すでに存在している
                _labelOpe.Text = "Nothing to do.";
                _labelSrc.Text = "";
                _labelDst.Text = "";
                next = true;
                return;
            }
        }

        public void clearOpeMessage()
        {
            _labelOpe.Text = "";
            _labelSrc.Text = "";
            _labelDst.Text = "";
        }

        public void bringControlsToFront()
        {
            foreach (Panel panel in _panels)
            {
                panel.BringToFront();
            }

            _form.bringControlsToFront();
        }

        public void updateControls(Setting.Act act, bool opened = false, bool resizing = false)
        {
            this.bringControlsToFront();
            // 
            //_imageCtrl.sendControlsToBack();

            if (resizing)
            {
                _labelOpe.Visible = false;
                _labelSrc.Visible = false;
                _labelDst.Visible = false;

                foreach (Panel panel in _panels)
                {
                    panel.Visible = false;
                }

                return;
            }

            switch (_setting.act)
            {
                case Setting.Act.Act1:
                    _labelOpe.Left = 12;
                    break;

                case Setting.Act.Act2:
                    _labelOpe.Left = _setting.buttonSize.Width + 30 + 50;
                    break;

                case Setting.Act.Act3:
                    _labelOpe.Left = _setting.buttonSize.Width + 30 + 50;
                    break;

                default:
                    break;
            }

            _labelOpe.Top = _form.ClientRectangle.Height - 48;
            _labelSrc.Left = _labelOpe.Left;
            _labelSrc.Top = _form.ClientRectangle.Height - 34;
            _labelDst.Left = _labelOpe.Left;
            _labelDst.Top = _form.ClientRectangle.Height - 20;

            // 
            int topLeftTotalHeight = 0;
            int topRightTotalHeight = 0;
            int bottomLeftTotalHeight = 0;
            int bottomRightTotalHeight = 0;

            foreach (Panel panel in _panels)
            {
                ConsolePanel consolePanel = (ConsolePanel)panel.Tag;

                switch (consolePanel.pos)
                {
                    case ConsolePanel.Pos.TopLeft:
                        panel.Top = 0;
                        panel.Left = 0;
                        panel.Top += topLeftTotalHeight;

                        topLeftTotalHeight += panel.Height;
                        break;

                    case ConsolePanel.Pos.TopRight:
                        panel.Top = 0;
                        panel.Left = _form.ClientRectangle.Width - panel.Width;
                        panel.Top += topRightTotalHeight;

                        topRightTotalHeight += panel.Height;
                        break;

                    case ConsolePanel.Pos.BottomLeft:
                        panel.Top = _form.ClientRectangle.Height - panel.Height;
                        panel.Left = 0;
                        panel.Top += bottomLeftTotalHeight;

                        bottomLeftTotalHeight += panel.Height;
                        break;

                    case ConsolePanel.Pos.BottomRight:
                        panel.Top = _form.ClientRectangle.Height - panel.Height;
                        panel.Left = _form.ClientRectangle.Width - panel.Width;
                        panel.Top += bottomRightTotalHeight;

                        bottomRightTotalHeight += panel.Height;
                        break;

                    default:
                        break;
                }
            }

            // 
            switch (act)
            {
                case Setting.Act.Act1:
                    _labelOpe.Visible = true;
                    _labelSrc.Visible = true;
                    _labelDst.Visible = true;

                    foreach (Panel panel in _panels)
                    {
                        ConsolePanel consolePanel = (ConsolePanel)panel.Tag;

                        if (_setting.lefty)
                        {
                            if (consolePanel.pos == ConsolePanel.Pos.TopLeft)
                            {
                                panel.Visible = true;
                            }
                            else
                            {
                                panel.Visible = false;
                            }
                        }
                        else
                        {
                            if (consolePanel.pos == ConsolePanel.Pos.TopRight)
                            {
                                panel.Visible = true;
                            }
                            else
                            {
                                panel.Visible = false;
                            }
                        }
                    }
                    break;

                case Setting.Act.Act2:
                    _labelOpe.Visible = true;
                    _labelSrc.Visible = true;
                    _labelDst.Visible = true;

                    foreach (Panel panel in _panels)
                    {
                        panel.Visible = true;
                    }
                    break;

                case Setting.Act.Act3:
                    _labelOpe.Visible = false;
                    _labelSrc.Visible = false;
                    _labelDst.Visible = false;

                    foreach (Panel panel in _panels)
                    {
                        panel.Visible = false;
                    }
                    break;

                default:
                    break;
            }
            
            // 
            if (opened)
            {
                foreach (Button button in _buttons)
                {
                    ConsoleButton consoleButton = (ConsoleButton)button.Tag;

                    switch (consoleButton.ope)
                    {
                        case ConsoleButton.Ope.Move:
                        case ConsoleButton.Ope.Copy:
                            button.Enabled = true;
                            break;

                        case ConsoleButton.Ope.Undo:
                            if (_histories.Count == 0)
                            {
                                button.Enabled = false;
                            }
                            else
                            {
                                button.Enabled = true;
                            }
                            break;

                        default:
                            button.Enabled = true;
                            break;
                    }
                }
            }
            else
            {
                foreach (Button button in _buttons)
                {
                    ConsoleButton consoleButton = (ConsoleButton)button.Tag;

                    if (consoleButton.ope == ConsoleButton.Ope.Undo)
                    {
                        if (_histories.Count == 0)
                        {
                            button.Enabled = false;
                        }
                        else
                        {
                            button.Enabled = true;
                        }
                    }
                    else
                    {
                        button.Enabled = false;
                    }
                }
            }
        }
    }
}
