using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml 
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentInput = "0";
        private string currentOperation = "";
        private double firstNumber = 0;
        private double secondNumber = 0;
        private bool IsNewCalculation = true;
        private bool isOperationJustPresed = false;
        private bool iSDecimal = false;
        private bool Devision = false;
        private bool Angular = false;
        private double results = 0;
        private bool Equal = false;
        public MainWindow()
        {

            InitializeComponent();
            ResultTextBlock.Text = currentInput;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        }


        private void NumbButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string digit = button.Content?.ToString() ?? "";

            if (IsNewCalculation || currentInput == "0" || isOperationJustPresed)
            {
                currentInput = digit;
                IsNewCalculation = false;
                isOperationJustPresed = false;

            }
            else
            {
                currentInput += digit;

            }


            ResultTextBlock.Text = currentInput;
            Debug.WriteLine($" Input : {currentInput}" +
                $" Op : {currentOperation}" +
                $" , 1st : {firstNumber}" +
                $" , 2nd : {secondNumber}" +
                $" , Equal : {Equal}" +
                $" , NewCalc :  {IsNewCalculation} " +
                $" , OpPressed : {isOperationJustPresed}" +
                $" , Decimal : {iSDecimal}" +
                $" , Angular : {Angular}" +
                $" , Devision : {Devision}");



        }


        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string Operation = button.Content?.ToString() ?? "";
            if (!isOperationJustPresed)
            {
                if (!string.IsNullOrEmpty(currentOperation))
                {
                    CalculateResult();
                }
                else
                {
                    firstNumber = double.Parse(currentInput);
                }
            }
            currentOperation = Operation;
            isOperationJustPresed = true;

        }

        private void CalculateResult()
        {
            double secondNumber = double.Parse(currentInput);


            switch (currentOperation)
            {
                case "+":
                    OperationTextBlock.Text = $"{firstNumber} + {secondNumber} =";
                    results = firstNumber + secondNumber;
                    break;
                case "-":
                    OperationTextBlock.Text = $"{firstNumber} - {secondNumber} =";
                    results = firstNumber - secondNumber;
                    break;
                case "x":
                    OperationTextBlock.Text = $"{firstNumber} X {secondNumber} =";
                    results = firstNumber * secondNumber;
                    break;
                case "÷":
                    if (secondNumber != 0)
                    {
                        OperationTextBlock.Text = $"{firstNumber} ÷ {secondNumber} =";
                        results = firstNumber / secondNumber;
                    }
                    else
                    {
                        MessageBox.Show("Canot divide by zero", "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
            }

            if (iSDecimal || Devision || Angular)
            {
                if (Angular)
                {
                    currentInput = results.ToString("N6");
                    Angular = false;
                }
                else
                {
                    currentInput = results.ToString("N2");
                }
                iSDecimal = false;
                Devision = false;

            }
            else if (!iSDecimal || !Devision || !Angular)
            {
                currentInput = results.ToString("N0");
            }



            ResultTextBlock.Text = currentInput;

            firstNumber = results;

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            currentInput = "0";
            currentOperation = "";
            firstNumber = 0;
            isOperationJustPresed = false;
            IsNewCalculation = true;
            ResultTextBlock.Text = currentInput;
            OperationTextBlock.Text = "";
            Equal = false;
            iSDecimal = false;
            results = 0;

        }

        private void PlusMinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isOperationJustPresed && !IsNewCalculation && currentInput != "0")
            {
                currentInput = currentInput.StartsWith("-") ? currentInput[1..] : "-" + currentInput;
            }
            ResultTextBlock.Text = currentInput;

        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isOperationJustPresed && !IsNewCalculation)
            {
                double number = double.Parse(currentInput);
                number /= 100;
                currentInput = number.ToString();
                ResultTextBlock.Text = currentInput;


            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isOperationJustPresed && currentInput.Length > 0 && !IsNewCalculation)
            {
                currentInput = currentInput[..^1];
                if (string.IsNullOrEmpty(currentInput) || currentInput == "-")
                {
                    currentInput = "0";
                }
                ResultTextBlock.Text = currentInput;

            }

        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            iSDecimal = true;
            if (isOperationJustPresed)
            {
                currentInput = "0.";
                isOperationJustPresed = false;
            }
            else if (!currentInput.Contains('.'))
            {
                IsNewCalculation = false;
                currentInput += ".";

            }
            ResultTextBlock.Text = currentInput;



        }


        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            Equal = true;
            if (!string.IsNullOrEmpty(currentOperation) && !isOperationJustPresed)
            {
                CalculateResult();
                currentOperation = "";
                IsNewCalculation = true;
                isOperationJustPresed = true;
            }

        }



        private void SquareButton_Click(object sender, RoutedEventArgs e)
        {
            double result;
            if (Equal)
            {
                result = results * results;

                OperationTextBlock.Text = $"{results}² = ";
                currentInput = result.ToString();
                firstNumber = result;
                ResultTextBlock.Text = result.ToString();
                Equal = false;
            }

            if (isOperationJustPresed)
            {
                currentInput = "0";
                OperationTextBlock.Text += "²";
            }
            else if (!IsNewCalculation)
            {
                double Number = double.Parse(currentInput);
                result = Number * Number;

                OperationTextBlock.Text = $"{Number}²";
                if (iSDecimal)
                {
                    currentInput = result.ToString("N2");
                }
                else
                {
                    currentInput = result.ToString("N0");
                }
                ResultTextBlock.Text = currentInput;
                if (string.IsNullOrEmpty(currentOperation))
                {
                    firstNumber = result;
                }
                else
                {
                    secondNumber = result;
                }
                IsNewCalculation = true;
            }

        }

        private void SquareRootButton_Click(object sender, RoutedEventArgs e)
        {
            double ResultS;
            if (Equal)
            {
                ResultS = Math.Sqrt(results);
                OperationTextBlock.Text = $"√{results} = ";
                firstNumber = ResultS;
                currentInput = ResultS.ToString();
                ResultTextBlock.Text = ResultS.ToString("N4");
                Equal = false;

            }

            if (isOperationJustPresed)
            {
                currentInput = "0";
                OperationTextBlock.Text += "√";
            }
            else if (!IsNewCalculation)
            {
                double Number = double.Parse(currentInput);
                ResultS = Math.Sqrt(Number);

                OperationTextBlock.Text = $"√{Number}";
                if (string.IsNullOrEmpty(currentOperation))
                {
                    firstNumber = ResultS;
                }
                else
                {
                    secondNumber = ResultS;
                }


                if (iSDecimal)
                {
                    currentInput = ResultS.ToString("N2");
                }
                else
                {
                    currentInput = ResultS.ToString("N0");
                }
                ResultTextBlock.Text = currentInput;

                IsNewCalculation = true;
            }
        }

        private void DivisionButton_Click(object sender, RoutedEventArgs e)
        {
            Devision = true;
            double result;
            if (Equal)
            {
                result = 1 / results;
                OperationTextBlock.Text = $"{results}⁻¹ = ";
                currentInput = result.ToString("N4");
                firstNumber = result;
                ResultTextBlock.Text = result.ToString("N4");
                Equal = false;
            }


            if (isOperationJustPresed)
            {
                currentInput = "0";
                OperationTextBlock.Text += "⁻¹";
            }
            else if (!IsNewCalculation)
            {
                double Number = double.Parse(currentInput);
                result = 1 / Number;
                if (Number == 0)
                {
                    MessageBox.Show("Cannot devide by zero ", "ERROR"
                        , MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                OperationTextBlock.Text = $"{Number}⁻¹";

                currentInput = result.ToString("N2");

                if (string.IsNullOrEmpty(currentOperation))
                {
                    firstNumber = result;
                }
                else
                {
                    secondNumber = result;
                }
                ResultTextBlock.Text = currentInput;

                IsNewCalculation = true;


            }
        }

        private void AngularButton_Click(object sender, RoutedEventArgs e)
        {
            double rezult = 0;

            Angular = true;
            Button button = sender as Button;
            string operation = button.Content?.ToString() ?? "";
            if (Equal)
            {
                double radians = results * Math.PI / 180.0;
                switch (operation)
                {
                    case "sin(x)":
                        OperationTextBlock.Text = $"Sin({results}) =  ";
                        rezult = Math.Sin(radians);
                        break;
                    case "cos(x)":
                        OperationTextBlock.Text = $"Cos({results}) =  ";
                        rezult = Math.Cos(radians);
                        break;
                    case "tan(x)":
                        OperationTextBlock.Text = $"Tan({results}) =   ";
                        rezult = Math.Tan(radians);
                        break;
                }
                Equal = false;
                currentInput = rezult.ToString("N4");
                firstNumber = rezult;
                ResultTextBlock.Text = rezult.ToString("N4");
            }

            if (isOperationJustPresed)
            {
                currentInput = "0";

            }
            else if (!IsNewCalculation)
            {
                double Number = double.Parse(currentInput);
                double Radians = Number * Math.PI / 180.0;

                switch (operation)
                {
                    case "sin(x)":
                        OperationTextBlock.Text = $"Sin({Number})";
                        rezult = Math.Sin(Radians);
                        break;
                    case "cos(x)":
                        OperationTextBlock.Text = $"Cos({Number})";
                        rezult = Math.Cos(Radians);
                        break;
                    case "tan(x)":
                        OperationTextBlock.Text = $"Tan({Number})";
                        rezult = Math.Tan(Radians);
                        break;
                }
                currentInput = rezult.ToString("N4");
                if (string.IsNullOrEmpty(currentOperation))
                {
                    firstNumber = rezult;
                }
                else
                {
                    secondNumber = rezult;
                }
                ResultTextBlock.Text = currentInput;
                IsNewCalculation = true;

            }


        }
    }
}