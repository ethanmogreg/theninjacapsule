using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal4 : MonoBehaviour
{
    // Start is called before the first frame update
    private bool hasReachedGoal = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKey && hasReachedGoal)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level5");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0.00001f;
            hasReachedGoal = true;

        }
    }
}
