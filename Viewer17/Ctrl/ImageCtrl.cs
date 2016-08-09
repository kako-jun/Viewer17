using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
//using System.Drawing.Imaging;
//using System.Runtime.InteropServices;

namespace Viewer17
{
    internal class ImageCtrl
    {
        private Setting _setting;
        private MainForm _form;

        private PictureBox _pictureBox;
        private Button _buttonPrev;
        private Button _buttonNext;
        private Label _labelName;
        private TextBox _textBoxCur;
        private Label _labelTotal;

        private List<string> _filePaths;
        private int _curIndex;
        private Image _image;
        private Bitmap _bmp;

        private Point _mouseDownPoint;
        private int _deltaBk;

        private ConsoleCtrl _consoleCtrl;
        public ConsoleCtrl consoleCtrl { set { _consoleCtrl = value; } }

        public ImageCtrl(Setting setting, MainForm form, PictureBox pictureBoxPreview, Button buttonPrev, Button buttonNext, Label labelName, TextBox textBoxCur, Label labelTotal)
        {
            _setting = setting;
            _form = form;

            _pictureBox = pictureBoxPreview;
            _buttonPrev = buttonPrev;
            _buttonNext = buttonNext;
            _labelName = labelName;
            _textBoxCur = textBoxCur;
            _labelTotal = labelTotal;

            _filePaths = new List<string>();
            _curIndex = 0;
            _image = null;
            _bmp = null;

            _mouseDownPoint = new Point();
            _deltaBk = 0;

            _consoleCtrl = null;
        }

        public void initControls()
        {
            _pictureBox.Paint += new PaintEventHandler(this.pictureBoxPreview_Paint);
            _pictureBox.MouseClick += new MouseEventHandler(this.pictureBoxPreview_MouseClick);
            _pictureBox.MouseDown += new MouseEventHandler(this.pictureBoxPreview_MouseDown);
            _pictureBox.MouseMove += new MouseEventHandler(this.pictureBoxPreview_MouseMove);
            _pictureBox.MouseUp += new MouseEventHandler(this.pictureBoxPreview_MouseUp);

            _buttonPrev.Click += new EventHandler(this.buttonPrev_Click);
            _buttonNext.Click += new EventHandler(this.buttonNext_Click);

            _labelName.Click += new EventHandler(this.labelName_Click);
            _textBoxCur.TextChanged += new EventHandler(this.textBoxCur_TextChanged);
            _textBoxCur.KeyPress += new KeyPressEventHandler(this.textBoxCur_KeyPress);
            _labelTotal.Click += new EventHandler(this.labelTotal_Click);
        }

        public void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Home:
                    labelName_Click(null, null);
                    this.updateControls(_setting.act, true);
                    break;

                case Keys.End:
                    labelTotal_Click(null, null);
                    this.updateControls(_setting.act, true);
                    break;

                default:
                    break;
            }
        }

        private void pictureBoxPreview_MouseClick(object sender, MouseEventArgs e)
        {
            // textBoxCurでカーソルが点滅し続けるのを防ぐため
            _pictureBox.Focus();

            // 
            if (_setting.act == Setting.Act.Act2 || _setting.act == Setting.Act.Act3)
            {
                if (_form.ClientRectangle.Width - e.X < 10 && _form.ClientRectangle.Height - e.Y < 10)
                {
                    Application.Exit();
                }
            }
        }

        private void pictureBoxPreview_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDownPoint.X = e.X;
            _mouseDownPoint.Y = e.Y;
        }

        private void pictureBoxPreview_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;

            if ((_filePaths == null)
                || (_filePaths.Count == 0))
            {
                return;
            }

            if (_mouseDownPoint.X == 0)
            {
                return;
            }
            
            bool pass = false;
            if (_mouseDownPoint.X < pictureBox.Width / 8 && e.X < pictureBox.Width / 8)
            {
            }
            else if (pictureBox.Width - pictureBox.Width / 8 < _mouseDownPoint.X && pictureBox.Width - pictureBox.Width / 8 < e.X)
            {
            }
            else
            {
                pass = true;
            }

            if (pass)
            {
                if (e.X - _mouseDownPoint.X > 0)
                {
                    int delta = e.X - _mouseDownPoint.X;
                    if (delta > 10)
                    {
                        _deltaBk = 0;
                        _mouseDownPoint = new Point();
                        buttonPrev_Click(null, null);
                        this.updateControls(_setting.act, true);
                    }
                    else
                    {
                        //// ずらして表示
                        //pictureBoxPreview.Refresh();
                        //Graphics g = pictureBox.CreateGraphics();
                        //g.DrawImage(_bmp, (pictureBoxPreview.Width - _bmp.Width) / 2 - 3 * _deltaBk, (pictureBoxPreview.Height - _bmp.Height) / 2);
                        //_deltaBk++;
                    }
                }
                else
                {
                    int delta = _mouseDownPoint.X - e.X;
                    if (delta > 10)
                    {
                        _deltaBk = 0;
                        _mouseDownPoint = new Point();
                        buttonNext_Click(null, null);
                        this.updateControls(_setting.act, true);
                    }
                    else
                    {
                        //// ずらして表示
                        //pictureBoxPreview.Refresh();
                        //Graphics g = pictureBox.CreateGraphics();
                        //g.DrawImage(_bmp, (pictureBoxPreview.Width - _bmp.Width) / 2 + 3 * _deltaBk, (pictureBoxPreview.Height - _bmp.Height) / 2);
                        //_deltaBk++;
                    }
                }
            }
        }

        private void pictureBoxPreview_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;

            if ((_filePaths == null)
                || (_filePaths.Count == 0))
            {
                return;
            }

            if (_mouseDownPoint.X == 0)
            {
                return;
            }

            bool pass = false;
            if (_mouseDownPoint.X < pictureBox.Width / 8 && e.X < pictureBox.Width / 8)
            {
                pass = true;
            }
            else if (pictureBox.Width - pictureBox.Width / 8 < _mouseDownPoint.X && pictureBox.Width - pictureBox.Width / 8 < e.X)
            {
                pass = true;
            }
            else
            {
            }

            // 
            _mouseDownPoint = new Point();
            _deltaBk = 0;

            if (pass)
            {
                // 
                if (e.X < pictureBox.Width / 8)
                {
                    if (e.Y < pictureBox.Height / 2)
                    {
                        if (e.Y < pictureBox.Height / 4 && _setting.level >= 1700)
                        {
                            if (e.Y < pictureBox.Height / 8 && _setting.level >= 17000)
                            {
                                // 1000個戻る
                                this.decPage(_curIndex, 1000);
                            }
                            else
                            {
                                // 100個戻る
                                this.decPage(_curIndex, 100);
                            }
                        }
                        else
                        {
                            // 10個戻る
                            this.decPage(_curIndex, 10);
                        }
                    }
                    else
                    {
                        // 1個戻る
                        this.decPage(_curIndex, 1);
                    }
                }
                else if (pictureBox.Width - pictureBox.Width / 8 < e.X)
                {
                    if (e.Y < pictureBox.Height / 2)
                    {
                        if (e.Y < pictureBox.Height / 4 && _setting.level >= 1700)
                        {
                            if (e.Y < pictureBox.Height / 8 && _setting.level >= 17000)
                            {
                                // 1000個進む
                                this.incPage(_curIndex, 1000);
                            }
                            else
                            {
                                // 100個進む
                                this.incPage(_curIndex, 100);
                            }
                        }
                        else
                        {
                            // 10個進む
                            this.incPage(_curIndex, 10);
                        }
                    }
                    else
                    {
                        // 1個進む
                        this.incPage(_curIndex, 1);
                    }
                }
            }
        }

        public void moveCurPage(int delta)
        {
            if (delta == 0)
            {
            }
            else if (delta > 0)
            {
                this.incPage(_curIndex, delta);
            }
            else
            {
                this.decPage(_curIndex, System.Math.Abs(delta));
            }
        }

        private void decPage(int curIndex, int delta)
        {
            if (curIndex == 0)
            {
                return;
            }

            if ((_filePaths == null)
                || (_filePaths.Count == 0))
            {
                return;
            }

            // 
            if (curIndex > delta)
            {
                _curIndex -= delta;
            }
            else
            {
                _curIndex = 0;
            }

            _image = this.loadImage(_filePaths[_curIndex]);
            if (_image != null)
            {
                this.updateControls(_setting.act, true);
            }
            else
            {
                this.updateControls(_setting.act, false);
            }
        }

        private void incPage(int curIndex, int delta)
        {
            if (curIndex == _filePaths.Count - 1)
            {
                return;
            }

            if ((_filePaths == null)
                || (_filePaths.Count == 0))
            {
                return;
            }

            // 
            if (curIndex < _filePaths.Count - 1 - delta)
            {
                _curIndex += delta;
            }
            else
            {
                _curIndex = _filePaths.Count - 1;
            }

            _image = this.loadImage(_filePaths[_curIndex]);
            if (_image != null)
            {
                this.updateControls(_setting.act, true);
            }
            else
            {
                this.updateControls(_setting.act, false);
            }
        }

        private void pictureBoxPreview_Paint(object sender, PaintEventArgs e)
        {
            if (_bmp != null)
            {
                e.Graphics.DrawImage(_bmp, (_pictureBox.Width - _bmp.Width) / 2, (_pictureBox.Height - _bmp.Height) / 2);
            }
        }

        internal void buttonPrev_Click(object sender, EventArgs e)
        {
            this.decPage(_curIndex, 1);
        }

        internal void buttonNext_Click(object sender, EventArgs e)
        {
            this.incPage(_curIndex, 1);
        }

        private void labelName_Click(object sender, EventArgs e)
        {
            if ((_filePaths == null)
                || (_filePaths.Count == 0))
            {
                return;
            }

            _curIndex = 0;
            _image = this.loadImage(_filePaths[_curIndex]);
            if (_image != null)
            {
                this.updateControls(_setting.act, true);
            }
            else
            {
                this.updateControls(_setting.act, false);
            }
        }

        private void textBoxCur_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            System.Text.RegularExpressions.Match m = reg.Match(tb.Text);

            if (m.Success)
            {
                tb.Text = reg.Replace(tb.Text, "");
            }
        }

        private void textBoxCur_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return)
            {
                return;
            }

            if ((_filePaths == null)
                || (_filePaths.Count == 0))
            {
                return;
            }

            int cur = 0;
            if (int.TryParse(_textBoxCur.Text, out cur))
            {
                cur--;

                if ((cur >= 0)
                    && (cur < _filePaths.Count))
                {
                    _curIndex = cur;
                    _image = this.loadImage(_filePaths[_curIndex]);
                    if (_image != null)
                    {
                        this.updateControls(_setting.act, true);
                    }
                    else
                    {
                        this.updateControls(_setting.act, false);
                    }
                }
            }

            // ビープ音を消す
            e.Handled = true;
        }

        private void labelTotal_Click(object sender, EventArgs e)
        {
            if ((_filePaths == null)
                || (_filePaths.Count == 0))
            {
                return;
            }

            _curIndex = _filePaths.Count - 1; ;
            _image = this.loadImage(_filePaths[_curIndex]);
            if (_image != null)
            {
                this.updateControls(_setting.act, true);
            }
            else
            {
                this.updateControls(_setting.act, false);
            }
        }

        public void addImage(string filePath, ref bool next)
        {
            next = false;

            _pictureBox.Image = null;

            _image = null;
            _bmp = null;

            _filePaths.Add(filePath);
            _filePaths.Sort();
            _curIndex = _filePaths.IndexOf(filePath);

            _image = this.loadImage(_filePaths[_curIndex]);
            if (_image == null)
            {
                this.updateControls(_setting.act, false);
            }
            else
            {
                next = true;
                this.updateControls(_setting.act, true);
            }
        }

        public void removeCurImage(ref bool next)
        {
            next = false;

            // ★_curIndexを使わず、filePathから計算する

            _pictureBox.Image = null;

            _image = null;
            _bmp = null;

            _filePaths.RemoveAt(_curIndex);
            if (_filePaths.Count > 0)
            {
                if (_curIndex == _filePaths.Count)
                {
                    _curIndex--;
                }

                _image = this.loadImage(_filePaths[_curIndex]);
            }

            if (_image == null)
            {
                this.updateControls(_setting.act, false);
            }
            else
            {
                next = true;
                this.updateControls(_setting.act, true);
            }
        }

        public void clearImages()
        {
            _pictureBox.Image = null;

            _filePaths.Clear();
            _curIndex = 0;
            _image = null;
            _bmp = null;

            this.updateControls(_setting.act, false);
        }

        public bool loadImages(string dirPath)
        {
            if (dirPath == "")
            {
                return false;
            }

            _filePaths = this.grepImages(dirPath);

            if (_filePaths == null)
            {
                _filePaths = new List<string>();
                return false;
            }

            if (_filePaths.Count == 0)
            {
                return false;
            }

            _image = this.loadImage(_filePaths[0]);
            if (_image != null)
            {
                return true;
            }

            return false;
        }

        private List<string> grepImages(string dirPath)
        {
            try
            {
                List<string> filePaths = new List<string>();
                filePaths.AddRange(System.IO.Directory.GetFiles(dirPath, "*.png", System.IO.SearchOption.AllDirectories));
                filePaths.AddRange(System.IO.Directory.GetFiles(dirPath, "*.jpg", System.IO.SearchOption.AllDirectories));
                filePaths.AddRange(System.IO.Directory.GetFiles(dirPath, "*.jpeg", System.IO.SearchOption.AllDirectories));
                filePaths.AddRange(System.IO.Directory.GetFiles(dirPath, "*.bmp", System.IO.SearchOption.AllDirectories));
                filePaths.AddRange(System.IO.Directory.GetFiles(dirPath, "*.gif", System.IO.SearchOption.AllDirectories));
                filePaths.Sort();

                return filePaths;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private Image loadImage(string filePath)
        {
            Image image = null;

            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                image = Image.FromStream(fs);
                fs.Close();

                _consoleCtrl.filePath = filePath;

                _setting.level++;
                this.showLevelUpMessage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return image;
        }

        //public void sendControlsToBack()
        //{
        //    _pictureBox.SendToBack();
        //    _buttonPrev.SendToBack();
        //    _buttonNext.SendToBack();

        //    _labelName.SendToBack();
        //    _pictureBox.SendToBack();
        //    _labelTotal.SendToBack();
        //}

        private void showLevelUpMessage()
        {
            switch (_setting.level)
            {
                case 1:
                    MessageBox.Show(Viewer17.Properties.Resources.Level1.Replace(@"\n", "\n"));
                    _setting.save();
                    break;

                case 7:
                    MessageBox.Show(Viewer17.Properties.Resources.Level7.Replace(@"\n", "\n"));
                    _setting.save();
                    break;

                case 17:
                    MessageBox.Show(Viewer17.Properties.Resources.Level17.Replace(@"\n", "\n"));
                    _setting.save();
                    break;

                case 170:
                    MessageBox.Show(Viewer17.Properties.Resources.Level170.Replace(@"\n", "\n"));
                    _setting.save();
                    break;

                case 1700:
                    MessageBox.Show(Viewer17.Properties.Resources.Level1700.Replace(@"\n", "\n"));
                    _setting.save();
                    break;

                case 17000:
                    MessageBox.Show(Viewer17.Properties.Resources.Level17000.Replace(@"\n", "\n"));
                    _setting.save();
                    break;

                default:
                    break;
            }
        }

        public void updateControls(Setting.Act act, bool opened = false, bool resizing = false)
        {
            if (resizing)
            {
                _pictureBox.Visible = false;
                _buttonPrev.Visible = false;
                _buttonNext.Visible = false;
                _labelName.Visible = false;
                _textBoxCur.Visible = false;
                _labelTotal.Visible = false;
                return;
            }

            if (opened)
            {
                // 
                //this.sendControlsToBack();

                switch (act)
                {
                    case Setting.Act.Act1:
                        _pictureBox.Visible = true;
                        _buttonPrev.Visible = true;
                        _buttonNext.Visible = true;

                        _labelName.Visible = true;
                        _textBoxCur.Visible = true;
                        _labelTotal.Visible = true;

                        if (_setting.lefty)
                        {
                            _pictureBox.Top = 40;
                            _pictureBox.Left = 268;
                            _pictureBox.Width = _form.ClientRectangle.Width - 52 - 268;
                            _pictureBox.Height = _form.ClientRectangle.Height - 40 - 140;

                            _buttonPrev.Top = _pictureBox.Top;
                            _buttonPrev.Left = _pictureBox.Left - _buttonPrev.Width;
                            _buttonPrev.Height = _pictureBox.Height;

                            _buttonNext.Top = _pictureBox.Top;
                            _buttonNext.Left = _pictureBox.Right;
                            _buttonNext.Height = _pictureBox.Height;

                            _labelName.Top = _form.ClientRectangle.Height - 119;
                            _labelName.Left = _buttonPrev.Left;

                            _textBoxCur.Top = _form.ClientRectangle.Height - 134;
                            _textBoxCur.Left = _form.ClientRectangle.Width - 115;

                            _labelTotal.Top = _form.ClientRectangle.Height - 119;
                            _labelTotal.Left = _form.ClientRectangle.Width - 112;
                        }
                        else
                        {
                            _pictureBox.Top = 40;
                            _pictureBox.Left = 52;
                            _pictureBox.Width = _form.ClientRectangle.Width - 52 - 268;
                            _pictureBox.Height = _form.ClientRectangle.Height - 40 - 140;

                            _buttonPrev.Top = _pictureBox.Top;
                            _buttonPrev.Left = _pictureBox.Left - _buttonPrev.Width;
                            _buttonPrev.Height = _pictureBox.Height;

                            _buttonNext.Top = _pictureBox.Top;
                            _buttonNext.Left = _pictureBox.Right;
                            _buttonNext.Height = _pictureBox.Height;

                            _labelName.Top = _form.ClientRectangle.Height - 119;
                            _labelName.Left = _buttonPrev.Left;

                            _textBoxCur.Top = _form.ClientRectangle.Height - 134;
                            _textBoxCur.Left = _form.ClientRectangle.Width - 331;

                            _labelTotal.Top = _form.ClientRectangle.Height - 119;
                            _labelTotal.Left = _form.ClientRectangle.Width - 328;
                        }
                        break;

                    case Setting.Act.Act2:
                        _pictureBox.Visible = true;
                        _buttonPrev.Visible = false;
                        _buttonNext.Visible = false;

                        _labelName.Visible = false;
                        _textBoxCur.Visible = false;
                        _labelTotal.Visible = false;

                        _pictureBox.Top = 0;
                        _pictureBox.Left = 0;
                        _pictureBox.Width = _form.ClientSize.Width;
                        _pictureBox.Height = _form.ClientSize.Height;
                        break;

                    case Setting.Act.Act3:
                        _pictureBox.Visible = true;
                        _buttonPrev.Visible = false;
                        _buttonNext.Visible = false;

                        _labelName.Visible = false;
                        _textBoxCur.Visible = false;
                        _labelTotal.Visible = false;

                        _pictureBox.Top = 0;
                        _pictureBox.Left = 0;
                        _pictureBox.Width = _form.ClientSize.Width;
                        _pictureBox.Height = _form.ClientSize.Height;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                // 
                _pictureBox.Visible = false;
                _buttonPrev.Visible = false;
                _buttonNext.Visible = false;

                _labelName.Visible = false;
                _textBoxCur.Visible = false;
                _labelTotal.Visible = false;
            }

            // 
            if (opened)
            {
                double pictureBoxAspect = (double)_pictureBox.Width / (double)_pictureBox.Height;
                double imageAspect = (double)_image.Width / (double)_image.Height;

                int w = _pictureBox.Width;
                int h = _pictureBox.Height;

                if (pictureBoxAspect > imageAspect)
                {
                    w = (int)((double)h * imageAspect);
                }
                else
                {
                    h = (int)((double)w / imageAspect);
                }

                if (w > 0 && w > 0)
                {
                    _bmp = new Bitmap(_image, w, h);

                    _pictureBox.Refresh();
                    Graphics g = _pictureBox.CreateGraphics();
                    g.DrawImage(_bmp, (_pictureBox.Width - _bmp.Width) / 2, (_pictureBox.Height - _bmp.Height) / 2);
                }

                System.IO.FileInfo fi = new System.IO.FileInfo(_filePaths[_curIndex]);
                _labelName.Text = fi.Name;
                _textBoxCur.Text = (_curIndex + 1).ToString();
                _labelTotal.Text = " / " + _filePaths.Count.ToString();
            }

            _consoleCtrl.clearOpeMessage();

            //this.sendControlsToBack();
        }
    }
}
