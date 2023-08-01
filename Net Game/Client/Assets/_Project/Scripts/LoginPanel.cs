using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    //�˺������
    private InputField idInput;
    //���������
    private InputField pwInput;
    //��½&ע�ᰴť
    private Button loginBtn;


    //��ʼ��ʾ��ʱ��
    private float startTime = float.MaxValue;
    //��ʾ����ʧ��
    private bool showConnFail = false;
    //ip�͵�ַ
    private string ip = "127.0.0.1";
    private int port = 8888;

    //��ʼ��LoginPanel
    public override void OnInit()
    {
        skinPath = "LoginPanel";
        layer = PanelManager.Layer.Panel;
    }

    //��ʾ
    public override void OnShow(params object[] args)
    {
        //Ѱ�����
        idInput = skin.transform.Find("IdInput").GetComponent<InputField>();
        pwInput = skin.transform.Find("PwInput").GetComponent<InputField>();
        loginBtn = skin.transform.Find("LoginBtn").GetComponent<Button>();
        //������ť�¼�
        loginBtn.onClick.AddListener(OnClick_Login);


        //����Э�����
        NetManager.AddMsgListener("MsgLogin", OnMsgLogin);
        //�����¼�����
        NetManager.AddEventListener(NetManager.NetEvent.ConnectSucc, OnConnectSucc);
        NetManager.AddEventListener(NetManager.NetEvent.ConnectFail, OnConnectFail);
        //���ӷ�����
        NetManager.Connect(ip, port);
        //��¼ʱ��
        startTime = Time.time;
    }

    /// <summary>
    /// ��¼
    /// </summary>
    public void OnClick_Login()
    {
        //����
        MsgLogin msgLogin = new MsgLogin();
        msgLogin.id = idInput.text;
        msgLogin.pw = pwInput.text;
        NetManager.Send(msgLogin);

    }

    //�ر�
    public override void OnClose()
    {
        //����Э�����
        NetManager.RemoveMsgListener("MsgLogin", OnMsgLogin);
        //�����¼�����
        NetManager.RemoveEventListener(NetManager.NetEvent.ConnectSucc, OnConnectSucc);
        NetManager.RemoveEventListener(NetManager.NetEvent.ConnectFail, OnConnectFail);
    }

    //���ӳɹ��ص�
    void OnConnectSucc(string err)
    {
        Debug.Log("OnConnectSucc");
    }

    //����ʧ�ܻص�
    void OnConnectFail(string err)
    {
        showConnFail = true;
        //PanelManager.Open<TipPanel>(err);
    }


    //�յ���½Э��
    public void OnMsgLogin(MsgBase msgBase)
    {
        MsgLogin msg = (MsgLogin)msgBase;
        if (msg.result == 0)
        {
            Debug.Log("��½�ɹ�");
            //����id
            GameMain.id = msg.id;
            //�رս���
            Close();
        }
        else
        {
            PanelManager.Open<TipPanel>("��½ʧ��");
        }
    }

    public void Update()
    {
        if (showConnFail)
        {
            showConnFail = false;
            PanelManager.Open<TipPanel>("��������ʧ�ܣ������´���Ϸ");
        }
    }
}
