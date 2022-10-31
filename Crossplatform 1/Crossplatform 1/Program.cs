int[,] a = new int[13, 13];
int[] b = new int[13];
int[] c = new int[13];
int k = 0, n = 0, col = 0, t = 0;


int s(int n, int k)
{
    if (k == 0) return 1;
    else return a[n, k];
}

string path = @"input.txt";
bool fileExist = File.Exists(path);
if (!fileExist)
{
    Console.WriteLine("File does not exist");
    return;
}
string text = File.ReadAllText("input.txt");
var textMatrix = text.Split("\r\n");
var firstTextArray = textMatrix[0].Split(" ");
n = Convert.ToInt32(firstTextArray[0]);

if (n >= 13)
{
    Console.WriteLine("N must be <= 12");
    return;
}
k = Convert.ToInt32(firstTextArray[1]);

if (k <= 0 || k >= n)
{
    Console.WriteLine("K must be >= 0 and <= N");
    return;
}
var secondTextArray = textMatrix[1].Split(" ");

for (int i = 1; i <= 12; i++)
{
    a[i, 1] = i;
    for (int j = 2; j <= i; j++)
        a[i, j] = a[i, j - 1] * (i - j + 1);
}

for (int i = 1; i <= k; i++)
{
    b[i] = Convert.ToInt32(secondTextArray[i - 1]);
    t = 0;
    for (int j = 1; j <= b[i]; j++)
        if (c[j] == 0) t++;
    col = col + (t - 1) * s(n - i, k - i);
    c[b[i]] = 1;
}

File.WriteAllText("output.txt", (col + 1).ToString());