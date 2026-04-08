using Newtonsoft.Json;
using System.Text;
namespace Task3ConsoleApp;

public class FileManager
{
    public static List<T> ReadTextFile<T>(string filePath)
    {
        var streamReader = new StreamReader(filePath, Encoding.UTF8);
        var jsonString = streamReader.ReadToEnd();
        var collection = JsonConvert.DeserializeObject<List<T>>(jsonString) ?? new List<T>();
        streamReader.Close();
        return collection;
    }
    public static void RewriteTextFile(string filePath, string text)
    {
        var streamWriter = new StreamWriter(filePath, false, System.Text.Encoding.UTF8);
        streamWriter.WriteLine(text);
        streamWriter.Close();
    }
}