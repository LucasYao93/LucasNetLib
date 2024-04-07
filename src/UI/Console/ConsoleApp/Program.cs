using System.Text;

public class Program
{
    public static void Main()
    {
        string str = "2";

        // 使用 UTF-8 编码将字符串转换为字节数组
        byte[] bytes = Encoding.UTF8.GetBytes(str);

        // 输出字节数组
        Console.WriteLine("字节数组: " + BitConverter.ToString(bytes));
    }
}