using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DManager : MonoBehaviour
{

    public List<GameObject> fishdialogs;
    public List<GameObject> eeldialogs;
    public GameObject FailDialog;
    public GameObject FinishDialog;
    public GameObject EelImage;
    public GameObject FishImage;
    private GameObject diag;


    // Start is called before the first frame update
    private int FDex = 0;
    private int EDex = 0;
    void Start()
    {
        BarMinigameScript.OnFish += FishCondition;
        BarMinigameScript.OnEel += EelCondition;
        BarMinigameScript.OnFail += FailCondition;
        StartCoroutine(WaitForLastMessageDone());
    }

    void FailCondition()
    {
        FailDialog.GetComponent<TextInjector>().SubmitText();
    }

    void FishCondition()
    {
        fishdialogs[FDex].GetComponent<TextInjector>().SubmitText();
        FDex += 1;
        StartCoroutine(ShowFish());
    }

    void EelCondition()
    {
        eeldialogs[EDex].GetComponent<TextInjector>().SubmitText();
        EDex += 1;
        StartCoroutine(ShowEel());
    }

 

    IEnumerator ShowEel()
    {
        EelImage.SetActive(true);
        yield return new WaitUntil(() => WindowText.isDone == true);
        EelImage.SetActive(false);
    }
       
    
    IEnumerator ShowFish()
    {
        FishImage.SetActive(true);
        yield return new WaitUntil(() => WindowText.isDone==true);
        FishImage.SetActive(false);
    }


    IEnumerator WaitForLastMessageDone()
    {
        yield return new WaitUntil(() => EDex >=3 && FDex >= 3);
        yield return new WaitUntil(() => WindowText.isDone ==true);
        FinishDialog.GetComponent<TextInjector>().SubmitText();
    }
    
}
