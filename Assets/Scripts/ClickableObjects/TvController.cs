using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TvController : MonoBehaviour, IClickable
{
    public Light spotLight;
    List<float> numberList = new List<float> { .1f, .2f, .4f, .7f };

    [SerializeField]
    List<Texture> tvScreenImgList = new List<Texture>();
    Texture tvScreenImage;
    int currentTextureIndex = 0;
    int currentAudioClipIndex = 0;

    [SerializeField]
    MeshRenderer tvPanel;

    public float screenSpeed = 2f;

    int flag = 0;

    void Start()
    {
        StartCoroutine(RandomTvLight());
    }

    void Update()
    {
        ScroolScreen();
    }

    public void Click()
    {
        gameObject.GetOrAdComponent<AudioSource>().PlayOneShot(SoundManager.Instance.tvZip);

        Action selectedAction = (flag == tvScreenImgList.Count) ? TvOff : TvZip;
        selectedAction.Invoke();
    }

    void TvZip()
    {
        flag++;
        tvPanel.material.SetColor("_EmissionColor", Color.white);
        spotLight.gameObject.SetActive(true);

        tvScreenImage = tvScreenImgList.NextItem(ref currentTextureIndex);
        tvPanel.material.SetTexture("_EmissionMap", tvScreenImage);
        tvPanel.material.EnableKeyword("_EMISSION");

        AudioSource sound = gameObject.GetComponent<AudioSource>();
        sound.clip = (SoundManager.Instance.tvShows.NextItem(ref currentAudioClipIndex));
        sound.loop = true;
        sound.Play();
    }

    IEnumerator RandomTvLight()
    {
        float time = numberList.Rand();
        RandomTvLightIntensity(time);
        SetEmissionIntensity(tvPanel.material, time);
        yield return new WaitForSeconds(time);
        StartCoroutine(RandomTvLight());
    }

    void RandomTvLightIntensity(float time)
    {
        float innerAngle = UnityEngine.Random.Range(40f, 60f);
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

    [ContextMenu("TvOff")]
    void TvOff()
    {
        flag = 0;
        StopAllCoroutines();
        gameObject.GetComponent<AudioSource>().Stop();
        tvPanel.material.SetColor("_EmissionColor", Color.black);
        spotLight.gameObject.SetActive(false);
    }
}
