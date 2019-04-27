using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPowerUpOld : PowerUpOld {

	public override void GivePowerUp() {
		controller.PickupLazer();
	}
}
