namespace CreajectBackend;

using System.IO;
using System.Text.Json;

public class DatabaseManager
{
    private Dictionary<string, string>? ProjectInfo;

    public void NewProject(String name, String path)
    {
        ProjectInfo = new Dictionary<string, string>
        {
            ["name"] = name
        };

        var ProjectFormatOptions = new JsonSerializerOptions {WriteIndented = true};
        string ProjectFileContent = JsonSerializer.Serialize(ProjectInfo, ProjectFormatOptions);

        Directory.CreateDirectory(path);
        File.WriteAllText($"{path}/{name}.creaject", ProjectFileContent);
    }
}

// testing
class Program
{
    static void Main(string[] args)
    {
        DatabaseManager db = new DatabaseManager();
        db.NewProject("TestProj", "./TestProj");
    }
}