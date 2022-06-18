using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DManager : MonoBehaviour
{

    public List<GameObject> dialogs;
    public GameObject FailDialog;

    // Start is called before the first frame update
    private int DDex = 0;
    void Start()
    {
        BarMinigameScript.OnSuccess += MainCondition;
        BarMinigameScript.OnFail += FailCondition;
    }

    void FailCondition()
    {
        FailDialog.GetComponent<TextInjector>().SubmitText();
    }

    void MainCondition()
    {
        dialogs[DDex].GetComponent<TextInjector>().SubmitText();
        DDex += 1;
    }
}
