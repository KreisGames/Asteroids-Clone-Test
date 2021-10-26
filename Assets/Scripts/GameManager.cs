using MovingObjectScripts.PlayerScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //UI fields
    [SerializeField] private Text speedText;
    [SerializeField] private Text angleText;
    [SerializeField] private Text numberOfLaserChargesText;
    [SerializeField] private Text coordsText;
    [SerializeField] private Text laserCooldownText;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject loseScreenCanvas;
    [SerializeField] private Text finalScoreText;

    private PlayerController _playerController;
    private PlayerDestroyer _playerDestroyer;
    private AmmoSystem _ammoSystem;

    //Set all refs
    private void Awake()
    {
        _playerController = player.GetComponent<PlayerController>();
        _playerDestroyer = player.GetComponent<PlayerDestroyer>();
        _ammoSystem = player.GetComponent<AmmoSystem>();
        Time.timeScale = 1;
    }

    //Check for death, if not - update UI
    private void Update()
    {
        if (_playerDestroyer.GetDeathState())
        {
            GameOver();
            return;
        }

        speedText.text = "Speed: " + _playerController.GetSpeed().ToString("N1");
        angleText.text = "Angle: " + player.transform.localRotation.eulerAngles.z.ToString("N1");
        coordsText.text = "Position: " + (Vector2)player.transform.position;
        numberOfLaserChargesText.text = "Laser: " + _ammoSystem.GetCurrentAmmoCount() + "/" + _ammoSystem.GetMaxAmmoCount();
        laserCooldownText.text = _ammoSystem.GetCooldown().ToString("N1");
    }
    
    private void GameOver()
    {
        Time.timeScale = 0;
        loseScreenCanvas.SetActive(true);
        finalScoreText.text = "Score: " + ScoreSystem.GetScore();
    }

    //Reloads scene
    public void RestartGame()
    {
        ScoreSystem.ResetScore();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    
}
