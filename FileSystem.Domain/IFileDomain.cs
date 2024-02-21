namespace FileSystem.Domain;

public interface IFileDomain
{
    FileDomain CreateFileDomain(string fileName, string shortcut);
}