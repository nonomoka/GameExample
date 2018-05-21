namespace MudClient
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMainPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbMainWindow = new System.Windows.Forms.RichTextBox();
            this.txbInputBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnection = new System.Windows.Forms.Button();
            this.txbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbServerIP = new System.Windows.Forms.TextBox();
            this.tabConfigPage = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabMainPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMainPage);
            this.tabControl.Controls.Add(this.tabConfigPage);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(773, 677);
            this.tabControl.TabIndex = 6;
            // 
            // tabMainPage
            // 
            this.tabMainPage.Controls.Add(this.groupBox2);
            this.tabMainPage.Controls.Add(this.groupBox1);
            this.tabMainPage.Location = new System.Drawing.Point(4, 22);
            this.tabMainPage.Name = "tabMainPage";
            this.tabMainPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabMainPage.Size = new System.Drawing.Size(765, 651);
            this.tabMainPage.TabIndex = 0;
            this.tabMainPage.Text = "主頁";
            this.tabMainPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txbMainWindow);
            this.groupBox2.Controls.Add(this.txbInputBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(753, 570);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "主視窗";
            // 
            // txbMainWindow
            // 
            this.txbMainWindow.BackColor = System.Drawing.Color.Black;
            this.txbMainWindow.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txbMainWindow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txbMainWindow.Location = new System.Drawing.Point(8, 21);
            this.txbMainWindow.Name = "txbMainWindow";
            this.txbMainWindow.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedHorizontal;
            this.txbMainWindow.Size = new System.Drawing.Size(737, 506);
            this.txbMainWindow.TabIndex = 7;
            this.txbMainWindow.Text = "";
            // 
            // txbInputBox
            // 
            this.txbInputBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txbInputBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txbInputBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txbInputBox.Location = new System.Drawing.Point(8, 533);
            this.txbInputBox.Name = "txbInputBox";
            this.txbInputBox.Size = new System.Drawing.Size(737, 27);
            this.txbInputBox.TabIndex = 0;
            this.txbInputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbInputBox_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnection);
            this.groupBox1.Controls.Add(this.txbPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txbServerIP);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 63);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "連線";
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(465, 23);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(75, 23);
            this.btnConnection.TabIndex = 5;
            this.btnConnection.Text = "連線";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // txbPort
            // 
            this.txbPort.Location = new System.Drawing.Point(354, 24);
            this.txbPort.Name = "txbPort";
            this.txbPort.Size = new System.Drawing.Size(100, 22);
            this.txbPort.TabIndex = 4;
            this.txbPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbPort_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "port : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "服務器位址 : ";
            // 
            // txbServerIP
            // 
            this.txbServerIP.Location = new System.Drawing.Point(103, 24);
            this.txbServerIP.Name = "txbServerIP";
            this.txbServerIP.Size = new System.Drawing.Size(196, 22);
            this.txbServerIP.TabIndex = 1;
            // 
            // tabConfigPage
            // 
            this.tabConfigPage.Location = new System.Drawing.Point(4, 22);
            this.tabConfigPage.Name = "tabConfigPage";
            this.tabConfigPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfigPage.Size = new System.Drawing.Size(765, 651);
            this.tabConfigPage.TabIndex = 1;
            this.tabConfigPage.Text = "設定頁";
            this.tabConfigPage.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 701);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "NMud v1.0.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabMainPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabConfigPage;
        private System.Windows.Forms.TabPage tabMainPage;
        private System.Windows.Forms.TextBox txbPort;
        private System.Windows.Forms.TextBox txbInputBox;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.TextBox txbServerIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txbMainWindow;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

