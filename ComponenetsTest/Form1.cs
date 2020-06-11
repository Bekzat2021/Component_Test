using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponenetsTest
{
    public partial class Form1 : Form
    {
        int answers = 0;
        bool[] answersResult = new bool[7];
        int rightAnswers = 0;
        public Form1()
        {
            InitializeComponent();
            button2.Click += NextQuestion;
            button2.Click += QuestionChecking;
            button2.Click += UpdateLabel;

            button1.Click += PreviousQuestion;

            trackBar1.ValueChanged += UpdateTrackBarValue;
        }

        private void UpdateTrackBarValue(object sender, EventArgs e)
        {
            label11.Text = $"Положение индикатора: {trackBar1.Value}";
        }

        private void UpdateLabel(object sender, EventArgs e)
        {
            label13.Text = answers.ToString();
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
            
            switch (tabControl1.SelectedIndex)
            {
                case 1:
                    if("Слово" == textBox1.Text)
                    {
                        answersResult[answers++] = true;
                        rightAnswers++;
                    }
                    else
                        answersResult[answers++] = false;
                    break;
                case 2:
                    if (checkBox2.Checked && checkBox3.Checked)
                    {
                        answersResult[answers++] = true;
                        rightAnswers++;
                    }
                    else
                        answersResult[answers++] = false;
                    break;
                case 3:
                    if (radioButton4.Checked)
                    {
                        answersResult[answers++] = true;
                        rightAnswers++;
                    }
                    else
                        answersResult[answers++] = false;
                    break;
                case 4:
                    if (textBox2.Text == "Ответ для поля 1" &&
                        textBox3.Text == "Ответ для поля 2" &&
                        textBox4.Text == "Ответ для поля 3")
                    {
                        answersResult[answers++] = true;
                        rightAnswers++;
                    }
                    else
                        answersResult[answers++] = false;
                    break;
                case 5:
                    if (comboBox1.SelectedIndex == 2)
                    {
                        answersResult[answers++] = true;
                        rightAnswers++;
                    }
                    else
                        answersResult[answers++] = false;
                    break;
                case 6:
                    if ((int)trackBar1.Value == 5)
                    {
                        answersResult[answers++] = true;
                        rightAnswers++;
                    }
                    else
                        answersResult[answers++] = false;
                    break;
                case 7:
                    if (checkedListBox1.GetItemChecked(0) && checkedListBox1.GetItemChecked(3))
                    {
                        answersResult[answers++] = true;
                        rightAnswers++;
                    }
                    else
                        answersResult[answers++] = false;


                    label14.Text = $"Вы ответили правильно на {rightAnswers} вопросов из 7";

                    WriteAnswersToFile();
                    break;
                default:
                    break;
            }
        }

        private void WriteAnswersToArray(bool value, int questionNumber)
        {
            //Метод который записывает ответы в массив да и сам массив должен быть не глобальным
            //переделать и метод WriteAnswersToFile()
        }

        private void WriteAnswersToFile()
        {
            string result = null;
            for (int i = 0; i < answersResult.Length; i++)
            {
                if (answersResult[i] == true)
                    result += $"Вы ответили правильно на вопрос {i+1} {Environment.NewLine}";
                else
                    result += $"Вы ответили не правильно на вопрос {i+1} {Environment.NewLine}";
            }
            var exePath = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(exePath, @"Answers\answers.txt");

            using(StreamWriter streamWriter = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                streamWriter.WriteLine(result);
            }
        }
    }
}
