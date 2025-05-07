using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Masonpathscript : MonoBehaviour
{
    public string scenename;

    public void Loadscene()
    {
        SceneManager.LoadScene(scenename);
    }

}
