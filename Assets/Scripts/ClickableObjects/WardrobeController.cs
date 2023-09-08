using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WardrobeController : MonoBehaviour, IClickable
{
    [SerializeField]
    GameObject leftDoor;

    Vector3 openDoorRotation;
    Vector3 closeDoorRotation;
    bool isDoorOpen;

    public WardrobeController()
    {
        openDoorRotation = new Vector3(-90, 0, 150);
        closeDoorRotation = new Vector3(-90, 0, 0);
    }

    public void Click()
    {
        InteractionDoor();
    }

    void InteractionDoor()
    {
        if (!isDoorOpen)
        {
            leftDoor.transform.DORotate(openDoorRotation, 1f);
            isDoorOpen = true;
        }
        else
        {
            leftDoor.transform.DORotate(closeDoorRotation, 1f).OnComplete(()=>{isDoorOpen = false;});
        }
    }
}
