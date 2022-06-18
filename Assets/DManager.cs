using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DManager : MonoBehaviour
{

    public List<GameObject> fishdialogs;
    public List<GameObject> eeldialogs;
    public GameObject FailDialog;

    // Start is called before the first frame update
    private int FDex = 0;
    private int EDex = 0;
    void Start()
    {
        BarMinigameScript.OnFish += FishCondition;
        BarMinigameScript.OnEel += EelCondition;
        BarMinigameScript.OnFail += FailCondition;
    }

    void FailCondition()
    {
        FailDialog.GetComponent<TextInjector>().SubmitText();
    }

    void FishCondition()
    {
        fishdialogs[FDex].GetComponent<TextInjector>().SubmitText();
        FDex += 1;
    }

    void EelCondition()
    {
        eeldialogs[EDex].GetComponent<TextInjector>().SubmitText();
        EDex += 1;
    }
}
