using System;
using DI.Core;
using FileSystem.Core;
using FileSystem.Domain;
using SOLID_Start;


class Program
{
    static void Main()
    {
        // Set up dependency injection container
        var diContainer = new DiContainer();
        diContainer.Register<IFileRegistry, FileRegistry>(Scope.Singleton);
        diContainer.Register<IFileDomain, FileDomain>(Scope.Singleton);
        
        var inputActionsFactory = new InputActionsFactory(diContainer);
        
        var actions = inputActionsFactory.GetAllActions();

        while (true)
        {
            Console.WriteLine("Enter a command:");
            var input = Console.ReadLine();

            if (!TryHandle(input, actions))
            {
                Console.WriteLine($"Unknown command '{input}', please try again");
            }
        }
    }

    static bool TryHandle(string input, List<IInputAction> actions)
    {
        foreach (var inputAction in actions)
        {
            if (inputAction.CanHandle(input))
            {
                var command = inputAction.GetCommand(input);
                command.Execute();
                return true;
            }
        }

        return false;
    }
}