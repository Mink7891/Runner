using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFrogScript : MonoBehaviour
{
    public GameObject frog;
    private void Start()
    {
        InvokeRepeating("Spawn", 1f, 1f);
    }
    public Vector3 PositionSpawn()
    {
        Vector3 vector = new Vector3();
        int rnd = Random.Range(1, 4);
        switch (rnd)
        {
            case 1:
                vector = new Vector3(-100f, 0.076f, 0);
                break;
            case 2:
                vector = new Vector3(-100f, 0.076f, 4);
                break;
            case 3:
                vector = new Vector3(-100f, 0.076f, 8);
                break;
        }
        return vector;

    }
    public void Spawn()
    {
        Instantiate(frog, PositionSpawn(), frog.transform.rotation);
    }


}
