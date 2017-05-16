using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bank
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnStart.Enabled = false;
        }

        private void txtSourceKind_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtSourceKind.Text.Trim(), "^\\d+$"))
            {
                lblTip1.Text = "请输入整数";
                btnStart.Enabled = false;
            }
            else if (int.Parse(txtSourceKind.Text) > 20)
            {
                lblTip1.Text = "要求小于20";
                btnStart.Enabled = false;
            }
            else
            {
                lblTip1.Text = null;
                if (!(txtProNum.Text).Equals(""))
                { btnStart.Enabled = true; }
            }
        }

        private void txtProNum_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtProNum.Text.Trim(), "^\\d+$"))
            {
                lblTip2.Text = "请输入整数";
                btnStart.Enabled = false;
            }
            else if (int.Parse(txtProNum.Text) > 20)
            {
                lblTip2.Text = "要求小于20";
                btnStart.Enabled = false;
            }
            else
            {
                lblTip2.Text = null;
                if (txtSourceKind.Text != "")
                    btnStart.Enabled = true;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                int sourceNum = int.Parse(txtSourceKind.Text);
                int proNum = int.Parse(txtProNum.Text);
                string str = txtSourceKind.Text + "-" + txtProNum.Text;
                dynamicForm df = new dynamicForm(str);
                df.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("请检查输入是否合格！");
            }
        }

    }
}
