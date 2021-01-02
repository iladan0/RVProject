using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    // Start is called before the first frame update
    public void BacktoMain()

    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}
