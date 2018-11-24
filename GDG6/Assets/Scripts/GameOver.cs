using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvas;
        private void Start()
        {
            canvas.alpha = 0;
            StartCoroutine(FadeIn());
        }

        private IEnumerator FadeIn()
        {
            float time = 0;
            while (time < 1f)
            {
                time += Time.deltaTime;
                canvas.alpha = time;
                yield return null;
            }

            yield return new WaitForSeconds(5f);

            SceneManager.LoadScene(0);
        }
    }
}