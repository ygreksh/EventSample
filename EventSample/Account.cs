using System;

namespace EventSample
{
    public class Account
    {
        public delegate void AccountHandler(string message);
        private event AccountHandler _notify;
        public event AccountHandler Notify
        {
            add
            {
                _notify += value;
                Console.WriteLine($"{value.Method.Name} добавлен");
            } 
            remove
            {
                _notify -= value;
                Console.WriteLine($"{value.Method.Name} удален");
            }
        }
        public Account(int sum)
        {
            Sum = sum;
        }
        // сумма на счете
        public int Sum { get; private set;}
        // добавление средств на счет
        public void Put(int sum)    
        {
            Sum += sum;
            _notify?.Invoke($"Счет пополнен на {sum}. Итого: {Sum}");
        }
        // списание средств со счета
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                _notify?.Invoke($"Счет уменьшен на {sum}. Итого: {Sum}");
            }
            else
            {
                _notify?.Invoke($"На счету недостаточно денег для снятия. Текущий баланс {Sum}");
            }
        }
    }
}