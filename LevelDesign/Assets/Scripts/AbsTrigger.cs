using UnityEngine;

public class AbsTrigger : MonoBehaviour
{
    [SerializeField]
    Animator animatedObj;
    [SerializeField]
    string AniName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animatedObj.Play(AniName);
        }
    }
}