using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] ParticleSystem _particles;

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "ABC")
        {
            _particles.gameObject.SetActive(true);
            Destroy(this.gameObject, 0.5f);
        }
    }
}