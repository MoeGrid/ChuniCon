using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ChuniCon.Entity;
using ChuniCon.Utils;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace ChuniCon.Forms
{
    public partial class MainForm : Form
    {
        private ChuniIO.ChuniIoSliderCallback SliderCallback;
        private Preset CurrentPreset = null;
        private Thread RefreshThread;
        private bool RefreshThreadFlag;
        private Thread RefreshColorThread;
        private bool RefreshColorThreadFlag;

        public delegate void GuiInvoke();
        public delegate void GuiInvoke<T>(T p1);
        public delegate void GuiInvoke<T, U>(T p1, U p2);

        public MainForm()
        {
            InitializeComponent();
            // 初始化ChuniIO
            int status = ChuniIO.ChuniIoJvsInit();
            if (status != 0)
            {
                MessageBox.Show("ChuniIO初始化失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            // 注册触摸回调
            SliderCallback = new ChuniIO.ChuniIoSliderCallback(Callback);
            // 启动刷新列表线程
            RefreshThreadFlag = true;
            RefreshThread = new Thread(RefreshKeyPairList);
            RefreshThread.IsBackground = true;
            RefreshThread.Start();
            // 启动刷新颜色线程
            RefreshColorThreadFlag = true;
            RefreshColorThread = new Thread(RefreshColor);
            RefreshColorThread.IsBackground = true;
            RefreshColorThread.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadPreset();
            ChuniIO.ChuniIoSliderStart(SliderCallback);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 停止线程
            RefreshThreadFlag = false;
            RefreshThread.Join();
            RefreshColorThreadFlag = false;
            RefreshColorThread.Join();
            // 停止触摸回调
            ChuniIO.ChuniIoSliderStop();
        }

        /// <summary>
        /// 新建预设
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewPresetBtn_Click(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("创建预设", "请输入预设名称", "新预设");
            if (HasInvalidFileNameChars(name))
            {
                MessageBox.Show("预设名称包含非法字符!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (name == "")
            {
                MessageBox.Show("预设名称不能为空!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var tmp = new Preset
            {
                Name = name,
                KeyPair = new KeyPair[32],
                RGBPair = new RGBPair[31],
                Sensitivity = 100
            };
            for (byte i = 0; i < 32; i++)
            {
                tmp.KeyPair[i] = new KeyPair()
                {
                    Area = i,
                    Key = 0,
                    Status = 0
                };
            }
            for (byte i = 0; i < 31; i++)
            {
                tmp.RGBPair[i] = new RGBPair()
                {
                    Area = i,
                    Color = Color.Black,
                    PressColor = Color.Black.Reverse()
                };
            }
            CurrentPreset = tmp;
            tmp.GenKeyGroup();
            SavePreset(tmp);
            LoadPreset();
        }

        /// <summary>
        /// 保存预设
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SavePresetBtn_Click(object sender, EventArgs e)
        {
            if (CurrentPreset != null)
            {
                SavePreset(CurrentPreset);
                LoadPreset();
            }
        }

        /// <summary>
        /// 选择预设
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PresetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PresetList.SelectedIndex == -1)
                return;
            Preset preset = PresetList.SelectedItem as Preset;
            ShowPreset(preset);
            CurrentPreset = preset;
        }

        /// <summary>
        /// 预设列表右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PresetList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && PresetList.SelectedIndex != -1)
                PresetMenu.Show(MousePosition.X, MousePosition.Y);
        }

        /// <summary>
        /// 修改预设
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyPresetMenu_Click(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("修改预设名称", "请输入预设名称", CurrentPreset.Name);
            if (name == "")
            {
                MessageBox.Show("预设名称不能为空!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CurrentPreset.Name = name;
            SavePreset(CurrentPreset);
            LoadPreset();
        }

        /// <summary>
        /// 删除预设
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeletePresetMenu_Click(object sender, EventArgs e)
        {
            DeletePreset(CurrentPreset);
        }

        /// <summary>
        /// 键对右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyPairList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && KeyPairList.SelectedIndices.Count > 0)
                KeyPairMenu.Show(MousePosition.X, MousePosition.Y);
        }

        /// <summary>
        /// 修改键码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyKeyMenu_Click(object sender, EventArgs e)
        {
            Keys? same = null;
            foreach (int i in KeyPairList.SelectedIndices)
            {
                var pair = CurrentPreset.KeyPair[i];
                if (same != null && pair.Key != same)
                {
                    same = null;
                    break;
                }
                same = pair.Key;
            }
            var form = new KeyCodeForm();
            if(same != null)
                form.Key = same.Value;
            if (form.ShowDialog() != DialogResult.OK)
                return;
            foreach (int i in KeyPairList.SelectedIndices)
            {
                CurrentPreset.KeyPair[i].Key = form.Key;
                KeyPairList.Items[i].SubItems[1].Text = form.Key.ToString();
            }
            CurrentPreset.GenKeyGroup();
        }

        /// <summary>
        /// LED右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RGBPairList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && RGBPairList.SelectedIndices.Count > 0)
                RGBPairMenu.Show(MousePosition.X, MousePosition.Y);
        }

        /// <summary>
        /// 修改颜色菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyColor_Click(object sender, EventArgs e)
        {
            ColorDialog ColorForm = new ColorDialog();
            if (ColorForm.ShowDialog() == DialogResult.OK)
            {
                foreach (int i in RGBPairList.SelectedIndices)
                {
                    var color = ColorForm.Color;
                    var item = RGBPairList.Items[i].SubItems[1];
                    CurrentPreset.RGBPair[i].Color = color;
                    item.Text = color.ToCommaString();
                    item.BackColor = color;
                    item.ForeColor = color.Reverse();
                }
            }
        }

        /// <summary>
        /// 修改按下颜色菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyPressColor_Click(object sender, EventArgs e)
        {
            ColorDialog ColorForm = new ColorDialog();
            if (ColorForm.ShowDialog() == DialogResult.OK)
            {
                foreach (int i in RGBPairList.SelectedIndices)
                {
                    if (i % 2 == 1)
                    {
                        var item = RGBPairList.Items[i].SubItems[2];
                        item.Text = "-";
                    }
                    else
                    {
                        var color = ColorForm.Color;
                        var item = RGBPairList.Items[i].SubItems[2];
                        CurrentPreset.RGBPair[i].PressColor = color;
                        item.Text = color.ToCommaString();
                        item.BackColor = color;
                        item.ForeColor = color.Reverse();
                    }
                }
            }
        }

        /// <summary>
        /// 修改灵敏度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SensitivityBar_Scroll(object sender, EventArgs e)
        {
            if (CurrentPreset != null)
            {
                CurrentPreset.Sensitivity = (byte)SensitivityBar.Value;
                SensitivityLab.Text = "灵敏度: " + SensitivityBar.Value;
            }
        }

        /// <summary>
        /// 驱动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DriverBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DriverBox.Checked)
            {
                var ret = DD.Btn(0);
                if (ret != 1)
                {
                    MessageBox.Show("DD驱动初始化失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NormalBox.Checked = true;
                    return;
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 载入预设
        /// </summary>
        private void LoadPreset()
        {
            if (!Directory.Exists("preset"))
                return;
            PresetList.Items.Clear();
            var files = Directory.GetFiles("preset", "*.json");
            foreach (var item in files)
            {
                var preset = JsonConvert.DeserializeObject<Preset>(File.ReadAllText(item));
                preset.Name = Path.GetFileNameWithoutExtension(item);
                preset.OriginName = preset.Name;
                preset.GenKeyGroup();
                int index = PresetList.Items.Add(preset);
                if (CurrentPreset != null && CurrentPreset.Name == preset.Name)
                    PresetList.SelectedIndex = index;
            }
        }

        /// <summary>
        /// 显示预设
        /// </summary>
        private void ShowPreset(Preset preset)
        {
            // Key表
            KeyPairList.Items.Clear();
            foreach (var i in preset.KeyPair)
            {
                var item = new ListViewItem();
                item.Text = (i.Area + 1).ToString();
                item.SubItems.Add(i.Key.ToString());
                item.SubItems.Add("0");
                KeyPairList.Items.Add(item);
            }
            // RGB表
            RGBPairList.Items.Clear();
            foreach (var i in preset.RGBPair)
            {
                var item = new ListViewItem();
                item.UseItemStyleForSubItems = false;
                item.Text = (i.Area + 1).ToString();
                item.SubItems.Add(i.Color.ToCommaString());
                item.SubItems[1].BackColor = i.Color;
                item.SubItems[1].ForeColor = i.Color.Reverse();
                if (i.Area % 2 == 1)
                {
                    item.SubItems.Add("-");
                }
                else
                {
                    item.SubItems.Add(i.PressColor.ToCommaString());
                    item.SubItems[2].BackColor = i.PressColor;
                    item.SubItems[2].ForeColor = i.PressColor.Reverse();
                }
                RGBPairList.Items.Add(item);
            }
            // 灵敏度
            SensitivityBar.Value = preset.Sensitivity;
            SensitivityLab.Text = "灵敏度: " + preset.Sensitivity;
        }

        /// <summary>
        /// 保存预设
        /// </summary>
        private void SavePreset(Preset preset)
        {
            if (!Directory.Exists("preset"))
                Directory.CreateDirectory("preset");
            var p = Path.Combine("preset", preset.Name + ".json");
            if (preset.Name != preset.OriginName)
            {
                var op = Path.Combine("preset", preset.OriginName + ".json");
                if (File.Exists(op))
                    File.Move(op, p);
                preset.OriginName = preset.Name;
            }
            File.WriteAllText(p, JsonConvert.SerializeObject(preset));
        }

        /// <summary>
        /// 删除预设
        /// </summary>
        /// <param name="preset"></param>
        private void DeletePreset(Preset preset)
        {
            CurrentPreset = null;
            KeyPairList.Items.Clear();
            RGBPairList.Items.Clear();
            File.Delete(Path.Combine("preset", preset.Name + ".json"));
            LoadPreset();
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        private void RefreshKeyPairList()
        {
            while (RefreshThreadFlag)
            {
                if (CurrentPreset != null)
                {
                    BeginInvoke(new GuiInvoke(() =>
                    {
                        if (CurrentPreset != null)
                        {
                            KeyPairList.BeginUpdate();
                            for (int i = 0; i < 32; i++)
                                KeyPairList.Items[i].SubItems[2].Text = CurrentPreset.KeyPair[i].Status.ToString();
                            KeyPairList.EndUpdate();
                        }
                    }));
                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 刷新颜色
        /// </summary>
        private void RefreshColor()
        {
            byte[] color = new byte[31 * 3];
            while (RefreshColorThreadFlag)
            {
                if (CurrentPreset != null)
                {
                    var rgbs = CurrentPreset.RGBPair;
                    for (int i = 0; i < rgbs.Length; i++)
                    {
                        color[i * 3 + 0] = rgbs[i].Color.B;
                        color[i * 3 + 1] = rgbs[i].Color.R;
                        color[i * 3 + 2] = rgbs[i].Color.G;
                        // 触摸颜色
                        if (i % 2 == 0)
                        {
                            if (CurrentPreset.KeyPair[i].Status > CurrentPreset.SensitivityValue || CurrentPreset.KeyPair[i + 1].Status > CurrentPreset.SensitivityValue)
                            {
                                color[i * 3 + 0] = rgbs[i].PressColor.B;
                                color[i * 3 + 1] = rgbs[i].PressColor.R;
                                color[i * 3 + 2] = rgbs[i].PressColor.G;
                            }
                        }
                    }
                    ChuniIO.ChuniIoSliderSetLeds(color);
                }
                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// 台子报告触摸状态回调
        /// </summary>
        /// <param name="buffer"></param>
        private void Callback(byte[] buffer)
        {
            if (CurrentPreset == null)
                return;
            foreach (var item in CurrentPreset.KeyGroup)
            {
                // 计算键状态
                bool status = false;
                foreach (var item1 in item.Area)
                {
                    CurrentPreset.KeyPair[item1].Status = buffer[item1];
                    if (buffer[item1] >= CurrentPreset.SensitivityValue)
                        status = true;
                }
                if (item.Key > 0)
                {
                    if (status && !item.Status)
                    {
                        // 按下
                        if (NormalBox.Checked)
                            Win32API.KeybdEvent((byte)item.Key, 0, 0, 0);
                        else if (DriverBox.Checked)
                            DD.Key(DD.Todc((byte)item.Key), 1);
                    }
                    else if (!status && item.Status)
                    {
                        // 松开
                        if (NormalBox.Checked)
                            Win32API.KeybdEvent((byte)item.Key, 0, 2, 0);
                        else if (DriverBox.Checked)
                            DD.Key(DD.Todc((byte)item.Key), 2);
                    }
                }
                item.Status = status;
            }
        }

        /// <summary>
        /// 是否有非法字符
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool HasInvalidFileNameChars(string name)
        {
            var invalid = Path.GetInvalidFileNameChars();
            foreach (char c in invalid)
            {
                if (name.IndexOf(c) != -1)
                    return true;
            }
            return false;
        }

    }
}
