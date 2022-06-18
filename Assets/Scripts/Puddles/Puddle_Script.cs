using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle_Script : MonoBehaviour, IItemInteraction
{
    Vector2 HorizontalDirection;
    GameObject WantedTorch;
    [SerializeField]
    List<Item> items;
    public bool isHooked;
    public bool isFish;



    private GameObject silhouette;
    public Sprite eel;
    public Sprite fish;
    IEnumerator MovementStateMachine()
    {

        Vector2 newdir = Random.insideUnitCircle.normalized * 0.002f;
        if (Random.value < 0.4f)
        {
            WantedTorch = null;

        }
        HorizontalDirection = newdir;
        yield return new WaitForSeconds(Random.value * 4);
        StartCoroutine("MovementStateMachine");
    }

    private void OnEnable()
    {
        BarMinigameScript.OnFish += Catch;
        BarMinigameScript.OnEel += Catch;
        BarMinigameScript.OnFail += Release;

    }

    private void OnDisable()
    {
        BarMinigameScript.OnFish -= Catch;
        BarMinigameScript.OnEel -= Catch;
        BarMinigameScript.OnFail -= Release;
    }

    IEnumerator TorchStateMachine()
    {
        foreach (GameObject torch in GameObject.FindGameObjectsWithTag("Torch"))
        {
            if (Random.value > 0.5)
            {
                WantedTorch = torch;
            }
        }
        yield return new WaitForSeconds(Random.value * 4);
        StartCoroutine("TorchStateMachine");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MovementStateMachine");
        StartCoroutine("TorchStateMachine");
        silhouette = transform.GetChild(0).gameObject;
        if (isFish)
        {
            silhouette.GetComponent<SpriteRenderer>().sprite = fish;
        }
        else
        {
            silhouette.GetComponent<SpriteRenderer>().sprite = eel;
        }
    }

    // Update is called once per frame
    void Update()
    {
        silhouette.transform.Rotate(new Vector3(0, 0, 90), 0.02f);
        if (!isHooked)
        {
            if (WantedTorch == null)
            {
                transform.Translate(new Vector3(HorizontalDirection.x, HorizontalDirection.y, 0));
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, WantedTorch.transform.position, 0.0006f);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        HorizontalDirection = new Vector2(collision.contacts[0].normal.x, collision.contacts[0].normal.z).normalized * 0.002f;
    }

    public bool CanInteract(Item item, out IItemInteraction interaction)
    {
        if (items.Contains(item))
        {
            interaction = this;
            return true;
        }
        else
        {
            interaction = null;
            return false;
        }

    }
    public void Catch()
    {
        if (isHooked)
        {
            Debug.Log("Caught");
            Destroy(gameObject);
        }
    }
    public void Release()
    {
        if (isHooked)
            isHooked = false;
    }
}
