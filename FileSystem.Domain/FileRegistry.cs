namespace FileSystem.Domain;

public class FileRegistry : IFileRegistry
{
    private static FileRegistry instance;

    public static FileRegistry Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new FileRegistry();
            }

            return instance;
        }
    }

    private readonly List<FileDomain> files = new List<FileDomain>();



    public FileDomain Add(string filePath, string name)
    {
        var fileDescriptor = new FileDomain(name, filePath);

        files.Add(fileDescriptor);
        return fileDescriptor;
    }

    public void Remove(string shortcut)
    {
        var file = files.FirstOrDefault(f => f.Shortcut == shortcut);
        if (file != null)
        {
            files.Remove(file);
        }
    }

    public List<FileDomain> GetAll()
    {
        return files;
    }
}