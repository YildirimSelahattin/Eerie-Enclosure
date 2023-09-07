using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvController : MonoBehaviour
{
    public Light spotLight;
    List<float> numberList = new List<float> { .1f, .2f, .4f, .7f };

    [SerializeField]
    MeshRenderer tvPanel;

    public float screenSpeed = 2f;

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
        spotLight.intensity = time / 1.5f;
        SetEmissionIntensity(tvPanel.material, time);
        yield return new WaitForSeconds(time);
        StartCoroutine(RandomTvLight());
    }

    void Update()
    {
        ScroolScreen();
    }

    void SetEmissionIntensity(Material material, float color)
    {
        Color emissionColor = material.GetColor("_EmissionColor");
        emissionColor = new Color(color, color, color);
        material.SetColor("_EmissionColor", emissionColor);
    }

    void ScroolScreen()
    {
        tvPanel.materials[0].mainTextureOffset += new Vector2(screenSpeed * Time.deltaTime, 0f);
    }
}
