using UnityEngine;

public class AK47 : WeaponAbs
{
    [SerializeField]
    ParticleSystem particle;

    public AK47()
        : base("AK-47", false, 30, 0)
    {
        CurrentAmmo = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }

        if ((Input.GetKeyDown(KeyCode.R) && CurrentAmmo < MagSize))
        {
            Reload();
        }
    }

    public override bool Fire()
    {
        if (CurrentAmmo > 0)
        {
            CurrentAmmo--;
            particle.Play();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddAmmo()
    {
        MaxAmmo += MagSize;
    }

}