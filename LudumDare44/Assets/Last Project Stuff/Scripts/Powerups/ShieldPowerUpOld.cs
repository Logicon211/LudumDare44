using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUpOld : PowerUpOld {

	public override void GivePowerUp() {
		controller.PickupShield();
	}
}
