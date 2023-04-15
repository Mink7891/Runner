using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConrolPlayerScrip : MonoBehaviour
{
    public GameObject shere, box;
    void Start()
    {
        if (MenuConrolScript.playerShere)
        {
            shere.SetActive(true);
            box.SetActive(false);
        }
        else
        {
            box.SetActive(true);
            shere.SetActive(false);
        }
    }

}
