using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISticky {

	void AttachToPlayer (Transform playerTrans, List<StickyObject> stuckObjects);

	void DetatchFromPlayer(List<StickyObject> stuckObjects);

}
