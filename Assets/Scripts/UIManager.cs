using UnityEngine;
using TMPro;

//Ovo vjerojatno nije tocno niti radi kako treba.
//Sve ovo mi je jasno u teoriji i kad gledam kod i citam kuzim sve, ali cim treba sad ovo pospajati ili sto ja vec znam, gotovo, raspad sistema. 
//Ne znam sto vise radim, zasto pola stvari pise kako treba a nece se nista pospajat i funkcionirati.

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text playerHPText;
    [SerializeField] private TMP_Text loseText;

    [SerializeField] private PlayerHealth playerHP;
    [SerializeField] private GameObject endPanel;

    private void Start()
    {
        endPanel.SetActive(false);
        UpdateText();
    }

    private void UpdateText()
    {
        scoreText.text = $"Score {GameManager.instance.score}";
        playerHPText.text = $"HP {PlayerHealth.instance.currentHP}";
    }

    private void Lose()
    {
        endPanel.SetActive(true);
        loseText.text = "You Suck";
    }

    private void OnEnable()
    {
        playerHP.WhenDead += Lose; 
    }
    private void OnDisable()
    {
        playerHP.WhenDead -= Lose;
    }
}
