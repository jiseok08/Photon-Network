using UnityEngine;
using Photon.Pun;

public class Head : MonoBehaviourPunCallbacks
{
    [SerializeField] Rotation rotation;

    [SerializeField] float maximunAngle = 65;
    [SerializeField] float minimumAngle = -65;

    private void Awake()
    {
        rotation = GetComponent<Rotation>();
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            rotation.RotateX(minimumAngle, maximunAngle);
        }
    }
}
