using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class GameMain : MonoBehaviour
{
    public static string id = "";

    void Start()
    {

        //网络监听
        NetManager.AddEventListener(NetManager.NetEvent.Close, OnConnectClose);
        NetManager.AddMsgListener("MsgKick", OnMsgKick);

        //初始化
        PanelManager.Init();
        //打开登陆面板
        PanelManager.Open<LoginPanel>();


    }
    // Update is called once per frame
    void Update()
    {
        NetManager.Update();
    }

    //关闭连接
    void OnConnectClose(string err)
    {
        Debug.Log("断开连接");
    }

    //被踢下线
    void OnMsgKick(MsgBase msgBase)
    {
        PanelManager.Open<TipPanel>("被踢下线");
    }

}
