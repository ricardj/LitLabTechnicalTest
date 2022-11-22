using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RestartGame : IAction<VoidAction>
{
    public override void ExecuteAction(VoidAction data = null, UnityAction onFinish = null)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Update()
    {
        //DEBUG KEY
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ExecuteAction();
            }
        }
    }


}
