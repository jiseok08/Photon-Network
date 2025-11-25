using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomView : MonoBehaviourPunCallbacks
{
    [SerializeField] Text roomText;

    [SerializeField] string titleText;

    public void OnConnectRoom()
    {
        PhotonNetwork.JoinRoom(titleText);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        PanelManager.Instance.Load(Panel.Error, message);
    }

    public void UpdateRoomInformation(RoomInfo roomInfo)
    {
        titleText = roomInfo.Name;

        roomText.text = roomInfo.Name + " ( " + roomInfo.PlayerCount + " / " + roomInfo.MaxPlayers + " )"; 
    }
}
