using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimedMathQuiz
{
    public partial class Form1 : Form
    {
        //Create random object
        Random randomizer = new Random();
        //Two variables for the addition problem
        int addend1, addend2;
        //Two variables for the subtraction problem
        int minuend, subtrahend;
        //Two variables for the multiplication problem
        int multiplicand, multiplier;
        //Two variables for the division problem
        int dividend, divisor;
        //Variable for the timer
        int timeLeft;
        //Variable for today's date
        DateTime today = DateTime.Today;

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        public void StartTheQuiz()
        {
            //Displays the Date in the lower left corner
            dateLabel.Text = today.ToString("dd MMMM yyyy");
            //Creates random values for the addition problem
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //Assigns the value of the variable to the text of the labels in the form
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            //Initializes the sum value at zero
            sum.Value = 0;

            //Fills in the subtraction problem
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //Fills in the multiplication problem
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //Fills in the division problem
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            //Starts the timer with 30 seconds
            timeLeft = 30;
            timeLabel.Text = timeLeft + " Seconds";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(CheckTheAnswer())
            {
                //Timer stops and Congratulations message appears
                timer1.Stop();
                MessageBox.Show("You got all the answers correct!\nCongratulations!");
                startButton.Enabled = true;
            }
            else if(timeLeft > 0)
            {
                //CheckTheAnswer returns false, timer keeps going
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " Seconds";
            }
            else
            {
                //If user ran out of time, display times up. Then display lose message.
                //Display answers and reenable start button.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("Sorry, you didn't finish in time.");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void dateLabel_Click(object sender, EventArgs e)
        {

        }

        private bool CheckTheAnswer()
        {
            //Checks the answers to see if they are correct. Returns true if so, false if not.
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
