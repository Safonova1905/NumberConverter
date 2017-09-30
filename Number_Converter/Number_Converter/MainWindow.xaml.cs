using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NumberConverter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            long num = 0;
            string res = "";

            //ініціалізація основних римських цифр і відповідних їм еквівалентів
            int[] mas1 = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] mas2 = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            //отримуємо введене користувачем число
            String text = textBox1.Text;
            if (text != "")
            {
                try     //перевірка введеного користувачем числа
                {
                    num = Convert.ToInt64(text);
                }
                catch (FormatException c)   //перевірка, чи користувач ввів лише число
                {
                    MessageBox.Show("Помилка! Введіть, будь ласка, число");
                }
                catch (OverflowException c)     //перевірка чи введене користувачем число не перевищує розмір типу long
                {
                    MessageBox.Show("Помилка! Введіть, будь ласка, менше число");
                }
                finally     //якщо число введено коректно
                {
                    int i = 0;

                    while (num > 0)     //поки число більше нуля, то
                    {
                        if (mas1[i] <= num)     //перевіряємо всі арабські числа, якщо арабське число не менше за num, то
                        {
                            num = num - mas1[i];    //віднімаємо від num це арабське число і
                            res = res + mas2[i];    //записуємо у відповідь його римський еквівалент
                        }
                        else i++;   //інакше, переходимо до наступного арабського числа
                    }

                    textBlock1.Text = res;  //надсилаємо відповідь до користувача
                }
            }
        }

    }
}
