namespace MazeGenerator
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
            this.generateMaze = new System.Windows.Forms.Button();
            this.mazeTextbox = new System.Windows.Forms.RichTextBox();
            this.widthLabel = new System.Windows.Forms.Label();
            this.widthValue = new System.Windows.Forms.NumericUpDown();
            this.heightValue = new System.Windows.Forms.NumericUpDown();
            this.heightLabel = new System.Windows.Forms.Label();
            this.startingY = new System.Windows.Forms.NumericUpDown();
            this.startingX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.wallValue = new System.Windows.Forms.NumericUpDown();
            this.passageValue = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.exportMaze = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.widthValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wallValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passageValue)).BeginInit();
            this.SuspendLayout();
            // 
            // generateMaze
            // 
            this.generateMaze.Location = new System.Drawing.Point(583, 12);
            this.generateMaze.Name = "generateMaze";
            this.generateMaze.Size = new System.Drawing.Size(317, 46);
            this.generateMaze.TabIndex = 0;
            this.generateMaze.Text = "Generate Maze";
            this.generateMaze.UseVisualStyleBackColor = true;
            this.generateMaze.Click += new System.EventHandler(this.generateMaze_Click);
            // 
            // mazeTextbox
            // 
            this.mazeTextbox.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.mazeTextbox.Location = new System.Drawing.Point(9, 12);
            this.mazeTextbox.Name = "mazeTextbox";
            this.mazeTextbox.Size = new System.Drawing.Size(568, 578);
            this.mazeTextbox.TabIndex = 1;
            this.mazeTextbox.Text = "";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(583, 134);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(35, 13);
            this.widthLabel.TabIndex = 3;
            this.widthLabel.Text = "Width";
            // 
            // widthValue
            // 
            this.widthValue.Location = new System.Drawing.Point(586, 150);
            this.widthValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.widthValue.Name = "widthValue";
            this.widthValue.Size = new System.Drawing.Size(104, 20);
            this.widthValue.TabIndex = 4;
            this.widthValue.Value = new decimal(new int[] {
            41,
            0,
            0,
            0});
            // 
            // heightValue
            // 
            this.heightValue.Location = new System.Drawing.Point(719, 150);
            this.heightValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.heightValue.Name = "heightValue";
            this.heightValue.Size = new System.Drawing.Size(104, 20);
            this.heightValue.TabIndex = 6;
            this.heightValue.Value = new decimal(new int[] {
            41,
            0,
            0,
            0});
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(716, 134);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(38, 13);
            this.heightLabel.TabIndex = 5;
            this.heightLabel.Text = "Height";
            // 
            // startingY
            // 
            this.startingY.Location = new System.Drawing.Point(719, 201);
            this.startingY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.startingY.Name = "startingY";
            this.startingY.Size = new System.Drawing.Size(104, 20);
            this.startingY.TabIndex = 8;
            this.startingY.Value = new decimal(new int[] {
            5522,
            0,
            0,
            0});
            // 
            // startingX
            // 
            this.startingX.Location = new System.Drawing.Point(586, 201);
            this.startingX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.startingX.Name = "startingX";
            this.startingX.Size = new System.Drawing.Size(104, 20);
            this.startingX.TabIndex = 9;
            this.startingX.Value = new decimal(new int[] {
            13761,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(583, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Starting X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(716, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Starting Y";
            // 
            // wallValue
            // 
            this.wallValue.Location = new System.Drawing.Point(586, 249);
            this.wallValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.wallValue.Name = "wallValue";
            this.wallValue.Size = new System.Drawing.Size(104, 20);
            this.wallValue.TabIndex = 12;
            this.wallValue.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // passageValue
            // 
            this.passageValue.Location = new System.Drawing.Point(719, 249);
            this.passageValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.passageValue.Name = "passageValue";
            this.passageValue.Size = new System.Drawing.Size(104, 20);
            this.passageValue.TabIndex = 13;
            this.passageValue.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(583, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Wall";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(716, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Passage";
            // 
            // exportMaze
            // 
            this.exportMaze.Enabled = false;
            this.exportMaze.Location = new System.Drawing.Point(583, 64);
            this.exportMaze.Name = "exportMaze";
            this.exportMaze.Size = new System.Drawing.Size(317, 48);
            this.exportMaze.TabIndex = 16;
            this.exportMaze.Text = "Export Maze";
            this.exportMaze.UseVisualStyleBackColor = true;
            this.exportMaze.Click += new System.EventHandler(this.exportMaze_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 602);
            this.Controls.Add(this.exportMaze);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.passageValue);
            this.Controls.Add(this.wallValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startingX);
            this.Controls.Add(this.startingY);
            this.Controls.Add(this.heightValue);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.widthValue);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.mazeTextbox);
            this.Controls.Add(this.generateMaze);
            this.Name = "Form1";
            this.Text = "Maze Generator";
            ((System.ComponentModel.ISupportInitialize)(this.widthValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wallValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passageValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateMaze;
        private System.Windows.Forms.RichTextBox mazeTextbox;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.NumericUpDown widthValue;
        private System.Windows.Forms.NumericUpDown heightValue;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.NumericUpDown startingY;
        private System.Windows.Forms.NumericUpDown startingX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown wallValue;
        private System.Windows.Forms.NumericUpDown passageValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button exportMaze;
    }
}

