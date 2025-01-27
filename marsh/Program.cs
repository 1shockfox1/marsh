using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

Marsh<string>[] mas = new Marsh<string>[8];
for (int i = 0; i < mas.Length; i++)
{
Console.Write("Введите Начало маршрута:");
string nach = Console.ReadLine()!;
Console.Write("Введите конец маршрута:");
string kon = Console.ReadLine()!;
Console.Write("Введите номер маршрута:");
decimal nomer = decimal.Parse(Console.ReadLine()!);
mas[i] = new Marsh<string>(nach, kon, nomer); 
}
Array.Sort(mas);

Console.WriteLine("\nОтсортированные маршруты по конечному пункту:");
foreach (var route in mas)
{
    Console.WriteLine(route);
}
class Marsh<T> : ICloneable, IComparable
{
    public T Nach { get; set; }

    public T Kon { get; set; }

    public decimal Nomer { get; set; }

    public Marsh(T nach, T kon, decimal nomer)
    {
        Nach = nach;
        Kon = kon;
        Nomer = nomer;
    }
    public override string ToString()
    {
        return $"Начало марщрута:{Nach}, конец маршрута:{Kon}, номер маршрута:{Nomer}";
    }
    public object Clone() => new Marsh<T>(Nach, Kon, Nomer);
    public int CompareTo(object? obj)
    {
        if (obj is Marsh<int>)
        {
            Marsh<int> temp = (obj as Marsh<int>)!;
            return Kon!.ToString()!.CompareTo(temp.Kon);
        }
        else if (obj is Marsh<string>)
        {
            Marsh<string> temp = (obj as Marsh<string>)!;
            return Kon!.ToString()!.CompareTo(temp.Kon);
        }
        else throw new ArgumentException("Некорректное значение параметра");
    }
}
