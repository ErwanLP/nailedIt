using UnityEngine;
using System;
using WebSocketSharp;


public class CustomSocket
{
    public CustomSocket()
    {
        Debug.Log("Init socket");
        using (var ws = new WebSocket("ws://127.0.0.1:3000"))
        {
            ws.OnMessage += (sender, e) =>
                Debug.Log("Recu du serveur " + e.Data);

            ws.Connect();
            ws.Send("Premier message");
            
        }
    }
}