using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishController : MonoBehaviour
{
    public static finishController instance;

    [SerializeField] private GameObject finishScreen;

    private void Awake()
    {
        instance = this;
    }
    public void finishWorks()
    {
        finishScreen.SetActive(true);
    }
}
