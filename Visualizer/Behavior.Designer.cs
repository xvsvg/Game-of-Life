namespace Visualizer
{
    partial class GameForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PauseFrameButton = new System.Windows.Forms.Button();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.Zoom = new System.Windows.Forms.NumericUpDown();
            this.Density = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Field = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Zoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Density)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Field)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.PauseFrameButton);
            this.splitContainer1.Panel1.Controls.Add(this.GenerateButton);
            this.splitContainer1.Panel1.Controls.Add(this.Zoom);
            this.splitContainer1.Panel1.Controls.Add(this.Density);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Field);
            this.splitContainer1.Size = new System.Drawing.Size(1589, 748);
            this.splitContainer1.SplitterDistance = 314;
            this.splitContainer1.TabIndex = 0;
            // 
            // PauseFrameButton
            // 
            this.PauseFrameButton.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PauseFrameButton.Location = new System.Drawing.Point(28, 253);
            this.PauseFrameButton.Name = "PauseFrameButton";
            this.PauseFrameButton.Size = new System.Drawing.Size(138, 31);
            this.PauseFrameButton.TabIndex = 6;
            this.PauseFrameButton.Text = "pause frame";
            this.PauseFrameButton.UseVisualStyleBackColor = true;
            this.PauseFrameButton.Click += new System.EventHandler(this.PauseGameButton);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenerateButton.Location = new System.Drawing.Point(28, 203);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(138, 33);
            this.GenerateButton.TabIndex = 5;
            this.GenerateButton.Text = "generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.StartGameButton);
            // 
            // Zoom
            // 
            this.Zoom.Location = new System.Drawing.Point(28, 63);
            this.Zoom.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.Zoom.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Zoom.Name = "Zoom";
            this.Zoom.Size = new System.Drawing.Size(120, 20);
            this.Zoom.TabIndex = 4;
            this.Zoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Zoom.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Density
            // 
            this.Density.Location = new System.Drawing.Point(28, 149);
            this.Density.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Density.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Density.Name = "Density";
            this.Density.Size = new System.Drawing.Size(120, 20);
            this.Density.TabIndex = 3;
            this.Density.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Density.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.Density.ValueChanged += new System.EventHandler(this.Density_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(24, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Population density";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zoom";
            // 
            // Field
            // 
            this.Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Field.Location = new System.Drawing.Point(0, 0);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(1267, 744);
            this.Field.TabIndex = 0;
            this.Field.TabStop = false;
            this.Field.MouseMove += new System.Windows.Forms.MouseEventHandler(this.InteractByMouse);
            // 
            // Timer
            // 
            this.Timer.Interval = 40;
            this.Timer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1589, 748);
            this.Controls.Add(this.splitContainer1);
            this.Name = "GameForm";
            this.Text = "Game of Life";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Zoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Density)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Field)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.NumericUpDown Density;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Field;
        private System.Windows.Forms.NumericUpDown Zoom;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Button PauseFrameButton;
        private System.Windows.Forms.Timer Timer;
    }
}

