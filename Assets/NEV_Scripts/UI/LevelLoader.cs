using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slider;

        
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadYourAsyncScene(sceneIndex));
    }

    IEnumerator LoadYourAsyncScene(int sceneIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        LoadingScreen.SetActive(true);

        while (!asyncLoad.isDone)
        {
            slider.value = asyncLoad.progress; 
            yield return null;
        }
    }
}