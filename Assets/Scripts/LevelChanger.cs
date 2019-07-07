using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public bool Scene1;
    public Animator animator;

    private int level;

    private void Start()
    {
        if (Scene1 == true)
        {
            FadeToNextLevel();
        }
    }

    public void FadeToNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex!=2)
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else {
            FadeToLevel(0);
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        level = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(level); 
    }
}
