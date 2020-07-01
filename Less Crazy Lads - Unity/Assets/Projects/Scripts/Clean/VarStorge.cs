using UnityEngine;

[CreateAssetMenu(fileName = "VarStorge")]
public class VarStorge : ScriptableObject
{

	public int score;
	public int highScore;

	[Header("Difficult Level")]
	[Tooltip("The Higher The Number The Higer The Chanse.")]
	 public float easyPattern;
	 public float midPattern;
	 public float hardPattern;

	public float playerSpeed;
	public float forwardSpeed;
	public float spacingBtwObsticale = 3;
	public float safeDisFromStart;
}
