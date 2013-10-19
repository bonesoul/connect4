namespace conn4_client
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_main = new System.Windows.Forms.TabPage();
            this.grp_AI_net = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.cmd_connect = new System.Windows.Forms.Button();
            this.txt_server = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_AI_net_color = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.grp_AI_2 = new System.Windows.Forms.GroupBox();
            this.lbl_AI2_color = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.num_AI2_look_ahead = new System.Windows.Forms.NumericUpDown();
            this.grp_AI_1 = new System.Windows.Forms.GroupBox();
            this.lbl_AI1_color = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.num_AI1_look_ahead = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_status = new System.Windows.Forms.Label();
            this.cmd_start = new System.Windows.Forms.Button();
            this.progress_bar = new System.Windows.Forms.ProgressBar();
            this.pic_seat2_turn = new System.Windows.Forms.PictureBox();
            this.pic_seat1_turn = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_seat2 = new System.Windows.Forms.Label();
            this.lbl_seat1 = new System.Windows.Forms.Label();
            this.lbl_human = new System.Windows.Forms.Label();
            this.lbl_AI = new System.Windows.Forms.Label();
            this.lbl_AI_net = new System.Windows.Forms.Label();
            this.img_list = new System.Windows.Forms.ImageList(this.components);
            this.pic_board = new System.Windows.Forms.PictureBox();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tab_main.SuspendLayout();
            this.grp_AI_net.SuspendLayout();
            this.grp_AI_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_AI2_look_ahead)).BeginInit();
            this.grp_AI_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_AI1_look_ahead)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_seat2_turn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_seat1_turn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_board)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab_main);
            this.tabControl1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.Location = new System.Drawing.Point(738, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(284, 568);
            this.tabControl1.TabIndex = 1;
            // 
            // tab_main
            // 
            this.tab_main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tab_main.Controls.Add(this.grp_AI_net);
            this.tab_main.Controls.Add(this.grp_AI_2);
            this.tab_main.Controls.Add(this.grp_AI_1);
            this.tab_main.Controls.Add(this.groupBox1);
            this.tab_main.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tab_main.Location = new System.Drawing.Point(4, 22);
            this.tab_main.Name = "tab_main";
            this.tab_main.Padding = new System.Windows.Forms.Padding(3);
            this.tab_main.Size = new System.Drawing.Size(276, 542);
            this.tab_main.TabIndex = 0;
            this.tab_main.Text = "Oyun";
            this.tab_main.UseVisualStyleBackColor = true;
            // 
            // grp_AI_net
            // 
            this.grp_AI_net.Controls.Add(this.label1);
            this.grp_AI_net.Controls.Add(this.txt_port);
            this.grp_AI_net.Controls.Add(this.cmd_connect);
            this.grp_AI_net.Controls.Add(this.txt_server);
            this.grp_AI_net.Controls.Add(this.label5);
            this.grp_AI_net.Controls.Add(this.lbl_AI_net_color);
            this.grp_AI_net.Controls.Add(this.label9);
            this.grp_AI_net.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grp_AI_net.Location = new System.Drawing.Point(16, 416);
            this.grp_AI_net.Name = "grp_AI_net";
            this.grp_AI_net.Size = new System.Drawing.Size(248, 96);
            this.grp_AI_net.TabIndex = 10;
            this.grp_AI_net.TabStop = false;
            this.grp_AI_net.Text = "Yapay Zeka (Að Üzerinden)";
            this.grp_AI_net.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(8, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Port:";
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(64, 64);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(112, 23);
            this.txt_port.TabIndex = 14;
            this.txt_port.Text = "4444";
            // 
            // cmd_connect
            // 
            this.cmd_connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_connect.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmd_connect.Location = new System.Drawing.Point(184, 64);
            this.cmd_connect.Name = "cmd_connect";
            this.cmd_connect.Size = new System.Drawing.Size(56, 24);
            this.cmd_connect.TabIndex = 13;
            this.cmd_connect.Text = "Baðlan";
            this.cmd_connect.UseVisualStyleBackColor = true;
            this.cmd_connect.Click += new System.EventHandler(this.cmd_connect_Click);
            // 
            // txt_server
            // 
            this.txt_server.Location = new System.Drawing.Point(64, 40);
            this.txt_server.Name = "txt_server";
            this.txt_server.Size = new System.Drawing.Size(176, 23);
            this.txt_server.TabIndex = 12;
            this.txt_server.Text = "127.0.0.1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(8, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Sunucu:";
            // 
            // lbl_AI_net_color
            // 
            this.lbl_AI_net_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_AI_net_color.Location = new System.Drawing.Point(64, 16);
            this.lbl_AI_net_color.Name = "lbl_AI_net_color";
            this.lbl_AI_net_color.Size = new System.Drawing.Size(48, 21);
            this.lbl_AI_net_color.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(8, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Renk:";
            // 
            // grp_AI_2
            // 
            this.grp_AI_2.Controls.Add(this.lbl_AI2_color);
            this.grp_AI_2.Controls.Add(this.label6);
            this.grp_AI_2.Controls.Add(this.label8);
            this.grp_AI_2.Controls.Add(this.num_AI2_look_ahead);
            this.grp_AI_2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grp_AI_2.Location = new System.Drawing.Point(16, 352);
            this.grp_AI_2.Name = "grp_AI_2";
            this.grp_AI_2.Size = new System.Drawing.Size(48, 40);
            this.grp_AI_2.TabIndex = 9;
            this.grp_AI_2.TabStop = false;
            this.grp_AI_2.Text = "Yapay Zeka";
            this.grp_AI_2.Visible = false;
            // 
            // lbl_AI2_color
            // 
            this.lbl_AI2_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_AI2_color.Location = new System.Drawing.Point(112, 24);
            this.lbl_AI2_color.Name = "lbl_AI2_color";
            this.lbl_AI2_color.Size = new System.Drawing.Size(48, 21);
            this.lbl_AI2_color.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(8, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Renk:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(8, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Arama Derinliði:";
            // 
            // num_AI2_look_ahead
            // 
            this.num_AI2_look_ahead.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.num_AI2_look_ahead.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_AI2_look_ahead.Location = new System.Drawing.Point(112, 48);
            this.num_AI2_look_ahead.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.num_AI2_look_ahead.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_AI2_look_ahead.Name = "num_AI2_look_ahead";
            this.num_AI2_look_ahead.Size = new System.Drawing.Size(96, 21);
            this.num_AI2_look_ahead.TabIndex = 7;
            this.num_AI2_look_ahead.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.num_AI2_look_ahead.ValueChanged += new System.EventHandler(this.num_AI2_look_ahead_ValueChanged);
            // 
            // grp_AI_1
            // 
            this.grp_AI_1.Controls.Add(this.lbl_AI1_color);
            this.grp_AI_1.Controls.Add(this.label4);
            this.grp_AI_1.Controls.Add(this.label3);
            this.grp_AI_1.Controls.Add(this.num_AI1_look_ahead);
            this.grp_AI_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grp_AI_1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grp_AI_1.Location = new System.Drawing.Point(128, 352);
            this.grp_AI_1.Name = "grp_AI_1";
            this.grp_AI_1.Size = new System.Drawing.Size(48, 40);
            this.grp_AI_1.TabIndex = 8;
            this.grp_AI_1.TabStop = false;
            this.grp_AI_1.Text = "Yapay Zeka";
            this.grp_AI_1.Visible = false;
            // 
            // lbl_AI1_color
            // 
            this.lbl_AI1_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_AI1_color.Location = new System.Drawing.Point(112, 24);
            this.lbl_AI1_color.Name = "lbl_AI1_color";
            this.lbl_AI1_color.Size = new System.Drawing.Size(48, 21);
            this.lbl_AI1_color.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(8, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Renk:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Arama Derinliði:";
            // 
            // num_AI1_look_ahead
            // 
            this.num_AI1_look_ahead.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.num_AI1_look_ahead.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_AI1_look_ahead.Location = new System.Drawing.Point(112, 48);
            this.num_AI1_look_ahead.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.num_AI1_look_ahead.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_AI1_look_ahead.Name = "num_AI1_look_ahead";
            this.num_AI1_look_ahead.Size = new System.Drawing.Size(96, 21);
            this.num_AI1_look_ahead.TabIndex = 7;
            this.num_AI1_look_ahead.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.num_AI1_look_ahead.ValueChanged += new System.EventHandler(this.num_AI1_look_ahead_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_status);
            this.groupBox1.Controls.Add(this.cmd_start);
            this.groupBox1.Controls.Add(this.progress_bar);
            this.groupBox1.Controls.Add(this.pic_seat2_turn);
            this.groupBox1.Controls.Add(this.pic_seat1_turn);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lbl_seat2);
            this.groupBox1.Controls.Add(this.lbl_seat1);
            this.groupBox1.Controls.Add(this.lbl_human);
            this.groupBox1.Controls.Add(this.lbl_AI);
            this.groupBox1.Controls.Add(this.lbl_AI_net);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 328);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Oyun Masasý";
            // 
            // lbl_status
            // 
            this.lbl_status.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_status.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_status.Location = new System.Drawing.Point(8, 176);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(232, 104);
            this.lbl_status.TabIndex = 14;
            this.lbl_status.Text = "Oyunun baþlamasý bekleniyor...";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmd_start
            // 
            this.cmd_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_start.Location = new System.Drawing.Point(144, 280);
            this.cmd_start.Name = "cmd_start";
            this.cmd_start.Size = new System.Drawing.Size(96, 40);
            this.cmd_start.TabIndex = 11;
            this.cmd_start.Text = "Yeni Oyun";
            this.cmd_start.UseVisualStyleBackColor = true;
            this.cmd_start.Click += new System.EventHandler(this.cmd_start_Click);
            // 
            // progress_bar
            // 
            this.progress_bar.Location = new System.Drawing.Point(8, 160);
            this.progress_bar.Maximum = 7;
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.Size = new System.Drawing.Size(232, 15);
            this.progress_bar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress_bar.TabIndex = 13;
            // 
            // pic_seat2_turn
            // 
            this.pic_seat2_turn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pic_seat2_turn.Image = global::conn4_client.Properties.Resources.arrow;
            this.pic_seat2_turn.Location = new System.Drawing.Point(184, 32);
            this.pic_seat2_turn.Name = "pic_seat2_turn";
            this.pic_seat2_turn.Size = new System.Drawing.Size(24, 37);
            this.pic_seat2_turn.TabIndex = 7;
            this.pic_seat2_turn.TabStop = false;
            this.pic_seat2_turn.Visible = false;
            // 
            // pic_seat1_turn
            // 
            this.pic_seat1_turn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pic_seat1_turn.Image = global::conn4_client.Properties.Resources.arrow;
            this.pic_seat1_turn.Location = new System.Drawing.Point(40, 32);
            this.pic_seat1_turn.Name = "pic_seat1_turn";
            this.pic_seat1_turn.Size = new System.Drawing.Size(24, 37);
            this.pic_seat1_turn.TabIndex = 6;
            this.pic_seat1_turn.TabStop = false;
            this.pic_seat1_turn.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(112, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 29);
            this.label7.TabIndex = 5;
            this.label7.Text = "-";
            // 
            // lbl_seat2
            // 
            this.lbl_seat2.AllowDrop = true;
            this.lbl_seat2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbl_seat2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_seat2.Location = new System.Drawing.Point(144, 24);
            this.lbl_seat2.Name = "lbl_seat2";
            this.lbl_seat2.Size = new System.Drawing.Size(96, 120);
            this.lbl_seat2.TabIndex = 4;
            this.lbl_seat2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lbl_seat2.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbl_seat2_DragDrop);
            this.lbl_seat2.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbl_seat2_DragEnter);
            // 
            // lbl_seat1
            // 
            this.lbl_seat1.AllowDrop = true;
            this.lbl_seat1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbl_seat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_seat1.Location = new System.Drawing.Point(8, 24);
            this.lbl_seat1.Name = "lbl_seat1";
            this.lbl_seat1.Size = new System.Drawing.Size(96, 120);
            this.lbl_seat1.TabIndex = 3;
            this.lbl_seat1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lbl_seat1.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbl_seat1_DragDrop);
            this.lbl_seat1.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbl_seat1_DragEnter);
            // 
            // lbl_human
            // 
            this.lbl_human.BackColor = System.Drawing.Color.White;
            this.lbl_human.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_human.Image = global::conn4_client.Properties.Resources.people;
            this.lbl_human.Location = new System.Drawing.Point(88, 280);
            this.lbl_human.Name = "lbl_human";
            this.lbl_human.Size = new System.Drawing.Size(40, 40);
            this.lbl_human.TabIndex = 2;
            this.lbl_human.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_human_MouseDown);
            // 
            // lbl_AI
            // 
            this.lbl_AI.BackColor = System.Drawing.Color.White;
            this.lbl_AI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_AI.Image = global::conn4_client.Properties.Resources.ai;
            this.lbl_AI.Location = new System.Drawing.Point(8, 280);
            this.lbl_AI.Name = "lbl_AI";
            this.lbl_AI.Size = new System.Drawing.Size(40, 40);
            this.lbl_AI.TabIndex = 1;
            this.lbl_AI.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_AI_MouseDown);
            // 
            // lbl_AI_net
            // 
            this.lbl_AI_net.BackColor = System.Drawing.Color.White;
            this.lbl_AI_net.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_AI_net.Image = global::conn4_client.Properties.Resources.ai_net;
            this.lbl_AI_net.Location = new System.Drawing.Point(48, 280);
            this.lbl_AI_net.Name = "lbl_AI_net";
            this.lbl_AI_net.Size = new System.Drawing.Size(40, 40);
            this.lbl_AI_net.TabIndex = 0;
            this.lbl_AI_net.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_AI_net_MouseDown);
            // 
            // img_list
            // 
            this.img_list.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_list.ImageStream")));
            this.img_list.TransparentColor = System.Drawing.Color.Transparent;
            this.img_list.Images.SetKeyName(0, "ai.gif");
            this.img_list.Images.SetKeyName(1, "ai_net.gif");
            this.img_list.Images.SetKeyName(2, "people.gif");
            // 
            // pic_board
            // 
            this.pic_board.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_board.BackColor = System.Drawing.Color.White;
            this.pic_board.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_board.Location = new System.Drawing.Point(0, 0);
            this.pic_board.Name = "pic_board";
            this.pic_board.Size = new System.Drawing.Size(738, 569);
            this.pic_board.TabIndex = 0;
            this.pic_board.TabStop = false;
            this.pic_board.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_board_MouseDown);
            this.pic_board.Paint += new System.Windows.Forms.PaintEventHandler(this.pic_board_Paint);
            // 
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            this.bw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 570);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pic_board);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Connect 4 [ Hüseyin Uslu ]";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_main.ResumeLayout(false);
            this.grp_AI_net.ResumeLayout(false);
            this.grp_AI_net.PerformLayout();
            this.grp_AI_2.ResumeLayout(false);
            this.grp_AI_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_AI2_look_ahead)).EndInit();
            this.grp_AI_1.ResumeLayout(false);
            this.grp_AI_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_AI1_look_ahead)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_seat2_turn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_seat1_turn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_board)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_board;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ImageList img_list;
        private System.Windows.Forms.TabPage tab_main;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_seat2;
        private System.Windows.Forms.Label lbl_seat1;
        private System.Windows.Forms.Label lbl_human;
        private System.Windows.Forms.Label lbl_AI;
        private System.Windows.Forms.Label lbl_AI_net;
        private System.Windows.Forms.GroupBox grp_AI_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown num_AI1_look_ahead;
        private System.Windows.Forms.Label lbl_AI1_color;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grp_AI_2;
        private System.Windows.Forms.Label lbl_AI2_color;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown num_AI2_look_ahead;
        private System.Windows.Forms.GroupBox grp_AI_net;
        private System.Windows.Forms.Label lbl_AI_net_color;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmd_connect;
        private System.Windows.Forms.TextBox txt_server;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmd_start;
        private System.Windows.Forms.PictureBox pic_seat1_turn;
        private System.Windows.Forms.PictureBox pic_seat2_turn;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.ProgressBar progress_bar;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_port;
    }
}

