using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float score;

    private void Awake()
    {
        instance = this;
    }
    public void ChangeScore(int amount)
    {
        score += amount;
        Debug.Log(score);
    }

}
