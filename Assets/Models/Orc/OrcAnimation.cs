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

    void Update()
    {
        if (Input.GetKeyDown("space")){
            animator.SetBool("IsDancing", true);
            //animator.SetBool("IsDancing", false);
            StartCoroutine(GiveSword());
        }
    }

    private IEnumerator startAnim()
    {
        yield return new WaitForSeconds(1);
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

    private IEnumerator GiveSword()
    {
        yield return new WaitForSeconds(7);
        gameObject.transform.DORotate(new Vector3(0, 180, 0), 3, RotateMode.LocalAxisAdd);
        yield return new WaitForSeconds(4);
        Sequence SortieOrc = DOTween.Sequence();
        SortieOrc.Append(porte.transform.DORotate(new Vector3(0, -90, 0), 3, RotateMode.LocalAxisAdd));
        SortieOrc.Append(gameObject.transform.DOMoveZ(-2.2f, 4).
            OnComplete(() => endWalking()).
            OnStart(() => animator.SetBool("IsWalking", true)));
        SortieOrc.Append(porte.transform.DORotate(new Vector3(0, 90, 0), 3, RotateMode.LocalAxisAdd));
    }

    private void endWalking()
    {
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsDancing", false);
    }

}
