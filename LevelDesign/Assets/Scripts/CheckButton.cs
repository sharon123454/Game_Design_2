using UnityEngine;

public class CheckButton : MonoBehaviour
{
    public bool isPushed = false;
    bool _usable = false;

    private void Start()
    {
        isPushed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        _usable = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (_usable && Input.GetKey(KeyCode.E))
        {
            isPushed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _usable = false;
    }
}
