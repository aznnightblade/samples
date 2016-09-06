using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseLook : MonoBehaviour
{

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    public float rotationX = 0F;
    public float rotationY = 0F;

    public bool m_AimingDownSight = false;
    public float m_ADSModifier = 1.5f;
    public float m_FieldOfView = 60.0f;


    void Start()
    {

    }


    void Update()
    {
        bool buttonPressed = false;


#if UNITY_ANDROID
        buttonPressed = InputChecker.GetTrigger(PLAYER_NUMBER.ONE, TRIGGER.LEFT);
#else
        buttonPressed = Input.GetMouseButton(1);
#endif


        // Aiming down sight
        float vel = 0.0f;
        Camera.main.fieldOfView = Mathf.SmoothDamp(Camera.main.fieldOfView, m_FieldOfView, ref vel, 0.1f);
        if (buttonPressed)
        {
            m_AimingDownSight = true;
            m_FieldOfView = 40.0f;
        }
        else
        {
            m_AimingDownSight = false;
            m_FieldOfView = 60.0f;
        }



#if UNITY_ANDROID

        // Android Controller
        if (axes == RotationAxes.MouseXAndY)
        {
            // Lower sensitivity for aiming down sight
            if (m_AimingDownSight)
            {
                rotationX = transform.localEulerAngles.y + InputChecker.GetAxis(PLAYER_NUMBER.ONE, JOYSTICK.RIGHT, AXIS.X) * ((sensitivityX - m_ADSModifier) * Time.deltaTime);
                rotationY += InputChecker.GetAxis(PLAYER_NUMBER.ONE, JOYSTICK.RIGHT, AXIS.Y) * ((sensitivityY - m_ADSModifier) * Time.deltaTime);
            }
            else
            {
                rotationX = transform.localEulerAngles.y + InputChecker.GetAxis(PLAYER_NUMBER.ONE, JOYSTICK.RIGHT, AXIS.X) * (sensitivityX * Time.deltaTime);
                rotationY += InputChecker.GetAxis(PLAYER_NUMBER.ONE, JOYSTICK.RIGHT, AXIS.Y) * (sensitivityY * Time.deltaTime);
            }

            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0.0f);

        }

#endif

        // PC mouse look
        if (axes == RotationAxes.MouseXAndY)
        {
            // Lower sensitivity for aiming down sight
            if (m_AimingDownSight)
            {
                rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse_X") * ((sensitivityX - m_ADSModifier) * Time.deltaTime);
                rotationY += Input.GetAxis("Mouse_Y") * ((sensitivityY - m_ADSModifier) * Time.deltaTime);
            }
            else
            {
                rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse_X") * (sensitivityX * Time.deltaTime);
                rotationY += Input.GetAxis("Mouse_Y") * (sensitivityY * Time.deltaTime);
            }

            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0.0f);
        }
    }

}