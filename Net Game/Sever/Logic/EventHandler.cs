﻿using System;

/// <summary>
/// 事件处理器
/// </summary>
public partial class EventHandle
{
    public static void OnDisconnect(ClientState c)
    {
        Console.WriteLine("Close");
        //Player下线
        if (c.player != null)
        {
            //离开战场
            int roomId = c.player.roomId;
            if (roomId >= 0)
            {
                Room room = RoomManager.GetRoom(roomId);
                room.RemovePlayer(c.player.id);
            }
            //保存数据
            DbManager.UpdatePlayerData(c.player.id, c.player.data);
            //移除
            PlayerManager.RemovePlayer(c.player.id);
        }
    }

    //计时器自动连续计时调用方法
    public static void OnTimer()
    {
        CheckPing();
        RoomManager.Update();
    }

    //Ping检查
    public static void CheckPing()
    {
        //现在的时间戳
        long timeNow = NetManager.GetTimeStamp();
        //遍历，删除
        foreach (ClientState s in NetManager.clients.Values)
        {
            if (timeNow - s.lastPingTime > NetManager.pingInterval * 4)
            {
                Console.WriteLine("Ping Close " + s.socket.RemoteEndPoint.ToString());
                NetManager.Close(s);
                return;
            }
        }
    }

}