using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaWithEvents
{
    public delegate void AccountStateHandler(object sender, AccountEventArgs e); //"object sender" - какой-то объект вызывающий событие

    class Program
    {

        static void Main(string[] args)
        {
            int a=45785;
            Account account = new Account(a);
            account.Added += (sender, e) => { Console.WriteLine($"На счет поступило: {e.Sum}"); };
            account.WithdrawN += (sender, e) => { Console.WriteLine($"Со счета снято: {e.Sum}"); };
            Console.WriteLine($"На вашем счете: {a}");
            Console.WriteLine("Введите сумму транзакции...");
            int b = Convert.ToInt32(Console.ReadLine());
            if (b > 0)
            {
                    account.Put(b);
            }
            else
            {
                account.Withdraw(b);
            }
            

            Console.WriteLine();
            Console.WriteLine("Click! on continue...");
            Console.ReadLine();
        }
    }
}
