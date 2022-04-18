using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move_Button : MonoBehaviour
{
    // Start is called before the first frame update

    public void MoveWorkroom()
    {
        SceneManager.LoadScene("Workroom");
    }

    public void MoveMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void MoveSpoide()
    {
        SceneManager.LoadScene("Workroom_Spoide");
    }

    public void MoveConversation2()
    {
        SceneManager.LoadScene("Conversation2");
    }

    public void MoveConversation3()
    {
        SceneManager.LoadScene("Conversation3");
    }

}
