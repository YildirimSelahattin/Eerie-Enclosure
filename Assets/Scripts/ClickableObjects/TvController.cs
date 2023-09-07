using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvController : MonoBehaviour, IClickable
{
    public Light spotLight;
    List<float> numberList = new List<float> { .1f, .2f, .4f, .7f };

    [SerializeField]
    List<Texture> tvScreenImgList = new List<Texture>();
    Texture tvScreenImage;
    int currentIndex = 0;

    [SerializeField]
    MeshRenderer tvPanel;

    public float screenSpeed = 2f;

    void Start()
    {
        StartCoroutine(RandomTvLight());
    }
    public void Click()
    {
        //ToDo:
        //Click sesi
        //Ve değisen kanala gore yeni tv sesi
        TvZip(tvPanel.material);
    }

    IEnumerator RandomTvLight()
    {
        float time = numberList.Rand();
        RandomTvLightIntensity(time);
        SetEmissionIntensity(tvPanel.material, time);
        yield return new WaitForSeconds(time);
        StartCoroutine(RandomTvLight());
    }

    void Update()
    {
        ScroolScreen();
    }

    void RandomTvLightIntensity(float time)
    {

        float innerAngle = Random.Range(40f, 60f);
        float outerAngle = innerAngle + 20;
        spotLight.innerSpotAngle = innerAngle;
        spotLight.spotAngle = outerAngle;
        spotLight.intensity = time / 1.5f;
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

    void TvZip(Material material)
    {
        tvScreenImage = tvScreenImgList.NextItem(ref currentIndex);
        material.SetTexture("_EmissionMap", tvScreenImage);
        material.EnableKeyword("_EMISSION");
    }
}
