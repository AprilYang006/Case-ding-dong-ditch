using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideButtonScript : MonoBehaviour
{
    Button ButtonToHide;
    [SerializeField] private GameObject CaseFile;
    [SerializeField] private GameObject Masons;
    void Start()
    {
        CaseFile.SetActive(true);
        Masons.SetActive(false);
    }


    void Clickthisbutton()
    {
        CaseFile.SetActive(false);
        Masons.SetActive(true);
    }
    
}
