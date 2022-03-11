using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CharacterController : MonoBehaviour
{
    [Header("运动参数")]
    public float MoveSpeed = 10;
    public float Accelerate_Multiple = 3f;
    public float Accelerate_Time = 1f;

    private float MoveMultiple = 1f;
    private bool isAccelerate = false;

    public float JumpForce = 100;

    // Update is called once per frame
    public void UpdateMovementController()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (!isAccelerate && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)))
        {
            MoveMultiple = Accelerate_Multiple;
            TargetFieldofView = Accelerate_Field_of_View;
            Invoke("SpeedRecover", Accelerate_Time);
            isAccelerate = true;
        }

        transform.position += (RotateX.right * x) * Time.deltaTime * (MoveMultiple * MoveSpeed);
        transform.position += (RotateX.forward * z) * Time.deltaTime * (MoveMultiple * MoveSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(RotateX.up * JumpForce);
        }

        if (x != 0 || z != 0)
            Body.rotation = Quaternion.LookRotation(x * RotateX.right + z * RotateX.forward);
    }

    public void SpeedRecover()
    {
        MoveMultiple = 1f;
        TargetFieldofView = Normal_Field_of_View;
        isAccelerate = false;
    }
}
