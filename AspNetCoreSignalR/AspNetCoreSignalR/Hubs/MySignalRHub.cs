using Microsoft.AspNetCore.SignalR;

namespace AspNetCoreSignalR.Hubs
{
    /// <summary>
    /// My SignalR Hub
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.SignalR.Hub" />
    public class MySignalRHub : Hub
    {
        /// <summary>
        /// New Update method
        /// </summary>
        public void NewUpdate(string command, double state)
        {
            Clients.All.InvokeAsync("NewUpdate", command, state);
        }
    }
}
