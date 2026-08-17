using Godot;
using CreajectBackend;

public partial class BackendService : Node
{
    private DatabaseManager DB;

    public override void _Ready()
    {
        // initialize managers
        DB = new DatabaseManager();
    }

    // expose backend methods
    public bool NewProject(string Name, string Path)
    {
        return DB.NewProject(Name, Path);
    }

    public bool OpenProject(string Path)
    {
        return DB.OpenProject(Path);
    }
}
