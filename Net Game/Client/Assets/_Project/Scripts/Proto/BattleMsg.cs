
//̹����Ϣ
[System.Serializable]
public class TankInfo
{
    public string id = "";  //���id
    public int camp = 0;    //��Ӫ
    public int hp = 0;      //����ֵ

    public float x = 0;     //λ��
    public float y = 0;
    public float z = 0;
    public float ex = 0;    //��ת
    public float ey = 0;
    public float ez = 0;
}


//����ս������������ͣ�
public class MsgEnterBattle : MsgBase
{
    public MsgEnterBattle() { protoName = "MsgEnterBattle"; }
    //����˻�
    public TankInfo[] tanks;
    public int mapId = 1;	//��ͼ��ֻ��һ��
}

//ս���������������ͣ�
public class MsgBattleResult : MsgBase
{
    public MsgBattleResult() { protoName = "MsgBattleResult"; }
    //����˻�
    public int winCamp = 0;	 //��ʤ����Ӫ
}

//����˳�����������ͣ�
public class MsgLeaveBattle : MsgBase
{
    public MsgLeaveBattle() { protoName = "MsgLeaveBattle"; }
    //����˻�
    public string id = "";	//���id
}