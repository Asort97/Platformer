using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void EnablePause(bool isEnabled)
    {
        pausePanel.SetActive(isEnabled);
        Time.timeScale = isEnabled ? 0f : 1f;
    }
}
