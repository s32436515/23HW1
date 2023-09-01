using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Animator animator;

    public playerController playerCtrl;

    bool playerMove;


    void Start()
    {
        playerCtrl = new playerController();
        animator = player.GetComponent<Animator>();
    }

    void Update()
    {
        animSwitcher();
    }

    void animSwitcher()
    {
        animator.SetBool("playerMove", playerMove);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) playerMove = true;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) playerMove = true;
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) playerMove = false;
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) playerMove = false;
    }

}
