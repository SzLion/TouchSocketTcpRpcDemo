using System.Collections.Generic;
using System.ComponentModel;
using TouchSocket.Rpc;
using TouchSocket.Rpc.TouchRpc;


namespace ConsoleApp1;


public class EditorRpcClientServer: IRpcServer
{
    
    [TouchRpc(true)]
    public void WaitInvoke()
    {
        Console.WriteLine("WaitInvoke 响应");
    }
    [TouchRpc(true)]
    public void WaitSend()
    {
        Console.WriteLine("WaitSend 响应");
    }

}
