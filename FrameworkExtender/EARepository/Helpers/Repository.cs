using System;
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

        public static EA.Repository GetRepository(string repositoryGuid)
        {
            IMoniker[] monikers = new IMoniker[1];

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
                
                // Check the provided GUID against this repository instance GUID
                if (rep.InstanceGUID != repositoryGuid) continue;

                return rep;
            }

            // Returns null if no open repository with the provided GUID can be found
            return null;
        }
    }
}
