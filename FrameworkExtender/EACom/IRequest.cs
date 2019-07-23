using System.Runtime.InteropServices;

namespace EACom
{
    [Guid("42BF71AE-CFCA-4798-8955-439D7D75D115")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface IRequest
    {
        [DispId(1)]
        void Init(string instanceGuid);

        [DispId(2)]
        int Request(string parameters);

        [DispId(3)]
        string Result(int identifier);
    }
}