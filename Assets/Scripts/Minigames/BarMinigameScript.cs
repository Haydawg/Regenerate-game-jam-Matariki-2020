using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarMinigameScript : MonoBehaviour
{

    public GameObject MainSlider;
    public GameObject L;
    public GameObject R;
    public bool isFish;
    float gamepos;
    float leftSpot;
    float rightSpot;

    public static event HandleOnFish OnFish;
    public delegate void HandleOnFish();
    public static event HandleOnEel OnEel;
    public delegate void HandleOnEel();

    public static event HandleFail OnFail;
    public delegate void HandleFail();
    // Start is called before the first frame update
    void Start()
    {
        MainSlider = GameObject.Find("Main");
        L =  GameObject.Find("Left");
        R =  GameObject.Find("Right");
        leftSpot = Random.value;
        rightSpot = Mathf.Lerp(leftSpot, 1, Random.value + 0.02f);

        MainSlider.GetComponent<Slider>().value = rightSpot;
        L.GetComponent<Slider>().value = leftSpot;
        R.GetComponent<Slider>().value = rightSpot;

    }

    // Update is called once per frame
    void Update()
    {
        gamepos = 0.5f+0.5f*Mathf.Sin(Time.time * 3);
        MainSlider.GetComponent<Slider>().value = gamepos;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (leftSpot <= gamepos && gamepos <= rightSpot)
                Succeess();
            else
                Failure();
        }
       
    }
    public void Succeess()
    {
        if (isFish)
        {
            OnFish.Invoke();
        }else
        {
            OnEel.Invoke();
        }
        Debug.Log("Caught fish");
        GameObject.Destroy(gameObject, 0.2f);

    }
    public void Failure()
    {
        OnFail.Invoke();
        Debug.Log("Fish escaped");
        GameObject.Destroy(gameObject, 0.2f);

    }
}
