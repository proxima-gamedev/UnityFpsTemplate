using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public float mouseSensitivity = 1;

    float xAxisClamp = 0;

    [SerializeField]
    Transform playerTransform, cameraTransform;
    void Update()
    {
        //Cursor.lockState = CursorLockMode.Locked; //mauseun gözükmememsi için
        RotateCamera();
    }
    void RotateCamera()
    {
        float mauseX = Input.GetAxis("Mouse X");
        float mauseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mauseX * mouseSensitivity;
        float rotAmountY = mauseY * mouseSensitivity;

        xAxisClamp -= rotAmountY;

        Vector3 rotPlayerArms = cameraTransform.transform.rotation.eulerAngles;
        Vector3 rotPlayer = playerTransform.transform.rotation.eulerAngles;

        rotPlayerArms.x -= rotAmountY;
        rotPlayerArms.z = 0;
        rotPlayer.y += rotAmountX;

        if (xAxisClamp > 90f)
        {
            xAxisClamp = 90;
            rotPlayerArms.x = 90;
        }
        else if (xAxisClamp < -90f)
        {
            xAxisClamp = -90;
            rotPlayerArms.x = 270;
        }
        cameraTransform.rotation = Quaternion.Euler(rotPlayerArms);
        playerTransform.rotation = Quaternion.Euler(rotPlayer);


    }
}
