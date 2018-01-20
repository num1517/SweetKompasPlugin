using System;
using System.Windows.Forms;

using SweetKompasPlugin.Model;
using SweetKompasPlugin.Model.Exceptions;
using System.Drawing;

namespace SweetKompasPlugin
{
    public partial class MainForm : Form
    {
        private KompasWrapper _kompasWrapper = new KompasWrapper();

        public MainForm()
        {
            InitializeComponent();
        }

        private void BuildButton_Click(object sender, System.EventArgs e)
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
                CandyCountLabel.BackColor = Color.Red;
                MessageBox.Show(exception.Message);
            }
            catch (CandyLengthException exception)
            {
                CandyLengthLabel.BackColor = Color.Red;
                MessageBox.Show(exception.Message);
            }
            catch (CandyWidthException exception)
            {
                CandyWidthLabel.BackColor = Color.Red;
                MessageBox.Show(exception.Message);
            }
            catch (CandyHeightException exception)
            {
                CandyHeightLabel.BackColor = Color.Red;
                MessageBox.Show(exception.Message);
            }
            catch (FormDepthByLengthException exception)
            {
                FormDepthByLengthLabel.BackColor = Color.Red;
                MessageBox.Show(exception.Message);
            }
            catch (FormDepthByWidthException exception)
            {
                FormDepthByWidthLabel.BackColor = Color.Red;
                MessageBox.Show(exception.Message);
            }
            catch (FormDepthByHeightException exception)
            {
                FormDepthByHeightLabel.BackColor = Color.Red;
                MessageBox.Show(exception.Message);
            }
        }
    }
}
