using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using EA;

namespace Repository.Helpers
{
    public static class Repository
    {
        [DllImport("ole32.dll")]
        private static extern int CreateBindCtx(uint reserved, out IBindCtx bindCtx);

        [DllImport("ole32.dll")]
        private static extern int GetRunningObjectTable(uint reserved,
            out IRunningObjectTable runningObjectTable);

        // Gets a list of running Sparx instances and returns the one associated with the provided GUID
        public static (int processID, EA.Repository repository) GetRepository(string repositoryGuid)
        {
            var monikers = new IMoniker[1];

            GetRunningObjectTable(0, out var rot);
            rot.EnumRunning(out var enumMoniker);

            while (enumMoniker.Next(1, monikers, IntPtr.Zero) == 0)
            {
                CreateBindCtx(0, out var ctx);

                monikers[0].GetDisplayName(ctx, null, out var name);

                if (!name.Contains("Sparx.EA.App")) continue;

                // Get the COM object instance
                rot.GetObject(monikers[0], out var val);
                var app = (App) val;
                var rep = app.Repository;
                
                // Get the process id of the COM object instance
                var pid = int.Parse(name.Split(':')[1]);
                
                // Check the provided GUID against this repository instance GUID
                if (rep.InstanceGUID != repositoryGuid) continue;

                return (pid, rep);
            }

            // Returns -1 for the pid and null for the repository if no EA instance with provided instanceGUID is found
            return (-1, null);
        }

        // Gets and returns the list running Sparx instances
        public static IEnumerable<(int processID, EA.Repository repository)> GetOpenRepositories()
        {
            var repositoryList = new List<(int processID, EA.Repository repository)>();
            
            var monikers = new IMoniker[1];

            GetRunningObjectTable(0, out var rot);
            rot.EnumRunning(out var enumMoniker);

            while (enumMoniker.Next(1, monikers, IntPtr.Zero) == 0)
            {
                CreateBindCtx(0, out var ctx);

                monikers[0].GetDisplayName(ctx, null, out var name);

                if (!name.Contains("Sparx.EA.App")) continue;

                // Get the COM object instance
                rot.GetObject(monikers[0], out var val);
                var app = (App) val;
                var rep = app.Repository;
                
                // Get the process id of the COM object instance
                var pid = int.Parse(name.Split(':')[1]);
                
                repositoryList.Add((pid, rep));
            }

            // Returns an empty list
            return repositoryList;
        }
    }
}
