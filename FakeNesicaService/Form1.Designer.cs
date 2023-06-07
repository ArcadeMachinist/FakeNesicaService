
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
            button1 = new System.Windows.Forms.Button();
            listBox1 = new System.Windows.Forms.ListBox();
            s_gameid = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            s_tenpoid = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            s_tenponame = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            s_address = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            s_prefecture = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            s_host = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            s_img = new System.Windows.Forms.TextBox();
            s_version = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(26, 30);
            button1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(162, 57);
            button1.TabIndex = 0;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 32;
            listBox1.Location = new System.Drawing.Point(26, 293);
            listBox1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            listBox1.Name = "listBox1";
            listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            listBox1.Size = new System.Drawing.Size(1677, 772);
            listBox1.TabIndex = 1;
            // 
            // s_gameid
            // 
            s_gameid.Location = new System.Drawing.Point(381, 34);
            s_gameid.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            s_gameid.Name = "s_gameid";
            s_gameid.Size = new System.Drawing.Size(128, 39);
            s_gameid.TabIndex = 2;
            s_gameid.Text = "3500";
            s_gameid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            s_gameid.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(262, 42);
            label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(106, 32);
            label1.TabIndex = 3;
            label1.Text = "Game ID";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(548, 42);
            label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label2.Size = new System.Drawing.Size(134, 32);
            label2.TabIndex = 4;
            label2.Text = "Location ID";
            // 
            // s_tenpoid
            // 
            s_tenpoid.Location = new System.Drawing.Point(696, 34);
            s_tenpoid.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            s_tenpoid.Name = "s_tenpoid";
            s_tenpoid.Size = new System.Drawing.Size(95, 39);
            s_tenpoid.TabIndex = 5;
            s_tenpoid.Text = "77";
            s_tenpoid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            s_tenpoid.TextChanged += s_tenpoid_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(847, 42);
            label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(175, 32);
            label3.TabIndex = 6;
            label3.Text = "Location Name";
            // 
            // s_tenponame
            // 
            s_tenponame.Location = new System.Drawing.Point(1031, 34);
            s_tenponame.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            s_tenponame.Name = "s_tenponame";
            s_tenponame.Size = new System.Drawing.Size(322, 39);
            s_tenponame.TabIndex = 7;
            s_tenponame.Text = "Meditation Garden";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(921, 96);
            label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(98, 32);
            label4.TabIndex = 8;
            label4.Text = "Address";
            label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // s_address
            // 
            s_address.Location = new System.Drawing.Point(1031, 89);
            s_address.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            s_address.Name = "s_address";
            s_address.Size = new System.Drawing.Size(322, 39);
            s_address.TabIndex = 9;
            s_address.Text = "Abbey Road";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(897, 153);
            label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(123, 32);
            label5.TabIndex = 10;
            label5.Text = "Prefecture";
            // 
            // s_prefecture
            // 
            s_prefecture.Location = new System.Drawing.Point(1031, 145);
            s_prefecture.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            s_prefecture.Name = "s_prefecture";
            s_prefecture.Size = new System.Drawing.Size(322, 39);
            s_prefecture.TabIndex = 11;
            s_prefecture.Text = "Tokyo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(100, 96);
            label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(92, 32);
            label6.TabIndex = 12;
            label6.Text = "Version";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(128, 212);
            label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(63, 32);
            label7.TabIndex = 13;
            label7.Text = "Host";
            label7.Click += label7_Click;
            // 
            // s_host
            // 
            s_host.Location = new System.Drawing.Point(202, 204);
            s_host.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            s_host.Name = "s_host";
            s_host.Size = new System.Drawing.Size(1152, 39);
            s_host.TabIndex = 14;
            s_host.Text = "httphost=dev.starwing.jp,tcphost=dev.starwing.jp";
            s_host.TextChanged += s_host_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(113, 153);
            label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(80, 32);
            label8.TabIndex = 15;
            label8.Text = "Image";
            label8.Click += label8_Click;
            // 
            // s_img
            // 
            s_img.Location = new System.Drawing.Point(202, 145);
            s_img.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            s_img.Name = "s_img";
            s_img.Size = new System.Drawing.Size(678, 39);
            s_img.TabIndex = 16;
            s_img.Text = "D:\\system\\DUA\\news\\1450152887.png";
            // 
            // s_version
            // 
            s_version.Location = new System.Drawing.Point(202, 89);
            s_version.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            s_version.Name = "s_version";
            s_version.Size = new System.Drawing.Size(678, 39);
            s_version.TabIndex = 17;
            s_version.Text = "2.83(x64) 2017/11/07";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1733, 1108);
            Controls.Add(s_version);
            Controls.Add(s_img);
            Controls.Add(label8);
            Controls.Add(s_host);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(s_prefecture);
            Controls.Add(label5);
            Controls.Add(s_address);
            Controls.Add(label4);
            Controls.Add(s_tenponame);
            Controls.Add(label3);
            Controls.Add(s_tenpoid);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(s_gameid);
            Controls.Add(listBox1);
            Controls.Add(button1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            MaximizeBox = false;
            Name = "Form1";
            Text = "FakeNesica Service 20230607";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
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

