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
   
    private TcpTouchRpcClient client;
    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }
    public void Connect()
    {
        try
        {
            client.SafeDispose();
            client = new TcpTouchRpcClient();
            client.Setup(new TouchSocketConfig()
                .SetRemoteIPHost("127.0.0.1:7790")
                .SetVerifyToken("FFDRpc")
                .UseDelaySender()
                .UsePlugin()
                .SetMaxPackageSize(1024*1024*10)
                .ConfigureContainer(a =>
                {
                    a.AddEasyLogger(s =>
                    {
                        Debug.Log(s);
                    });
                })
                .ConfigureRpcStore(a =>
                {
                    a.RegisterServer<TestRpcServer>();
                })
                .ConfigurePlugins(a =>
                {
                    //a.Add<TestTcpRpcPlugin>();
                    //a.UseTouchRpcHeartbeat<TcpTouchRpcClient>();
                }));
            client.Connect();
                
            
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            throw;
        }
            
    }
    private void OnApplicationQuit()
    {
        client.SafeDispose();
    }

   
}
