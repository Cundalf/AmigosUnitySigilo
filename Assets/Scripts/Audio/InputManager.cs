using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Singleton
    private static InputManager _sharedInstance = null;

    public static InputManager sharedInstance
    {
        get
        {
            return _sharedInstance;
        }
    }

    private void Awake()
    {
        if (_sharedInstance != null && _sharedInstance != this)
        {
            Destroy(gameObject);
            return;
        }

        _sharedInstance = this;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (GameManager.sharedInstance.actualGameState == GameManager.GameState.InGame)
        {
            // Ataque del personaje (default: left mouse)
            if (Input.GetButton("Fire1")) 
            {
                //GameManager.sharedInstance.actualPlayer.GetComponent<WeaponController>().shoot();
                return;
            }

            // Ataque secundario del personaje (default: right mouse)
            if (Input.GetButtonUp("Fire2"))
            {
                return;
            }

            // Boton de cambiar arma (default: q)
            if (Input.GetButtonUp("ChangeWeapon"))
            {
                //GameManager.sharedInstance.actualPlayer.GetComponent<WeaponController>().quickChangeOfWeapon();
                return;
            }

            // Boton de recarga (default: r)
            if (Input.GetButtonUp("Reload"))
            {
                //GameManager.sharedInstance.actualPlayer.GetComponent<WeaponController>().reload();
                return;
            }

        }
        
        // Menu (default: Escape)
        if (Input.GetButtonUp("Cancel"))
        {
            switch(GameManager.sharedInstance.actualGameState)
            {
                case GameManager.GameState.InGame:
                    GameManager.sharedInstance.PauseGame();
                    break;
                case GameManager.GameState.Pause:
                    GameManager.sharedInstance.ResumeGame();
                    break;
            }
            return;
        }
    }
}
