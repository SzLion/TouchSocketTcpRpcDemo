using System.Diagnostics;
using TouchSocket.Core;
using TouchSocket.Rpc.TouchRpc;
using TouchSocket.Sockets;

namespace TouchSocketRpcServiceDemo;

public class TestTcpRpcPlugin: TouchRpcPluginBase<TcpTouchRpcSocketClient>
{
    protected override void OnRouting(TcpTouchRpcSocketClient client, PackageRouterEventArgs e)
    {
        if (e.RouterType== RouteType.Rpc)
        {
            e.IsPermitOperation = true;
        }
        base.OnRouting(client, e);
    }

    protected override void OnHandshaked(TcpTouchRpcSocketClient client, VerifyOptionEventArgs e)
    {
        Console.WriteLine($"客户端id：{client.ID}");
        Console.WriteLine($"客户端：{client.GetIPPort()}已连接");
        
        client.Invoke("WaitInvoke",InvokeOption.WaitInvoke);
        
        client.Invoke("WaitSend",InvokeOption.WaitSend);

        
    }
}