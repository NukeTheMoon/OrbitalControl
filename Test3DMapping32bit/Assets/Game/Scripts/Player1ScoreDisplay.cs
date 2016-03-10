using UnityEngine;
using System.Text;

public class Player1ScoreDisplay : MonoBehaviour {

    private TextMesh _textMesh;

    void Start()
    {
        _textMesh = GetComponent<TextMesh>();
    }

	void Update () {
        _textMesh.text = Score.Player1Score.ToScoreFormat();
	}
}
