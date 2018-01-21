using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

using SweetKompasPlugin.Model;
using SweetKompasPlugin.Model.Exceptions;


namespace SweetKompasPlugin
{
    public partial class MainForm : Form
    {
        private KompasWrapper _kompasWrapper = new KompasWrapper();

        private Dictionary<TextBox, Label> _textBoxLabelBindDictionary = new Dictionary<TextBox, Label>();

        public MainForm()
        {
            InitializeComponent();
            _textBoxLabelBindDictionary.Add(CandyCountTextBox, CandyCountLabel);
            _textBoxLabelBindDictionary.Add(CandyLengthTextBox, CandyLengthLabel);
            _textBoxLabelBindDictionary.Add(CandyWidthTextBox, CandyWidthLabel);
            _textBoxLabelBindDictionary.Add(CandyHeightTextBox, CandyHeightLabel);
            _textBoxLabelBindDictionary.Add(FormDepthByLengthTextBox, FormDepthByLengthLabel);
            _textBoxLabelBindDictionary.Add(FormDepthByWidthTextBox, FormDepthByWidthLabel);
            _textBoxLabelBindDictionary.Add(FormDepthByHeightTextBox, FormDepthByHeightLabel);
            CandyCountTextBox.KeyPress += new KeyPressEventHandler(IsNumberOrDotPressed);
            CandyLengthTextBox.KeyPress += new KeyPressEventHandler(IsNumberOrDotPressed);
            CandyWidthTextBox.KeyPress += new KeyPressEventHandler(IsNumberOrDotPressed);
            CandyHeightTextBox.KeyPress += new KeyPressEventHandler(IsNumberOrDotPressed);
            FormDepthByLengthTextBox.KeyPress += new KeyPressEventHandler(IsNumberOrDotPressed);
            FormDepthByWidthTextBox.KeyPress += new KeyPressEventHandler(IsNumberOrDotPressed);
            FormDepthByHeightTextBox.KeyPress += new KeyPressEventHandler(IsNumberOrDotPressed);
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            CandyForm candyForm = null;

            try
            {
                int candyCount = Convert.ToInt32(CandyCountTextBox.Text);
                double candyLength = Convert.ToDouble(CandyLengthTextBox.Text);
                double candyWidth = Convert.ToDouble(CandyWidthTextBox.Text);
                double candyHeight = Convert.ToDouble(CandyHeightTextBox.Text);
                double formDepthByLength = Convert.ToDouble(FormDepthByLengthTextBox.Text);
                double formDepthByWidth = Convert.ToDouble(FormDepthByWidthTextBox.Text);
                double formDepthByHeight = Convert.ToDouble(FormDepthByHeightTextBox.Text);

                candyForm = new CandyForm(candyCount, candyLength, candyWidth, candyHeight, formDepthByLength, formDepthByWidth, formDepthByHeight);
            }
            catch (CandyCountException exception)
            {
                ShowErrorMessage(CandyCountLabel, exception.Message);
            }
            catch (CandyLengthException exception)
            {
                ShowErrorMessage(CandyLengthLabel, exception.Message);
            }
            catch (CandyWidthException exception)
            {
                ShowErrorMessage(CandyWidthLabel, exception.Message);
            }
            catch (CandyHeightException exception)
            {
                ShowErrorMessage(CandyHeightLabel, exception.Message);
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
                ShowErrorMessage(null, "Невозможно построить деталь. В параметрах допущена ошибка.");
            }

            if (candyForm != null)
            {
                _kompasWrapper.StartKompas();
                _kompasWrapper.BuildCandyForm(candyForm);
            }
        }

        private void ChangeToBackColor(object sender, EventArgs e)
        {
            _textBoxLabelBindDictionary[(TextBox)sender].BackColor = DefaultBackColor;
        }

        private void ShowErrorMessage(Label label, string message)
        {
            if (label != null)
            {
                label.BackColor = Color.PaleVioletRed;
            }
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, 
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

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
    }
}
