namespace FileSystem.Core;

public interface IInputCommandFactory
{
    List<IInputAction> GetAllCommands();
}