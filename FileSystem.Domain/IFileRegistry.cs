namespace FileSystem.Domain;

public interface IFileRegistry
{
    FileDomain Add(string filePath, string name);
    void Remove(string filePath);
    List<FileDomain> GetAll();
}
