using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DManager : MonoBehaviour
{

    public List<GameObject> fishdialogs;
    public List<GameObject> eeldialogs;
    public GameObject FailDialog;
    public GameObject EelImage;
    public GameObject FishImage;

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
        print("Fish caught");
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
        var a = GameObject.Find("DiagHolder");
        yield return new WaitUntil(() => a.activeInHierarchy == false);
        EelImage.SetActive(false);
    }
       
    
    IEnumerator ShowFish()
    {
        FishImage.SetActive(true);
        var a = GameObject.Find("DiagHolder");
        yield return new WaitUntil(() => a.activeInHierarchy == false);
        FishImage.SetActive(false);
    }
    
}
