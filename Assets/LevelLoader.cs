using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public void LoadLevel(int buildIndex)
    {
        StartCoroutine(Load(buildIndex));
    }

    IEnumerator Load(int buildIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(buildIndex);
    }
}
