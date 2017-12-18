using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OrcAnimation : MonoBehaviour {
    Animator animator;
    Animation idle;
    GameObject FBX;
    GameObject porte;
    bool isWalking;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        FBX = GameObject.Find("FBX");
        porte = GameObject.Find("fi_vil_door04");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Sequence EntreeOrc = DOTween.Sequence();
            EntreeOrc.Append(porte.transform.DORotate(new Vector3(0, -90, 0), 3, RotateMode.LocalAxisAdd).SetLoops(2, LoopType.Yoyo));
            EntreeOrc.Insert(1, (gameObject.transform.DOMoveZ(-6, 4)).
                OnComplete(() => animator.SetBool("IsWalking", false))).
                OnStart(() => animator.SetBool("IsWalking", true));

        }
    }

}
