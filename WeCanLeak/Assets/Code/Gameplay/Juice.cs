using UnityEngine;
using System;
using System.Collections;

public enum JuiceType
{
	Phlegm,
	YellowBile,
	BlackBile,
	Blood
}

[Serializable]
public class Juice {

	public JuiceType type;
	public int amount;
}
