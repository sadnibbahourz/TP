using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Refrences
    public KeyCode restart;
    public GameObject player;
    #endregion

    #region Variables
    [Tooltip("The lowest the player can go without dieing")]
    public float lowest;
    #endregion
    // Start is called before the first frame update


    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(restart) || player.transform.position.y <= lowest)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
