using Programm;

class Program
{
    static void Main(string[] args)
    {
        Heap heap = new Heap(); 
        heap.Add(10);
        heap.Add(5);
        heap.Add(20);
        heap.Add(3);

        Console.WriteLine("Минимум: " + heap.RemoveMin());  // Ожидается 3
        Console.WriteLine("Куча после удаления минимума: " + heap);

        heap.DecreaseKey(1, 4);  // Уменьшаем элемент
        Console.WriteLine("Куча после уменьшения элемента: " + heap);

        heap.IncreaseKey(0, 15);  // Увеличиваем элемент
        Console.WriteLine("Куча после увеличения элемента: " + heap);
    }
}