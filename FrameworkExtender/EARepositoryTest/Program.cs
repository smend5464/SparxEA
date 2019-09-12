using System;

namespace EARepositoryTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
//                var repository = Repository.Helpers.Repository.GetRepository(args[0]);
                var openRepositories = Repository.Helpers.Repository.GetOpenRepositories();
                
                foreach (var rep in openRepositories)
                {
//                    repository.WriteOutput("Script", rep.ConnectionString, 0);
                    var pid = rep.processID;
                    var repository = rep.repository;
                    Console.WriteLine("Process ID: {0}, InstanceGUID: {1}, Repository: {2}", pid,
                        repository.InstanceGUID, repository.ConnectionString);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}