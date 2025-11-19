using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomView : MonoBehaviour
{
    [SerializeField] Text roomText;

    [SerializeField] string titleText;

    public void OnConnectRoom()
    {
        PhotonNetwork.JoinRoom(titleText);
    }

    public void UpdateRoomInformation(RoomInfo roomInfo)
    {
        titleText = roomInfo.Name;

        roomText.text = roomInfo.Name + " ( " + roomInfo.PlayerCount + " / " + roomInfo.MaxPlayers + " )"; 
    }
}
