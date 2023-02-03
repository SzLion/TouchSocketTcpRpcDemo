// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using TouchSocket.Core;
using TouchSocket.Rpc;
using TouchSocket.Rpc.TouchRpc;
using TouchSocket.Sockets;
using TouchSocketRpcServiceDemo;

Console.WriteLine("Hello, World!");
var service = new TcpTouchRpcService();
TouchSocketConfig config = new TouchSocketConfig() //配置
    .SetListenIPHosts(new IPHost[] {new IPHost(7790)})
    .SetThreadCount(50)
    .UseDelaySender()
    .UsePlugin()
    .SetMaxPackageSize(1024 * 1024 * 10)
    .ConfigureContainer(a => { a.AddEasyLogger((s => {  })); })
    .ConfigureRpcStore(a =>
    {
        a.RegisterServer<TestRpcServer>(); //注册服务
    })
    .ConfigurePlugins(a =>
    {
        a.Add<TestTcpRpcPlugin>();
    })
    .SetVerifyToken("FFDRpc");

service.Setup(config)
    .Start();
Console.WriteLine("Start");

Console.ReadKey();