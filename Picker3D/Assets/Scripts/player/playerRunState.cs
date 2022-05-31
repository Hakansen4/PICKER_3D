using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRunState : playerBaseState
{
    private float speed;
    private Transform transfrm;
    private Rigidbody rgb;
    public override void EnterState(playerStateManager charachter)
    {
        init(charachter);
    }

    public override void OnTriggerEnter(playerStateManager charachter, Collider collisionInfo)
    {
        if(collisionInfo.CompareTag("Platform"))
        {
            collisionInfo.gameObject.SetActive(false);
            charachter.Balls.ThrowBalls();
            charachter.SwitchState(charachter.StopState);
            collisionInfo.gameObject.GetComponentInParent<platformController>().StartPlatform();
        }
        else if(collisionInfo.CompareTag("Finish"))
        {
            collisionInfo.GetComponentInParent<finishController>().finishWorks();
            charachter.SwitchState(charachter.StopState);
        }
    }

    public override void UpdateState(playerStateManager charachter)
    {
        run();
        runHorizontal();
    }

    private void run()
    {
        rgb.MovePosition(transfrm.position += new Vector3(-speed * Time.fixedDeltaTime, 0, 0));
    }
    private void runHorizontal()
    {
        float horizontal = Input.GetAxis("Horizontal");
        var vec = transfrm.position;
        var pos = vec += new Vector3(0, 0, speed * Time.fixedDeltaTime * horizontal);
        pos.z = Mathf.Clamp(pos.z, -10f, 10f);
        transfrm.position = pos;
            
    }
    private void init(playerStateManager charachter)
    {
        speed = charachter.Playerdata.speed;
        transfrm = charachter.GetComponent<Transform>();
        rgb = charachter.GetComponent<Rigidbody>();
    }
}
