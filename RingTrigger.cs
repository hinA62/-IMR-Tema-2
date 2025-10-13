using UnityEngine;

public class RingTrigger : MonoBehaviour
{
    public int ringScore = 0;

    private ScoreManager scoreManager;
    private const string Ball = "Grabbable";

    private static bool hasBallScoredThisThrow = false;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Ball))
        {
            if (hasBallScoredThisThrow)
            {
                return;
            }

            scoreManager.AddScore(ringScore);
            hasBallScoredThisThrow = true;

            HandleBallAfterHit(other.gameObject);
        }
    }


    public static void ResetScoringStatus()
    {
        hasBallScoredThisThrow = false;
    }

    public void ResetAllGameStatus()
    {
        RingTrigger.ResetScoringStatus();
    }

    private void HandleBallAfterHit(GameObject ball)
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        Collider ballCollider = ball.GetComponent<Collider>();

        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }
        if (ballCollider != null)
        {
            ballCollider.enabled = false;
        }

        Destroy(ball, 2f);
    }
}