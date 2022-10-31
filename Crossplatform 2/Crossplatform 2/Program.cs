//Немає перевірок та роботи з файлами, введення даних відбувається відповідно до умови завдання номер 30

long n, a, b, c;
long[] mas = new long [5002];

n = Convert.ToInt32(Console.ReadLine());

for (int i = 1; i <= n + 2; i++)
{
    mas[i] = 0;
}
for (int i = 1; i <= n; i++)
{
    a = Convert.ToInt32(Console.ReadLine());
    b = Convert.ToInt32(Console.ReadLine());
    c = Convert.ToInt32(Console.ReadLine());
    if (mas[i] > a + mas[i - 1])
    { 
        mas[i] = a + mas[i - 1];
    }
    if (mas[i+1] > b + mas[i - 1])
    {
        mas[i + 1] = b + mas[i - 1];
    }
    if (mas[i+2] > c + mas[i - 1])
    {
        mas[i + 2] = c + mas[i - 1];
    }
}
Console.WriteLine(mas[n]);