namespace FileSystem.Domain;

public class FileDomain 
{
    public string FilePath { get; }
    public string Shortcut { get; }

    public FileDomain(string filePath, string shortcut)
    {
        FilePath = filePath;
        Shortcut = shortcut;
    }
}