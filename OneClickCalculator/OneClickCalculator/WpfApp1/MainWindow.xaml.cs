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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int maxlen = 17;
        double result = 0, entered = 0, memory = 0, perc = 0;
        string lastop = "";
        bool isminus = false, isshiftl = false, isshiftr = false, ifdot = false, ifequal = false, ifpercent = false, ifcleared = true;
        

        public MainWindow()
        {
            
        }

        //Binding
        public void KeyUpPass(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.RightShift:
                    isshiftr = false;
                    break;
                case Key.LeftShift:
                    isshiftl = false;
                    break;
            }
        }
        public void KeyDownClick(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.LeftShift:
                    isshiftl = true;
                    break;
                case Key.RightShift:
                    isshiftr = true;
                    break;

                case Key.OemQuestion:
                case Key.OemPeriod:
                case Key.OemComma:
                case Key.Decimal:
                    EnterClick(".");
                    break;

                case Key.Delete:
                    ClearClick("C");
                    break;
                case Key.Back:
                    ClearClick("NoForwardSpace");
                    break;

                case Key.Multiply:
                    OperatorClick("*");
                    break;
                case Key.Divide:
                    OperatorClick("/");
                    break;
                case Key.Subtract:
                    OperatorClick("-");
                    break;
                case Key.Add:
                    OperatorClick("+");
                    break;

                case Key.Return:
                    EqualClick();
                    break;

                case Key.D1:
                    EnterClick("1");
                    break;
                case Key.D2:
                    EnterClick("2");
                    break;
                case Key.D3:
                    EnterClick("3");
                    break;
                case Key.D4:
                    EnterClick("4");
                    break;
                case Key.D6:
                    EnterClick("6");
                    break;
                case Key.D7:
                    EnterClick("7");
                    break;
                case Key.D9:
                    EnterClick("9");
                    break;
                case Key.D0:
                    EnterClick("0");
                    break;
                case Key.NumPad1:
                    EnterClick("1");
                    break;
                case Key.NumPad2:
                    EnterClick("2");
                    break;
                case Key.NumPad3:
                    EnterClick("3");
                    break;
                case Key.NumPad4:
                    EnterClick("4");
                    break;
                case Key.NumPad5:
                    EnterClick("5");
                    break;
                case Key.NumPad6:
                    EnterClick("6");
                    break;
                case Key.NumPad7:
                    EnterClick("7");
                    break;
                case Key.NumPad8:
                    EnterClick("8");
                    break;
                case Key.NumPad9:
                    EnterClick("9");
                    break;
            }
            if (isshiftl || isshiftr)
            {
                switch (e.Key)
                {
                    case Key.D5:
                        PercentClick();
                        break;
                    case Key.D8:
                        OperatorClick("*");
                        break;
                    case Key.OemPlus:
                        OperatorClick("+");
                        break;                        
                }
            }
            else
                switch (e.Key)
                {
                    case Key.D5:
                        EnterClick("5");
                        break;
                    case Key.D8:
                        EnterClick("8");
                        break;
                    case Key.OemPlus:
                        EqualClick();
                        break;
                    case Key.OemMinus:
                        OperatorClick("-");
                        break;
                }

        }        
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "b0":
                    EnterClick("0");
                    break;
                case "b1":
                    EnterClick("1");
                    break;
                case "b2":
                    EnterClick("2");
                    break;
                case "b3":
                    EnterClick("3");
                    break;
                case "b4":
                    EnterClick("4");
                    break;
                case "b5":
                    EnterClick("5");
                    break;
                case "b6":
                    EnterClick("6");
                    break;
                case "b7":
                    EnterClick("7");
                    break;
                case "b8":
                    EnterClick("8");
                    break;
                case "b9":
                    EnterClick("9");
                    break;
                case "bdot":
                    EnterClick(".");
                    break;
                case "bnotx":
                    EnterClick("notx");
                    break;
                case "bx3":
                    EnterClick("x^3");
                    break;
                case "bx2":
                    EnterClick("x^2");
                    break;
                case "bplusminus":
                    EnterClick("plusminus");
                    break;
                case "bsqrt":
                    EnterClick("sqrt");
                    break;

                case "bperc":
                    PercentClick();
                    break;

                case "bce":
                    ClearClick("CE");
                    break;
                case "bc":
                    ClearClick("C");
                    break;
                case "bnoforwardspace":
                    ClearClick("NoForwardSpace");
                    break;

                case "bequal":
                    EqualClick();
                    break;

                case "bplus":
                    OperatorClick("+");
                    break;
                case "bminus":
                    OperatorClick("-");
                    break;
                case "bmulti":
                    OperatorClick("*");
                    break;
                case "bdiv":
                    OperatorClick("/");
                    break;

                case "bmc":
                    MButtonClick("MC");
                    break;
                case "bmr":
                    MButtonClick("MR");
                    break;
                case "bminc":
                    MButtonClick("M+");
                    break;
                case "bmdec":
                    MButtonClick("M-");
                    break;
                case "bms":
                    MButtonClick("MS");
                    break;


            }
        }

        //Helping
        public void ButtonClickEnabled(bool n)
        {
            b0.IsEnabled = n;
            b1.IsEnabled = n;
            b2.IsEnabled = n;
            b3.IsEnabled = n;
            b4.IsEnabled = n;
            b5.IsEnabled = n;
            b6.IsEnabled = n;
            b7.IsEnabled = n;
            b8.IsEnabled = n;
            b9.IsEnabled = n;
            bdot.IsEnabled = n;
            ifpercent = !n;
        }
        public void DoLastOp(string a)
        {
            switch (a)
            {
                case "-":
                    result -= entered;
                    break;
                case "+":
                    result += entered;
                    break;
                case "*":
                    result *= entered;
                    break;
                case "/":
                    result /= entered;
                    break;
            }

            TextBlockLast.Text = result.ToString() + " " + a;
        }

        //Doing)
        private void MButtonClick(string s)
        {
            switch (s)
            {
                case "MC":
                    bmc.IsEnabled = false; bmc.Opacity = 0.2;
                    bmr.IsEnabled = false; bmr.Opacity = 0.2;
                    memory = 0;
                    TextBlockMemory.Text = "";
                    break;
                case "MR":
                    TextBlockRes.Text = memory.ToString();
                    entered = memory;
                    break;
                case "M+":
                    if (entered != 0)
                    {
                        bmc.IsEnabled = true; bmc.Opacity = 0.5;
                        bmr.IsEnabled = true; bmr.Opacity = 0.5;
                        memory +=Convert.ToDouble(TextBlockRes.Text);
                    }
                    TextBlockMemory.Text = "M: " + memory.ToString();
                    break;
                case "M-":
                    if (entered != 0)
                    {
                        bmc.IsEnabled = true; bmc.Opacity = 0.5;
                        bmr.IsEnabled = true; bmr.Opacity = 0.5;
                        memory -= Convert.ToDouble(TextBlockRes.Text);
                    }
                    TextBlockMemory.Text = "M: " + memory.ToString();
                    break;
                case "MS":
                    if (entered != 0)
                    {
                        bmc.IsEnabled = true; bmc.Opacity = 0.5;
                        bmr.IsEnabled = true; bmr.Opacity = 0.5;
                        memory = Convert.ToDouble(TextBlockRes.Text);
                    }
                    TextBlockMemory.Text = "M: " + memory.ToString();
                    break;
            }

            if (memory == 0)
            {
                bmc.IsEnabled = false; bmc.Opacity = 0.2;
                bmr.IsEnabled = false; bmr.Opacity = 0.2;
                TextBlockMemory.Text = "";
            }
        }
        private void EnterClick(string s)
        {
            if (TextBlockRes.Text == "NaN") { TextBlockRes.Text = "0"; }
            
            switch (s)
            {
                case ".":
                    if (!ifdot)
                    {
                        if (TextBlockRes.Text == "" || ifequal) { TextBlockRes.Text = "0"; ifdot = false; }
                        TextBlockRes.Text += ",";
                        ifdot = true;
                    }
                    break;

                case "notx":
                    if (Convert.ToDouble(TextBlockRes.Text) != 0)
                    {
                        TextBlockRes.Text = (1 / Convert.ToDouble(TextBlockRes.Text)).ToString();
                        if (Convert.ToDouble(TextBlockRes.Text) % 1 == 0) { ifdot = false; } else { ifdot = true; }
                    }
                    break;

                case "plusminus":
                    if (Convert.ToDouble(TextBlockRes.Text) != 0) { TextBlockRes.Text = (-Convert.ToDouble(TextBlockRes.Text)).ToString(); }
                    if (Convert.ToDouble(TextBlockRes.Text) % 1 == 0) { ifdot = false; } else { ifdot = true; }
                    break;

                case "x^2":

                    double x = Convert.ToDouble(TextBlockRes.Text);
                    TextBlockRes.Text = (x * x).ToString();
                    if (Convert.ToDouble(TextBlockRes.Text) % 1 == 0) { ifdot = false; } else { ifdot = true; }
                    break;

                case "x^3":
                    double y = Convert.ToDouble(TextBlockRes.Text);
                    TextBlockRes.Text = (y * y * y).ToString();
                    if (Convert.ToDouble(TextBlockRes.Text) % 1 == 0) { ifdot = false; } else { ifdot = true; }
                    break;

                case "sqrt":
                    TextBlockRes.Text = (Math.Sqrt(Convert.ToDouble(TextBlockRes.Text))).ToString();
                    if (Convert.ToDouble(TextBlockRes.Text) % 1 == 0) { ifdot = false; } else { ifdot = true; }
                    break;

                default:
                    {
                        
                        if (TextBlockRes.Text.Length <= maxlen)
                        {
                            if (TextBlockRes.Text == "0" || ifequal == true) { TextBlockRes.Text = ""; ifdot = false; }
                            TextBlockRes.Text += s;

                        }
                        break;
                    }

            }
            entered = Convert.ToDouble(TextBlockRes.Text);
            if (ifequal)
            {
                ifdot = false;
                ifequal = false;
                ifcleared = true;
            }
        }
        private void PercentClick()
        {
            
            if (entered > 0 && TextBlockLast.Text != "") 
            {
                if (!ifpercent)
                {
                    perc = entered;
                    entered = result * perc / 100;
                    TextBlockRes.Text = entered.ToString();
                    ButtonClickEnabled(false);
                    bperc.Foreground = Brushes.Red;

                }
                else
                {
                    entered = Convert.ToDouble(TextBlockRes.Text) * 100 / result;
                    TextBlockRes.Text = entered.ToString();
                    ButtonClickEnabled(true);
                    bperc.Foreground = Brushes.Black;
                }
            }
        }
        private void ClearClick(string s)
        {
            
            switch (s)
            {
                case "CE":
                    entered = 0;
                    TextBlockRes.Text = "0";
                    ButtonClickEnabled(true);
                    ifdot = false;
                    bperc.Foreground = Brushes.Black;
                    if (ifequal) { result = 0; ifequal = false; ifpercent = false; ifcleared = true; lastop = ""; }
                    break;


                case "C":
                    ButtonClickEnabled(true);
                    bperc.Foreground = Brushes.Black;
                    result = 0; ifdot = false; ifequal = false;
                    entered = 0; ifpercent = false; ifcleared = true;
                    TextBlockLast.Text = "";
                    TextBlockRes.Text = "0";
                    lastop = "";
                    break;

                case "NoForwardSpace":
                    ButtonClickEnabled(true);
                    bperc.Foreground = Brushes.Black;
                    if (TextBlockRes.Text.Length > 0 && TextBlockRes.Text!="NaN")
                    {

                        string m = TextBlockRes.Text;
                        if (m[m.Length - 1] == ',') { ifdot = false; }
                        TextBlockRes.Text = m.Substring(0, TextBlockRes.Text.Length - 1);
                    }
                    if (TextBlockRes.Text == "") { TextBlockRes.Text = "0"; }
                    if (TextBlockRes.Text == "-") { TextBlockRes.Text = "0"; } entered = Convert.ToDouble(TextBlockRes.Text);
                    if (ifequal) { result = entered; }
                    
                    break;
            }
        }
        private void OperatorClick(string s)
        {
            if (TextBlockRes.Text == "0" && s == "-") { TextBlockRes.Text = "-"; isminus = true; }
            else if (TextBlockRes.Text == "-" && s == "-") { TextBlockRes.Text = "0"; isminus = true; }
            else
            {
                if (!ifequal)

                {
                    ButtonClickEnabled(true);
                    bperc.Foreground = Brushes.Black;
                    ifdot = false;



                    if (!ifcleared)
                    {
                        if (!isminus) { DoLastOp(lastop); }

                    }
                    else
                    {
                        result = entered;
                        lastop = s;
                        TextBlockLast.Text = result.ToString() + " " + lastop;
                        ifcleared = false;

                    }
                    
                }
                ifequal = false;
                lastop = s;
                TextBlockLast.Text = result.ToString() + " " + lastop;
                TextBlockRes.Text = "0";
                entered = 0;
            }
        }
        private void EqualClick()
        {
            ButtonClickEnabled(true);
            bperc.Foreground = Brushes.Black;

            if (entered != 0)
            {
                DoLastOp(lastop);
                TextBlockLast.Text = "";
                TextBlockRes.Text = result.ToString();
            }
            else
            {
                if (lastop == "/")
                {
                    TextBlockRes.Text = "NaN";
                    TextBlockLast.Text = "";
                    lastop = "";
                    result = 0;
                    ifcleared = true;
                }
            }

            ifequal = true;
        }
    }
}
