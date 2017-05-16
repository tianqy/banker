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
    public partial class dynamicForm : Form
    {
        int sourceNum = 0;
        int proNum = 0;
        public dynamicForm()
        {
            InitializeComponent();
        }
        public dynamicForm(string str)
        {
            InitializeComponent();
            string[] st= str.Split('-');
            sourceNum = int.Parse(st[0]);   //资源种类数
            proNum = int.Parse(st[1]);      //进程数目

            createSumSource();     //动态生成设置资源总数的控件

            createTotalSourcePerProcess(); //动态生成进程总资源表

            createHadSourcePerProcess();//动态生成进程已有资产表

            createApplySource();//生成申请资源表

            setStyle();    //窗体布局
        }

        //申请资源表
        private void createApplySource()
        {
            DataTable dt = new DataTable();
            dt = newDataTable();
            dgv4.DataSource = dt;
            dgv4.Columns[0].ReadOnly = true;
        }

        //设置布局
        private void setStyle()
        {
            //表1布局
            this.dgv1.RowHeadersVisible = false;
            dgv1.Columns[0].Width = 60;
            dgv1.Columns[1].Width = 60;
            this.dgv1.Height = 20 + 24 * sourceNum;

            //表2布局
            this.dgv2.RowHeadersVisible = false;
            for (int i = 0; i <= sourceNum; i++)
                dgv2.Columns[i].Width = 60;
            if (sourceNum <= 5)
                this.dgv2.Width = 65 + 60 * sourceNum;
            else this.dgv2.Width = 365;
            if(proNum<=8)
                this.dgv2.Height = 18 + 24 * proNum;
            else this.dgv2.Height = 18 + 24 * 8;

            //表3布局
            this.dgv3.RowHeadersVisible = false;
            for (int i = 0; i <= sourceNum; i++)
                dgv3.Columns[i].Width = 60;
            if (sourceNum <= 5)
                this.dgv3.Width = 65 + 60 * sourceNum;
            else this.dgv3.Width = 365;
            if (proNum <= 8)
                this.dgv3.Height = 18 + 24 * proNum;
            else this.dgv3.Height = 18 + 24 * 8;

            //表4布局
            this.dgv4.RowHeadersVisible = false;
            for (int i = 0; i <= sourceNum; i++)
                dgv4.Columns[i].Width = 60;
            if (sourceNum <= 5)
                this.dgv4.Width = 65 + 60 * sourceNum;
            else this.dgv4.Width = 365;
            if(proNum<=8)
                this.dgv4.Height = 18 + 24 * proNum;
            else this.dgv4.Height = 18 + 24 * 8;

            //窗体大小
            if (sourceNum <= 3)
                this.Width = 760 + 100 * sourceNum;
            else this.Width = 1060;
            if (proNum <= 3)
                this.Height = 450 + 48 * proNum;
            else this.Height = 450 + 48 * 3;
        }

        //创建每个进程已有资源表
        private void createHadSourcePerProcess()
        {
            DataTable dt = new DataTable();
            dt = newDataTable();
            dgv3.DataSource = dt;
            dgv3.Columns[0].ReadOnly = true;
        }

        //创建每个进程总共需要资源表
        private void createTotalSourcePerProcess()
        {
            DataTable dt = new DataTable();
            dt = newDataTable();
            dgv2.DataSource = dt;
            dgv2.Columns[0].ReadOnly = true;
            //this.dgv1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        //创建剩余资源列表
        private void createSumSource()
        {
            DataTable dt = new DataTable(); //创建table对象
            dt.Columns.Add(new DataColumn("资源", typeof(string)));
            dt.Columns.Add(new DataColumn("数目", typeof(int)));
            DataRow dr;//行
            for (int i = 1; i <= sourceNum; i++)
            {
                dr = dt.NewRow();
                dr[0] = "资源" + i;
                dr[1] = 0;
                dt.Rows.Add(dr);//在表的对象的行里添加此行
            }
            dgv1.DataSource = dt;
            dgv1.Columns[0].ReadOnly = true;
        }

        //创建table
        private DataTable newDataTable()
        {
            DataTable dt = new DataTable(); //创建table对象
            dt.Columns.Add(new DataColumn("进程", typeof(string)));
            for (int i = 1; i <= sourceNum; i++)
            {
                dt.Columns.Add(new DataColumn("资源" + i.ToString(), typeof(int)));
            }
            DataRow dr;//行
            for (int i = 1; i <= proNum; i++)
            {
                dr = dt.NewRow();
                dr[0] = "进程" + i;
                for (int j = 1; j <= sourceNum; j++)
                {
                    dr[j] = 0;
                }
                dt.Rows.Add(dr);//在表的对象的行里添加此行
            }
            return dt;
        }

        //关闭窗体事件
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //查找序列
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int[] sourceMax=new int[sourceNum]; //现有资源数组
            int[,] sourceNeedMax = new int[proNum, sourceNum];  //各进程总共所需资源数组
            int[,] sourceHad = new int[proNum, sourceNum];  //各进程已获得的资源数组
            int[,] sourceApply = new int[proNum, sourceNum];    //申请资源数组
            int i = 1;
            try
            {
                for (i = 0; i < sourceNum; i++)
                {
                    sourceMax[i] = int.Parse(this.dgv1.Rows[i].Cells[1].Value.ToString());
                }
                for (i = 0; i < proNum; i++)
                {
                    for (int j = 0; j < sourceNum; j++)
                    {
                        sourceNeedMax[i, j] = int.Parse(this.dgv2.Rows[i].Cells[j + 1].Value.ToString());
                        sourceHad[i, j] = int.Parse(this.dgv3.Rows[i].Cells[j + 1].Value.ToString());
                        sourceApply[i, j] = int.Parse(this.dgv4.Rows[i].Cells[j + 1].Value.ToString());
                    }
                }
                if (myCheck(sourceMax, sourceNeedMax, sourceHad, sourceApply))
                    haveSort(sourceMax, sourceNeedMax, sourceHad, sourceApply);
                else MessageBox.Show("输入有误,请更改！");
            }
            catch
            {
                MessageBox.Show("输入存在格式错误，请确认输入为正整数");
            } 
        }

        //检测输入异常
        private bool myCheck(int[] sourceMax, int[,] sourceNeedMax, int[,] sourceHad, int[,] sourceApply)
        {
            bool flag = true;
            //剩余资源检测
            foreach(int a in sourceMax)
            {
                if (a < 0)
                {
                    flag = false;
                    break;
                }
            }
            if (!flag)
            {
                MessageBox.Show("剩余资源数不能小于0!");
                return flag;
            }
            //最大需求检测
            foreach(int a in sourceNeedMax)
            {
                if (a < 0)
                {
                    flag = false;
                    break;
                }
            }
            if (!flag)
            {
                MessageBox.Show("进程需要资源数不能为负！");
                return flag;
            }
            //已有资源检测
            foreach(int a in sourceHad)
            {
                if (a < 0)
                {
                    flag = false;
                    break;
                }
            }
            if (!flag)
            {
                MessageBox.Show("进程已有资源不能设为负值！");
                return flag;
            }
            //申请资源检测
            foreach(int a in sourceApply)
            {
                if (a < 0)
                {
                    flag = false;
                    break;
                }
            }
            if (!flag)
            {
                MessageBox.Show("申请资源不能为负！");
                return flag;
            }
            //检测冲突
            int status = 0;
            for (int i = 0; i < proNum; i++)
            {
                int sum = 0;
                for (int j = 0; j < sourceNum; j++)
                {
                    sum += sourceNeedMax[i, j];
                }
                if (sum == 0)
                {
                    MessageBox.Show("进程的最大所需资源数不能全为0");
                    flag = false;
                    break;
                }
            }

            for (int i = 0; i < proNum; i++)
            {
                for (int j = 0; j < sourceNum; j++)
                {
                    if(sourceApply[i,j]>sourceNeedMax[i,j]- sourceHad[i, j])
                    {
                        status = 1;
                        flag = false;
                        break;
                    }
                }

                if (status==1)
                {
                    MessageBox.Show("数据冲突，请检查输入！");
                    break;
                }
                else if(status == 2)
                {
                    MessageBox.Show("申请过多，无法满足！");
                    break;
                }
            }
           return flag;  
        }

        //判断是否有序列
        private void haveSort(int[] sourceMax, int[,] sourceNeedMax, int[,] sourceHad, int[,] sourceApply)
        {
            int[,] sourceNeed = new int[proNum, sourceNum];
            for (int i = 0; i < proNum; i++)
            {
                for (int j = 0; j < sourceNum; j++)
                {
                    sourceHad[i, j] += sourceApply[i, j];
                    sourceNeed[i, j] = sourceNeedMax[i, j] - sourceHad[i, j];
                    sourceMax[j] -= sourceApply[i, j];
                }
            }
           // string ss = "";
            string sort = "";
            for (int k = 0; k < proNum; k++)
            {
                for (int i = 0; i < proNum; i++)
                {
                    bool flag = true;
                    //判断是否够分配
                    for (int j = 0; j < sourceNum; j++)
                    {
                        if (sourceMax[j] < sourceNeed[i, j])
                        {
                            flag = false;
                            
                            break;
                        }
                    }
                    //分配并释放
                    if (flag&&isEnd(sourceNeed,i))
                    {
                        for (int j = 0; j < sourceNum; j++)
                        {
                            sourceMax[j] += sourceHad[i, j];
                            sourceNeed[i, j] = 0;
                            sourceHad[i, j] = 0;
                        }
                        sort = sort + (i+1).ToString();
                    }
                    if (sort.Length == proNum)
                        break;
                }
            }
            if (sort.Length == proNum)  //找到序列
            {
                string tmp = "";
                for (int i = 0; i < proNum - 1; i++)
                {
                    tmp += (sort[i] + "->");
                }
                tmp += sort[proNum - 1];
                lblSafe.Text = "安全";
                lblSafeSort.Text = tmp;
                MessageBox.Show("操作成功");
            }
            else
            {
                lblSafe.Text = "不安全";
                MessageBox.Show("无法实现");
                lblSafeSort.Text = "不存在";
            }
        }

        //判断是否已经释放
        bool isEnd(int[,] sourceNeed,int row)
        {
            int flag = 0;
            for(int rol = 0; rol < sourceNum; rol++)
            {
                if (sourceNeed[row,rol] == 0)
                {
                    flag++;
                }
            }
            if (flag == sourceNum)
            {
                return false;
            }
            else return true;
        }
    }
}
