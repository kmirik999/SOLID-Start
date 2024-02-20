namespace FileSystem.Domain;

public interface IFileDomain
{
    FileDomain CreateFileDescriptor(string fileName, string shortcut);
}