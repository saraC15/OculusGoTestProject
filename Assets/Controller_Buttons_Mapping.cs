using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

/// Should trigger VRTK Controller Events when buttons on Oculus go controller pressed.
/// Made because VRTK did not recognise the Oculus go controller.
public class Controller_Buttons_Mapping : MonoBehaviour
{

    public VRTK_ControllerEvents ControllerEvents;

    // Start is called before the first frame
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
         if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
         {
            OnTriggerPressed();
        } else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            OnTriggerReleased();
        }
    }

    private void OnTriggerPressed()
    {
        ControllerInteractionEventArgs e = new ControllerInteractionEventArgs
        {
            buttonPressure = 1,
            controllerReference = new VRTK_ControllerReference(1),
            touchpadAxis = new Vector2(0, -1),
            touchpadAngle = 1,
            touchpadTwoAxis = new Vector2(0, -1),
            touchpadTwoAngle = 1
        };
        ControllerEvents.OnTriggerPressed(e);
    }

    private void OnTriggerReleased()
    {
        ControllerInteractionEventArgs e = new ControllerInteractionEventArgs
        {
            buttonPressure = 1,
            controllerReference = new VRTK_ControllerReference(1),
            touchpadAxis = new Vector2(0, -1),
            touchpadAngle = 1,
            touchpadTwoAxis = new Vector2(0, -1),
            touchpadTwoAngle = 1
        };
        ControllerEvents.OnTriggerReleased(e);
    }
}

