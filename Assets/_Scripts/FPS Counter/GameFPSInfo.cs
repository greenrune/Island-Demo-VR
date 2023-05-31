using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public struct FPSColor {
    public Color color;
    public int minimumFPS;
}


public class GameFPSInfo : MonoBehaviour
{
    [Header("Target Frame")]
    public int frameRange = 60;

    [Header("Target Frame")]
    public TextMeshProUGUI averageFPSLabel, lowestFPSLabel, millisecondsLabel;
    [SerializeField]
    private FPSColor[] coloring;
    private int AverageFPS { get; set; }
    private float Milliseconds { get; set; }
    private int LowestFPS { get; set; }
    
    int[] fpsBuffer;
    int fpsBufferIndex;
    
    void Start()
    {
        Application.targetFrameRate = frameRange;
    }
    
    void Update()
    {
        if (fpsBuffer == null || fpsBuffer.Length != frameRange) {
            InitializeBuffer ();
        }
        
        UpdateBuffer ();
        CalculateFPS ();
        DisplayInfo();
    }

    #region Core

    void InitializeBuffer () {
            if (frameRange <= 0) {
                frameRange = 1;
            }
            fpsBuffer = new int[frameRange];
            fpsBufferIndex = 0;
        }
        
        void UpdateBuffer () {
            fpsBuffer[fpsBufferIndex++] = (int) (1f / Time.unscaledDeltaTime);
            if (fpsBufferIndex >= frameRange) {
                fpsBufferIndex = 0;
            }
        }
        
        void CalculateFPS () {
            int sum = 0;
            int lowest = int.MaxValue;
            for (int i = 0; i < frameRange; i++) {
                int fps = fpsBuffer[i];
                sum += fps;
                if (fps < lowest) {
                    lowest = fps;
                }
            }
            float milliSecond = frameRange * 1000 / sum;
            AverageFPS = (int) ((float) sum / frameRange);
            LowestFPS = lowest;
            Milliseconds = milliSecond;
        }

    #endregion

    #region Display

    void DisplayInfo()
    {
        DisplayFPSColor(averageFPSLabel, AverageFPS);
        DisplayFPSColor (lowestFPSLabel, LowestFPS);
        millisecondsLabel.text = string.Format ("{0: 0.0}", Milliseconds);
        
        void DisplayFPSColor (TextMeshProUGUI label, int fps) {
            label.text = Mathf.Clamp (fps, 0, 60).ToString();
            
            for (int i = 0; i < coloring.Length; i++) {
                if (fps >= coloring[i].minimumFPS) {
                    label.color = coloring[i].color;
                    break;
                }
            }
        }
    }

    #endregion
    
}
