// Author: Kyle Chapman
// Date: February 7, 2021
// Description:
//  This program is meant to show a "grid" made of labels and allow the user
//  to adjust their content by manipulating a set of NumericUpDown controls
//  along with a textbox. Specifying a "row" and "column" using the NUDs and
//  a value in the TextBox followed by clicking the button manipulates the
//  value in the labels.
//  Quotation marks have been used quite a bit in the description above because
//  actual grid-structured controls have been avoided in the interest of using
//  elements students have seen before.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayIndexDemo
{
    public partial class formArrayDemo : Form
    {
        Label[,] labelArray;


        public formArrayDemo()
        {
            InitializeComponent();

            // When the form loads, assign all of the labels that appear as part of the "grid"'s content to an array.
            labelArray = new Label[,] {
                { labelRow0Column0, labelRow0Column1, labelRow0Column2, labelRow0Column3 },
                { labelRow1Column0, labelRow1Column1, labelRow1Column2, labelRow1Column3 },
                { labelRow2Column0, labelRow2Column1, labelRow2Column2, labelRow2Column3 },
                { labelRow3Column0, labelRow3Column1, labelRow3Column2, labelRow3Column3 }
            };
        }

        /// <summary>
        /// Based on the NUD values, set the Text property of the relevant Label equal to whatever is in the entry TextBox. For the sake of demonstration, range validation on the array was omitted, allowing unhandled exceptions to be observed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakeChange(object sender, EventArgs e)
        {
            // Set row and column based on the NUD contents.
            // A hard cast to integer is used since these controls have been configured so they must be integers.
            // These lines are not 100% necessary but are being done to make the array addressing clearer.
            int row = (int)numericChangeRowIndex.Value;
            int column = (int)numericChangeColumnIndex.Value;

            // Set the text property of the label at the entered row and column equal to the contents of the TextBox.
            labelArray[row, column].Text = textBoxValueInput.Text;
        }

        /// <summary>
        /// Show a MessageBox that indicates the value based on the NUD values. For the sake of demonstration, range validation on the array was omitted, allowing unhandled exceptions to be observed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindValue(object sender, EventArgs e)
        {
            // Set row and column based on the NUD contents.
            // A hard cast to integer is used since these controls have been configured so they must be integers.
            // These lines are not 100% necessary but are being done to make the array addressing clearer.
            int row = (int)numericFindRowIndex.Value;
            int column = (int)numericFindColumnIndex.Value;

            // Display a MessageBox showing the row and column and the value in the Label at those coordinates.
            MessageBox.Show("The value at " + numericFindRowIndex.Value + "," + numericFindColumnIndex.Value + " is: " + labelArray[row, column].Text);
        }
    }
}
