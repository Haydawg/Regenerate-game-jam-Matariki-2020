using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInjector : MonoBehaviour
{

    [MultilineAttribute]
    public string text = "";

    public GameObject textfield;


    public void Start()
    {
    }


    public void SubmitText()
    {
        var a = textfield.GetComponent<WindowText>();
        a.toggler.SetActive(true);
        a.Inject(text);

    }

   




    
}
