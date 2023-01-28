using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciopasswordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variables
            string userName, password, option;

            Console.WriteLine("\t\tRegistro de usuario\n\n");
            Console.Write("Ingrese nombre de usuario: ");
            userName= Console.ReadLine();

            Console.Write("Desea que se le genere una contraseña? [S/N]: ");
            option= Console.ReadLine();
            option = option.ToUpper();

            switch(option)
            {
                case "S":
                    Password userPassword = new Password();
                    password = userPassword.passwordGenerator();
                    Console.WriteLine($"\n{userName} tiene la contraseña {password}");
                    Console.WriteLine("Presione cualquier tecla para finalizar.");
                    Console.ReadKey();
                    break;
                case "N":
                    break;
            }
        }
    }

    class Password
    {
        //Variables
        string numbers = "0123456789";
        string lowercaseLetters = "abcdefghijklmnopqrstuvwxz";
        string uppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVXYZ";
        string specialCharacters = "$#%!?&";

        //Contadores
        int accontantNumbers = 0, accontantLowercase = 0, accontantUppercase = 0, accontantSpecial = 0;

        //Funcion para generar contra
        public string passwordGenerator()
        {
            //Variable guardar contra
            string savedPassword = "";

            Random random = new Random();
            int passwordLength = random.Next(8, 12);

            //Variables con porcentajes de probabilidad
            double hasNumber = passwordLength * .15;
            double hasLowercase = passwordLength * .35;
            double mayTener = passwordLength * .35;
            double espTener = passwordLength * .15;

            //Variable tipo Char almacena cada caracter
            char chosenCharacters;

            while (savedPassword.Length < passwordLength)
            {
                switch (random.Next(0, 4))
                {
                    case 0:
                        if (accontantNumbers < hasNumber)
                        {
                            chosenCharacters = numbers[random.Next(numbers.Length)];
                            savedPassword += chosenCharacters;
                            accontantNumbers++;
                        }
                        break;
                    case 1:
                        if (accontantLowercase < hasLowercase)
                        {
                            chosenCharacters = lowercaseLetters[random.Next(lowercaseLetters.Length)];
                            savedPassword += chosenCharacters;
                            accontantLowercase++;
                        }
                        break;
                    case 2:
                        if (accontantUppercase < mayTener)
                        {
                            chosenCharacters = uppercaseLetters[random.Next(uppercaseLetters.Length)];
                            savedPassword += chosenCharacters;
                            accontantUppercase++;
                        }
                        break;
                    case 3:
                        if (accontantSpecial < espTener)
                        {
                            chosenCharacters = specialCharacters[random.Next(specialCharacters.Length)];
                            savedPassword += chosenCharacters;
                            accontantSpecial++;
                        }
                        break;
                }
            }
            return savedPassword;
        }
    }
}
