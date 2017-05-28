using UnityEngine;
using System;
using WebSocketSharp;


public class CustomSocket
{

    public Action<string[]> callbackRoomFound;
    public Action<string[]> callbackBoom;


    public WebSocket ws;

    public CustomSocket()
    {
        this.ws = new WebSocket("ws://127.0.0.1:3000");
        //this.ws = new WebSocket("ws://92.222.80.130:3001");

        this.ws.OnOpen += (sender, e) => {
            //Debug.Log("Connected");
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

    public void setCallbackRoomFound(Action<string[]> callback)
    {
        this.callbackRoomFound = callback;
    }

    public void setCallbackBoom(Action<string[]> callback)
    {
        this.callbackBoom = callback;
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
            string[] split = e.Data.Split(';');
            string type = split[0];
            switch (type)
            {
                case "ROOM_FOUND":
                    this.callbackRoomFound(split);
                    break;
                case "BOOM":
                    this.callbackBoom(split);
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }

    }
}