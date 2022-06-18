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
        if (Vector3.Distance(PlayerController.Instance.transform.position, targetPos) < distTofish)
        {
            CastLine(targetPos);
            currentFish.isHooked = true;
        }
        else
            Debug.Log("Fish is too Far");

    }
    void CastLine(Vector3 targetPos)
    {
        GameObject line = Instantiate(linePrefab, PlayerController.Instance.transform);
        line.GetComponent<Rigidbody>().velocity = ((targetPos - PlayerController.Instance.transform.position) * 2);
        Instantiate(GameManager.Instance.minigame);


    }

}
