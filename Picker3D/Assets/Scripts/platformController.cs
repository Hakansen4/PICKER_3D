using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class platformController : MonoBehaviour
{
    [SerializeField] private PlatformData Platformdata;

    private int needBallCount;
    private int collectedBallCount = 0;
    private float checkTime;
    private float timer = 0;

    private bool started = false;
    private bool finished = false;

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private playerStateManager Player;
    [SerializeField] private GameObject _Door1;
    [SerializeField] private GameObject _Door2;
    [SerializeField] private GameObject _MoveObject;
    [SerializeField] private Transform _MovePoss;
    [SerializeField] private GameObject _LevelFailedScreen;

    private void Awake()
    {
        init();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            collectedBallCount++;
        }
    }
    private void Update()
    {
        updateText();
        if (started  &&  !finished)
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
            _LevelFailedScreen.SetActive(true);
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
        finished = true;
    }
    private void updateText()
    {
        _text.text = collectedBallCount.ToString() + " / " + needBallCount.ToString();
    }
    private void init()
    {
        needBallCount = Platformdata.NeedBall;
        checkTime = Platformdata.CheckTime;
    }
}
