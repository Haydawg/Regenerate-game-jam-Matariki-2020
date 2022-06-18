using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle_Script : MonoBehaviour
{
    Vector2 HorizontalDirection;
    GameObject WantedTorch;
    IEnumerator MovementStateMachine()
    {
        WantedTorch = null;
        HorizontalDirection = Random.insideUnitCircle.normalized * 0.002f;
        yield return new WaitForSeconds(Random.value * 4);
        StartCoroutine("MovementStateMachine");
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
    }

    // Update is called once per frame
    void Update()
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

    private void OnCollisionEnter(Collision collision)
    {
        HorizontalDirection = new Vector2(collision.contacts[0].normal.x, collision.contacts[0].normal.z).normalized * 0.002f;
    }


}
