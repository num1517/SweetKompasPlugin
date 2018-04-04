using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

using SweetKompasPlugin.Model;
using SweetKompasPlugin.Model.Exceptions;


namespace SweetKompasPlugin
{
    /// <summary>
    /// Главное окно программы
    /// </summary>
    public partial class MainForm : Form
    {
        private KompasWrapper _kompasWrapper = new KompasWrapper();

        /// <summary>
        /// Словарь для привязки текстбоксов и лейблов
        /// </summary>
        private Dictionary<TextBox, Label> _textBoxLabelBindDictionary = 
            new Dictionary<TextBox, Label>();

        /// <summary>
        /// Конструктор главного окна.
        /// Заполняем словарь текстбоксами и лейблами.
        /// И как бонус накидываем на текстбоксы валидирующий обработчик
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _textBoxLabelBindDictionary.Add(CandyCountTextBox, 
                CandyCountLabel);
            _textBoxLabelBindDictionary.Add(FormDepthByLengthTextBox, 
                FormDepthByLengthLabel);
            _textBoxLabelBindDictionary.Add(FormDepthByWidthTextBox, 
                FormDepthByWidthLabel);
            _textBoxLabelBindDictionary.Add(FormDepthByHeightTextBox, 
                FormDepthByHeightLabel);
            _textBoxLabelBindDictionary.Add(RectCandyLengthTextBox, 
                RectCandyLengthLabel);
            _textBoxLabelBindDictionary.Add(RectCandyWidthTextBox, 
                RectCandyWidthLabel);
            _textBoxLabelBindDictionary.Add(RectCandyHeightTextBox, 
                RectCandyHeightLabel);
            _textBoxLabelBindDictionary.Add(SphereCandyRadiusTextBox, 
                SphereCandyRadiusLabel);
            _textBoxLabelBindDictionary.Add(CylinderCandyLengthTextBox, 
                CylinderCandyLengthLabel);
            _textBoxLabelBindDictionary.Add(CylinderCandyRadiusTextBox, 
                CylinderCandyRadiusLabel);

            CandyCountTextBox.KeyPress += 
                new KeyPressEventHandler(IsNumberOrDotPressed);
            FormDepthByLengthTextBox.KeyPress += 
                new KeyPressEventHandler(IsNumberOrDotPressed);
            FormDepthByWidthTextBox.KeyPress += 
                new KeyPressEventHandler(IsNumberOrDotPressed);
            FormDepthByHeightTextBox.KeyPress += 
                new KeyPressEventHandler(IsNumberOrDotPressed);
            RectCandyLengthTextBox.KeyPress += 
                new KeyPressEventHandler(IsNumberOrDotPressed);
            RectCandyWidthTextBox.KeyPress += 
                new KeyPressEventHandler(IsNumberOrDotPressed);
            RectCandyHeightTextBox.KeyPress += 
                new KeyPressEventHandler(IsNumberOrDotPressed);
            SphereCandyRadiusTextBox.KeyPress += 
                new KeyPressEventHandler(IsNumberOrDotPressed);
            CylinderCandyLengthTextBox.KeyPress += 
                new KeyPressEventHandler(IsNumberOrDotPressed);
            CylinderCandyRadiusTextBox.KeyPress += 
                new KeyPressEventHandler(IsNumberOrDotPressed);
        }

        /// <summary>
        /// Кнопка построить деталь
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Параметры события</param>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            // Создадим конфетну форму

            CandySettings candySettings = null;
            try
            {
                int candyCount = Convert.ToInt32(CandyCountTextBox.Text);
                double formDepthByLength = 
                    Convert.ToDouble(FormDepthByLengthTextBox.Text);
                double formDepthByWidth = 
                    Convert.ToDouble(FormDepthByWidthTextBox.Text);
                double formDepthByHeight = 
                    Convert.ToDouble(FormDepthByHeightTextBox.Text);

                candySettings = new CandySettings(candyCount, 
                    formDepthByLength, formDepthByWidth, formDepthByHeight);
            }
            catch (CandyCountException exception)
            {
                ShowErrorMessage(CandyCountLabel, exception.Message);
            }
            catch (FormDepthByLengthException exception)
            {
                ShowErrorMessage(FormDepthByLengthLabel, exception.Message);
            }
            catch (FormDepthByWidthException exception)
            {
                ShowErrorMessage(FormDepthByWidthLabel, exception.Message);
            }
            catch (FormDepthByHeightException exception)
            {
                ShowErrorMessage(FormDepthByHeightLabel, exception.Message);
            }
            catch (FormatException)
            {
                ShowErrorMessage(null, 
                    "Невозможно построить деталь. " 
                    + "В параметрах допущена ошибка.");
            }

            // Создадим конфету

            CandyBase candy = null;
            try
            {
                switch (CandyType.SelectedIndex)
                {
                    case 0:
                        candy = BuildRectCandy();
                        break;
                    case 1:
                        candy = BuildSphereCandy();
                        break;
                    case 2:
                        candy = BuildCylinderCandy();
                        break;
                }
            }
            catch (CandyHeightException exception)
            {
                ShowErrorMessage(RectCandyHeightLabel, exception.Message);
            }
            catch (CandyLengthException exception)
            {
                Label label = (CandyType.SelectedIndex == 0) 
                    ? RectCandyLengthLabel : CylinderCandyLengthLabel;
                ShowErrorMessage(label, exception.Message);
            }
            catch (CandyRadiusException exception)
            {
                Label label = (CandyType.SelectedIndex == 1) 
                    ? SphereCandyRadiusLabel : CylinderCandyRadiusLabel;
                ShowErrorMessage(label, exception.Message);
            }
            catch (CandyWidthException exception)
            {
                ShowErrorMessage(RectCandyWidthLabel, exception.Message);
            }
            catch (FormatException)
            {
                ShowErrorMessage(null, 
                    "Невозможно построить деталь. " 
                    + "В параметрах допущена ошибка.");
            }

            if (candySettings != null && candy != null)
            {
                _kompasWrapper.StartKompas();
                _kompasWrapper.BuildCandySettings(candySettings, candy);
            }
        }

        /// <summary>
        /// Возвращение исходного цвета для лейбла привязанного к текстбоксу
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Параметры события</param>
        private void ChangeToBackColor(object sender, EventArgs e)
        {
            _textBoxLabelBindDictionary[(TextBox)sender].BackColor = 
                Color.Transparent;
        }

        /// <summary>
        /// Вывод сообщения об ошибке 
        /// и подсветка лейбла, связанного с этой ошибкой
        /// </summary>
        /// <param name="label">Подсвечиваемый лейбл</param>
        /// <param name="message">Выводимое на экран сообщение</param>
        private void ShowErrorMessage(Label label, string message)
        {
            // Сообщение об ошибки может быть не привязано к лейблу
            if (label != null)
            {
                label.BackColor = Color.PaleVioletRed;
            }
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, 
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Событие проверяющее чтобы текстбокс содержал 
        /// максимум один знак разделения (точка, запятая)
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Параметры события</param>
        private void IsNumberOrDotPressed(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsControl(e.KeyChar))
                && !(Char.IsDigit(e.KeyChar))
                && !((e.KeyChar == '.')
                && (((TextBox)sender).Text.IndexOf(".") == -1)
                && (((TextBox)sender).Text.IndexOf(",") == -1))
                && !((e.KeyChar == ',')
                && (((TextBox)sender).Text.IndexOf(",") == -1)
                && (((TextBox)sender).Text.IndexOf(".") == -1))
            )
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Проверка текстбокса на неверные 
        /// значения (пустота или просто точка/запятая)
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Параметры события</param>
        private void TextBoxValidate(object sender, EventArgs e)
        {
            TextBox textBox = ((TextBox)sender);
            if (textBox.Text == ""
                || textBox.Text == "."
                || textBox.Text == ",")
            {
                ShowErrorMessage(_textBoxLabelBindDictionary[textBox],
                    "Данный параметр содержит неверное значение.");
                textBox.Focus();
            }
        }

        /// <summary>
        /// Создание прямоугольной конфеты
        /// </summary>
        /// <returns>Возвращает прямоугольную конфету</returns>
        private Rect BuildRectCandy()
        {
            double rectCandyLength = 
                Convert.ToDouble(RectCandyLengthTextBox.Text);
            double rectCandyWidth = 
                Convert.ToDouble(RectCandyWidthTextBox.Text);
            double rectCandyHeight = 
                Convert.ToDouble(RectCandyHeightTextBox.Text);

            return new Rect(rectCandyWidth, rectCandyHeight, rectCandyLength);
        }

        /// <summary>
        /// Создание сферической конфеты
        /// </summary>
        /// <returns>Возвращает сферическую конфету</returns>
        private Sphere BuildSphereCandy()
        {
            double sphereCandyRadius = 
                Convert.ToDouble(SphereCandyRadiusTextBox.Text);

            return new Sphere(sphereCandyRadius);
        }

        /// <summary>
        /// Создание цилиндрической конфеты
        /// </summary>
        /// <returns>Возвращает цилиндрическую конфету</returns>
        private Cylinder BuildCylinderCandy()
        {
            double cylinderCandyRadius = 
                Convert.ToDouble(CylinderCandyRadiusTextBox.Text);
            double cylinderCandyLength = 
                Convert.ToDouble(CylinderCandyLengthTextBox.Text);

            return new Cylinder(cylinderCandyRadius, cylinderCandyLength);
        }
    }
}
