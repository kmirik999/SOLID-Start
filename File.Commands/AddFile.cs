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
    private readonly IFileDomain fileDomain;

    public AddFileInputAction(IFileRegistry fileRegistry, IFileDomain fileDescriptorFactory)
    {
        this.fileRegistry = fileRegistry;
        this.fileDomain = fileDescriptorFactory;
    }

    protected override AddFileCommand GetCommandInternal(string[] args)
    {
        return new AddFileCommand(fileRegistry, fileDomain, args[0]);
    }
}

[Command]
public class AddFileCommand : Command
{
    private readonly string filePath;
    private readonly IFileRegistry fileRegistry;
    private readonly IFileDomain fileDomain;

    public AddFileCommand(IFileRegistry fileRegistry, IFileDomain fileDomain, string filePath)
    {
        this.fileRegistry = fileRegistry;
        this.fileDomain = fileDomain;
        this.filePath = filePath;
    }

    public override void Execute()
    {
        var fileDescriptor = fileDomain.CreateFileDescriptor(filePath, null); //  no shortcut 
        fileRegistry.Add(fileDescriptor);
        Console.WriteLine($"File {fileDescriptor.FilePath} added!");
    }
}