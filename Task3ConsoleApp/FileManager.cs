using Newtonsoft.Json;
using System.Text;
namespace Task3ConsoleApp;

public class FileManager
{
    public static List<T> ReadJSONFile<T>(string filePath)
    {
        var streamReader = new StreamReader(filePath, Encoding.UTF8);
        var jsonString = streamReader.ReadToEnd();
        var collection = JsonConvert.DeserializeObject<List<T>>(jsonString) ?? new List<T>();
        streamReader.Close();
        return collection;
    }
    public static void RewriteJSONFile(string filePath, string text)
    {
        var streamWriter = new StreamWriter(filePath, false, System.Text.Encoding.UTF8);
        streamWriter.WriteLine(text);
        streamWriter.Close();
    }
    public static List<string> ReadTextFile(string filePath)
    {
        var streamReader = new StreamReader(filePath, System.Text.Encoding.UTF8);
        var fileLines = new List<string>();
        while (!streamReader.EndOfStream)
        {
            fileLines.Add(streamReader.ReadLine());
        }
        streamReader.Close();
        return fileLines;
    }
    public static void AppendToTextFile(string filePath, string text)
    {
        var streamWriter = new StreamWriter(filePath, true, System.Text.Encoding.UTF8);
        streamWriter.WriteLine(text);
        streamWriter.Close();
    }
}