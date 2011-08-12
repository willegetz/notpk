// HexVitals written by William Getz 5/26/2011
// The purpose of this program is to derive the seven vital pieces of information
// needed in order to work with hexagons in a Role Playing Game setting.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HexagonVitals01
{
    public partial class Form1 : Form
    {
        private double _startingMeasurement;
        private int _measurementTypeIndex;

        HexVitals hex;

        public Form1()
        {
            InitializeComponent();

            // Apothem is a line segment from the center to the midpoint of one of its sides.
            // I felt it easier to use this term than to write out the above.
            comboBoxSelectStartingMeasurement.Items.Add("Apothem Length");
            comboBoxSelectStartingMeasurement.Items.Add("Area");
            comboBoxSelectStartingMeasurement.Items.Add("Center to Vertex Length");
            comboBoxSelectStartingMeasurement.Items.Add("Perimeter Length");
            comboBoxSelectStartingMeasurement.Items.Add("Side Length");
            comboBoxSelectStartingMeasurement.Items.Add("Side to Side Length");
            comboBoxSelectStartingMeasurement.Items.Add("Vertex to Vertex Length");
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            hex = new HexVitals();

            _measurementTypeIndex = comboBoxSelectStartingMeasurement.SelectedIndex;

            try
            {
                if (IsValidData())
                {
                    hex.DeriveSideLength(_measurementTypeIndex, _startingMeasurement);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                textBoxStartingMeasurement.Focus();
            }
            
            
            DisplayHexInformation();
        }

        public bool IsValidData()
        {
            return
                IsValidSelection(_measurementTypeIndex) &&
                IsValidEntry(textBoxStartingMeasurement.Text);
        }

        public bool IsValidSelection(int measurementType)
        {
            if (measurementType < 0)
            {
                MessageBox.Show("Please select the type of measurement to use", "Selection Error");
                comboBoxSelectStartingMeasurement.Focus();
                return false;
            }
            return true;
        }

        public bool IsValidEntry(string startingMeasurement)
        {
            
            try
            {
                _startingMeasurement = Double.Parse(startingMeasurement);

                if (_startingMeasurement <= 0)
                {
                    MessageBox.Show("Measurement must be greater than 0", "Entry Error");
                    textBoxStartingMeasurement.Focus();
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("You have made an invalid entry.\nPlease enter measurement as an integer or decimal", "Entry Error");
                textBoxStartingMeasurement.Focus();
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("You have entered a measurement that is too large", "Entry Error");
                textBoxStartingMeasurement.Focus();
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                textBoxStartingMeasurement.Focus();
                return false;
            }
            return true;
        }

        private void DisplayHexInformation()
        {
            textBoxApothem.Text = hex.ApothemLength.ToString("f4");
            textBoxArea.Text = hex.Area.ToString("f4");
            textBoxCenterToVertex.Text = hex.CenterToVertex.ToString("f4");
            textBoxPerimeter.Text = hex.PerimeterLength.ToString("f4");
            textBoxSide.Text = hex.SideLength.ToString("f4");
            textBoxSideToSide.Text = hex.SideToSideLength.ToString("f4");
            textBoxVertexToVertex.Text = hex.VertexToVertexLength.ToString("f4");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
