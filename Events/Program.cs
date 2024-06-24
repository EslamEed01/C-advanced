namespace Events
{
    // we will use stock example
    public class Program
    {
        static void Main(string[] args)
        {
            // clled subscriber
            var stock = new stock("amazon");
            stock.price = 100;
            stock.onpricechanged += Stock_onpricechanged;
            Console.WriteLine($"stock before change ${stock.price}");
            stock.changestockprice(0.05m);// green 
            //stock.changestockprice(0.0m); // gray
           // stock.changestockprice(-0.05m); // red
           // make unsubscribe 
            //stock.onpricechanged -= Stock_onpricechanged;
             //stock.changestockprice(-0.05m); // no changes 
            Console.WriteLine($"stock after change ${stock.price}");
        }

        private static void Stock_onpricechanged(stock stock, decimal oldprice)
        {
            if (stock.price > oldprice)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"stock name {stock.name}: {stock.price}");
            }
            else if(stock.price < oldprice)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"stock name {stock.name}: {stock.price}");


            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"stock name {stock.name}: {stock.price}");
            }

        }
    }

    public delegate void stochpricehandler(stock stock, decimal oldprice);


    // called publisher
    public class stock
    {
        public string name { get; set; }
        public decimal price { get; set; }

        public event stochpricehandler onpricechanged;
        public stock(string stockname)
        {
            name = stockname;
        }
        public void changestockprice(decimal  percent)
        {
            decimal oldprice=this.price;
            this.price += Math.Round(this.price * percent,2);
            if(onpricechanged!= null)
            {
                onpricechanged(this, oldprice);// firing the event
            }

        }






    }
}
