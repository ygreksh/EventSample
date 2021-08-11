namespace EventSample
{
    public class Account
    {
        public delegate void AccountHandler(string message);

        public event AccountHandler Notify;
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
            Notify?.Invoke($"Счет пополнен на {sum}. Итого: {Sum}");
        }
        // списание средств со счета
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                Notify?.Invoke($"Счет уменьшен на {sum}. Итого: {Sum}");
            }
            else
            {
                Notify?.Invoke($"На счету недостаточно денег для снятия. Текущий баланс {Sum}");
            }
        }
    }
}