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
    public partial class MainForm : Form
    {
        private Setting _setting;

        private bool _opened;
        private bool _resizing;
        private Rectangle _formRectBk;

        private string _keyHistory;

        private ImageCtrl _imageCtrl;
        private ConsoleCtrl _consoleCtrl;

        public MainForm(string dirPath)
        {
            _setting = new Setting();
            _setting.load();

            _opened = false;
            _resizing = false;
            _formRectBk = new Rectangle();

            _keyHistory = "";

            _imageCtrl = null;
            _consoleCtrl = null;

            InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_setting != null)
            {
                _setting.save();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _imageCtrl = new ImageCtrl(_setting, this, pictureBoxPreview, buttonPrev, buttonNext, labelName, textBoxCur, labelTotal);
            _imageCtrl.initControls();

            _consoleCtrl = new ConsoleCtrl(_setting, this, labelOpe, labelSrc, labelDst);
            _consoleCtrl.initControls(_setting.panels);

            _imageCtrl.consoleCtrl = _consoleCtrl;
            _consoleCtrl.imageCtrl = _imageCtrl;

            _formRectBk = new Rectangle(this.Left, this.Top, this.Width, this.Height);

            labelOpe.Text = "";
            labelSrc.Text = "";
            labelDst.Text = "";

            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += new System.EventHandler(MainForm_DisplaySettingsChanged);

            // 
            this.changeAct(_setting.act);

            this.updateControls(_setting.act, false);

            // 
            string[] args;
            args = System.Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                string filePath = args[1];

                string dirPath = "";
                if (System.IO.Directory.Exists(filePath))
                {
                    dirPath = filePath;
                }
                else
                {
                    dirPath = System.IO.Path.GetDirectoryName(filePath);
                }

                string dirPathSlash = dirPath.Replace(@"\", "/");

                if (_imageCtrl.loadImages(dirPathSlash))
                {
                    _opened = true;
                }

                this.updateControls(_setting.act, _opened);
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            _resizing = true;
            this.updateControls(_setting.act, _opened);
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            _resizing = false;

            switch (_setting.act)
            {
                case Setting.Act.Act1:
                    _formRectBk = new Rectangle(this.Left, this.Top, this.Width, this.Height);
                    break;

                case Setting.Act.Act2:
                    break;

                case Setting.Act.Act3:
                    break;

                default:
                    break;
            }

            this.updateControls(_setting.act, _opened);
        }

        private void MainForm_DisplaySettingsChanged(object sender, EventArgs e)
        {
            this.MainForm_ResizeEnd(null, null);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    break;

                case Keys.Delete:
                    break;

                case Keys.F11:
                    switch (_setting.act)
                    {
                        case Setting.Act.Act1:
                            this.changeAct(Setting.Act.Act2);
                            break;

                        case Setting.Act.Act2:
                            this.changeAct(Setting.Act.Act3);
                            break;

                        case Setting.Act.Act3:
                            this.changeAct(Setting.Act.Act1);
                            break;

                        default:
                            break;
                    }

                    this.updateControls(_setting.act, _opened);
                    break;

                case Keys.Escape:
                    this.changeAct(Setting.Act.Act1);
                    this.updateControls(_setting.act, _opened);
                    break;

                default:
                    break;
            }

            _imageCtrl.MainForm_KeyDown(sender, e);
            _consoleCtrl.MainForm_KeyDown(sender, e);

            // 
            string key = (e.KeyCode).ToString();
            if (e.Shift == false)
            {
                key = key.ToLower();
            }

            _keyHistory += key;
            this.interpretKey(_keyHistory);
        }

        [System.Security.Permissions.UIPermission(
         System.Security.Permissions.SecurityAction.LinkDemand,
         Window = System.Security.Permissions.UIPermissionWindow.AllWindows)]
        protected override bool ProcessDialogKey(Keys keyData)
        {
            // 
            string key = (keyData & Keys.KeyCode).ToString();
            key = key.ToLower();

            if (key != "b" && key != "a")
            {
                _keyHistory += key;
                this.interpretKey(_keyHistory);
            }

            // 
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left:
                    _imageCtrl.moveCurPage(-1);

                    //左キーの本来の処理（左側のコントロールにフォーカスを移す）を
                    //させたくないときは、trueを返す
                    return true;

                case Keys.Right:
                    _imageCtrl.moveCurPage(1);
                    return true;

                case Keys.Up:
                    _imageCtrl.moveCurPage(-10);
                    return true;

                case Keys.Down:
                    _imageCtrl.moveCurPage(10);
                    return true;

                default:
                    break;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void interpretKey(string keys)
        {
            if (keys == "")
            {
                return;
            }

            switch (keys)
            {
                case "up":
                    break;
                case "upup":
                    break;
                case "upupdown":
                    break;
                case "upupdowndown":
                    break;
                case "upupdowndownleft":
                    break;
                case "upupdowndownleftright":
                    break;
                case "upupdowndownleftrightleft":
                    break;
                case "upupdowndownleftrightleftright":
                    break;
                case "upupdowndownleftrightleftrightb":
                    break;
                case "upupdowndownleftrightleftrightba":
                    _setting.level = 17000;
                    _setting.save();

                    // 音を鳴らす
                    Console.Beep(5730, 573);
                    break;

                default:
                    _keyHistory = "";
                    break;
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            this.allowOnlyFile(e);
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            _opened = false;
            _imageCtrl.clearImages();

            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (string filePath in filePaths)
            {
                string dirPath = "";
                if (System.IO.Directory.Exists(filePath))
                {
                    dirPath = filePath;
                }
                else
                {
                    dirPath = System.IO.Path.GetDirectoryName(filePath);
                }

                string dirPathSlash = dirPath.Replace(@"\", "/");

                if (_imageCtrl.loadImages(dirPathSlash))
                {
                    _opened = true;
                }

                this.updateControls(_setting.act, _opened);
                break;
            }
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.ClientRectangle.Width - e.X < 10 && this.ClientRectangle.Height - e.Y < 10)
            {
                Application.Exit();
            }
        }

        private void buttonDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                _opened = false;
                _imageCtrl.clearImages();

                string dirPath = dlg.SelectedPath;
                string dirPathSlash = dirPath.Replace(@"\", "/");

                if (_imageCtrl.loadImages(dirPathSlash))
                {
                    _opened = true;
                }

                this.updateControls(_setting.act, _opened);
            }
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            SettingForm form = new SettingForm(_setting);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _consoleCtrl.initControls(_setting.panels);

                this.updateControls(_setting.act, _opened);
            }
        }

        private void buttonMax_Click(object sender, EventArgs e)
        {
            switch (_setting.act)
            {
                case Setting.Act.Act1:
                    this.changeAct(Setting.Act.Act2);
                    break;

                case Setting.Act.Act2:
                    if (_setting.level >= 7)
                    {
                        this.changeAct(Setting.Act.Act3);
                    }
                    else
                    {
                        this.changeAct(Setting.Act.Act1);
                    }
                    break;

                case Setting.Act.Act3:
                    this.changeAct(Setting.Act.Act1);
                    break;

                default:
                    break;
            }

            this.updateControls(_setting.act, _opened);
        }

        private void allowOnlyFile(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void changeAct(Setting.Act act)
        {
            bool pass = false;
            if (act == Setting.Act.Act1)
            {
                pass = true;
            }
            else if (act == Setting.Act.Act2 && _setting.level >= 1)
            {
                pass = true;
            }
            else if (act == Setting.Act.Act3 && _setting.level >= 7)
            {
                pass = true;
            }

            if (pass)
            {
                _setting.act = act;
                _setting.save();

                switch (_setting.act)
                {
                    case Setting.Act.Act1:
                        this.Hide();

                        if (this.FormBorderStyle != FormBorderStyle.Sizable)
                        {
                            this.FormBorderStyle = FormBorderStyle.Sizable;
                        }

                        this.Top = _formRectBk.Top;
                        this.Left = _formRectBk.Left;
                        this.Width = _formRectBk.Width;
                        this.Height = _formRectBk.Height;

                        _resizing = true;
                        break;

                    case Setting.Act.Act2:
                        this.Hide();

                        _resizing = true;
                        break;

                    case Setting.Act.Act3:
                        // 一瞬画像が消えてしまってチラつくのでコメントアウト
                        //_resizing = true;
                        break;

                    default:
                        break;
                }

                //this.MainForm_ResizeEnd(null, null);
                //this.updateControls(_setting.act, _opened);
                timerChangeAct.Start();
            }
        }

        private void timerChangeAct_Tick(object sender, EventArgs e)
        {
            if (_resizing)
            {
                this.MainForm_ResizeEnd(null, null);
                this.Show();
            }
            else
            {
                timerChangeAct.Stop();
            }
        }

        public void bringControlsToFront()
        {
            buttonDir.BringToFront();
            buttonSetting.BringToFront();
            buttonMax.BringToFront();
        }

        private void updateControls(Setting.Act act, bool opened)
        {
            this.bringControlsToFront();

            buttonMax.Top = 0;
            buttonMax.Left = this.ClientRectangle.Width - buttonMax.Width;

            switch (act)
            {
                case Setting.Act.Act1:
                    if (this.FormBorderStyle != FormBorderStyle.Sizable)
                    {
                        this.FormBorderStyle = FormBorderStyle.Sizable;
                    }

                    buttonSetting.Visible = true;

                    if (_setting.level >= 1)
                    {
                        buttonMax.Visible = true;
                        buttonMax.Image = Viewer17.Properties.Resources.arrow_out;
                    }
                    else
                    {
                        buttonMax.Visible = false;
                    }
                    break;

                case Setting.Act.Act2:
                    if (this.FormBorderStyle != FormBorderStyle.None)
                    {
                        this.FormBorderStyle = FormBorderStyle.None;
                    }

                    this.Top = Screen.GetBounds(this).Top;
                    this.Left = Screen.GetBounds(this).Left;
                    this.Width = Screen.GetBounds(this).Width;
                    this.Height = Screen.GetBounds(this).Height;

                    buttonSetting.Visible = true;

                    if (_setting.level >= 7)
                    {
                        buttonMax.Image = Viewer17.Properties.Resources.arrow_out;
                    }
                    else
                    {
                        buttonMax.Image = Viewer17.Properties.Resources.arrow_in;
                    }
                    break;

                case Setting.Act.Act3:
                    if (this.FormBorderStyle != FormBorderStyle.None)
                    {
                        this.FormBorderStyle = FormBorderStyle.None;
                    }
                    
                    this.Top = Screen.GetBounds(this).Top;
                    this.Left = Screen.GetBounds(this).Left;
                    this.Width = Screen.GetBounds(this).Width;
                    this.Height = Screen.GetBounds(this).Height;

                    buttonSetting.Visible = false;
                    buttonMax.Image = Viewer17.Properties.Resources.arrow_in;
                    break;

                default:
                    break;
            }

            _imageCtrl.updateControls(act, opened, _resizing);
            _consoleCtrl.updateControls(act, opened, _resizing);
        }
    }
}
