using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using Unity.VisualScripting;
using System.Collections;
using UnityEditor.Rendering.LookDev;

public class MasterManager : MonoBehaviourPunCallbacks
{
    private WaitForSeconds waitForSeconds = new WaitForSeconds(5); 

    public IEnumerator Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            while (true)
            {
                if (PhotonNetwork.CurrentRoom != null)
                {
                    PhotonNetwork.InstantiateRoomObject("Ball", Vector3.zero, Quaternion.identity);
                }

                yield return waitForSeconds;
            }
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);

        Debug.Log(PhotonNetwork.PlayerList[0]);
    }
}
