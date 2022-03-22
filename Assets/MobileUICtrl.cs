using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileUICtrl : MonoBehaviour {
    public playerctrl playerCtrl;
    public void MobileMoveLeft()
    {
        playerCtrl.MobileMoveLeft();
    }
    public void MobileMoveRight()
    {
        playerCtrl.MobileMoveRight();
    }
    public void MobileMoveJump()
    {
        playerCtrl.MobileMoveJump();
    }
    public void MobileMoveFire()
    {
        playerCtrl.MobileMoveFire();
    }
    public void MobileStop()
    {
        playerCtrl.MobileStop();
    }
}
