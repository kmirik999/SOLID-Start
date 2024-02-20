namespace FileSystem.Domain;

public interface IFileRegistry
{
    void Add(FileDomain fileDescriptor);

    void Remove(string shortcut);

    List<FileDomain> GetAll();
}
