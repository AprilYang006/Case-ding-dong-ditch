using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Demoscreenscript : MonoBehaviour
{
    public string scenename;

    public void Loadscene()
    {
        SceneManager.LoadScene(scenename);
    }
}
