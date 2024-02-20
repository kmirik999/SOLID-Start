using System;
using FileSystem.Core;
using FileSystem.Domain;


[InputAction]
public class ListFilesInputAction : InputAction<ListFilesCommand>
{
    protected override string Module => "file";

    protected override string Action => "list";
    
    protected override string HelpString => "list all files";

    private readonly IFileRegistry fileRegistry;

    public ListFilesInputAction(IFileRegistry fileRegistry)
    {
        this.fileRegistry = fileRegistry;
    }

    protected override ListFilesCommand GetCommandInternal(string[] args)
    {
        return new ListFilesCommand(fileRegistry);
    }
}

[Command]
public class ListFilesCommand : Command
{
    private readonly IFileRegistry fileRegistry;

    public ListFilesCommand(IFileRegistry fileRegistry)
    {
        this.fileRegistry = fileRegistry;
    }

    public override void Execute()
    {
        var counter = 1;
        foreach (var file in fileRegistry.GetAll())
        {
            Console.WriteLine($"{counter++}.\t{file.FilePath} (Shortcut: {file.Shortcut})");
        }
    }
}