using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace EACom
{
    [Guid("65BE0EE6-88F7-47B4-A1C6-27A6A7F64327")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("EACom.Request.1")]
    [ComVisible(true)]
    public class RequestClass : IRequest
    {
        private EA.Repository _repository;
        private string _result = string.Empty;

        public void Init(string instanceGuid)
        {
            _repository = Repository.Helpers.Repository.GetRepository(instanceGuid);
        }

        public string Request(string parameters)
        {
            var task = Task.Run(async () => await Task.Run( () => HandleRequest(parameters)));
            task.Wait();
            return task.Result;
        }

        private string HandleRequest(string parameters)
        {
            return "Hello World!";
        }
    }
}