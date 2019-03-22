using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaWithEvents
{
    //*********** Класс который инкапсулирует (содержит внутри себя) все данные о событии ***********
    public class AccountEventArgs  
    {
        //********** Свойства **********
        public string Message {get;}
        public int Sum{ get; }

        //*********** Конструктор экземпляров класса ***********
        public AccountEventArgs(string message,int sum)
        {
            Message = message;
            Sum = sum;
        }
    }
}
