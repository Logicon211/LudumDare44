using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUpOld : PowerUpOld {

	public override void GivePowerUp() {
		controller.PickupHealth();
	}
}

