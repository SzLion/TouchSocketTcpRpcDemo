using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using TouchSocket.Core;
using TouchSocket.Rpc;
using TouchSocket.Rpc.TouchRpc;
using TouchSocket.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class TestTcpRpcService : MonoBehaviour
{
    public Button InvokeBtn;
    public Button SendBtn;
    
    
    public TcpTouchRpcService service { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        InvokeBtn.onClick.AddListener(WaitInvoke);
        SendBtn.onClick.AddListener(WaitSend);
        Setup();
    }
    public void Setup()
    {
        try
        {
            service = new TcpTouchRpcService();
            TouchSocketConfig config = new TouchSocketConfig() //配置
                .SetListenIPHosts(new IPHost[] {new IPHost(7790)})
                .SetThreadCount(50)
                .UseDelaySender()
                .UsePlugin()
                .SetMaxPackageSize(1024 * 1024 * 10)
                .ConfigureContainer(a => { a.AddEasyLogger((s => { Debug.Log(s); })); })
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

            service.Logger.Info($"{service.GetType().Name}已启动，监听端口：{7790}");
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            throw;
        }

    }

    private void OnApplicationQuit()
    {
        service.SafeDispose();
    }

    public void WaitInvoke()
    {
        foreach (var tcpTouchRpcSocketClient in service.GetClients())
        {
            tcpTouchRpcSocketClient.Invoke("WaitInvoke",InvokeOption.WaitInvoke);
        }
    }
    public void WaitSend()
    {
        foreach (var tcpTouchRpcSocketClient in service.GetClients())
        {
            tcpTouchRpcSocketClient.Invoke("WaitSend",InvokeOption.WaitSend);
        }
    }
}
