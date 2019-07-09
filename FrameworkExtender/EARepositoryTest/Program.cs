using System;

namespace EARepositoryTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var repository = Repository.Helpers.Repository.GetRepository(args[0]);

            try
            {
                var instance = string.Format($"Instance Guid: {repository.InstanceGUID}");
                Console.WriteLine(instance);
                repository.WriteOutput("Script", instance, 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}