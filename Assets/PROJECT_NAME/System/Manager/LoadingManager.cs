using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingManager : SingletonPersistant<LoadingManager>
{
    public delegate void FadeInLoadingScreenDelegate(float nbSec);
    public event FadeInLoadingScreenDelegate FadeInLoadingScreen;
    public delegate void FadeOutLoadingScreenDelegate(float nbSec);
    public event FadeInLoadingScreenDelegate FadeOutLoadingScreen;

    private float nbSecForFade = 1f;

    private Scene currentScene;

    public void ChangeScene(string sceneToLoad)
    {
        StartCoroutine(LoadSceneAsync(sceneToLoad));
    }
    
    private IEnumerator LoadSceneAsync(string newSceneToLoad)
    {
        Scene oldScene = SceneManager.GetActiveScene();

        //Load LoadingScreen if not yet loaded
        if(!SceneManager.GetSceneByName("LoadingScreen").IsValid())
        {
            SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Additive);
            yield return null;
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("LoadingScreen"));

        print("1");

        //FadeIn loading screen
        //FadeInLoadingScreen(nbSecForFade);
        yield return new WaitForSeconds(nbSecForFade);
        print("2");
        //Unload old scene
        AsyncOperation asyncTask = SceneManager.UnloadSceneAsync(oldScene);
        while (!asyncTask.isDone)
        {
            yield return null;
        }
        print("3");

        //Load new scene
        asyncTask = SceneManager.LoadSceneAsync(newSceneToLoad, LoadSceneMode.Additive);
        while (!asyncTask.isDone)
        {
            yield return null;
        }
        print("4");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(newSceneToLoad));
        
        //TODO temp fix because fade in/out busted
        asyncTask = SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("LoadingScreen"));
        while (!asyncTask.isDone)
        {
            yield return null;
        }
        print("5");
        //FadeOut loadingScreen
        //FadeOutLoadingScreen(nbSecForFade);
        yield break;
    }
}
