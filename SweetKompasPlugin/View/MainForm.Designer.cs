﻿namespace SweetKompasPlugin
{
    partial class MainForm
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
            this.BuildButton = new System.Windows.Forms.Button();
            this.CandyCountTextBox = new System.Windows.Forms.TextBox();
            this.CandyCountLabel = new System.Windows.Forms.Label();
            this.CandyLengthLabel = new System.Windows.Forms.Label();
            this.CandyLengthTextBox = new System.Windows.Forms.TextBox();
            this.CandyWidthLabel = new System.Windows.Forms.Label();
            this.CandyWidthTextBox = new System.Windows.Forms.TextBox();
            this.CandyHeightLabel = new System.Windows.Forms.Label();
            this.CandyHeightTextBox = new System.Windows.Forms.TextBox();
            this.FormDepthByLengthLabel = new System.Windows.Forms.Label();
            this.FormDepthByLengthTextBox = new System.Windows.Forms.TextBox();
            this.FormDepthByWidthLabel = new System.Windows.Forms.Label();
            this.FormDepthByWidthTextBox = new System.Windows.Forms.TextBox();
            this.FormDepthByHeightLabel = new System.Windows.Forms.Label();
            this.FormDepthByHeightTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(110, 220);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(75, 23);
            this.BuildButton.TabIndex = 0;
            this.BuildButton.Text = "Построить";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // CandyCountTextBox
            // 
            this.CandyCountTextBox.Location = new System.Drawing.Point(197, 10);
            this.CandyCountTextBox.Name = "CandyCountTextBox";
            this.CandyCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.CandyCountTextBox.TabIndex = 1;
            this.CandyCountTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.CandyCountTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // CandyCountLabel
            // 
            this.CandyCountLabel.AutoSize = true;
            this.CandyCountLabel.Location = new System.Drawing.Point(13, 13);
            this.CandyCountLabel.Name = "CandyCountLabel";
            this.CandyCountLabel.Size = new System.Drawing.Size(128, 13);
            this.CandyCountLabel.TabIndex = 2;
            this.CandyCountLabel.Text = "Количество конфет, мм";
            // 
            // CandyLengthLabel
            // 
            this.CandyLengthLabel.AutoSize = true;
            this.CandyLengthLabel.Location = new System.Drawing.Point(13, 43);
            this.CandyLengthLabel.Name = "CandyLengthLabel";
            this.CandyLengthLabel.Size = new System.Drawing.Size(110, 13);
            this.CandyLengthLabel.TabIndex = 3;
            this.CandyLengthLabel.Text = "Длина конфеты, мм";
            // 
            // CandyLengthTextBox
            // 
            this.CandyLengthTextBox.Location = new System.Drawing.Point(197, 40);
            this.CandyLengthTextBox.Name = "CandyLengthTextBox";
            this.CandyLengthTextBox.Size = new System.Drawing.Size(100, 20);
            this.CandyLengthTextBox.TabIndex = 4;
            this.CandyLengthTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.CandyLengthTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // CandyWidthLabel
            // 
            this.CandyWidthLabel.AutoSize = true;
            this.CandyWidthLabel.Location = new System.Drawing.Point(13, 73);
            this.CandyWidthLabel.Name = "CandyWidthLabel";
            this.CandyWidthLabel.Size = new System.Drawing.Size(116, 13);
            this.CandyWidthLabel.TabIndex = 5;
            this.CandyWidthLabel.Text = "Ширина конфеты, мм";
            // 
            // CandyWidthTextBox
            // 
            this.CandyWidthTextBox.Location = new System.Drawing.Point(197, 70);
            this.CandyWidthTextBox.Name = "CandyWidthTextBox";
            this.CandyWidthTextBox.Size = new System.Drawing.Size(100, 20);
            this.CandyWidthTextBox.TabIndex = 6;
            this.CandyWidthTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.CandyWidthTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // CandyHeightLabel
            // 
            this.CandyHeightLabel.AutoSize = true;
            this.CandyHeightLabel.Location = new System.Drawing.Point(12, 103);
            this.CandyHeightLabel.Name = "CandyHeightLabel";
            this.CandyHeightLabel.Size = new System.Drawing.Size(115, 13);
            this.CandyHeightLabel.TabIndex = 7;
            this.CandyHeightLabel.Text = "Высота конфеты, мм";
            // 
            // CandyHeightTextBox
            // 
            this.CandyHeightTextBox.Location = new System.Drawing.Point(197, 100);
            this.CandyHeightTextBox.Name = "CandyHeightTextBox";
            this.CandyHeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.CandyHeightTextBox.TabIndex = 8;
            this.CandyHeightTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.CandyHeightTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // FormDepthByLengthLabel
            // 
            this.FormDepthByLengthLabel.AutoSize = true;
            this.FormDepthByLengthLabel.Location = new System.Drawing.Point(13, 133);
            this.FormDepthByLengthLabel.Name = "FormDepthByLengthLabel";
            this.FormDepthByLengthLabel.Size = new System.Drawing.Size(162, 13);
            this.FormDepthByLengthLabel.TabIndex = 9;
            this.FormDepthByLengthLabel.Text = "Толщина формы по длине, мм";
            // 
            // FormDepthByLengthTextBox
            // 
            this.FormDepthByLengthTextBox.Location = new System.Drawing.Point(197, 130);
            this.FormDepthByLengthTextBox.Name = "FormDepthByLengthTextBox";
            this.FormDepthByLengthTextBox.Size = new System.Drawing.Size(100, 20);
            this.FormDepthByLengthTextBox.TabIndex = 10;
            this.FormDepthByLengthTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.FormDepthByLengthTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // FormDepthByWidthLabel
            // 
            this.FormDepthByWidthLabel.AutoSize = true;
            this.FormDepthByWidthLabel.Location = new System.Drawing.Point(13, 163);
            this.FormDepthByWidthLabel.Name = "FormDepthByWidthLabel";
            this.FormDepthByWidthLabel.Size = new System.Drawing.Size(170, 13);
            this.FormDepthByWidthLabel.TabIndex = 11;
            this.FormDepthByWidthLabel.Text = "Толщина формы по ширине, мм";
            // 
            // FormDepthByWidthTextBox
            // 
            this.FormDepthByWidthTextBox.Location = new System.Drawing.Point(197, 160);
            this.FormDepthByWidthTextBox.Name = "FormDepthByWidthTextBox";
            this.FormDepthByWidthTextBox.Size = new System.Drawing.Size(100, 20);
            this.FormDepthByWidthTextBox.TabIndex = 12;
            this.FormDepthByWidthTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.FormDepthByWidthTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // FormDepthByHeightLabel
            // 
            this.FormDepthByHeightLabel.AutoSize = true;
            this.FormDepthByHeightLabel.Location = new System.Drawing.Point(13, 193);
            this.FormDepthByHeightLabel.Name = "FormDepthByHeightLabel";
            this.FormDepthByHeightLabel.Size = new System.Drawing.Size(169, 13);
            this.FormDepthByHeightLabel.TabIndex = 13;
            this.FormDepthByHeightLabel.Text = "Толщина формы по высоте, мм";
            // 
            // FormDepthByHeightTextBox
            // 
            this.FormDepthByHeightTextBox.Location = new System.Drawing.Point(197, 190);
            this.FormDepthByHeightTextBox.Name = "FormDepthByHeightTextBox";
            this.FormDepthByHeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.FormDepthByHeightTextBox.TabIndex = 14;
            this.FormDepthByHeightTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.FormDepthByHeightTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 251);
            this.Controls.Add(this.FormDepthByHeightTextBox);
            this.Controls.Add(this.FormDepthByHeightLabel);
            this.Controls.Add(this.FormDepthByWidthTextBox);
            this.Controls.Add(this.FormDepthByWidthLabel);
            this.Controls.Add(this.FormDepthByLengthTextBox);
            this.Controls.Add(this.FormDepthByLengthLabel);
            this.Controls.Add(this.CandyHeightTextBox);
            this.Controls.Add(this.CandyHeightLabel);
            this.Controls.Add(this.CandyWidthTextBox);
            this.Controls.Add(this.CandyWidthLabel);
            this.Controls.Add(this.CandyLengthTextBox);
            this.Controls.Add(this.CandyLengthLabel);
            this.Controls.Add(this.CandyCountLabel);
            this.Controls.Add(this.CandyCountTextBox);
            this.Controls.Add(this.BuildButton);
            this.Name = "MainForm";
            this.Text = "Sweet Kompas3D plug-in";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.TextBox CandyCountTextBox;
        private System.Windows.Forms.Label CandyCountLabel;
        private System.Windows.Forms.Label CandyLengthLabel;
        private System.Windows.Forms.TextBox CandyLengthTextBox;
        private System.Windows.Forms.Label CandyWidthLabel;
        private System.Windows.Forms.TextBox CandyWidthTextBox;
        private System.Windows.Forms.Label CandyHeightLabel;
        private System.Windows.Forms.TextBox CandyHeightTextBox;
        private System.Windows.Forms.Label FormDepthByLengthLabel;
        private System.Windows.Forms.TextBox FormDepthByLengthTextBox;
        private System.Windows.Forms.Label FormDepthByWidthLabel;
        private System.Windows.Forms.TextBox FormDepthByWidthTextBox;
        private System.Windows.Forms.Label FormDepthByHeightLabel;
        private System.Windows.Forms.TextBox FormDepthByHeightTextBox;
    }
}

