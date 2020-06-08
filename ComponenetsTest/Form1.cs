using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponenetsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Click += NextQuestion;
            button2.Click += QuestionChecking;
            button1.Click += PreviousQuestion;
        }

        private void NextQuestion(object sender, EventArgs e)
        {
            if (tabControl1.TabCount != tabControl1.SelectedIndex)
                tabControl1.SelectedIndex++;
        }

        private void PreviousQuestion(object sender, EventArgs e)
        {
            if (0 != tabControl1.SelectedIndex)
                tabControl1.SelectedIndex--;
        }

        private void QuestionChecking(object sender, EventArgs e)
        {
            bool[] answersResult = new bool[7];
            switch (tabControl1.SelectedIndex)
            {
                case 1:
                    answersResult[0] = CheckAnswer("Слово", textBox1.Text);
                    break;
                default:
                    break;
            }
        }

        private bool CheckAnswer(string rightAnswer, string userAnswer)
        {
            if (rightAnswer == userAnswer)
                return true;
            else
                return false;
        }
    }
}
