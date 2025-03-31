// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;

public class stack
{
    public static void Main()
    {
        // Stack creation and initialization
        Stack myStack = new Stack();
        myStack.Push("Hello");
        myStack.Push("World");
        myStack.Push("!");

        // Stack properties and values
        Console.WriteLine("myStack");
        Console.WriteLine("\tCount:     {0} ", myStack.Count);
        Console.WriteLine("\tValues:");
        PrintValues(myStack);
    }

    // PrintValues Method
    public static void PrintValues(IEnumerable myCollection)
    {
        foreach (object obj in myCollection)
        {
            Console.WriteLine("\t\t{0}", obj);
        }
    }
}
