using System;

namespace Chp6_CashRegister5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Customer!");

            double purchaseAmount = Convert("Enter Purchase amount: ");
            double paymentAmount = Convert("Enter Payment Amount:");
            double changeDue = paymentAmount - purchaseAmount;

            while (changeDue < 0)
            {
                Console.WriteLine($"Amount still due is: {changeDue}");
                purchaseAmount = Convert("\n Please re-enter the purchase amount\n");
                paymentAmount = Convert("\n Please re-enter the payment amount\n");
                changeDue = paymentAmount - purchaseAmount;
            }

            if (paymentAmount - purchaseAmount == 0)
            {
                Console.WriteLine("Payment Accepted!");
            }

            else if (paymentAmount > purchaseAmount)
            {
                Console.WriteLine($"Change Due is: ${changeDue}");
                ChangeAmount(changeDue);
            }

            Console.WriteLine("\n Thank you.\t Have a nice day!");

        }  //End of Main

        private static double Convert(string input)
        {

            double convertedAmount = 0;

            while (convertedAmount <= 0)
            {
                Console.WriteLine(input);

                try
                {
                    convertedAmount = double.Parse(Console.ReadLine());

                }

                catch (Exception)
                {
                    convertedAmount = -1;
                }

                if (convertedAmount <= 0)
                {
                    Console.WriteLine($"Input Error\n");
                }
            }

            return convertedAmount;
        } //End of Convert

        private static double Condense(double changeDue, double denominator)
        {
            double quantity = (int)(changeDue / denominator);
            double refund = Math.Round(changeDue, 2) % denominator;

            if (quantity != 0)

                Console.WriteLine($"\n Customer will receive ({quantity}) {denominator}'s. Amount owed to customer is {Math.Round(refund, 2)}");
            return refund;



        }  //End of Condense


        private static void ChangeAmount(double changeDue)
        {
            double changeDueTwenties = Condense(changeDue, 20);

            double changeDueTens = Condense(changeDueTwenties, 10);

            double changeDueFives = Condense(changeDueTens, 5);

            double changeDueOnes = Condense(changeDueFives, 1);

            double changeDueQuarters = Condense(changeDueOnes, 0.25);

            double changeDueDimes = Condense(changeDueQuarters, 0.10);

            double changeDueNickels = Condense(changeDueDimes, 0.05);

            double changeDuePennies = Condense(changeDueNickels, 0.01);

        } //End of Change Amount


    
    }
}
