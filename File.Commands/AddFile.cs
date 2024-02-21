using System;
using FileSystem.Core;
using FileSystem.Domain;


[InputAction]
public class AddFileInputAction : InputAction<AddFileCommand>
{
    protected override string Module => "file";

    protected override string Action => "add";
    
    protected override string HelpString => "add a file";

    private readonly IFileRegistry fileRegistry;

    public AddFileInputAction(IFileRegistry fileRegistry)
    {
        this.fileRegistry = fileRegistry;
    }

    protected override AddFileCommand GetCommandInternal(string[] args)
    {
        return new AddFileCommand(fileRegistry, args);
    }
}

[Command]
public class AddFileCommand : Command
{
    private readonly string filePath;
    private readonly string shortcut;
    private readonly IFileRegistry registry;
    private readonly IFileDomain fileDomain;

    public AddFileCommand(IFileRegistry fileRegistry, string[] args)
    {
        this.registry = fileRegistry;
        
        this.filePath = args[0].ToString();
        this.shortcut = filePath;
        if (args.Length == 2)
        {
            this.shortcut = args[1].ToString();
        }
    }

    public override void Execute()
    {
        
        registry.Add(filePath, shortcut);
        Console.WriteLine($"FileDomain {filePath} added!");
    }
}