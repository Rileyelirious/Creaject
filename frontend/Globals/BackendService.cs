using Godot;
using System;
using CreajectBackend;

public partial class BackendService : Node
{
    private static DatabaseManager DB;

    public override void _Ready()
    {
        // initialize managers
        DB = new DatabaseManager();
    }

    // expose backend methods
}
