using System.Collections;
using UnityEngine;

public class ToReveal : MonoBehaviour
{
    [SerializeField]
    GameObject camera4Rev;
    [SerializeField]
    GameManager GM;
    Player _cache;
    bool _played = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!_played)
        {
            _cache = other.GetComponentInChildren<Player>();
            StartCoroutine(TriggerReveal());
        }
    }

    IEnumerator TriggerReveal()
    {
        _cache.enabled = false;
        camera4Rev.SetActive(true);
        GM.startPressed = false;
        yield return new WaitForSeconds(20);
        _cache.enabled = true;
        camera4Rev.SetActive(false);
        GM.startPressed = true;
        _played = true;
    }
}
