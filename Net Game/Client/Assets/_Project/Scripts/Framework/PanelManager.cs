using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    //Layer
    public enum Layer
    {
        Panel,
        Tip,
    }
    //�㼶�б�
    private static Dictionary<Layer, Transform> layers = new Dictionary<Layer, Transform>();
    //����б�
    public static Dictionary<string, BasePanel> panels = new Dictionary<string, BasePanel>();
    //�ṹ
    public static Transform root;
    public static Transform canvas;

    //��ʼ��
    public static void Init()
    {
        root = GameObject.Find("Root").transform;
        canvas = root.Find("Canvas");
        Transform panel = canvas.Find("Panel");
        Transform tip = canvas.Find("Tip");
        layers.Add(Layer.Panel, panel);
        layers.Add(Layer.Tip, tip);
    }

    //�����
    public static void Open<T>(params object[] para) where T : BasePanel
    {
        //�Ѿ���
        string name = typeof(T).ToString();
        if (panels.ContainsKey(name))
        {
            return;
        }
        //���
        BasePanel panel = root.gameObject.AddComponent<T>();
        panel.OnInit();
        panel.Init();
        //������
        Transform layer = layers[panel.layer];
        panel.skin.transform.SetParent(layer, false);
        //�б�
        panels.Add(name, panel);
        //OnShow
        panel.OnShow(para);
    }

    //�ر����
    public static void Close(string name)
    {
        //û�д�
        if (!panels.ContainsKey(name))
        {
            return;
        }
        BasePanel panel = panels[name];

        //OnClose
        panel.OnClose();
        //�б�
        panels.Remove(name);
        //����
        GameObject.Destroy(panel.skin);
        Component.Destroy(panel);
    }

}