using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace MyCompany.MyModuleCodeBehind
{
    public class Interop
    {
        private readonly IJSRuntime _jsRuntime;

        public Interop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
    }
}
