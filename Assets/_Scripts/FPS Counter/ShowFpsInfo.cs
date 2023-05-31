using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowFpsInfo : MonoBehaviour {
    public int frameRange = 60;

    public float showTime = 1f;
    public TextMeshProUGUI FpsInfo;
    public TextMeshProUGUI milisecondsInfo;

    [SerializeField]
    Color maxColor;
    [SerializeField]
    Color minColor;

    private int count = 0;
    private int targetFrameRate = 0;
    private float deltaTime = 0f;

    void Start () {
        Application.targetFrameRate = frameRange;
        targetFrameRate = frameRange;
    }
    public void SwitchFPS (int value) {
        Application.targetFrameRate = value;
        targetFrameRate = value;
    }

    // Update is called once per frame
    void Update () {
        count++;
        deltaTime += Time.deltaTime;
        if (deltaTime >= showTime) {
            float fps = count / deltaTime;
            float milliSecond = deltaTime * 1000 / count;
            //string fpsInfostr = string.Format ("{1: 0.}", fps);
            string msFpsInfo = string.Format ("{0: 0.0}", milliSecond);
            FpsInfo.text = Mathf.RoundToInt (fps).ToString ();
            FpsInfo.color = Color.Lerp (minColor, maxColor, fps / targetFrameRate);
            milisecondsInfo.text = msFpsInfo;
            count = 0;
            deltaTime = 0f;
        }
    }

}