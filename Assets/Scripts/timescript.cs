using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timescript : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 10f;
    [SerializeField]
    private string scenenametoload;
    private float timeElapsed;



    private void Start()
    {

        Invoke("Changecene", delayBeforeLoading);

    }

    void Changecene()
    {

        SceneManager.LoadScene(scenenametoload);
    }

}
