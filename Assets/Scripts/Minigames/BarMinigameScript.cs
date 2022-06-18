using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarMinigameScript : MonoBehaviour
{

    public GameObject MainSlider;
    public GameObject L;
    public GameObject R;
    float gamepos;
    float leftSpot;
    float rightSpot;
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
        if(Input.GetKeyDown(KeyCode.Space) &&  leftSpot <= gamepos && gamepos <= rightSpot)
        {
            GameObject.Destroy(gameObject, 1.2f);
        }
    }
}
