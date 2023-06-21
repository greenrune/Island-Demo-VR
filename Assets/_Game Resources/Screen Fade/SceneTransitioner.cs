using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{

    public bool Auto = false;
    [SerializeField]
    private string sceneToTransitionTo;

    private void Start()
    {
        if (Auto) Invoke("Transition", 3);
    }
    private void Update()
    {

        if (!Auto)
        {
            if (Input.anyKeyDown)
            {
                Transition();
            }
        }

    }
    public void Transition()
    {
        LoadingScreen.Instance.ShowInBlack(SceneManager.LoadSceneAsync(sceneToTransitionTo));
    }
}