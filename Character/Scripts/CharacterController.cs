using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CharacterController : MonoBehaviour
{
    [Header("子模块")]
    public Transform Body;

    void Start()
    {
        InitMovementController();

        InitMotionController();

        InitCameraController();
    }

    void Update()
    {
        //视角锁定时开始
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            UpdateMovementController();

            UpdateMotionController();

            UpdateCameraController();

            if (Input.GetKeyDown(KeyCode.Escape))
                Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
}
