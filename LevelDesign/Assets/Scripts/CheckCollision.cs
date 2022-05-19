using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    [SerializeField]
    GameManager GM;

    private void OnParticleCollision(GameObject other)
    {
        if (other.layer == 8)
        {
            if (other.CompareTag("Enemy"))
            {
                other.SetActive(false);
                GM.TimeToAdd(-2f);
            }
            if (other.CompareTag("Friendly"))
            {
                other.SetActive(false);
                GM.TimeToAdd(10f);
            }
        }
    }
}
