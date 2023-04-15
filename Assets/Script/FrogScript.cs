using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    private int life = 12;
    void Start()
    {
        transform.DOJump(new Vector3(100f, transform.position.y, transform.position.z), 1f, 20, 10f);
        Destroy(gameObject, life);
    }
    private void OnDestroy()
    {
        transform.DOKill();
    }
    private void Update()
    {
        if (!UIControl.tweenFrog)
        {
            transform.DOKill();
        }
    }
}
