using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private string sceneToTransitionTo;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadScene(int index)
    {
        LoadingScreen.Instance.Show(Transition());
    }
    
    AsyncOperation Transition()
    {
        return SceneManager.LoadSceneAsync(sceneToTransitionTo);
    }
}
