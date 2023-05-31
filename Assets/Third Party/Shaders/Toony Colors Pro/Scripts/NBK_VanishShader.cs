using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NBK_VanishShader : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] string varName = "";
    [Range(0, 1)]
    [SerializeField] float varValue = 1.0f;
    [SerializeField] float varDamp = 0.1f;


    private void Start()
    {
        if (PlayerPrefs.HasKey("Hide_Bridge")) varValue = PlayerPrefs.GetFloat("Hide_Bridge");
        else
        {
            varValue = 1;
            PlayerPrefs.SetFloat("Hide_Bridge", 1);
        }
    }

    void LateUpdate()
    {
        material.SetFloat(varName, varValue);
    }

    
    public void Execute()
    {
        varValue = 1;
        StartCoroutine(ChangeSomeValue(1,0,varDamp));
        PlayerPrefs.SetFloat("Hide_Bridge", 0);
    }
    
    public IEnumerator ChangeSomeValue(float oldValue, float newValue, float duration) {
        for (float t = 0f; t < duration; t += Time.deltaTime) {
            varValue = Mathf.Lerp(oldValue, newValue, t / duration);
            yield return null;
        }
        varValue = newValue;
    }
    
    [ContextMenu ("Set to Execute")]
    void Debug00 () {
        Execute ();
    }
}
