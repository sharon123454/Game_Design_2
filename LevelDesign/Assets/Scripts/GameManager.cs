using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    WeaponAbs currentGun;

    //Text
    [SerializeField]
    Text Current;
    [SerializeField]
    Text Max;
    [SerializeField]
    Text Timer;

    [SerializeField]
    GameObject StartButton;
    float addedTime = 0;
    public bool startPressed = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Current.text = currentGun.CurrentAmmo.ToString();
        Max.text = "/" + currentGun.MaxAmmo.ToString();
        if (startPressed)
        {
            addedTime += Time.deltaTime;
            Timer.text = addedTime.ToString();
        }
    }

    public void TimeToAdd(float num)
    {
        addedTime += num;
    }

}
