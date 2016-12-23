using UnityEngine;
using System;
using WebSocketSharp;


public class CustomSocket
{

    public WebSocket ws;

    public CustomSocket()
    {
        this.ws = new WebSocket("ws://127.0.0.1:3000");
        this.ws.OnOpen += (sender, e) => {
            Debug.Log("Connected");
        };
        this.ws.OnMessage += (sender, e) => {
            this.onMessage(sender, e);
        };
        this.ws.OnError += (sender, e) => {
            Debug.Log("Error");
            Debug.Log(e.Message);
        };
        this.ws.OnClose += (sender, e) => {
            Debug.Log("Connection is closed");
        };
        this.ws.Connect();
    }

    public void sendMessage(string message)
    {
        this.ws.Send(message);
    }

    private void onMessage(object sender, WebSocketSharp.MessageEventArgs e)
    {
        Debug.Log("Message from server");
        Debug.Log(e.Data);
        if (e.IsText)
        {
            Debug.Log(e.Data);
        }
        if (e.IsBinary)
        {
            Debug.Log(e.RawData);
        }
    }
}