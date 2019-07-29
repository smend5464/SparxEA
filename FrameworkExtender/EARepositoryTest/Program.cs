using System;

namespace EARepositoryTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var repository = Repository.Helpers.Repository.GetRepository(args[0]);
                if (repository == null)
                {
                    Console.WriteLine("Invalid Instance Guid: {0}", args[0]);
                    Environment.Exit(1);
                }

                Console.Write("Press Any Key to Pause simulation");
                Console.ReadKey();
                var sim = repository.Simulation;
                if (sim.IsSimulatorRunning())
                {
                    var result = sim.Pause();
                    Console.WriteLine("Simulation Paused={0}", result);
                }
                else
                {
                    Console.WriteLine("Simulation not active");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.Write("Press Any Key to Continue");
                Console.ReadKey();
            }
        }
    }
}