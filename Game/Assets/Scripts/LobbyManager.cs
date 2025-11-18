using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    Dictionary<string, GameObject> dictionary = new();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        GameObject prefab = null;
        

    }
}
