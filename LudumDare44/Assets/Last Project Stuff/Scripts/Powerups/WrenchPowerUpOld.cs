using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchPowerUpOld : PowerUpOld {

	public override void GivePowerUp() {
		controller.PickupWrench();
	}
}
