using UnityEngine;
using System.Text;

public class Player2ScoreDisplay : MonoBehaviour {

    private TextMesh _textMesh;

    void Start()
    {
        _textMesh = GetComponent<TextMesh>();
    }

	void Update () {
        _textMesh.text = Score.Player2Score.ToScoreFormat();
    }


}
