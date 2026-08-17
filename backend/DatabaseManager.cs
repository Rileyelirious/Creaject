namespace CreajectBackend;

using System.IO;
using System.Text.Json;

public class ProjectData
{
    public string ProjectName {get; set;}
    public string ProjectPath {get; set;}

    public ProjectData(string name, string path)
    {
        ProjectName = name;
        ProjectPath = path;
    }
}

public class DatabaseManager
{
    public ProjectData? CurrentProjectData {get; private set;}

    public bool NewProject(string Name, string PathToProject)
    {
        CurrentProjectData = new ProjectData(Name, Path.GetFullPath(PathToProject));

        var ProjectFormatOptions = new JsonSerializerOptions {WriteIndented = true};
        string ProjectFileContent = JsonSerializer.Serialize(CurrentProjectData, ProjectFormatOptions);

        if (Directory.Exists(PathToProject) != true)
        {
            Directory.CreateDirectory(PathToProject);
            File.WriteAllText($"{PathToProject}/{Name}.creaject", ProjectFileContent);
            return true;
        }
        else {return false;}
    }

    public bool OpenProject(string PathToFile)
    {
        string FileContent = File.ReadAllText(PathToFile);
        CurrentProjectData = JsonSerializer.Deserialize<ProjectData>(FileContent);
        return CurrentProjectData != null;
    }

    public void SaveDocument(string FileName, string FileContent)
    {
        if (CurrentProjectData != null)
        {
            Directory.CreateDirectory($"{CurrentProjectData.ProjectPath}/docs");
            File.WriteAllText($"{CurrentProjectData.ProjectPath}/docs/{FileName}.md", FileContent);
        }
    }
}