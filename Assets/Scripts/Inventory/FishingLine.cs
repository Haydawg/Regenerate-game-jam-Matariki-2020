using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLine : Item
{
    [SerializeField]
    GameObject linePrefab;
    [SerializeField]
    float distTofish;
    Puddle_Script currentFish;
    [SerializeField]
    AudioClip audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void UseItem(Vector3 targetPos, IItemInteraction interaction)
    {
        currentFish = interaction as Puddle_Script;
        if (currentFish.isFish == false)
        {
            GameObject.Find("ed").GetComponent<TextInjector>().SubmitText();
            CastLine(targetPos, false);
            return;
        }
        if (Vector3.Distance(PlayerController.Instance.transform.position, targetPos) < distTofish)
        {
            CastLine(targetPos);
            currentFish.isHooked = true;
        }
        else
            Debug.Log("Fish is too Far");

    }
    void CastLine(Vector3 targetPos,bool dogame=true)
    {
        GameObject line = Instantiate(linePrefab);
        PlayerController.Instance.itemAudio.PlayOneShot(audio);
        line.transform.position = PlayerController.Instance.transform.position;
        Vector3 toDir = (targetPos - PlayerController.Instance.transform.position) * 2;
        line.transform.rotation = Quaternion.FromToRotation(Vector3.up, toDir);
        line.transform.GetComponent<Rigidbody>().velocity = toDir;
        
        if (dogame)
        {
            var game = Instantiate(GameManager.Instance.minigame);
            game.GetComponent<BarMinigameScript>().isFish = true;
        }

    }

}
