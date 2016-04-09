using UnityEngine;
using System;
using System.Collections.Generic;

public enum OrganType
{
	Liver,
	Spleen,
	GallBladder,
	Lungs
}

[Serializable]
public class Organ {

	public JuiceType producer;
	public OrganType organType;
	public int health = 100; // 0-100 for alive

	public List<Juice> juices;
}
