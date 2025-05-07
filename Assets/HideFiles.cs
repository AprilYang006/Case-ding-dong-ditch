using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    Button ButtonToHide;
    void Start()
    {
        ButtonToHide = GetComponent<Button>();
        ButtonToHide.onClick.AddListener(() => HideButton());
    }

    void HideButton()
    {
        ButtonToHide.gameObject.SetActive(false);
    }
}

