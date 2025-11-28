using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem.LowLevel;

public class Character : MonoBehaviourPun
{
    [SerializeField] Mouse mouse;
    [SerializeField] Rotation rotation;
    [SerializeField] Camera remoteCamera;
    [SerializeField] CharacterController characterController;

    [SerializeField] float speed;
    [SerializeField] Vector3 direction;

    private void Awake()
    {
        mouse = GetComponent<Mouse>();
        rotation = GetComponent<Rotation>();
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        mouse.SetMouse(false);

        DisableCamera();
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            Control();

            Move();

            rotation.RotateY();
        }
    }

    public void Control()
    {
        direction.x += Input.GetAxisRaw("Horizontal");
        direction.z += Input.GetAxisRaw("Vertical");

        // direction 방향을 단위 백터로 설정합니다.
        direction.Normalize();
    }

    public void Move()
    {
        characterController.Move(characterController.transform.TransformDirection(direction) * speed * Time.deltaTime);
    }

    public void DisableCamera()
    { 
        // 현재 플레이어가 나 자신이라면
        if (photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            remoteCamera.gameObject.SetActive(false);
        }
    }
}
