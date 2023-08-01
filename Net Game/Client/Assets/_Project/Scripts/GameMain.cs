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

        //�������
        NetManager.AddEventListener(NetManager.NetEvent.Close, OnConnectClose);
        NetManager.AddMsgListener("MsgKick", OnMsgKick);

        //��ʼ��
        PanelManager.Init();
        //�򿪵�½���
        PanelManager.Open<LoginPanel>();


    }
    // Update is called once per frame
    void Update()
    {
        NetManager.Update();
    }

    //�ر�����
    void OnConnectClose(string err)
    {
        Debug.Log("�Ͽ�����");
    }

    //��������
    void OnMsgKick(MsgBase msgBase)
    {
        PanelManager.Open<TipPanel>("��������");
    }

}
