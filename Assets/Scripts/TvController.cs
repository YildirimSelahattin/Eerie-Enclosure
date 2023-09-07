using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvController : MonoBehaviour
{
    public Light spotLight;
    List<float> numberList = new List<float> { .1f, .2f, .4f, .7f };

    void Start()
    {
        StartCoroutine(RandomTvLight());
    }

    IEnumerator RandomTvLight()
    {
        float time = numberList.Rand();
        float innerAngle = Random.Range(40f, 60f);
        float outerAngle = innerAngle + 20;
        spotLight.innerSpotAngle = innerAngle;
        spotLight.spotAngle = outerAngle;
        spotLight.intensity = time/1.5f;
        yield return new WaitForSeconds(time);
        StartCoroutine(RandomTvLight());
    }
}
