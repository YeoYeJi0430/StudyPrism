using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPF_SimpleCalc
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool NewButton; // 연산자 버튼을 누른 후 새로 숫자가 시작되어야 함을 의미하는 변수
        private double SavedValue; // 연산자 버튼을 누를 때 현재 TxtResult에 있는 값을 저장하는 필드
        private double OperatorValue;
        public MainWindow()
        {
            InitializeComponent();
        }

        // 숫자 버튼
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string number = btn.Content.ToString();

            if (TxtResult.Text == "0" || NewButton == true)
            {
                TxtResult.Text = number;
                NewButton = false;
            }
            else
            {
                TxtResult.Text = TxtResult.Text + number;
            }
        }

        // 소수점 처리
        private void Dot_Button_Click(object sender, RoutedEventArgs e)
        {
            if (TxtResult.Text.Contains('.') == false)
            {
                TxtResult.Text = TxtResult.Text + '.';
            }
        }

        private void Eq_Button_Click(object sender, RoutedEventArgs e)
        {
            if (OperatorValue == '+')
            {
                TxtResult.Text = (SavedValue + double.Parse(TxtResult.Text)).ToString();
            }
            else if (OperatorValue == '-')
            {
                TxtResult.Text = (SavedValue - double.Parse(TxtResult.Text)).ToString();
            }
            else if (OperatorValue == '*')
            {
                TxtResult.Text = (SavedValue * double.Parse(TxtResult.Text)).ToString();
            }
            else
            {
                TxtResult.Text = (SavedValue / double.Parse(TxtResult.Text)).ToString();
            }
        }

        // Operator 4개 처리
        private void Op_Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            SavedValue = double.Parse(TxtResult.Text);
            OperatorValue = btn.Content.ToString()[0]; // 클릭된 연산자를 OperatorValue에 저장

            TxtResult.Text = " ";
            NewButton = false;
        }
    }
}
