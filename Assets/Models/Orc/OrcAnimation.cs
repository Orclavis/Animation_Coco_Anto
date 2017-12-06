using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAnimation : MonoBehaviour {
    Animator animator;
    Animation idle;
    GameObject FBX;
    bool isWalking;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        FBX = GameObject.Find("FBX");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetFloat("Speed", 2.0f);
            isWalking = true;
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetFloat("Speed", 0.0f);
            isWalking = false;
        }
        if (isWalking)
        {
            FBX.transform.Translate(new Vector3(0, 0, 0.01f));
        }
    }
}
