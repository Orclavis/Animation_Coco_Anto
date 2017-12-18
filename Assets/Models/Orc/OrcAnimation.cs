using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OrcAnimation : MonoBehaviour {
    Animator animator;
    Animation idle;
    GameObject FBX;
    GameObject porte;
    AudioSource audioSource;
    bool isWalking;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        FBX = GameObject.Find("FBX");
        porte = GameObject.Find("fi_vil_door04");
        audioSource = gameObject.GetComponent<AudioSource>();
        StartCoroutine(startAnim());
    }
	

    private IEnumerator startAnim()
    {
        yield return new WaitForSeconds(10);
        Sequence EntreeOrc = DOTween.Sequence();
        EntreeOrc.Append(porte.transform.DORotate(new Vector3(0, -90, 0), 3, RotateMode.LocalAxisAdd).SetLoops(2, LoopType.Yoyo));
        EntreeOrc.Insert(1, (gameObject.transform.DOMoveZ(-6, 4)).
            OnComplete(() => animator.SetBool("IsWalking", false))).
            OnStart(() => startWalking()).SetDelay(3);
    }
    private void startWalking()
    {
        animator.SetBool("IsWalking", true);
        audioSource.Play();
    }
}
