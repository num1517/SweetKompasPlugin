namespace SweetKompasPlugin
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
            this.RectCandyLengthLabel = new System.Windows.Forms.Label();
            this.RectCandyLengthTextBox = new System.Windows.Forms.TextBox();
            this.RectCandyWidthLabel = new System.Windows.Forms.Label();
            this.RectCandyWidthTextBox = new System.Windows.Forms.TextBox();
            this.RectCandyHeightLabel = new System.Windows.Forms.Label();
            this.RectCandyHeightTextBox = new System.Windows.Forms.TextBox();
            this.FormDepthByLengthLabel = new System.Windows.Forms.Label();
            this.FormDepthByLengthTextBox = new System.Windows.Forms.TextBox();
            this.FormDepthByWidthLabel = new System.Windows.Forms.Label();
            this.FormDepthByWidthTextBox = new System.Windows.Forms.TextBox();
            this.FormDepthByHeightLabel = new System.Windows.Forms.Label();
            this.FormDepthByHeightTextBox = new System.Windows.Forms.TextBox();
            this.FormParams = new System.Windows.Forms.GroupBox();
            this.CandyParams = new System.Windows.Forms.GroupBox();
            this.CandyType = new System.Windows.Forms.TabControl();
            this.RectCandyTab = new System.Windows.Forms.TabPage();
            this.SphereCandyTab = new System.Windows.Forms.TabPage();
            this.SphereCandyRadiusLabel = new System.Windows.Forms.Label();
            this.SphereCandyRadiusTextBox = new System.Windows.Forms.TextBox();
            this.CylinderCandyTab = new System.Windows.Forms.TabPage();
            this.CylinderCandyRadiusLabel = new System.Windows.Forms.Label();
            this.CylinderCandyRadiusTextBox = new System.Windows.Forms.TextBox();
            this.CylinderCandyLengthLabel = new System.Windows.Forms.Label();
            this.CylinderCandyLengthTextBox = new System.Windows.Forms.TextBox();
            this.FormParams.SuspendLayout();
            this.CandyParams.SuspendLayout();
            this.CandyType.SuspendLayout();
            this.RectCandyTab.SuspendLayout();
            this.SphereCandyTab.SuspendLayout();
            this.CylinderCandyTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(125, 338);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(75, 23);
            this.BuildButton.TabIndex = 0;
            this.BuildButton.Text = "Построить";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // CandyCountTextBox
            // 
            this.CandyCountTextBox.Location = new System.Drawing.Point(202, 22);
            this.CandyCountTextBox.Name = "CandyCountTextBox";
            this.CandyCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.CandyCountTextBox.TabIndex = 1;
            this.CandyCountTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.CandyCountTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // CandyCountLabel
            // 
            this.CandyCountLabel.AutoSize = true;
            this.CandyCountLabel.Location = new System.Drawing.Point(18, 25);
            this.CandyCountLabel.Name = "CandyCountLabel";
            this.CandyCountLabel.Size = new System.Drawing.Size(106, 13);
            this.CandyCountLabel.TabIndex = 2;
            this.CandyCountLabel.Text = "Количество конфет";
            // 
            // RectCandyLengthLabel
            // 
            this.RectCandyLengthLabel.AutoSize = true;
            this.RectCandyLengthLabel.Location = new System.Drawing.Point(8, 16);
            this.RectCandyLengthLabel.Name = "RectCandyLengthLabel";
            this.RectCandyLengthLabel.Size = new System.Drawing.Size(110, 13);
            this.RectCandyLengthLabel.TabIndex = 3;
            this.RectCandyLengthLabel.Text = "Длина конфеты, мм";
            // 
            // RectCandyLengthTextBox
            // 
            this.RectCandyLengthTextBox.Location = new System.Drawing.Point(192, 13);
            this.RectCandyLengthTextBox.Name = "RectCandyLengthTextBox";
            this.RectCandyLengthTextBox.Size = new System.Drawing.Size(100, 20);
            this.RectCandyLengthTextBox.TabIndex = 4;
            this.RectCandyLengthTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.RectCandyLengthTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // RectCandyWidthLabel
            // 
            this.RectCandyWidthLabel.AutoSize = true;
            this.RectCandyWidthLabel.Location = new System.Drawing.Point(8, 46);
            this.RectCandyWidthLabel.Name = "RectCandyWidthLabel";
            this.RectCandyWidthLabel.Size = new System.Drawing.Size(116, 13);
            this.RectCandyWidthLabel.TabIndex = 5;
            this.RectCandyWidthLabel.Text = "Ширина конфеты, мм";
            // 
            // RectCandyWidthTextBox
            // 
            this.RectCandyWidthTextBox.Location = new System.Drawing.Point(192, 43);
            this.RectCandyWidthTextBox.Name = "RectCandyWidthTextBox";
            this.RectCandyWidthTextBox.Size = new System.Drawing.Size(100, 20);
            this.RectCandyWidthTextBox.TabIndex = 6;
            this.RectCandyWidthTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.RectCandyWidthTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // RectCandyHeightLabel
            // 
            this.RectCandyHeightLabel.AutoSize = true;
            this.RectCandyHeightLabel.Location = new System.Drawing.Point(7, 76);
            this.RectCandyHeightLabel.Name = "RectCandyHeightLabel";
            this.RectCandyHeightLabel.Size = new System.Drawing.Size(115, 13);
            this.RectCandyHeightLabel.TabIndex = 7;
            this.RectCandyHeightLabel.Text = "Высота конфеты, мм";
            // 
            // RectCandyHeightTextBox
            // 
            this.RectCandyHeightTextBox.Location = new System.Drawing.Point(192, 73);
            this.RectCandyHeightTextBox.Name = "RectCandyHeightTextBox";
            this.RectCandyHeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.RectCandyHeightTextBox.TabIndex = 8;
            this.RectCandyHeightTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.RectCandyHeightTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // FormDepthByLengthLabel
            // 
            this.FormDepthByLengthLabel.AutoSize = true;
            this.FormDepthByLengthLabel.Location = new System.Drawing.Point(18, 55);
            this.FormDepthByLengthLabel.Name = "FormDepthByLengthLabel";
            this.FormDepthByLengthLabel.Size = new System.Drawing.Size(162, 13);
            this.FormDepthByLengthLabel.TabIndex = 9;
            this.FormDepthByLengthLabel.Text = "Толщина формы по длине, мм";
            // 
            // FormDepthByLengthTextBox
            // 
            this.FormDepthByLengthTextBox.Location = new System.Drawing.Point(202, 52);
            this.FormDepthByLengthTextBox.Name = "FormDepthByLengthTextBox";
            this.FormDepthByLengthTextBox.Size = new System.Drawing.Size(100, 20);
            this.FormDepthByLengthTextBox.TabIndex = 10;
            this.FormDepthByLengthTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.FormDepthByLengthTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // FormDepthByWidthLabel
            // 
            this.FormDepthByWidthLabel.AutoSize = true;
            this.FormDepthByWidthLabel.Location = new System.Drawing.Point(18, 85);
            this.FormDepthByWidthLabel.Name = "FormDepthByWidthLabel";
            this.FormDepthByWidthLabel.Size = new System.Drawing.Size(170, 13);
            this.FormDepthByWidthLabel.TabIndex = 11;
            this.FormDepthByWidthLabel.Text = "Толщина формы по ширине, мм";
            // 
            // FormDepthByWidthTextBox
            // 
            this.FormDepthByWidthTextBox.Location = new System.Drawing.Point(202, 82);
            this.FormDepthByWidthTextBox.Name = "FormDepthByWidthTextBox";
            this.FormDepthByWidthTextBox.Size = new System.Drawing.Size(100, 20);
            this.FormDepthByWidthTextBox.TabIndex = 12;
            this.FormDepthByWidthTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.FormDepthByWidthTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // FormDepthByHeightLabel
            // 
            this.FormDepthByHeightLabel.AutoSize = true;
            this.FormDepthByHeightLabel.Location = new System.Drawing.Point(18, 115);
            this.FormDepthByHeightLabel.Name = "FormDepthByHeightLabel";
            this.FormDepthByHeightLabel.Size = new System.Drawing.Size(169, 13);
            this.FormDepthByHeightLabel.TabIndex = 13;
            this.FormDepthByHeightLabel.Text = "Толщина формы по высоте, мм";
            // 
            // FormDepthByHeightTextBox
            // 
            this.FormDepthByHeightTextBox.Location = new System.Drawing.Point(202, 112);
            this.FormDepthByHeightTextBox.Name = "FormDepthByHeightTextBox";
            this.FormDepthByHeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.FormDepthByHeightTextBox.TabIndex = 14;
            this.FormDepthByHeightTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.FormDepthByHeightTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // FormParams
            // 
            this.FormParams.Controls.Add(this.CandyCountLabel);
            this.FormParams.Controls.Add(this.CandyCountTextBox);
            this.FormParams.Controls.Add(this.FormDepthByHeightTextBox);
            this.FormParams.Controls.Add(this.FormDepthByLengthLabel);
            this.FormParams.Controls.Add(this.FormDepthByHeightLabel);
            this.FormParams.Controls.Add(this.FormDepthByLengthTextBox);
            this.FormParams.Controls.Add(this.FormDepthByWidthTextBox);
            this.FormParams.Controls.Add(this.FormDepthByWidthLabel);
            this.FormParams.Location = new System.Drawing.Point(12, 12);
            this.FormParams.Name = "FormParams";
            this.FormParams.Size = new System.Drawing.Size(326, 142);
            this.FormParams.TabIndex = 15;
            this.FormParams.TabStop = false;
            this.FormParams.Text = "Параметры формы";
            // 
            // CandyParams
            // 
            this.CandyParams.Controls.Add(this.CandyType);
            this.CandyParams.Location = new System.Drawing.Point(12, 162);
            this.CandyParams.Name = "CandyParams";
            this.CandyParams.Size = new System.Drawing.Size(326, 158);
            this.CandyParams.TabIndex = 16;
            this.CandyParams.TabStop = false;
            this.CandyParams.Text = "Параметры конфет";
            // 
            // CandyType
            // 
            this.CandyType.Controls.Add(this.RectCandyTab);
            this.CandyType.Controls.Add(this.SphereCandyTab);
            this.CandyType.Controls.Add(this.CylinderCandyTab);
            this.CandyType.Location = new System.Drawing.Point(6, 19);
            this.CandyType.Name = "CandyType";
            this.CandyType.SelectedIndex = 0;
            this.CandyType.Size = new System.Drawing.Size(315, 133);
            this.CandyType.TabIndex = 17;
            // 
            // RectCandyTab
            // 
            this.RectCandyTab.Controls.Add(this.RectCandyHeightTextBox);
            this.RectCandyTab.Controls.Add(this.RectCandyLengthLabel);
            this.RectCandyTab.Controls.Add(this.RectCandyLengthTextBox);
            this.RectCandyTab.Controls.Add(this.RectCandyWidthLabel);
            this.RectCandyTab.Controls.Add(this.RectCandyWidthTextBox);
            this.RectCandyTab.Controls.Add(this.RectCandyHeightLabel);
            this.RectCandyTab.Location = new System.Drawing.Point(4, 22);
            this.RectCandyTab.Name = "RectCandyTab";
            this.RectCandyTab.Padding = new System.Windows.Forms.Padding(3);
            this.RectCandyTab.Size = new System.Drawing.Size(307, 107);
            this.RectCandyTab.TabIndex = 0;
            this.RectCandyTab.Text = "Прямоугольная";
            this.RectCandyTab.UseVisualStyleBackColor = true;
            // 
            // SphereCandyTab
            // 
            this.SphereCandyTab.Controls.Add(this.SphereCandyRadiusLabel);
            this.SphereCandyTab.Controls.Add(this.SphereCandyRadiusTextBox);
            this.SphereCandyTab.Location = new System.Drawing.Point(4, 22);
            this.SphereCandyTab.Name = "SphereCandyTab";
            this.SphereCandyTab.Padding = new System.Windows.Forms.Padding(3);
            this.SphereCandyTab.Size = new System.Drawing.Size(307, 107);
            this.SphereCandyTab.TabIndex = 1;
            this.SphereCandyTab.Text = "Сферическая";
            this.SphereCandyTab.UseVisualStyleBackColor = true;
            // 
            // SphereCandyRadiusLabel
            // 
            this.SphereCandyRadiusLabel.AutoSize = true;
            this.SphereCandyRadiusLabel.Location = new System.Drawing.Point(8, 16);
            this.SphereCandyRadiusLabel.Name = "SphereCandyRadiusLabel";
            this.SphereCandyRadiusLabel.Size = new System.Drawing.Size(113, 13);
            this.SphereCandyRadiusLabel.TabIndex = 5;
            this.SphereCandyRadiusLabel.Text = "Радиус конфеты, мм";
            // 
            // SphereCandyRadiusTextBox
            // 
            this.SphereCandyRadiusTextBox.Location = new System.Drawing.Point(192, 13);
            this.SphereCandyRadiusTextBox.Name = "SphereCandyRadiusTextBox";
            this.SphereCandyRadiusTextBox.Size = new System.Drawing.Size(100, 20);
            this.SphereCandyRadiusTextBox.TabIndex = 6;
            this.SphereCandyRadiusTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.SphereCandyRadiusTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // CylinderCandyTab
            // 
            this.CylinderCandyTab.Controls.Add(this.CylinderCandyRadiusLabel);
            this.CylinderCandyTab.Controls.Add(this.CylinderCandyRadiusTextBox);
            this.CylinderCandyTab.Controls.Add(this.CylinderCandyLengthLabel);
            this.CylinderCandyTab.Controls.Add(this.CylinderCandyLengthTextBox);
            this.CylinderCandyTab.Location = new System.Drawing.Point(4, 22);
            this.CylinderCandyTab.Name = "CylinderCandyTab";
            this.CylinderCandyTab.Padding = new System.Windows.Forms.Padding(3);
            this.CylinderCandyTab.Size = new System.Drawing.Size(307, 107);
            this.CylinderCandyTab.TabIndex = 2;
            this.CylinderCandyTab.Text = "Цилиндрическая";
            this.CylinderCandyTab.UseVisualStyleBackColor = true;
            // 
            // CylinderCandyRadiusLabel
            // 
            this.CylinderCandyRadiusLabel.AutoSize = true;
            this.CylinderCandyRadiusLabel.Location = new System.Drawing.Point(8, 17);
            this.CylinderCandyRadiusLabel.Name = "CylinderCandyRadiusLabel";
            this.CylinderCandyRadiusLabel.Size = new System.Drawing.Size(113, 13);
            this.CylinderCandyRadiusLabel.TabIndex = 7;
            this.CylinderCandyRadiusLabel.Text = "Радиус конфеты, мм";
            // 
            // CylinderCandyRadiusTextBox
            // 
            this.CylinderCandyRadiusTextBox.Location = new System.Drawing.Point(192, 14);
            this.CylinderCandyRadiusTextBox.Name = "CylinderCandyRadiusTextBox";
            this.CylinderCandyRadiusTextBox.Size = new System.Drawing.Size(100, 20);
            this.CylinderCandyRadiusTextBox.TabIndex = 8;
            this.CylinderCandyRadiusTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.CylinderCandyRadiusTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // CylinderCandyLengthLabel
            // 
            this.CylinderCandyLengthLabel.AutoSize = true;
            this.CylinderCandyLengthLabel.Location = new System.Drawing.Point(8, 47);
            this.CylinderCandyLengthLabel.Name = "CylinderCandyLengthLabel";
            this.CylinderCandyLengthLabel.Size = new System.Drawing.Size(110, 13);
            this.CylinderCandyLengthLabel.TabIndex = 9;
            this.CylinderCandyLengthLabel.Text = "Длина конфеты, мм";
            // 
            // CylinderCandyLengthTextBox
            // 
            this.CylinderCandyLengthTextBox.Location = new System.Drawing.Point(192, 44);
            this.CylinderCandyLengthTextBox.Name = "CylinderCandyLengthTextBox";
            this.CylinderCandyLengthTextBox.Size = new System.Drawing.Size(100, 20);
            this.CylinderCandyLengthTextBox.TabIndex = 10;
            this.CylinderCandyLengthTextBox.TextChanged += new System.EventHandler(this.ChangeToBackColor);
            this.CylinderCandyLengthTextBox.Leave += new System.EventHandler(this.TextBoxValidate);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 367);
            this.Controls.Add(this.CandyParams);
            this.Controls.Add(this.FormParams);
            this.Controls.Add(this.BuildButton);
            this.Name = "MainForm";
            this.Text = "Sweet Kompas3D plug-in";
            this.FormParams.ResumeLayout(false);
            this.FormParams.PerformLayout();
            this.CandyParams.ResumeLayout(false);
            this.CandyType.ResumeLayout(false);
            this.RectCandyTab.ResumeLayout(false);
            this.RectCandyTab.PerformLayout();
            this.SphereCandyTab.ResumeLayout(false);
            this.SphereCandyTab.PerformLayout();
            this.CylinderCandyTab.ResumeLayout(false);
            this.CylinderCandyTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.TextBox CandyCountTextBox;
        private System.Windows.Forms.Label CandyCountLabel;
        private System.Windows.Forms.Label RectCandyLengthLabel;
        private System.Windows.Forms.TextBox RectCandyLengthTextBox;
        private System.Windows.Forms.Label RectCandyWidthLabel;
        private System.Windows.Forms.TextBox RectCandyWidthTextBox;
        private System.Windows.Forms.Label RectCandyHeightLabel;
        private System.Windows.Forms.TextBox RectCandyHeightTextBox;
        private System.Windows.Forms.Label FormDepthByLengthLabel;
        private System.Windows.Forms.TextBox FormDepthByLengthTextBox;
        private System.Windows.Forms.Label FormDepthByWidthLabel;
        private System.Windows.Forms.TextBox FormDepthByWidthTextBox;
        private System.Windows.Forms.Label FormDepthByHeightLabel;
        private System.Windows.Forms.TextBox FormDepthByHeightTextBox;
        private System.Windows.Forms.GroupBox FormParams;
        private System.Windows.Forms.GroupBox CandyParams;
        private System.Windows.Forms.TabControl CandyType;
        private System.Windows.Forms.TabPage RectCandyTab;
        private System.Windows.Forms.TabPage SphereCandyTab;
        private System.Windows.Forms.TabPage CylinderCandyTab;
        private System.Windows.Forms.Label SphereCandyRadiusLabel;
        private System.Windows.Forms.TextBox SphereCandyRadiusTextBox;
        private System.Windows.Forms.Label CylinderCandyRadiusLabel;
        private System.Windows.Forms.TextBox CylinderCandyRadiusTextBox;
        private System.Windows.Forms.Label CylinderCandyLengthLabel;
        private System.Windows.Forms.TextBox CylinderCandyLengthTextBox;
    }
}

