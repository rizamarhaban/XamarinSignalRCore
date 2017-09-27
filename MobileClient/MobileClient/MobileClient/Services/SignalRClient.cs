using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MobileClient
{
    /// <summary>
    /// SignalR Client
    /// </summary>
    public class SignalRClient
    {
        private HubConnection _hub;
        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        public HubConnection Hub { get { return _hub; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalRClient"/> class.
        /// </summary>
        public SignalRClient()
        {
            Debug.WriteLine("SignalR Initialized...");
            InitializeSignalR().ContinueWith(task =>
            {
                Debug.WriteLine("SignalR Started...");
            });
        }

        /// <summary>
        /// Initializes SignalR.
        /// </summary>
        public async Task InitializeSignalR()
        {
            _hub = new HubConnectionBuilder()
                .WithUrl("http://[your signalr hub url]/updater")
                .Build();

            _hub.On<string, double>("NewUpdate",
                (command, state) => ValueChanged?
                .Invoke(this, new ValueChangedEventArgs(command, state)));

            await _hub.StartAsync();
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="state">The state.</param>
        public async Task SendMessage(string command, double state)
        {
            await _hub?.InvokeAsync("NewUpdate", new object[] { command, state });
        }
    }

}
