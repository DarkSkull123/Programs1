using System;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
namespace Program
{
    class Calculator
    {
        static decimal Z = 0;
        static decimal X = 0;
        static decimal Y = 0;
        static char key;
        static char KeY;
        static decimal Output;
        static decimal output;
        static void Main()
        {
            Console.WriteLine("|----------------------------------------------------------------|");
            Console.WriteLine("|---------------------------WELCOME------------------------------|");
            Console.WriteLine("|----------------------------------------------------------------|");
            Console.WriteLine("|------- IF YOU WANT TO CLEAR EVERYTHING PRESS      ----> (1) <--|");
            Console.WriteLine("|------- IF YOU WANT TO START AGAIN PRESS           ----> (2) <--|");
            Console.WriteLine("|------- IF YOU WANT TO CONTINUE CALCULATING PRESS  ----> (3) <--|");
            Console.WriteLine("|------- IF YOU WANT TO SQUARE THE OUTPUT PRESS     ----> (4) <--|");
            Console.WriteLine("|------- IF YOU WANT TO ROOT THE OUTPUT PRESS       ----> (5) <--|");
            Console.WriteLine("|------> (FOR DECIMAL VALUES PLEASE USE (,)) <-------------------|");
            Console.WriteLine("|------> (AFTER INPUTTING THE NUMBERS PLEASE PRESS ENTER <-------|");
            Console.WriteLine("|----------------------------------------------------------------|");


            Console.WriteLine(" ");
            Console.WriteLine("|----------------------------------------------------------------|");
            Console.WriteLine("|------------------- ENTER FIRST NUMBER (A) ---------------------|");
            Console.WriteLine("|----------------------------------------------------------------|");
            bool resoult = decimal.TryParse(Console.ReadLine(), out decimal X);
            

            while (resoult == false)
              {
                Console.WriteLine("|----------------------------------------------------------------|");
                Console.WriteLine("|---------------------------- ERROR -----------------------------|");
                Console.WriteLine("|----------------------------------------------------------------|");

                Console.WriteLine("|----------------------------------------------------------------|");
                Console.WriteLine("|------------------- ENTER FIRST NUMBER (A) ---------------------|");
                Console.WriteLine("|----------------------------------------------------------------|");
                resoult = decimal.TryParse(Console.ReadLine(), out X);
              }

           char key = ChoseOperation();
              Console.WriteLine("|----------------------------------------------------------------|");
            Console.WriteLine("\n|------------------- ENTER SECOND NUMBER (B) --------------------|");
              Console.WriteLine("|----------------------------------------------------------------|");
            bool Resoult = decimal.TryParse(Console.ReadLine(), out decimal Y);

              while (Resoult == false)
              {
                Console.WriteLine("|----------------------------------------------------------------|");
                Console.WriteLine("|---------------------------- ERROR -----------------------------|");
                Console.WriteLine("|----------------------------------------------------------------|");

                Console.WriteLine("|----------------------------------------------------------------|");
                Console.WriteLine("|-------------------- ENTER SECOND NUMBER (B) -------------------|");
                Console.WriteLine("|----------------------------------------------------------------|");
                Resoult = decimal.TryParse(Console.ReadLine(), out Y);
              }
           

            Calculate(X , Y , key);
            Console.WriteLine("|----------------------------------------------------------------|");
            Console.WriteLine("|-------------------------- RESULT ------------------------------|");
            Console.WriteLine("|----------------------------=" + " " + Z + " " + "=------------------------------|");
            Console.WriteLine("|----------------------------------------------------------------|");

            Menu();



        }

         static char ChoseOperation()
         {
            Console.WriteLine("|----------------------------------------------------------------|");
            Console.WriteLine("|---- what operation do you want to chose ( + , - , * , / )? ----|".ToUpper());
            Console.WriteLine("|----------------------------------------------------------------|");

            while (true)
            {
                key = Console.ReadKey(intercept : true).KeyChar;
                if ("+ - */".Contains(key))
                    break;
                  Console.WriteLine("|----------------------------------------------------------------|");
                Console.WriteLine("\n|----------------- Please input corect operator -----------------|".ToUpper());
                  Console.WriteLine("|----------------------------------------------------------------|");
            }
            Console.WriteLine("|---------------------------->" + " " + key + " " + "<-------------------------------|");
            return key;
           
         }
        private static decimal Calculate(decimal X , decimal Y , char key)
        {
            
            switch (key)
            {
                case '+':
                    Console.WriteLine("|---------------------------|");
                    Console.WriteLine("|---------- A + B ----------|");
                    Console.WriteLine("|---------------------------|");
                    Z = X + Y;
                    break;
                case '-':
                    Console.WriteLine("|---------------------------|");
                    Console.WriteLine("|---------- A - B ----------|");
                    Console.WriteLine("|---------------------------|");
                    Z = X - Y;
                    break;
                case '*':
                    Console.WriteLine("|---------------------------|");
                    Console.WriteLine("|---------- A * B ----------|");
                    Console.WriteLine("|---------------------------|");
                    Z = X * Y;
                    break;
                case '/':
                    if ((X == 0) || (Y == 0))
                    {
                        Console.WriteLine("|---------------------------|");
                        Console.WriteLine("|------ !!! EROR !!! -------|");
                        Console.WriteLine("|---------------------------|");
                        Output = 00 ;
                        output = 00;
                        Z = 00;
                    }
                    else
                    {
                        Console.WriteLine("|---------------------------|");
                        Console.WriteLine("|---------- A / B ----------|");
                        Console.WriteLine("|---------------------------|");
                        Z = X / Y;
                    }
                    break;

            }
            return Z;

        }
        static void Menu()
        {
            bool q = false;

            ChoseKey();
            if (KeY == null)
            {
                q = false;
            }
            else
            {
                q = true;
            }
            if (q == true)
            {
                switch (KeY)
                {
                   
                    case '1':
                        Console.Clear();
                        Console.WriteLine("|---------------------------|");
                        Console.WriteLine("|-------> THANK YOU <-------|");
                        Console.WriteLine("|---------------------------|");
                        
                        break;
                    case '2':
                        Console.Clear();
                        Main();
                        break;
                    case '3':
                        Continue();
                        break;
                    case '4':
                        Square();
                        break;
                    case '5':
                        Root();
                        break;
                    case '+':
                        Console.WriteLine("|----------------------------------------------------------------|");
                        Console.WriteLine("|----------------------------> + <-------------------------------|");
                        Console.WriteLine("|----------------------------------------------------------------|");
                        Continue();
                        break;
                    case '-':
                        Console.WriteLine("|----------------------------------------------------------------|");
                        Console.WriteLine("|----------------------------> - <-------------------------------|");
                        Console.WriteLine("|----------------------------------------------------------------|");
                        Continue();
                        break;
                    case '*':
                        Console.WriteLine("|----------------------------------------------------------------|");
                        Console.WriteLine("|----------------------------> * <-------------------------------|");
                        Console.WriteLine("|----------------------------------------------------------------|");
                        Continue();
                        break;
                    case '/':
                        Console.WriteLine("|----------------------------------------------------------------|");
                        Console.WriteLine("|----------------------------> / <-------------------------------|");
                        Console.WriteLine("|----------------------------------------------------------------|");
                        Continue();
                        break;
                        
                    default:
                        Console.WriteLine("|---------------------------|");
                        Console.WriteLine("|------> WRONG INPUT <------|");
                        Console.WriteLine("|---------------------------|");
                        q = false;
                        Menu();
                        break;
                }

            }
            else
            {
                Console.WriteLine("|---------------------------|");
                Console.WriteLine("|------- wrong input -------|".ToUpper());
                Console.WriteLine("|---------------------------|");
                q = false;
            }
            
        }

         static void Root()  // DELUJE SAMO KO JE VREDNST BILA PREJ KVADRIRANA!!!!!!!!
        {
            if( Z <= 0)
            {
                Console.WriteLine("|----------------------------------------------------------------|");
                Console.WriteLine("|---------------------------- ERROR -----------------------------|");
                Console.WriteLine("|----------------------------------------------------------------|");
            }
            
            double z = (double)Z; 
            Z = (decimal)Math.Sqrt(z); 
            Console.WriteLine("|----------------------------------------------------------------|");
            Console.WriteLine("|----------------------- ROOTED RESULT --------------------------|");
            Console.WriteLine("|----------------------------=" + " " + Z + " " + "=------------------------------|");
            Console.WriteLine("|----------------------------------------------------------------|");
            Menu();
        }

        static void Square()
        {
            Z = Z * Z;
            Console.WriteLine("|----------------------------------------------------------------|");
            Console.WriteLine("|----------------------- SQUARED RESULT -------------------------|");
            Console.WriteLine("|----------------------------=" + " " + Z + " " + "=------------------------------|");
            Console.WriteLine("|----------------------------------------------------------------|");
            Menu();
        }

        private  static void Continue()
        {
            key = KeY; 
            ChoseOperation();
              Console.WriteLine("|----------------------------------------------------------------|");
            Console.WriteLine("\n|------------------------- CHOSE NUMBER -------------------------|");
              Console.WriteLine("|----------------------------------------------------------------|");
            bool resoult = decimal.TryParse(Console.ReadLine(), out decimal Y);

            while (resoult == false)
            {
                Console.WriteLine("|---------------------------|");
                Console.WriteLine("|----------- ERROR ---------|");
                Console.WriteLine("|---------------------------|");

                Console.WriteLine("|---------------------------|");
                Console.WriteLine("|------- enter number ------|".ToUpper());
                Console.WriteLine("|---------------------------|");
                resoult = decimal.TryParse(Console.ReadLine(), out Y);
            }
 
            decimal output = Calculate( Z , Y , key);
            Console.WriteLine("|----------------------------------------------------------------|");
            Console.WriteLine("|--------------------------- RESULT -----------------------------|");
            Console.WriteLine("|----------------------------=" + " " + output + " " + "=------------------------------|");
            Console.WriteLine("|----------------------------------------------------------------|");
            Menu();
        }
        static char ChoseKey()
        {
            while (true)
            {
                
                    KeY = Console.ReadKey(intercept : true).KeyChar;
                if (char.IsDigit(KeY) || " + - * / ".Contains(KeY))
                    break;
                  Console.WriteLine("|----------------------------------------------------------------|");
                Console.WriteLine("\n|------------------- Please chose corect input ------------------|");
                  Console.WriteLine("|----------------------------------------------------------------|");
            }
            return KeY;
        }

    }
}
