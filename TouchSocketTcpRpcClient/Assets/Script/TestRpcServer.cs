using System.ComponentModel;
using TouchSocket.Rpc;
using TouchSocket.Rpc.TouchRpc;
using UnityEngine;

namespace Script
{
    public class TestRpcServer: IRpcServer
    {
        [TouchRpc(true)]
        public void WaitInvoke()
        {
            Debug.Log("Invoke调用成功");
        }
        [TouchRpc(true)]
        public void WaitSend()
        {
            Debug.Log("Send调用成功");
        }
    }
}