using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static event Action<int> OnGoalScored;
    [SerializeField] private int totalScore = 0;

    public void AddScore(int points)
    {
        totalScore += points;

        Debug.Log($"Gained: {points}. Total score: {totalScore}");
        OnGoalScored?.Invoke(points);
    }
}