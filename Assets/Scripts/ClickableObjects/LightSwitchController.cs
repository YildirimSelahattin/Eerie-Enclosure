using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchController : MonoBehaviour, IClickable
{
    [SerializeField]
    GameObject roomLight;

    public void Click()
    {
        if(roomLight.active)
        {
            roomLight.SetActive(false);
        }
        else
        {
            //ToDo:
            //Arada sırada zor acılsın yanıp sonerek falan
            roomLight.SetActive(true);
        }
    }
}
