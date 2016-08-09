using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Viewer17
{
    internal class GridCtrl
    {
        private Setting _setting;
        private SettingForm _form;

        private DataGridView _dataGridViewPanel;
        private Button _buttonPanelAdd;
        private Button _buttonPanelUp;
        private Button _buttonPanelDown;

        private BindingList<ConsolePanel> _panels;
        public BindingList<ConsolePanel> panels { get { return _panels; } set { _panels = value; } }
        private BindingSource _bindingSourcePanel;
        private int _curPanelIndex;

        private DataGridView _dataGridViewButton;
        private Button _buttonButtonAdd;
        private Button _buttonButtonUp;
        private Button _buttonButtonDown;

        private BindingList<ConsoleButton> _buttons;
        public BindingList<ConsoleButton> buttons { get { return _buttons; } set { _buttons = value; } }
        private BindingSource _bindingSourceButton;
        private int _curButtonIndex;

        DataGridViewComboBoxEditingControl _curComboBox;

        public GridCtrl(Setting setting, SettingForm form, DataGridView dataGridViewPanel, Button buttonPanelAdd, Button buttonPanelUp, Button buttonPanelDown, DataGridView dataGridViewButton, Button buttonButtonAdd, Button buttonButtonUp, Button buttonButtonDown)
        {
            _setting = setting;
            _form = form;

            _dataGridViewPanel = dataGridViewPanel;
            _buttonPanelAdd = buttonPanelAdd;
            _buttonPanelUp = buttonPanelUp;
            _buttonPanelDown = buttonPanelDown;

            _panels = new BindingList<ConsolePanel>(_setting.panels);
            _bindingSourcePanel = new BindingSource();
            _curPanelIndex = 0;

            _dataGridViewPanel.CellEnter += new DataGridViewCellEventHandler(this.dataGridViewPanel_CellEnter);
            _dataGridViewPanel.CellEndEdit += new DataGridViewCellEventHandler(this.dataGridViewPanel_CellEndEdit);
            _dataGridViewPanel.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dataGridViewPanel_EditingControlShowing);
            _dataGridViewPanel.CellContentClick += new DataGridViewCellEventHandler(this.dataGridViewPanel_CellContentClick);
            _dataGridViewPanel.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dataGridViewPanel_CellFormatting);
            _dataGridViewPanel.SelectionChanged += new EventHandler(this.dataGridViewPanel_SelectionChanged);
            _dataGridViewPanel.RowsAdded += new DataGridViewRowsAddedEventHandler(this.dataGridViewPanel_RowsAdded);
            _dataGridViewPanel.RowsRemoved += new DataGridViewRowsRemovedEventHandler(this.dataGridViewPanel_RowsRemoved);

            _buttonPanelAdd.Click += new EventHandler(this.buttonPanelAdd_Click);
            _buttonPanelUp.Click += new EventHandler(this.buttonPanelUp_Click);
            _buttonPanelDown.Click += new EventHandler(this.buttonPanelDown_Click);

            // 
            _dataGridViewButton = dataGridViewButton;
            _buttonButtonAdd = buttonButtonAdd;
            _buttonButtonUp = buttonButtonUp;
            _buttonButtonDown = buttonButtonDown;

            _buttons = new BindingList<ConsoleButton>();
            if (_setting.panels.Count > 0)
            {
                _buttons = new BindingList<ConsoleButton>(_setting.panels[0].buttons);
            }
            _bindingSourceButton = new BindingSource();
            _curButtonIndex = 0;

            _curComboBox = null;

            _dataGridViewButton.CellEnter += new DataGridViewCellEventHandler(this.dataGridViewButton_CellEnter);
            _dataGridViewButton.CellEndEdit += new DataGridViewCellEventHandler(this.dataGridViewButton_CellEndEdit);
            _dataGridViewButton.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dataGridViewButton_EditingControlShowing);
            _dataGridViewButton.CellContentClick += new DataGridViewCellEventHandler(this.dataGridViewButton_CellContentClick);
            _dataGridViewButton.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dataGridViewButton_CellFormatting);
            _dataGridViewButton.SelectionChanged += new EventHandler(this.dataGridViewButton_SelectionChanged);
            _dataGridViewButton.RowsAdded += new DataGridViewRowsAddedEventHandler(this.dataGridViewButton_RowsAdded);
            _dataGridViewButton.RowsRemoved += new DataGridViewRowsRemovedEventHandler(this.dataGridViewButton_RowsRemoved);

            _buttonButtonAdd.Click += new EventHandler(this.buttonButtonAdd_Click);
            _buttonButtonUp.Click += new EventHandler(this.buttonButtonUp_Click);
            _buttonButtonDown.Click += new EventHandler(this.buttonButtonDown_Click);
        }

        public void initControls(DataGridView dataGridView)
        {
            // 
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();

            switch (dataGridView.Name)
            {
                case "dataGridViewPanel":
                    {
                        // 
                        this.resetId(ref _panels);
                        _bindingSourcePanel.DataSource = _panels;
                        dataGridView.DataSource = _bindingSourcePanel;

                        DataGridViewColumn columnId = new DataGridViewTextBoxColumn();
                        columnId.Name = "columnId";
                        columnId.DataPropertyName = "id";
                        dataGridView.Columns.Add(columnId);

                        DataGridViewColumn columnTitle = new DataGridViewTextBoxColumn();
                        columnTitle.Name = "columnTitle";
                        columnTitle.DataPropertyName = "title";
                        dataGridView.Columns.Add(columnTitle);

                        DataGridViewColumn columnFgColor = new DataGridViewTextBoxColumn();
                        columnFgColor.Name = "columnFgColor";
                        columnFgColor.DataPropertyName = "fgColor";
                        dataGridView.Columns.Add(columnFgColor);

                        DataGridViewColumn columnFgColorSample = new DataGridViewImageColumn();
                        columnFgColorSample.Name = "columnFgColorSample";
                        dataGridView.Columns.Add(columnFgColorSample);

                        DataGridViewColumn columnBgColor = new DataGridViewTextBoxColumn();
                        columnBgColor.Name = "columnBgColor";
                        columnBgColor.DataPropertyName = "bgColor";
                        dataGridView.Columns.Add(columnBgColor);

                        DataGridViewColumn columnBgColorSample = new DataGridViewImageColumn();
                        columnBgColorSample.Name = "columnBgColorSample";
                        dataGridView.Columns.Add(columnBgColorSample);

                        DataGridViewComboBoxColumn columnPos = new DataGridViewComboBoxColumn();
                        columnPos.Name = "columnPos";
                        columnPos.DataSource = Enum.GetValues(typeof(ConsolePanel.Pos));
                        columnPos.DataPropertyName = "Pos";
                        dataGridView.Columns.Add(columnPos);

                        List<string> posJas = new List<string>();
                        posJas.Add(Viewer17.Properties.Resources.PosTopLeft);
                        posJas.Add(Viewer17.Properties.Resources.PosTopRight);
                        posJas.Add(Viewer17.Properties.Resources.PosBottomLeft);
                        posJas.Add(Viewer17.Properties.Resources.PosBottomRight);

                        DataGridViewComboBoxColumn columnPosJa = new DataGridViewComboBoxColumn();
                        columnPosJa.Name = "columnPosJa";
                        columnPosJa.DataSource = posJas;
                        dataGridView.Columns.Add(columnPosJa);

                        DataGridViewButtonColumn columnRemove = new DataGridViewButtonColumn();
                        columnRemove.Name = "columnRemove";
                        columnRemove.Text = Viewer17.Properties.Resources.RemoveButton;
                        columnRemove.UseColumnTextForButtonValue = true;
                        dataGridView.Columns.Add(columnRemove);

                        dataGridView.Columns[0].HeaderText = Viewer17.Properties.Resources.ColumnId;
                        dataGridView.Columns[1].HeaderText = Viewer17.Properties.Resources.ColumnPanelName;
                        dataGridView.Columns[2].HeaderText = "";
                        dataGridView.Columns[3].HeaderText = Viewer17.Properties.Resources.ColumnFgColor;
                        dataGridView.Columns[4].HeaderText = "";
                        dataGridView.Columns[5].HeaderText = Viewer17.Properties.Resources.ColumnBgColor;
                        dataGridView.Columns[6].HeaderText = "";
                        dataGridView.Columns[7].HeaderText = Viewer17.Properties.Resources.ColumnPos;
                        dataGridView.Columns[8].HeaderText = "";

                        dataGridView.Columns[0].Width = 30;
                        dataGridView.Columns[1].Width = 218;
                        dataGridView.Columns[2].Visible = false;
                        dataGridView.Columns[3].Width = 60;
                        dataGridView.Columns[4].Visible = false;
                        dataGridView.Columns[5].Width = 60;
                        dataGridView.Columns[6].Visible = false;
                        dataGridView.Columns[7].Width = 95;
                        dataGridView.Columns[8].Width = 50;

                        dataGridView.Columns[0].ReadOnly = true;
                        break;
                    }
                case "dataGridViewButton":
                    {
                        // 
                        this.resetId(ref _buttons);
                        _bindingSourceButton.DataSource = _buttons;
                        dataGridView.DataSource = _bindingSourceButton;

                        DataGridViewColumn columnId = new DataGridViewTextBoxColumn();
                        columnId.Name = "columnId";
                        columnId.DataPropertyName = "id";
                        dataGridView.Columns.Add(columnId);

                        DataGridViewColumn columnIcon = new DataGridViewTextBoxColumn();
                        columnIcon.Name = "columnIcon";
                        columnIcon.DataPropertyName = "iconPath";
                        dataGridView.Columns.Add(columnIcon);

                        DataGridViewImageColumn columnIconSample = new DataGridViewImageColumn();
                        columnIconSample.Name = "columnIconSample";
                        dataGridView.Columns.Add(columnIconSample);

                        DataGridViewColumn columnTitle = new DataGridViewTextBoxColumn();
                        columnTitle.Name = "columnTitle";
                        columnTitle.DataPropertyName = "title";
                        dataGridView.Columns.Add(columnTitle);

                        DataGridViewComboBoxColumn columnOpe = new DataGridViewComboBoxColumn();
                        columnOpe.Name = "columnOpe";
                        columnOpe.DataSource = Enum.GetValues(typeof(ConsoleButton.Ope));
                        columnOpe.DataPropertyName = "Ope";
                        dataGridView.Columns.Add(columnOpe);

                        List<string> opeJas = new List<string>();
                        opeJas.Add(Viewer17.Properties.Resources.OpeMove);
                        opeJas.Add(Viewer17.Properties.Resources.OpeCopy);
                        opeJas.Add(Viewer17.Properties.Resources.OpeDelete);
                        opeJas.Add(Viewer17.Properties.Resources.OpeUndo);

                        DataGridViewComboBoxColumn columnOpeJa = new DataGridViewComboBoxColumn();
                        columnOpeJa.Name = "columnOpeJa";
                        columnOpeJa.DataSource = opeJas;
                        dataGridView.Columns.Add(columnOpeJa);

                        DataGridViewColumn columnDir = new DataGridViewTextBoxColumn();
                        columnDir.Name = "columnDir";
                        columnDir.DataPropertyName = "dirName";
                        dataGridView.Columns.Add(columnDir);

                        DataGridViewComboBoxColumn columnKey = new DataGridViewComboBoxColumn();
                        columnKey.Name = "columnKey";
                        columnKey.DataSource = Enum.GetValues(typeof(ConsoleButton.Key));
                        columnKey.DataPropertyName = "Key";
                        dataGridView.Columns.Add(columnKey);

                        DataGridViewButtonColumn columnRemove = new DataGridViewButtonColumn();
                        columnRemove.Name = "columnRemove";
                        columnRemove.Text = Viewer17.Properties.Resources.RemoveButton;
                        columnRemove.UseColumnTextForButtonValue = true;
                        dataGridView.Columns.Add(columnRemove);

                        dataGridView.Columns[0].HeaderText = Viewer17.Properties.Resources.ColumnId;
                        dataGridView.Columns[1].HeaderText = "";
                        dataGridView.Columns[2].HeaderText = Viewer17.Properties.Resources.ColumnIcon;
                        dataGridView.Columns[3].HeaderText = Viewer17.Properties.Resources.ColumnButtonName;
                        dataGridView.Columns[4].HeaderText = "";
                        dataGridView.Columns[5].HeaderText = Viewer17.Properties.Resources.ColumnOpe;
                        dataGridView.Columns[6].HeaderText = Viewer17.Properties.Resources.ColumnDirName;
                        dataGridView.Columns[7].HeaderText = Viewer17.Properties.Resources.ColumnKey;
                        dataGridView.Columns[8].HeaderText = "";

                        dataGridView.Columns[0].Width = 30;
                        dataGridView.Columns[1].Visible = false;
                        dataGridView.Columns[2].Width = 60;
                        dataGridView.Columns[3].Width = 120;
                        dataGridView.Columns[4].Visible = false;
                        dataGridView.Columns[5].Width = 80;
                        dataGridView.Columns[6].Width = 115;
                        dataGridView.Columns[7].Width = 58;
                        dataGridView.Columns[8].Width = 50;

                        dataGridView.Columns[0].ReadOnly = true;
                        break;
                    }
                default:
                    break;
            }

            dataGridView.DefaultCellStyle.SelectionBackColor = Color.Blue;

            // 奇数行
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray;
            dataGridView.AlternatingRowsDefaultCellStyle.ForeColor = Color.Silver;
        }

        private void resetId(ref BindingList<ConsolePanel> panels)
        {
            for (int i = 0; i < panels.Count; i++)
            {
                panels[i].id = i;
            }
        }

        private void resetId(ref BindingList<ConsoleButton> buttons)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].id = i;
            }
        }

        private void dataGridViewPanel_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            switch (dataGridView.Columns[e.ColumnIndex].Name)
            {
                case "columnPosJa":
                    SendKeys.Send("{F4}");
                    break;

                default:
                    break;
            }
        }

        private void dataGridViewPanel_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                if (dataGridView.CurrentCell.OwningColumn.Name == "columnPosJa")
                {
                    _curComboBox = (DataGridViewComboBoxEditingControl)e.Control;
                    _curComboBox.SelectedIndexChanged += new EventHandler(columnPosJa_SelectedIndexChanged);
                }
            }
        }

        private void columnPosJa_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewComboBoxEditingControl comboBox = (DataGridViewComboBoxEditingControl)sender;
            _panels[_curPanelIndex].pos = (ConsolePanel.Pos)comboBox.SelectedIndex;
        }

        private void dataGridViewPanel_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            switch (dataGridView.Columns[e.ColumnIndex].Name)
            {
                case "columnPosJa":
                    if (_curComboBox != null)
                    {
                        _curComboBox.SelectedIndexChanged -= new EventHandler(columnPosJa_SelectedIndexChanged);
                        _curComboBox = null;
                    }
                    break;
            }
        }

        private void dataGridViewPanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            switch (dataGridView.Columns[e.ColumnIndex].Name)
            {
                case "columnFgColorSample":
                    {
                        ColorDialog dlg = new ColorDialog();
                        dlg.Color = (Color)dataGridView[e.ColumnIndex - 1, e.RowIndex].Value;
                        if (dlg.ShowDialog(_form) == DialogResult.OK)
                        {
                            dataGridView[e.ColumnIndex - 1, e.RowIndex].Value = dlg.Color;
                        }
                    }
                    break;

                case "columnBgColorSample":
                    {
                        ColorDialog dlg = new ColorDialog();
                        dlg.Color = (Color)dataGridView[e.ColumnIndex - 1, e.RowIndex].Value;
                        if (dlg.ShowDialog(_form) == DialogResult.OK)
                        {
                            dataGridView[e.ColumnIndex - 1, e.RowIndex].Value = dlg.Color;
                        }
                    }
                    break;

                case "columnRemove":
                    _panels.RemoveAt(e.RowIndex);
                    break;

                default:
                    break;
            }
        }

        private void dataGridViewPanel_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            switch (dataGridView.Columns[e.ColumnIndex].Name)
            {
                case "columnFgColorSample":
                    {
                        Color color = (Color)dataGridView[e.ColumnIndex - 1, e.RowIndex].Value;

                        Rectangle rect = new Rectangle(0, 0, 16, 16);
                        Bitmap sample = new Bitmap(rect.Width, rect.Height);
                        Graphics g = Graphics.FromImage(sample);
                        g.FillRectangle(new SolidBrush(color), rect);
                        g.DrawRectangle(Pens.White, rect.Left, rect.Top, rect.Width - 1, rect.Height - 1);
                        g.Dispose();
                        e.Value = sample;
                        e.FormattingApplied = true;
                    }
                    break;

                case "columnBgColorSample":
                    {
                        Color color = (Color)dataGridView[e.ColumnIndex - 1, e.RowIndex].Value;

                        Rectangle rect = new Rectangle(0, 0, 16, 16);
                        Bitmap sample = new Bitmap(rect.Width, rect.Height);
                        Graphics g = Graphics.FromImage(sample);
                        g.FillRectangle(new SolidBrush(color), rect);
                        g.DrawRectangle(Pens.White, rect.Left, rect.Top, rect.Width - 1, rect.Height - 1);
                        g.Dispose();
                        e.Value = sample;
                        e.FormattingApplied = true;
                    }
                    break;

                case "columnPosJa":
                    ConsolePanel.Pos pos = (ConsolePanel.Pos)dataGridView[e.ColumnIndex - 1, e.RowIndex].Value;
                    switch (pos)
                    {
                        case ConsolePanel.Pos.TopLeft:
                            e.Value = Viewer17.Properties.Resources.PosTopLeft;
                            break;
                        case ConsolePanel.Pos.TopRight:
                            e.Value = Viewer17.Properties.Resources.PosTopRight;
                            break;
                        case ConsolePanel.Pos.BottomLeft:
                            e.Value = Viewer17.Properties.Resources.PosBottomLeft;
                            break;
                        case ConsolePanel.Pos.BottomRight:
                            e.Value = Viewer17.Properties.Resources.PosBottomRight;
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
        }

        private void dataGridViewPanel_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            if (dataGridView.SelectedRows.Count > 0)
            {
                _curPanelIndex = dataGridView.SelectedRows[0].Index;

                // 
                if (_setting.panels.Count > 0)
                {
                    _buttons = new BindingList<ConsoleButton>(_setting.panels[_curPanelIndex].buttons);
                }

                this.resetId(ref _buttons);
                _bindingSourceButton.DataSource = _buttons;
                _dataGridViewButton.DataSource = _bindingSourceButton;

                _curButtonIndex = 0;

                if (_dataGridViewButton.Rows.Count > 0)
                {
                    _dataGridViewButton.Rows[0].Selected = true;
                }
            }
        }

        private void dataGridViewPanel_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.resetId(ref _panels);

            this.updateControls();
        }

        private void dataGridViewPanel_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.resetId(ref _panels);

            _buttons = new BindingList<ConsoleButton>();
            _bindingSourceButton.DataSource = _buttons;
            _dataGridViewButton.DataSource = _bindingSourceButton;

            _curButtonIndex = 0;

            this.updateControls();
        }

        private void buttonPanelAdd_Click(object sender, EventArgs e)
        {
            ConsolePanel panel = new ConsolePanel();

            if (_setting.lefty)
            {
                panel.pos = ConsolePanel.Pos.TopLeft;
            }

            _panels.Add(panel);
        }

        private void buttonPanelUp_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = _dataGridViewPanel;

            if (dataGridView.SelectedRows.Count > 0)
            {
                if (_curPanelIndex > 0)
                {
                    ConsolePanel tempPanel = _panels[_curPanelIndex];
                    _panels.RemoveAt(_curPanelIndex);
                    _panels.Insert(_curPanelIndex - 1, tempPanel);
                    dataGridView.Rows[_curPanelIndex - 1].Selected = true;

                    //_curPanelIndex--;
                }
            }
        }

        private void buttonPanelDown_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = _dataGridViewPanel;

            if (dataGridView.SelectedRows.Count > 0)
            {
                if (_curPanelIndex < _panels.Count - 1)
                {
                    ConsolePanel tempPanel = _panels[_curPanelIndex];
                    _panels.RemoveAt(_curPanelIndex);
                    _panels.Insert(_curPanelIndex + 1, tempPanel);
                    dataGridView.Rows[_curPanelIndex + 1].Selected = true;

                    //_curPanelIndex++;
                }
            }
        }

        private void dataGridViewButton_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            switch (dataGridView.Columns[e.ColumnIndex].Name)
            {
                case "columnOpeJa":
                    SendKeys.Send("{F4}");
                    break;

                case "columnKey":
                    SendKeys.Send("{F4}");
                    break;

                default:
                    break;
            }
        }

        private void dataGridViewButton_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                if (dataGridView.CurrentCell.OwningColumn.Name == "columnOpeJa")
                {
                    _curComboBox = (DataGridViewComboBoxEditingControl)e.Control;
                    _curComboBox.SelectedIndexChanged += new EventHandler(columnOpeJa_SelectedIndexChanged);
                }
            }
        }

        private void columnOpeJa_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewComboBoxEditingControl comboBox = (DataGridViewComboBoxEditingControl)sender;
            _buttons[_curButtonIndex].ope = (ConsoleButton.Ope)comboBox.SelectedIndex;
        }

        private void dataGridViewButton_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            switch (dataGridView.Columns[e.ColumnIndex].Name)
            {
                case "columnOpeJa":
                    if (_curComboBox != null)
                    {
                        _curComboBox.SelectedIndexChanged -= new EventHandler(columnOpeJa_SelectedIndexChanged);
                        _curComboBox = null;
                    }
                    break;
            }
        }

        private void dataGridViewButton_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            switch (dataGridView.Columns[e.ColumnIndex].Name)
            {
                case "columnIconSample":
                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.Filter = "Image files (*.png;*.jpg;*.bmp;*.gif;*.ico)|*.png;*.jpg;*.bmp;*.gif;*.ico";
                    if (dlg.ShowDialog(_form) == DialogResult.OK)
                    {
                        dataGridView[e.ColumnIndex - 1, e.RowIndex].Value = dlg.FileName;
                    }
                    break;

                case "columnRemove":
                    _buttons.RemoveAt(e.RowIndex);
                    break;

                default:
                    break;
            }
        }

        private void dataGridViewButton_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            switch (dataGridView.Columns[e.ColumnIndex].Name)
            {
                case "columnIconSample":
                    {
                        string iconPath = (string)dataGridView[e.ColumnIndex - 1, e.RowIndex].Value;

                        if (iconPath != "")
                        {
                            if (System.IO.Path.IsPathRooted(iconPath) == false)
                            {
                                iconPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + iconPath;
                            }

                            try
                            {
                                e.Value = new Bitmap(iconPath);
                                e.FormattingApplied = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            e.Value = Viewer17.Properties.Resources.layer_transparent;
                            e.FormattingApplied = true;
                        }
                    }
                    break;

                case "columnOpeJa":
                    ConsoleButton.Ope ope = (ConsoleButton.Ope)dataGridView[e.ColumnIndex - 1, e.RowIndex].Value;
                    switch (ope)
                    {
                        case ConsoleButton.Ope.Move:
                            e.Value = Viewer17.Properties.Resources.OpeMove;
                            dataGridView[e.ColumnIndex + 1, e.RowIndex].ReadOnly = false;
                            break;
                        case ConsoleButton.Ope.Copy:
                            e.Value = Viewer17.Properties.Resources.OpeCopy;
                            dataGridView[e.ColumnIndex + 1, e.RowIndex].ReadOnly = false;
                            break;
                        case ConsoleButton.Ope.Delete:
                            e.Value = Viewer17.Properties.Resources.OpeDelete;
                            dataGridView[e.ColumnIndex + 1, e.RowIndex].ReadOnly = true;
                            break;
                        case ConsoleButton.Ope.Undo:
                            e.Value = Viewer17.Properties.Resources.OpeUndo;
                            dataGridView[e.ColumnIndex + 1, e.RowIndex].ReadOnly = true;
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
        }

        private void dataGridViewButton_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            if (dataGridView.SelectedRows.Count > 0)
            {
                _curButtonIndex = dataGridView.SelectedRows[0].Index;
            }
        }

        private void dataGridViewButton_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.resetId(ref _buttons);

            this.updateControls();
        }

        private void dataGridViewButton_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.resetId(ref _buttons);

            this.updateControls();
        }

        private void buttonButtonAdd_Click(object sender, EventArgs e)
        {
            _buttons.Add(new ConsoleButton());
        }

        private void buttonButtonUp_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = _dataGridViewButton;

            if (dataGridView.SelectedRows.Count > 0)
            {
                if (_curButtonIndex > 0)
                {
                    ConsoleButton tempButton = _buttons[_curButtonIndex];
                    _buttons.RemoveAt(_curButtonIndex);
                    _buttons.Insert(_curButtonIndex - 1, tempButton);
                    dataGridView.Rows[_curButtonIndex - 1].Selected = true;

                    //_curIndex--;
                }
            }
        }

        private void buttonButtonDown_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = _dataGridViewButton;

            if (dataGridView.SelectedRows.Count > 0)
            {
                if (_curButtonIndex < _buttons.Count - 1)
                {
                    ConsoleButton tempButton = _buttons[_curButtonIndex];
                    _buttons.RemoveAt(_curButtonIndex);
                    _buttons.Insert(_curButtonIndex + 1, tempButton);
                    dataGridView.Rows[_curButtonIndex + 1].Selected = true;

                    //_curIndex++;
                }
            }
        }

        public void updateControls()
        {
            // 17個まで
            int panelCount = 0;
            int buttonCount = 0;
            foreach (ConsolePanel panel in _panels)
            {
                panelCount++;

                foreach (ConsoleButton button in panel.buttons)
                {
                    buttonCount++;
                }
            }

            if (panelCount < 17)
            {
                _buttonPanelAdd.Enabled = true;
            }
            else
            {
                _buttonPanelAdd.Enabled = false;
            }

            if (buttonCount < 17)
            {
                if (panelCount > 0)
                {
                    _buttonButtonAdd.Enabled = true;
                }
                else
                {
                    _buttonButtonAdd.Enabled = false;
                }
            }
            else
            {
                _buttonButtonAdd.Enabled = false;
            }

            if (_panels.Count >= 2)
            {
                _buttonPanelUp.Show();
                _buttonPanelDown.Show();
                _buttonButtonUp.Show();
                _buttonButtonDown.Show();
            }
            else
            {
                _buttonPanelUp.Hide();
                _buttonPanelDown.Hide();
                _buttonButtonUp.Hide();
                _buttonButtonDown.Hide();
            }
        }
    }
}
