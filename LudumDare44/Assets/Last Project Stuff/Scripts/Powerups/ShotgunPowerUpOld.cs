using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPowerUpOld : PowerUpOld {

	public override void GivePowerUp() {
		controller.PickupShotgun();
	}
}
