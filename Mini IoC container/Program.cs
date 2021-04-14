using System;

namespace Mini_IoC_container
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            container.Register<IRight, TestClass>();
            var test = container.Resolve<IRight>();
            Console.WriteLine(test.GetType().GetMethod("Message").Name);
        }
    }
}
