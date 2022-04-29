
namespace FakeNesicaService
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.s_gameid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.s_tenpoid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.s_tenponame = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.s_address = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.s_prefecture = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.s_host = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.s_img = new System.Windows.Forms.TextBox();
            this.s_version = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 119);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(776, 316);
            this.listBox1.TabIndex = 1;
            // 
            // s_gameid
            // 
            this.s_gameid.Location = new System.Drawing.Point(176, 14);
            this.s_gameid.Name = "s_gameid";
            this.s_gameid.Size = new System.Drawing.Size(61, 20);
            this.s_gameid.TabIndex = 2;
            this.s_gameid.Text = "3500";
            this.s_gameid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.s_gameid.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Game ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 17);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Location ID";
            // 
            // s_tenpoid
            // 
            this.s_tenpoid.Location = new System.Drawing.Point(321, 14);
            this.s_tenpoid.Name = "s_tenpoid";
            this.s_tenpoid.Size = new System.Drawing.Size(46, 20);
            this.s_tenpoid.TabIndex = 5;
            this.s_tenpoid.Text = "77";
            this.s_tenpoid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.s_tenpoid.TextChanged += new System.EventHandler(this.s_tenpoid_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Location Name";
            // 
            // s_tenponame
            // 
            this.s_tenponame.Location = new System.Drawing.Point(476, 14);
            this.s_tenponame.Name = "s_tenponame";
            this.s_tenponame.Size = new System.Drawing.Size(151, 20);
            this.s_tenponame.TabIndex = 7;
            this.s_tenponame.Text = "Meditation Garden";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Address";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // s_address
            // 
            this.s_address.Location = new System.Drawing.Point(476, 36);
            this.s_address.Name = "s_address";
            this.s_address.Size = new System.Drawing.Size(151, 20);
            this.s_address.TabIndex = 9;
            this.s_address.Text = "Abbey Road";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(414, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Prefecture";
            // 
            // s_prefecture
            // 
            this.s_prefecture.Location = new System.Drawing.Point(476, 59);
            this.s_prefecture.Name = "s_prefecture";
            this.s_prefecture.Size = new System.Drawing.Size(151, 20);
            this.s_prefecture.TabIndex = 11;
            this.s_prefecture.Text = "Tokyo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Version";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Host";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // s_host
            // 
            this.s_host.Location = new System.Drawing.Point(93, 83);
            this.s_host.Name = "s_host";
            this.s_host.Size = new System.Drawing.Size(534, 20);
            this.s_host.TabIndex = 14;
            this.s_host.Text = "httphost=paradox.arcade.cab,tcphost=paradox.arcade.cab";
            this.s_host.TextChanged += new System.EventHandler(this.s_host_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Image";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // s_img
            // 
            this.s_img.Location = new System.Drawing.Point(93, 59);
            this.s_img.Name = "s_img";
            this.s_img.Size = new System.Drawing.Size(315, 20);
            this.s_img.TabIndex = 16;
            this.s_img.Text = "D:\\system\\DUA\\news\\1450152887.png";
            // 
            // s_version
            // 
            this.s_version.Location = new System.Drawing.Point(93, 36);
            this.s_version.Name = "s_version";
            this.s_version.Size = new System.Drawing.Size(315, 20);
            this.s_version.TabIndex = 17;
            this.s_version.Text = "2.83(x64) 2017/11/07";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.s_version);
            this.Controls.Add(this.s_img);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.s_host);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.s_prefecture);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.s_address);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.s_tenponame);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.s_tenpoid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.s_gameid);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FakeNesica Service";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox s_gameid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox s_tenpoid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox s_tenponame;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox s_address;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox s_prefecture;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox s_host;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox s_img;
        private System.Windows.Forms.TextBox s_version;
    }
}

