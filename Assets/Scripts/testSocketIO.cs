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
            Reconnection = true, // Tự động kết nối lại nếu mất kết nối
            ReconnectionAttempts = 5, // Số lần thử kết nối lại
            ReconnectionDelay = 1000 // Thời gian chờ giữa các lần thử (ms)
        });

        // Sự kiện khi kết nối thành công
        client.OnConnected += async (sender, e) =>
        {
            Debug.LogWarning("Đã kết nối tới server Socket.IO!");
            // Gửi một message tới server
            await client.EmitAsync("ping", "Xin chào từ C# client!");
        };

        // Sự kiện khi mất kết nối
        client.OnDisconnected += (sender, e) =>
        {
            Debug.LogWarning("Mất kết nối tới server!");
        };

        // Lắng nghe sự kiện từ server
        client.On("pong", response =>
        {
            Debug.LogWarning($"Tin nhắn từ server: {response.GetValue<string>()}");
        });

        // Kết nối tới server
        await client.ConnectAsync();

        Debug.Log("Đang chạy...");
    }
}
