using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace EACom
{
    [Guid("65BE0EE6-88F7-47B4-A1C6-27A6A7F64327")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("EACom.Request.1")]
    [ComVisible(true)]
    public class RequestClass : IRequest
    {
        private EA.Repository _repository;
        private Dictionary<int, string> _result = new Dictionary<int, string>();

        public void Init(string instanceGuid)
        {
            _repository = Repository.Helpers.Repository.GetRepository(instanceGuid);
        }

        public int Request(string parameters)
        {
            throw new System.NotImplementedException();
        }

        public string Result(int identifier)
        {
            return _result.TryGetValue(identifier, out var value) ? value : string.Empty;
        }
    }
}