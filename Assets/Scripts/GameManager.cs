using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    protected int points = 0;
    public WarningText txtWarning;
    public TMP_Text txtFinalScore;
    public Button lv2Btn;
    protected string currScene = "Lv1";
    static GameManager instance;
    public static GameManager GetInstance() {
        return instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null) {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(string sceneName) {
        currScene = sceneName;
        lv2Btn.gameObject.SetActive(false);
        SceneManager.LoadScene(sceneName);
    }

    public string GetCurrentSceneName () {
        return currScene;
    }

    public void AddPoints(int n) {
        points += n;
        txtWarning.Show((n > 0 ? "+" : "") + n + " Points");
    }

    public void EndLv1() {
        lv2Btn.gameObject.SetActive(true);
    }

    public void EndLv2() {
        txtFinalScore.text = "Your final score is " + points;
    }

    public int GetPoints() {
        return points;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
