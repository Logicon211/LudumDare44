using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUpOld : PowerUpOld {

	public override void GivePowerUp() {
		controller.PickupSpeedBoost();
	}
}
