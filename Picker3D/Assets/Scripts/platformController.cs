using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class platformController : MonoBehaviour
{
    private int needBallCount = 10;
    private int collectedBallCount = 0;
    private float checkTime = 8;
    private float timer = 0;

    private bool started = false;

    [SerializeField] private playerStateManager Player;
    [SerializeField] private GameObject _Door1;
    [SerializeField] private GameObject _Door2;
    [SerializeField] private GameObject _MoveObject;
    [SerializeField] private Transform _MovePoss;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            collectedBallCount++;
        }
    }
    private void Update()
    {
        //Debug.Log("Collected : " + collectedBallCount);
        if(started)
        {
            Play();
        }
    }
    private void Play()
    {
        checkFail();
        checkPass();
    }
    public void StartPlatform()
    {
        timer = Time.time;
        started = true;
    }
    private void checkFail()
    {
        if(Time.time - timer > checkTime    &&  collectedBallCount < needBallCount)
        {
            //Failed
            Debug.Log("Failed");
        }
    }
    private void checkPass()
    {
        if(collectedBallCount >= needBallCount)
        {
            transform.DOMove(transform.position, 2).OnComplete(() => moveObject());
        }
    }
    private void moveObject()
    {
        _MoveObject.transform.DOMove(_MovePoss.position, 2).OnComplete(() => openDoors());
    }
    private void openDoors()
    {
        _MoveObject.GetComponent<BoxCollider>().isTrigger = false;
        _Door1.transform.DORotate(new Vector3(0, 90, 0), 2);
        _Door2.transform.DORotate(new Vector3(0, -90, 0), 2).OnComplete(() => movePlayer());
    }
    private void movePlayer()
    {
        Player.SwitchState(Player.RunState);
    }
}
