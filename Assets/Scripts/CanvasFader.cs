using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

public class CanvasFader : PersistentSingleton<CanvasFader>
{
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private Image loadingBar;
        [SerializeField] private float changeValue;
        [SerializeField] private float waitTime;
        [SerializeField] private bool fadeStarted;

        private void Start()
        {
                StartCoroutine(FadeIn());
        }

        public void FaderLoadString(string levelName)
        {
                StartCoroutine(FadeOutString(levelName));
        }
        
        public void FaderLoadInt(int levelIndex)
        {
                StartCoroutine(FadeOutInt(levelIndex));
        }

        private IEnumerator FadeIn()
        {
                canvasGroup.alpha = 1;
                loadingScreen.SetActive(false);
                fadeStarted = false;
                while (canvasGroup.alpha > 0)
                {
                        if (fadeStarted) yield break;
                        canvasGroup.alpha -= changeValue;
                        yield return new WaitForSeconds(waitTime);
                }
        }
        
        private IEnumerator FadeOutString(string levelName)
        {
                if (fadeStarted)
                        yield break;
                
                fadeStarted = true;
                while (canvasGroup.alpha < 1)
                {
                        canvasGroup.alpha += changeValue;
                        yield return new WaitForSeconds(waitTime);
                }

                //SceneManager.LoadScene(levelName);
                var asyncOp = SceneManager.LoadSceneAsync(levelName);
                asyncOp.allowSceneActivation = false;
                loadingScreen.SetActive(true);
                loadingBar.fillAmount = 0;

                while (!asyncOp.isDone)
                {
                        loadingBar.fillAmount = asyncOp.progress / 0.9f;
                        if (asyncOp.progress == 0.9f)
                        {
                                asyncOp.allowSceneActivation = true;
                        }
                        yield return null;
                }
                
                StartCoroutine(FadeIn());
        }
        
        private IEnumerator FadeOutInt(int levelIndex)
        {
                if (fadeStarted)
                        yield break;
                
                fadeStarted = true;
                while (canvasGroup.alpha < 1)
                {
                        canvasGroup.alpha += changeValue;
                        yield return new WaitForSeconds(waitTime);
                }

                // SceneManager.LoadScene(levelIndex);
                var asyncOp = SceneManager.LoadSceneAsync(levelIndex);
                asyncOp.allowSceneActivation = false;
                loadingScreen.SetActive(true);
                loadingBar.fillAmount = 0;

                while (!asyncOp.isDone)
                {
                        loadingBar.fillAmount = asyncOp.progress / 0.9f;
                        if (asyncOp.progress == 0.9f)
                        {
                                asyncOp.allowSceneActivation = true;
                        }
                        yield return null;
                }
                yield return new WaitForSeconds(0.1f);
                StartCoroutine(FadeIn());
        }
}