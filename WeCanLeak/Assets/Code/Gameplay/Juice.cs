using UnityEngine;
using System;
using System.Collections;

public enum JuiceType
{
	Blood,
	YellowBile,
	BlackBile,
	Phlegm
}

[Serializable]
public class Juice {

	public JuiceType type;
	public int amount;
}
