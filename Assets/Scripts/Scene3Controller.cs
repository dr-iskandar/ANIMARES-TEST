using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene3Controller : MonoBehaviour
{
    private float alphanya;
    private GameObject lastSphere;

    public LevelChanger levelchanger;
    public GameObject aditionalObject;

    private void Start()
    {
        lastSphere = GameObject.FindGameObjectWithTag("Sphere");
    }

    private void Update()
    {
        if (alphanya<=254)
        {
            alphanya += Time.deltaTime * 50f;
            aditionalObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, (byte)alphanya);
        }
    }

    public void restart()
    {
        levelchanger.FadeToNextLevel();
    }

    public void OnFadeComplete()
    {
        Destroy(lastSphere);
        SceneManager.LoadScene("Scene-1");
    }
}
