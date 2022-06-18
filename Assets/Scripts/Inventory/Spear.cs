using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Item
{
    [SerializeField]
    GameObject spearPrefab;
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
            ThrowSpear(targetPos);
            currentFish.isHooked = true;
        }
        else
            Debug.Log("Fish is too Far");

    }
    void ThrowSpear(Vector3 targetPos)
    {
        GameObject spear = Instantiate(spearPrefab);
        spear.transform.position = PlayerController.Instance.transform.position;
        Vector3 toDir = (targetPos - PlayerController.Instance.transform.position) * 2;
        spear.transform.rotation = Quaternion.FromToRotation(Vector3.up, toDir);
        spear.transform.GetChild(0).GetComponent<Rigidbody>().velocity = toDir;
        var game = Instantiate(GameManager.Instance.minigame);
        game.GetComponent<BarMinigameScript>().isFish = false;


    }

}
