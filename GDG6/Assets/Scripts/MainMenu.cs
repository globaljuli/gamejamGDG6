using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool loading = false;
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            LoadLevel1();
        }
    }

    private void LoadLevel1()
    {
        if (!loading)
        {
            loading = true;
            StartCoroutine(FadeAndLoadScene(1));
        }
    }

    private IEnumerator FadeAndLoadScene(int sceneIndex)
    {
        Instantiate(PrefabsManager.instance.FadeOutCanvas);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneIndex);
    }
}