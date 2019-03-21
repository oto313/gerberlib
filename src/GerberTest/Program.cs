using System;
using GerberLib;

namespace GerberTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Parser("a");
            p.GetNextCommand();
            Console.WriteLine("Hello World!");
        }
    }
}
