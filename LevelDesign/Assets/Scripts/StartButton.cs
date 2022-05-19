using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    GameManager GM;
    [SerializeField]
    GameObject PopUp;
    [SerializeField]
    Animator StartButtAnimation;
    [SerializeField]
    string AnimationName;
    bool _usable = false;

    private void OnTriggerEnter(Collider other)
    {
        _usable = true;
        PopUp.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (_usable && Input.GetKey(KeyCode.E))
        {
            StartButtAnimation.Play(AnimationName);
            GM.startPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _usable = false;
        PopUp.SetActive(false);
    }
}
