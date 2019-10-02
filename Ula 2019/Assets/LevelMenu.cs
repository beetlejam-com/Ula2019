using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    private RectTransform LevelButton;
    // public GameObject myUiButton;
    // public Transform myPosition;
    void Start()
    {
        Debug.Log(LevelButton);
        // LevelButton = this;
        // Instantiate(myUiButton, myPosition.position + new Vector3(300f, 0, 0), myPosition.rotation);
        for (int i = 0; i < 10; i++)
        {
            // RectTransform clone;
            // clone = Instantiate(LevelButton, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
            
 
        }
    }
}