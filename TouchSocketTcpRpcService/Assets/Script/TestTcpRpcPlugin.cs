using TouchSocket.Rpc.TouchRpc;
using TouchSocket.Sockets;
using UnityEngine;

namespace Script
{
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

        //public ILog Logger { get; }
        protected override void OnHandshaked(TcpTouchRpcSocketClient client, VerifyOptionEventArgs e)
        {
            Debug.Log($"客户端id：{client.ID}");
            Debug.Log($"客户端：{client.GetIPPort()}已连接");
        }

    }
}