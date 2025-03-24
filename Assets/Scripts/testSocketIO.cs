using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIOClient;
using System.Threading.Tasks;

public class testSocketIO : MonoBehaviour
{
    async Task Start()
    {
        var client = new SocketIOClient.SocketIO("http://localhost:9456", new SocketIOOptions
        {
            Reconnection = true, 
            ReconnectionAttempts = 5, 
            ReconnectionDelay = 1000
        });

        
        client.OnConnected += async (sender, e) =>
        {
            Debug.LogWarning("Đã kết nối tới server Socket.IO!");
            
            await client.EmitAsync("ping", "Xin chào từ C# client!");
        };

        
        client.OnDisconnected += (sender, e) =>
        {
            Debug.LogWarning("Mất kết nối tới server!");
        };

        
        client.On("pong", response =>
        {
            Debug.LogWarning($"Tin nhắn từ server: {response.GetValue<string>()}");
        });

        
        await client.ConnectAsync();

        Debug.Log("Đang chạy...");
    }
}
