using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;
    [SerializeField] string sceneToLoad; 

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) 
        {
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1); 
        SceneManager.LoadScene(sceneToLoad);
        transitionAnim.SetTrigger("Start");
    }
}
