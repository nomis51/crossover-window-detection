using System.Threading.Tasks;
using CrossOver.WindowDetection.Models;
using CrossOver.WindowDetection.WinAPI;

namespace CrossOver.WindowDetection
{
    public class WindowDetection
    {
        #region Public methods

        public async Task<object> GetForegroundWindowInfos(dynamic input)
        {
            var fwHwnd = WinApi.GetForegroundWindow();

            return await Task.FromResult(new WindowInfos
            {
                Title = WinApi.GetForegroundWindowText(fwHwnd),
                ProcessPath = WinApi.GetForegroundWindowModuleFileName(fwHwnd)
            });
        }
        #endregion
    }
}