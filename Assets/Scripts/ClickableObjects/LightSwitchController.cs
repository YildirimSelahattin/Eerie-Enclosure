using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchController : MonoBehaviour, IClickable
{
    [SerializeField]
    GameObject roomLight;

    public void Click()
    {
        gameObject.GetOrAdComponent<AudioSource>().PlayOneShot(SoundManager.Instance.lightSwitch);
        
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
