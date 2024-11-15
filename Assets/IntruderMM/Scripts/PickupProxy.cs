using System;
using UnityEngine;

public enum PickupType
{
	Custom = -2,
	Null = -1,
	SniperRifle = 0,
	RedDot = 1,
	Shield = 2,
	Binoculars = 3,
	Banana = 4,
	SMG = 5,
	Pistol = 6,
	Grenade = 7,
	SmokeGrenade = 8,
	CSGrenade = 9,
	LaserSensor = 10,
	RemoteCharge = 11,
	CardboardDecoy = 12,
	SMGAmmox30 = 13,
	PistolAmmox15 = 14,
	SniperAmmox5 = 15,
	Shotgun = 16,
	ShotgunAmmox6 = 17
}

[ExecuteInEditMode()]
public class PickupProxy : MonoBehaviour
{
	public ItemProxy pickupItem;
	public PickupType pickupType = PickupType.Custom;

	public string pickupMessage = ""; //Custom message for the pick up if you change things about it, like the ammo amount, to avoid default messages
	public int addedAmmo = -1; //Ammo added to the weapons ammo stash
	public int loadedAmmo = -1; //Ammo loaded in the weapon if you pick it up, use only if you want to replace the current magazine in the weapon
	public float respawnTime = -1; //Pick up will respawn after this amount of time
	public Activator activatorToActivate; //Activate an activator when you pick up this pick up
	private MeshFilter meshFilter;

	private void SetMeshFilter()
	{
		if (meshFilter != null)
		{
			return;
		}

		meshFilter = GetComponent<MeshFilter>() ?? gameObject.AddComponent<MeshFilter>();
	}

	protected void OnValidate()
	{
		if (pickupItem?.pickupMesh != null)
		{
			SetMeshFilter();

			meshFilter.mesh = pickupItem?.pickupMesh;
			transform.localScale = new Vector3(1, 1, 1);
		}
		else if (pickupItem == null && (int) pickupType >= 0)
		{
			SetMeshFilter();

			meshFilter.mesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
			transform.localScale = new Vector3(0.1f, 0.4f, 0.4f);
		}
	}
}
