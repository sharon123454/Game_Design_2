using UnityEngine;

public abstract class WeaponAbs : MonoBehaviour
{
    int _maxAmmo, _magSize, _currentAmmo;
    bool _hasScope;
    string _name;

    public int CurrentAmmo { get => _currentAmmo; protected set => _currentAmmo = value; }
    public int MaxAmmo { get => _maxAmmo; protected set => _maxAmmo = value; }
    public int MagSize { get => _magSize; private set => _magSize = value; }
    public bool HasScope { get => _hasScope; private set => _hasScope = value; }
    public string Name { get => _name; private set => _name = value; }

    public WeaponAbs(string name, bool hasScope, int magSize, int maxAmmo)
    {
        Name = name; HasScope = hasScope; MagSize = magSize; MaxAmmo = maxAmmo;
        CurrentAmmo = MagSize;
    }

    public abstract bool Fire();

    void Scope(bool HasScope)
    {
        if (!HasScope)
        {
            return;
        }

        Debug.Log("Zoom");
    }

    public void Reload()
    {
        if (!(MaxAmmo > 0))
        {
            Debug.Log("Out of Ammo");
            return;
        }

        int ammoToFill = MagSize - CurrentAmmo;

        if (MaxAmmo <= ammoToFill)
        {
            CurrentAmmo += MaxAmmo;
            MaxAmmo = 0;
            return;
        }

        MaxAmmo -= ammoToFill;
        CurrentAmmo = MagSize;
    }

}