using System;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Communication.Clients;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Models;

class Bot
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
        client.OnMessageReceived += Client_OnMessageReceived;
        client.OnWhisperReceived += Client_OnWhisperReceived;
        client.OnNewSubscriber += Client_OnNewSubscriber;
        client.OnConnected += Client_OnConnected;

        send = Send;

        client.Connect();
    }

    public void SendMessage(string message)
    {
        client.SendMessage(Channel, message);
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

    private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
    {
        return;
    }

    private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
    {
        return;
    }

    private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
    {
        return;
    }
}
