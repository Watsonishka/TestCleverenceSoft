namespace Task3ConsoleApp;
public class FileManager
{
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