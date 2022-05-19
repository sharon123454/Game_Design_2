using UnityEngine;

public class TwoForOne : MonoBehaviour
{
    [SerializeField]
    CheckButton _one, _two;
    Animator _openSesame;

    private void Start()
    {
        _openSesame = GetComponent<Animator>();
    }

    private void Update()
    {
        Open();
    }

    void Open()
    {
        if (_one.isPushed && _two.isPushed)
        {
            _openSesame.Play("2Bit2");
        }
    }

}