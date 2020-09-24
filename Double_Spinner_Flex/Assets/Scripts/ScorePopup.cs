using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePopup : MonoBehaviour
{
    [SerializeField] TextMeshPro scorePopupPrefab;
    [SerializeField] float flyUpSpeed = 20f;

    int minScoreNum = 100;
    int maxScoreNum = 200;

    ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void PopUpScoreNumber()
    {
        var scorePopUp = Instantiate(scorePopupPrefab, transform.position, Quaternion.identity);
        int scoreValue = Random.Range(minScoreNum, maxScoreNum);
        scorePopUp.text = "+" + scoreValue.ToString();
        scorePopUp.transform.Translate(Vector3.up * flyUpSpeed * Time.deltaTime);
        scoreManager.AddToScore(scoreValue);
        Destroy(scorePopUp.gameObject, 1f);
    }
}
