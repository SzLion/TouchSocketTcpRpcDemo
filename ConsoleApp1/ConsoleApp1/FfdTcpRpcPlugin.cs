using TouchSocket.Rpc.TouchRpc;

namespace ConsoleApp1;

public class FfdTcpRpcPlugin : TouchRpcPluginBase<TcpTouchRpcClient>
{
    protected override void OnHandshaked(TcpTouchRpcClient client, VerifyOptionEventArgs e)
    {
        
    }
}

public enum DeviceType : int
{
    Phone = 0,
    MrGlass = 1,
}