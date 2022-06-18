using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneTransition : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Luke Test Scene");
    }

    
}
