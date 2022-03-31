using System;
using System.Windows.Forms;

namespace ChuniCon.Forms
{
    public partial class KeyCodeForm : Form
    {
        public Keys Key = Keys.None;

        public KeyCodeForm()
        {
            InitializeComponent();
        }

        private void KeyCodeForm_Load(object sender, EventArgs e)
        {
            var keys = Enum.GetValues(typeof(Keys));
            foreach (var key in keys)
                KeyBox.Items.Add(key);
            KeyBox.SelectedItem = Key;
        }

        private void KeyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Key = (Keys)KeyBox.SelectedItem;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
