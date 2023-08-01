//系统消息，主要负责检测客户端和服务端的连接持续性
public class MsgPing : MsgBase
{
    public MsgPing() { protoName = "MsgPing"; }
}


public class MsgPong : MsgBase
{
    public MsgPong() { protoName = "MsgPong"; }
}
