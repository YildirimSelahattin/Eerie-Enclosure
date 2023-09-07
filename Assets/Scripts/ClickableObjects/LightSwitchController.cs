using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchController : MonoBehaviour, IClickable
{
    [SerializeField]
    GameObject roomLight;

    int flag = 0;

    public void Click()
    {
        

        gameObject.GetOrAdComponent<AudioSource>().PlayOneShot(SoundManager.Instance.lightSwitch);

        if(roomLight.active)
        {
            roomLight.SetActive(false);
        }
        else
        {
            flag++;
            if(flag == 3)
            {
                StartCoroutine(Delay());
                flag = 0;
            }
            else
            {
                roomLight.SetActive(true);
            }
            
        }
    }

    IEnumerator Delay()
    {
        roomLight.SetActive(true);
        yield return new WaitForSeconds(.08f);
        roomLight.SetActive(false);
        yield return new WaitForSeconds(.1f);
        roomLight.SetActive(true);
    }
}
