using System;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Communication.Clients;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Models;

public class Bot
{
    TwitchClient client;
    string Channel;
    bool send;

    public Bot(string username, string oauth, string channel, bool Send = true)
    {
        ConnectionCredentials credentials = new ConnectionCredentials(username, oauth);
        var clientOptions = new ClientOptions
        {
            MessagesAllowedInPeriod = 750,
            ThrottlingPeriod = TimeSpan.FromSeconds(30)
        };
        WebSocketClient customClient = new WebSocketClient(clientOptions);
        client = new TwitchClient(customClient);
        client.Initialize(credentials, channel);

        client.OnLog += Client_OnLog;
        client.OnJoinedChannel += Client_OnJoinedChannel;
        client.OnConnected += Client_OnConnected;

        send = Send;

        client.Connect();
    }

    public void SendMessage(string message)
    {
        try { client.SendMessage(Channel, message); }
        catch { return; }
    }
    private void Client_OnLog(object sender, OnLogArgs e)
    {
        Console.WriteLine($"{e.DateTime.ToString()}: {e.BotUsername} - {e.Data}");
    }

    public void End()
    {
        client.Disconnect();
    }

    private void Client_OnConnected(object sender, OnConnectedArgs e)
    {
        Console.WriteLine($"Connected to {e.AutoJoinChannel}");
    }

    private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
    {
        Channel = e.Channel;
        if(send) client.SendMessage(e.Channel, "Hi there!");
    }
}
