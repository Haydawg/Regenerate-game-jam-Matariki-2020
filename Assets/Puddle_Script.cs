using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle_Script : MonoBehaviour
{
    Vector2 HorizontalDirection;
    IEnumerator MovementStateMachine()
    {
        HorizontalDirection = Random.insideUnitCircle.normalized * 0.002f;
        yield return new WaitForSeconds(Random.value * 4);
        StartCoroutine("MovementStateMachine");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MovementStateMachine");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(HorizontalDirection.x,HorizontalDirection.y,0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        HorizontalDirection = new Vector2(collision.contacts[0].normal.x, collision.contacts[0].normal.z).normalized * 0.002f;
    }


}
