using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public string scenename;

    public void Loadscene()
    {
        SceneManager.LoadScene(scenename);
    }
}
