using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectedBalls : MonoBehaviour
{
    public static collectedBalls instance;

    public List<GameObject> Balls;
    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Balls.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            foreach (var item in Balls)
            {
                if (item.name == other.gameObject.name)
                {
                    Balls.Remove(item);
                    break;
                }
            }
        }
    }

    public void ThrowBalls()
    {
        foreach (var item in Balls)
        {
            item.GetComponent<Rigidbody>().AddForce(new Vector3(-400, 400, 0));
        }
    }
}