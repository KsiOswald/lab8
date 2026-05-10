using System;

internal class TypeCheck
{
    public static int IsInteger()
    {
        int num = 0;
        while (!int.TryParse(Console.ReadLine(), out num))
        {
            Console.Write("Неверный формат! Повторите попытку: ");
        }
        return num;
    }
    public static double IsDouble()
    {
        double num = 0;
        while (!double.TryParse(Console.ReadLine(), out num))
        {
            Console.Write("Неверный формат! Повторите попытку: ");
        }
        return num;
    }
}

