using System.Collections;

namespace IEnumerable_IEnumerator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var ints = new fiveinteger(1, 2, 3, 4, 5);
            //foreach (var i in ints)
            //{
            //    Console.WriteLine(i);
            //}
            //------------------------------------------------------------------//

            var temps=new List<tempreture>();
            Random rnd=new Random();
            for(var i =0; i<100;i++)
            {
                temps.Add(new tempreture(rnd.Next(1, 100)));

            }
          
            temps.Sort();

            foreach (var i in temps)
            {
                Console.WriteLine(i.values);
            }


        }

        public class fiveinteger : IEnumerable
        {
            int[] values;
            public fiveinteger(int n1, int n2, int n3, int n4, int n5)
            {
                values = new[] { n1, n2, n3, n4, n5 };
            }

            public IEnumerator GetEnumerator()
            {
                foreach (var i in values)
                {
                    yield return i;
                }
            }
        }
        public class tempreture:IComparable
        {
            public int values;
            public tempreture(int vlaue)
            {
                values = vlaue;

            }
            public int Value => values;

            public int CompareTo(object? obj)
            {
                var temp = obj as tempreture;
                return this.Value.CompareTo(temp.Value);

            }
        }
    }
}
