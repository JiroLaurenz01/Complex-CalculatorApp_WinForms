using System.Data;
using System.Linq;

namespace CALCULATOR
{
    public partial class CALCULATOR : Form
    {
        public CALCULATOR()
        {
            InitializeComponent();
        }

        // Event handler for the Erase button click
        private void EraseBtn_Click(object sender, EventArgs e)
        {
            // Get the length of the current text in the textbox
            var length = textBox.Text.Length;
            var index = length - 1;

            // Remove the last character from the textbox text
            textBox.Text = textBox.Text.Remove(index, 1);

            // If the textbox is now empty, set it to "0"
            if (textBox.Text.Length == 0)
                textBox.Text = "0";
        }

        // Event handler for all the numeric and operator buttons
        private void Buttons(object sender, EventArgs e)
        {
            // Get the last character in the textbox text
            char lastText;
            if (textBox.Text == "0")
                textBox.Clear();

            // Cast the sender object to a Button
            Button button = (Button)sender;

            // Get the text of the pressed button
            string pressedBtn = button.Text;

            // Check if the pressed button is an operator (+, -, *, /, or %)
            if (pressedBtn == "+" || pressedBtn == "-" || pressedBtn == "*" || pressedBtn == "/" || pressedBtn == "%")
            {
                // Get the last character in the textbox text
                lastText = textBox.Text.Last();

                // Check if the last character is already an operator, and if so, do not add the pressed operator
                if (lastText == '+' || lastText == '-' || lastText == '*' || lastText == '/' || lastText == '%')
                    textBox.Text += null;
                else
                    textBox.Text += button.Text;
            }
            else
                textBox.Text += button.Text;
        }

        // Event handler for the Equal button click
        private void EqualBtn_Click(object sender, EventArgs e)
        {
            // Get the equation from the textbox
            string equation = textBox.Text;

            // Check if the last character in the equation is an operator, and if so, remove it
            if (equation.Last() == '+' || equation.Last() == '-' || equation.Last() == '*' || equation.Last() == '/' || equation.Last() == '%')
                equation = equation.Remove(equation.Length - 1, 1);

            // Calculate the result of the equation using DataTable's Compute method
            var result = new DataTable().Compute(equation, null);

            // Display the result in the textbox
            textBox.Text = result.ToString();
        }

        // Event handler for the Clear button click
        private void ClearBtn_Click(object sender, EventArgs e) => textBox.Text = "0";

        // Event handler for the Exit button click
        private void ExitBtn_Click(object sender, EventArgs e) => Application.Exit();
    }
}