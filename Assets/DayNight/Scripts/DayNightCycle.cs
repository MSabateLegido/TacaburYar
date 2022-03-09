using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField, Range(0,1)] private float time;
    [SerializeField] private float fullDayLenghtSeconds = 600;
    [SerializeField] private float startTime = 0.5f;
    [SerializeField] private Vector3 noon = new Vector3(90,0,0);
    private float timeRate;

    [Header("Sun")]
    [SerializeField] private Light sun;
    [SerializeField] private Gradient sunColor;
    [SerializeField] private AnimationCurve sunIntensity;    
    
    [Header("Moon")]
    [SerializeField] private Light moon;
    [SerializeField] private Gradient moonColor;
    [SerializeField] private AnimationCurve moonIntensity;

    [Header("Other Lights")]
    [SerializeField] private AnimationCurve lightIntensity;
    [SerializeField] private AnimationCurve reflectionIntensity;
    // Start is called before the first frame update
    void Start()
    {
        time = startTime;
        timeRate = 1 / fullDayLenghtSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        //Increment time
        time += timeRate * Time.deltaTime;
        if (time >= 1) time = 0;

        //Rotating sun
        sun.transform.eulerAngles = (time - 0.25f) * noon * 4;

        //Rotating moon
        moon.transform.eulerAngles = (time - 0.75f) * noon * 4;

        //Light intensity
        sun.intensity = sunIntensity.Evaluate(time);
        moon.intensity = moonIntensity.Evaluate(time);

        //Change colors
        sun.color = sunColor.Evaluate(time);
        moon.color = moonColor.Evaluate(time);

        if (sun.intensity == 0 && sun.gameObject.activeInHierarchy) sun.gameObject.SetActive(false);
        if (sun.intensity > 0 && !sun.gameObject.activeInHierarchy) sun.gameObject.SetActive(true); 
        
        if (moon.intensity == 0 && moon.gameObject.activeInHierarchy) moon.gameObject.SetActive(false);
        if (moon.intensity > 0 && !moon.gameObject.activeInHierarchy) moon.gameObject.SetActive(true);

        //Lighting settings
        RenderSettings.ambientIntensity = lightIntensity.Evaluate(time);
        RenderSettings.reflectionIntensity = reflectionIntensity.Evaluate(time);
    }
}
