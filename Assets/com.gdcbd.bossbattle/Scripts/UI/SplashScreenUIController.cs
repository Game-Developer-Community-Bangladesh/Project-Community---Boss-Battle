using UnityEngine;

namespace com.gdcbd.bossbattle.utility
{
    public class SplashScreenUIController : MonoBehaviour
    {
        public void EulaAction(bool accepted)
        {
            if(!accepted)
                Application.Quit();
        }
    }
}
