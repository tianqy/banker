namespace bank
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblsource = new System.Windows.Forms.Label();
            this.lblpro = new System.Windows.Forms.Label();
            this.txtSourceKind = new System.Windows.Forms.TextBox();
            this.txtProNum = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblTip1 = new System.Windows.Forms.Label();
            this.lblTip2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblsource
            // 
            this.lblsource.AutoSize = true;
            this.lblsource.Font = new System.Drawing.Font("宋体", 15F);
            this.lblsource.Location = new System.Drawing.Point(160, 90);
            this.lblsource.Name = "lblsource";
            this.lblsource.Size = new System.Drawing.Size(129, 20);
            this.lblsource.TabIndex = 0;
            this.lblsource.Text = "资源种类数：";
            // 
            // lblpro
            // 
            this.lblpro.AutoSize = true;
            this.lblpro.Font = new System.Drawing.Font("宋体", 15F);
            this.lblpro.Location = new System.Drawing.Point(160, 133);
            this.lblpro.Name = "lblpro";
            this.lblpro.Size = new System.Drawing.Size(89, 20);
            this.lblpro.TabIndex = 1;
            this.lblpro.Text = "进程数：";
            // 
            // txtSourceKind
            // 
            this.txtSourceKind.Font = new System.Drawing.Font("宋体", 15F);
            this.txtSourceKind.Location = new System.Drawing.Point(295, 87);
            this.txtSourceKind.Name = "txtSourceKind";
            this.txtSourceKind.Size = new System.Drawing.Size(67, 30);
            this.txtSourceKind.TabIndex = 2;
            this.txtSourceKind.TextChanged += new System.EventHandler(this.txtSourceKind_TextChanged);
            // 
            // txtProNum
            // 
            this.txtProNum.Font = new System.Drawing.Font("宋体", 15F);
            this.txtProNum.Location = new System.Drawing.Point(295, 130);
            this.txtProNum.Name = "txtProNum";
            this.txtProNum.Size = new System.Drawing.Size(67, 30);
            this.txtProNum.TabIndex = 3;
            this.txtProNum.TextChanged += new System.EventHandler(this.txtProNum_TextChanged);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("宋体", 12F);
            this.btnStart.Location = new System.Drawing.Point(212, 201);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(77, 29);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "确定";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTip1
            // 
            this.lblTip1.AutoSize = true;
            this.lblTip1.Location = new System.Drawing.Point(383, 93);
            this.lblTip1.Name = "lblTip1";
            this.lblTip1.Size = new System.Drawing.Size(0, 12);
            this.lblTip1.TabIndex = 5;
            // 
            // lblTip2
            // 
            this.lblTip2.AutoSize = true;
            this.lblTip2.Location = new System.Drawing.Point(384, 139);
            this.lblTip2.Name = "lblTip2";
            this.lblTip2.Size = new System.Drawing.Size(0, 12);
            this.lblTip2.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 309);
            this.Controls.Add(this.lblTip2);
            this.Controls.Add(this.lblTip1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtProNum);
            this.Controls.Add(this.txtSourceKind);
            this.Controls.Add(this.lblpro);
            this.Controls.Add(this.lblsource);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblsource;
        private System.Windows.Forms.Label lblpro;
        private System.Windows.Forms.TextBox txtSourceKind;
        private System.Windows.Forms.TextBox txtProNum;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblTip1;
        private System.Windows.Forms.Label lblTip2;
    }
}

