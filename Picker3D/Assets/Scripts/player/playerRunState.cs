using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRunState : playerBaseState
{
    private float speed = 10.0f;
    private Transform transfrm;
    private Rigidbody rgb;
    public override void EnterState(playerStateManager charachter)
    {
        transfrm = charachter.GetComponent<Transform>();
        rgb = charachter.GetComponent<Rigidbody>();
    }

    public override void OnTriggerEnter(playerStateManager charachter, Collider collisionInfo)
    {
        if(collisionInfo.CompareTag("Platform"))
        {
            collisionInfo.gameObject.SetActive(false);
            charachter.Balls.ThrowBalls();
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
        rgb.MovePosition(transfrm.position += new Vector3(-speed * Time.deltaTime, 0, 0));
    }
    private void runHorizontal()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rgb.MovePosition(transfrm.position += new Vector3(0, 0, speed * Time.deltaTime * horizontal));
    }
}
