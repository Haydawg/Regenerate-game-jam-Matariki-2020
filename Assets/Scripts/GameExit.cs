using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForEscape());
    }

    

    IEnumerator WaitForEscape()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Escape));
        this.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    public void CloseMenu()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine(WaitForEscape());
    }
}
