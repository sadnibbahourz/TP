using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Refrences
    public KeyCode restart;

    #endregion

    #region Variables

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(restart))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
