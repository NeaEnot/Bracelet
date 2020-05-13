using System;
using System.Configuration;
using System.Windows;

namespace Bracelet
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            int count = textBox.Text.Length > 0 ? int.Parse(textBox.Text) : rnd.Next(1, int.Parse(ConfigurationManager.AppSettings["maxRandom"]));
            bool isRight = checkBoxRightArm.IsChecked.Value;

            var arms = FileLogic.getArms(count, isRight);

            textBlockLeftArm.Text = arms.leftArm;
            textBlockRightArm.Text = arms.rightArm;
        }
    }
}
