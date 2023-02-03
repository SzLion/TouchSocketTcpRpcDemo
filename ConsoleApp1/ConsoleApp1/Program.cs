// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Net.Mime;
using ConsoleApp1;
using TouchSocket.Core;
using TouchSocket.Rpc;
using TouchSocket.Rpc.TouchRpc;
using TouchSocket.Sockets;

Console.WriteLine("Hello, World!");

var  client = new TcpTouchRpcClient();
client.Setup(new TouchSocketConfig()
    .SetRemoteIPHost("127.0.0.1:7790")
    .SetVerifyToken("FFDRpc")
    .UseDelaySender()
    .UsePlugin()
    .SetMaxPackageSize(1024 * 1024 * 10)
    .ConfigureContainer(a =>
    {
        a.AddEasyLogger(s => { Console.WriteLine(s); });
    })
    .ConfigureRpcStore(a =>
    {
        a.RegisterServer<EditorRpcClientServer>(); //注册服务
    })
    .ConfigurePlugins(a =>
    {
        a.Add<FfdTcpRpcPlugin>();

        a.UseTouchRpcHeartbeat<TcpTouchRpcClient>();
    }));
client.Connect();
client.Logger.Info("logTest");
Console.ReadKey();