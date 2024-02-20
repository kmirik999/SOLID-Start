using System;
using FileSystem.Core;
using FileSystem.Domain;


[InputAction]
public class RemoveFileInputAction : InputAction<RemoveFileCommand>
{
    protected override string Module => "file";

    protected override string Action => "remove";
    
    protected override string HelpString => "remove a file";

    private readonly IFileRegistry fileRegistry;

    public RemoveFileInputAction(IFileRegistry fileRegistry)
    {
        this.fileRegistry = fileRegistry;
    }

    protected override RemoveFileCommand GetCommandInternal(string[] args)
    {
        return new RemoveFileCommand(fileRegistry, args[0]);
    }
}

[Command]
public class RemoveFileCommand : Command
{
    private readonly string shortcut;
    private readonly IFileRegistry fileRegistry;

    public RemoveFileCommand(IFileRegistry fileRegistry, string shortcut)
    {
        this.fileRegistry = fileRegistry;
        this.shortcut = shortcut;
    }

    public override void Execute()
    {
        fileRegistry.Remove(shortcut);
        Console.WriteLine($"File with shortcut {shortcut} removed!");
    }
}