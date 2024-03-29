using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KaldiracKontroller : MonoBehaviour
{
    [SerializeField]
    GameObject acilacakEngel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ok"))
        {
            GetComponent<Animator>().SetTrigger("kaldiracAcilsin");
            GetComponent<BoxCollider2D>().enabled= false;
            acilacakEngel.transform.DOLocalMoveY(acilacakEngel.transform.localPosition.y + 0.4f, 1f);
        }
    }
}
