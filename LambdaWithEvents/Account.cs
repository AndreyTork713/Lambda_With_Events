﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaWithEvents
{
    class Account
    {
        public int _sum;//Переменная для хранения суммы на счете

        //********** События для класса Account **********
        public event AccountStateHandler Added;
        public event AccountStateHandler WithdrawN;

        //********** Конструктор **********
        public Account(int sum)
        {
            _sum = sum;
        }

        //********** Методы для добавления (Put) и снятия (Withdraw) средств со счета **********
        public void Put(int sum)
        {
            _sum += sum;//Когда происходит внесение средств на счет - возникает событие Added**
            if (Added != null)//Проверка: Added должен ссылаться на конкретный (не NULL), в данном случае анонимный метод
            {
                Added(this,new AccountEventArgs($"На счет поступило: {sum}",sum));//Событие Added**
                Console.WriteLine($"Остаток средств на счете: {_sum}");
            }
        }
        public void Withdraw(int sum)
        {
            if (_sum >= sum)
            {
                _sum += sum; //Когда происходит снятие средств со счета - возникает событие WithdrawN***
                if (WithdrawN != null)//Проверка: WithdrawN должен ссылаться на конкретный (не NULL), в данном случае анонимный метод
                {
                    WithdrawN(this, new AccountEventArgs($"Со счета снято: {sum}", sum));//Событие WithdrawN***
                    Console.WriteLine($"Остаток средств на счете: {_sum}");
                }
            }
            else
            {
                Console.WriteLine("На счете не достаточно средств!");
                Console.WriteLine($"Остаток средств на счете: {_sum}");
            }
            
        }
    }
}
