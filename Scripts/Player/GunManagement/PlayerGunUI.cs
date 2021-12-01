using UnityEngine;
using TMPro;
using GunClasses;

namespace PlayerClasses.GunClasses
{
    public class PlayerGunUI : MonoBehaviour
    {
        private Gun _currentGun;

        private void Start()
        {
            _currentGun = GetComponent<PlayerGunSwap>().CurrentGun;
            GetComponent<PlayerGunSwap>().OnGunSwap += UpdateGunOnSwap;
        }

        private void UpdateGunOnSwap(Gun gun)
        {

        }
    }
}