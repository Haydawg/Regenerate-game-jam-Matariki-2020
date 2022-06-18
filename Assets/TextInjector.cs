using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInjector : MonoBehaviour
{

    [MultilineAttribute]
    public string curPut = "";

    public GameObject textfield;

    private void Start()
    {
        textfield.SetActive(true);
        var a = textfield.GetComponent<WindowText>();
        a.Inject(curPut);
        this.gameObject.SetActive(false);
    }

}
