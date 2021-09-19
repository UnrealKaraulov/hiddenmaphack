namespace UnkownHiddenMaphackLoader
{
    partial class Loader
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loader));
            this.MainMap = new System.Windows.Forms.CheckBox();
            this.TradeEnabled = new System.Windows.Forms.CheckBox();
            this.StartMapHack = new System.Windows.Forms.Button();
            this.WarcraftFound = new System.Windows.Forms.Label();
            this.GameDllFound = new System.Windows.Forms.Label();
            this.MaphackDllInject = new System.Windows.Forms.Label();
            this.IngameFound = new System.Windows.Forms.Label();
            this.ErrorID = new System.Windows.Forms.Label();
            this.CamHack = new System.Windows.Forms.CheckBox();
            this.CamDist = new System.Windows.Forms.TextBox();
            this.MiniMap = new System.Windows.Forms.CheckBox();
            this.PanelMinimap = new System.Windows.Forms.Panel();
            this.InternalMiniMap = new System.Windows.Forms.CheckBox();
            this.SPTIMER = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Mhtimer1 = new System.Windows.Forms.Timer(this.components);
            this.ChangeTopMost = new System.Windows.Forms.CheckBox();
            this.ColoredHeroes = new System.Windows.Forms.CheckBox();
            this.DrawOnlyEnemy = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.OptimizeSpeed = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GetCPUUSAGE = new System.Windows.Forms.Timer(this.components);
            this.CPUUSAGE = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMap
            // 
            this.MainMap.AutoSize = true;
            this.MainMap.BackColor = System.Drawing.Color.Transparent;
            this.MainMap.Checked = true;
            this.MainMap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MainMap.Location = new System.Drawing.Point(18, 12);
            this.MainMap.Name = "MainMap";
            this.MainMap.Size = new System.Drawing.Size(73, 17);
            this.MainMap.TabIndex = 0;
            this.MainMap.Text = "Маin Мар";
            this.MainMap.UseVisualStyleBackColor = false;
            // 
            // TradeEnabled
            // 
            this.TradeEnabled.AutoSize = true;
            this.TradeEnabled.BackColor = System.Drawing.Color.Transparent;
            this.TradeEnabled.Enabled = false;
            this.TradeEnabled.Location = new System.Drawing.Point(250, 12);
            this.TradeEnabled.Name = "TradeEnabled";
            this.TradeEnabled.Size = new System.Drawing.Size(83, 17);
            this.TradeEnabled.TabIndex = 0;
            this.TradeEnabled.Text = "Тrаdе Насk";
            this.TradeEnabled.UseVisualStyleBackColor = false;
            this.TradeEnabled.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // StartMapHack
            // 
            this.StartMapHack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartMapHack.Location = new System.Drawing.Point(282, 241);
            this.StartMapHack.Name = "StartMapHack";
            this.StartMapHack.Size = new System.Drawing.Size(75, 23);
            this.StartMapHack.TabIndex = 2;
            this.StartMapHack.Text = "Включить";
            this.StartMapHack.UseVisualStyleBackColor = true;
            this.StartMapHack.Click += new System.EventHandler(this.StartMapHack_Click);
            // 
            // WarcraftFound
            // 
            this.WarcraftFound.AutoSize = true;
            this.WarcraftFound.BackColor = System.Drawing.Color.Transparent;
            this.WarcraftFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WarcraftFound.ForeColor = System.Drawing.Color.DarkRed;
            this.WarcraftFound.Location = new System.Drawing.Point(12, 12);
            this.WarcraftFound.Name = "WarcraftFound";
            this.WarcraftFound.Size = new System.Drawing.Size(72, 13);
            this.WarcraftFound.TabIndex = 3;
            this.WarcraftFound.Text = "Wаrcrаft III";
            // 
            // GameDllFound
            // 
            this.GameDllFound.AutoSize = true;
            this.GameDllFound.BackColor = System.Drawing.Color.Transparent;
            this.GameDllFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GameDllFound.ForeColor = System.Drawing.Color.DarkRed;
            this.GameDllFound.Location = new System.Drawing.Point(14, 38);
            this.GameDllFound.Name = "GameDllFound";
            this.GameDllFound.Size = new System.Drawing.Size(66, 13);
            this.GameDllFound.TabIndex = 3;
            this.GameDllFound.Text = "Gаmе DLL";
            // 
            // MaphackDllInject
            // 
            this.MaphackDllInject.AutoSize = true;
            this.MaphackDllInject.BackColor = System.Drawing.Color.Transparent;
            this.MaphackDllInject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaphackDllInject.ForeColor = System.Drawing.Color.DarkRed;
            this.MaphackDllInject.Location = new System.Drawing.Point(6, 62);
            this.MaphackDllInject.Name = "MaphackDllInject";
            this.MaphackDllInject.Size = new System.Drawing.Size(84, 13);
            this.MaphackDllInject.TabIndex = 3;
            this.MaphackDllInject.Text = "МарHасkDLL";
            // 
            // IngameFound
            // 
            this.IngameFound.AutoSize = true;
            this.IngameFound.BackColor = System.Drawing.Color.Transparent;
            this.IngameFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IngameFound.ForeColor = System.Drawing.Color.DarkRed;
            this.IngameFound.Location = new System.Drawing.Point(21, 87);
            this.IngameFound.Name = "IngameFound";
            this.IngameFound.Size = new System.Drawing.Size(50, 13);
            this.IngameFound.TabIndex = 3;
            this.IngameFound.Text = "InGаmе";
            // 
            // ErrorID
            // 
            this.ErrorID.AutoSize = true;
            this.ErrorID.BackColor = System.Drawing.Color.Transparent;
            this.ErrorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ErrorID.ForeColor = System.Drawing.Color.Red;
            this.ErrorID.Location = new System.Drawing.Point(349, 206);
            this.ErrorID.Name = "ErrorID";
            this.ErrorID.Size = new System.Drawing.Size(17, 17);
            this.ErrorID.TabIndex = 4;
            this.ErrorID.Text = "0";
            // 
            // CamHack
            // 
            this.CamHack.AutoSize = true;
            this.CamHack.BackColor = System.Drawing.Color.Transparent;
            this.CamHack.Enabled = false;
            this.CamHack.Location = new System.Drawing.Point(18, 35);
            this.CamHack.Name = "CamHack";
            this.CamHack.Size = new System.Drawing.Size(62, 17);
            this.CamHack.TabIndex = 0;
            this.CamHack.Text = "Camera";
            this.CamHack.UseVisualStyleBackColor = false;
            this.CamHack.CheckedChanged += new System.EventHandler(this.CamHack_CheckedChanged);
            // 
            // CamDist
            // 
            this.CamDist.Enabled = false;
            this.CamDist.Location = new System.Drawing.Point(89, 32);
            this.CamDist.Name = "CamDist";
            this.CamDist.Size = new System.Drawing.Size(73, 20);
            this.CamDist.TabIndex = 1;
            this.CamDist.Text = "1600";
            this.CamDist.Visible = false;
            this.CamDist.TextChanged += new System.EventHandler(this.CamDist_TextChanged);
            // 
            // MiniMap
            // 
            this.MiniMap.AutoSize = true;
            this.MiniMap.BackColor = System.Drawing.Color.Transparent;
            this.MiniMap.Checked = true;
            this.MiniMap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MiniMap.Location = new System.Drawing.Point(97, 12);
            this.MiniMap.Name = "MiniMap";
            this.MiniMap.Size = new System.Drawing.Size(65, 17);
            this.MiniMap.TabIndex = 0;
            this.MiniMap.Text = "Мinimар";
            this.MiniMap.UseVisualStyleBackColor = false;
            this.MiniMap.CheckedChanged += new System.EventHandler(this.MiniMap_CheckedChanged);
            // 
            // PanelMinimap
            // 
            this.PanelMinimap.BackColor = System.Drawing.Color.DimGray;
            this.PanelMinimap.BackgroundImage = global::UnkownHiddenMaphackLoader.Properties.Resources.war3map;
            this.PanelMinimap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelMinimap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelMinimap.Location = new System.Drawing.Point(17, 75);
            this.PanelMinimap.Name = "PanelMinimap";
            this.PanelMinimap.Size = new System.Drawing.Size(256, 256);
            this.PanelMinimap.TabIndex = 5;
            // 
            // InternalMiniMap
            // 
            this.InternalMiniMap.AutoSize = true;
            this.InternalMiniMap.BackColor = System.Drawing.Color.Transparent;
            this.InternalMiniMap.Checked = true;
            this.InternalMiniMap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.InternalMiniMap.Location = new System.Drawing.Point(168, 12);
            this.InternalMiniMap.Name = "InternalMiniMap";
            this.InternalMiniMap.Size = new System.Drawing.Size(80, 17);
            this.InternalMiniMap.TabIndex = 0;
            this.InternalMiniMap.Text = "Мinimар v2";
            this.InternalMiniMap.UseVisualStyleBackColor = false;
            this.InternalMiniMap.CheckedChanged += new System.EventHandler(this.InternalMiniMap_CheckedChanged);
            // 
            // SPTIMER
            // 
            this.SPTIMER.Enabled = true;
            this.SPTIMER.Interval = 33333;
            this.SPTIMER.Tick += new System.EventHandler(this.SPTIMER_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(284, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Lаst errоr:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.IngameFound);
            this.panel1.Controls.Add(this.MaphackDllInject);
            this.panel1.Controls.Add(this.GameDllFound);
            this.panel1.Controls.Add(this.WarcraftFound);
            this.panel1.Location = new System.Drawing.Point(281, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(93, 116);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(279, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Wаrcrаft stаtus:";
            // 
            // Mhtimer1
            // 
            this.Mhtimer1.Enabled = true;
            this.Mhtimer1.Interval = 250;
            this.Mhtimer1.Tick += new System.EventHandler(this.Mhtimer1_Tick);
            // 
            // ChangeTopMost
            // 
            this.ChangeTopMost.AutoSize = true;
            this.ChangeTopMost.BackColor = System.Drawing.Color.Transparent;
            this.ChangeTopMost.Checked = true;
            this.ChangeTopMost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChangeTopMost.Location = new System.Drawing.Point(287, 314);
            this.ChangeTopMost.Name = "ChangeTopMost";
            this.ChangeTopMost.Size = new System.Drawing.Size(70, 17);
            this.ChangeTopMost.TabIndex = 0;
            this.ChangeTopMost.Text = "ON TOP ";
            this.ChangeTopMost.UseVisualStyleBackColor = false;
            this.ChangeTopMost.CheckedChanged += new System.EventHandler(this.TopChange);
            // 
            // ColoredHeroes
            // 
            this.ColoredHeroes.AutoSize = true;
            this.ColoredHeroes.BackColor = System.Drawing.Color.Transparent;
            this.ColoredHeroes.Checked = true;
            this.ColoredHeroes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ColoredHeroes.Location = new System.Drawing.Point(18, 58);
            this.ColoredHeroes.Name = "ColoredHeroes";
            this.ColoredHeroes.Size = new System.Drawing.Size(85, 17);
            this.ColoredHeroes.TabIndex = 0;
            this.ColoredHeroes.Text = "Color heroes";
            this.ColoredHeroes.UseVisualStyleBackColor = false;
            this.ColoredHeroes.CheckedChanged += new System.EventHandler(this.TopChange);
            // 
            // DrawOnlyEnemy
            // 
            this.DrawOnlyEnemy.AutoSize = true;
            this.DrawOnlyEnemy.BackColor = System.Drawing.Color.Transparent;
            this.DrawOnlyEnemy.Checked = true;
            this.DrawOnlyEnemy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DrawOnlyEnemy.Location = new System.Drawing.Point(109, 58);
            this.DrawOnlyEnemy.Name = "DrawOnlyEnemy";
            this.DrawOnlyEnemy.Size = new System.Drawing.Size(82, 17);
            this.DrawOnlyEnemy.TabIndex = 0;
            this.DrawOnlyEnemy.Text = "Only Enemy";
            this.DrawOnlyEnemy.UseVisualStyleBackColor = false;
            this.DrawOnlyEnemy.CheckedChanged += new System.EventHandler(this.TopChange);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Minimize";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OptimizeSpeed
            // 
            this.OptimizeSpeed.AutoSize = true;
            this.OptimizeSpeed.Checked = true;
            this.OptimizeSpeed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OptimizeSpeed.Location = new System.Drawing.Point(263, 35);
            this.OptimizeSpeed.Name = "OptimizeSpeed";
            this.OptimizeSpeed.Size = new System.Drawing.Size(69, 17);
            this.OptimizeSpeed.TabIndex = 10;
            this.OptimizeSpeed.Text = "Optimizer";
            this.OptimizeSpeed.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(144, 337);
            this.trackBar1.Maximum = 500;
            this.trackBar1.Minimum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.SmallChange = 10;
            this.trackBar1.TabIndex = 11;
            this.trackBar1.TickFrequency = 50;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Value = 400;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(15, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Update speed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(111, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "MIN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(247, 344);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "MAX";
            // 
            // GetCPUUSAGE
            // 
            this.GetCPUUSAGE.Enabled = true;
            this.GetCPUUSAGE.Interval = 1000;
            this.GetCPUUSAGE.Tick += new System.EventHandler(this.GetCPUUSAGE_Tick);
            // 
            // CPUUSAGE
            // 
            this.CPUUSAGE.AutoSize = true;
            this.CPUUSAGE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CPUUSAGE.Location = new System.Drawing.Point(306, 343);
            this.CPUUSAGE.Name = "CPUUSAGE";
            this.CPUUSAGE.Size = new System.Drawing.Size(36, 13);
            this.CPUUSAGE.TabIndex = 12;
            this.CPUUSAGE.Text = "CPU:";
            // 
            // Loader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 366);
            this.Controls.Add(this.CPUUSAGE);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.OptimizeSpeed);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PanelMinimap);
            this.Controls.Add(this.ErrorID);
            this.Controls.Add(this.StartMapHack);
            this.Controls.Add(this.CamDist);
            this.Controls.Add(this.TradeEnabled);
            this.Controls.Add(this.DrawOnlyEnemy);
            this.Controls.Add(this.ColoredHeroes);
            this.Controls.Add(this.ChangeTopMost);
            this.Controls.Add(this.CamHack);
            this.Controls.Add(this.InternalMiniMap);
            this.Controls.Add(this.MiniMap);
            this.Controls.Add(this.MainMap);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Loader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Loader_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox MainMap;
        private System.Windows.Forms.CheckBox TradeEnabled;
        private System.Windows.Forms.Button StartMapHack;
        private System.Windows.Forms.Label WarcraftFound;
        private System.Windows.Forms.Label GameDllFound;
        private System.Windows.Forms.Label MaphackDllInject;
        private System.Windows.Forms.Label IngameFound;
        private System.Windows.Forms.Label ErrorID;
        private System.Windows.Forms.CheckBox CamHack;
        private System.Windows.Forms.TextBox CamDist;
        private System.Windows.Forms.CheckBox MiniMap;
        private System.Windows.Forms.Panel PanelMinimap;
        private System.Windows.Forms.CheckBox InternalMiniMap;
        private System.Windows.Forms.Timer SPTIMER;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer Mhtimer1;
        private System.Windows.Forms.CheckBox ChangeTopMost;
        private System.Windows.Forms.CheckBox ColoredHeroes;
        private System.Windows.Forms.CheckBox DrawOnlyEnemy;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox OptimizeSpeed;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer GetCPUUSAGE;
        private System.Windows.Forms.Label CPUUSAGE;
    }
}

