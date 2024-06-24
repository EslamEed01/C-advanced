namespace Delegates
{
    // delegate : pointer used call methode knowing only the parameter of this methode
    // without know what methode or location 
    // delegate must have the same parameter type and same return type with methode
    public class Program
    {
        delegate int calculatedlg(int num1, int num2);
        static void Main(string[] args)
        {
            int num1 = 10;
            int num2 = 5;
            calculatedlg dlg = Add;// way
            calculate(num1, num2, dlg);
           
            Console.WriteLine("-----------------------------------------");
            dlg += multiply;
            dlg += sub;// excuate add,multiply ,sub and return last one" sub"
            calculate(num1, num2, dlg);
            Console.WriteLine("-----------------------------------------");


            calculate(num1, num2, dlg);
            calculate(num1,num2,Add);// another way
            // another way if methode is simple and private for this class 
            calculate(num1, num2, delegate (int num1, int num2) { return num1 + num2; });
            // updated with lampda expression to 
            calculate(num1, num2,( num1, num2) =>  num1 + num2);

            calculate(num1, num2,sub);
            calculate(num1, num2, multiply);
        }


        static void calculate(int num1,int num2, calculatedlg dlg )
        {

            int result=dlg(num1,num2);
           

            Console.WriteLine( $"Result ={ result}");

        }

        static int Add(int num1, int num2)
        {
            return num1 + num2;
        }
        static int sub(int num1, int num2)
        {
            return num1 - num2;
        }
        static int multiply(int num1, int num2)
        {
            return num1 * num2;
        }








    }
}
