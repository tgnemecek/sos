using UnityEngine;
using System.Collections;

//namespace para interagir com os sliders
using UnityEngine.UI;

//namespace que contem as classes para interagir com os mixers
using UnityEngine.Audio;

public class MixLevels : MonoBehaviour {
	
	/*
		A funcao SetFloat define o valor do volume do mixer.
		O primeiro argumento é o nome do parâmetro exposta do mixer (via UI do Unity);
		O segundo argumento é o valor que será passado para setar o volume.
		O valor é definido e passado automaticamente ao ajustar o valor do slider.

		É importante lembrar que ao expor um parâmetro, você desativa a habilidade de controlar o mixer
		via snapshots. Para liberar o parâmetro e retormar controle dos snapshots, basta usar a função 
		masterMixer.ClearFloat(<nome do parâmentro exposto>).
	*/

	public Slider group1Slider; //definir via inspector
	public Slider group2Slider; //definir via inspector
	public Slider group3Slider; //definir via inpector

	public AudioMixer masterMixer; //definir via inspector

	public void setGroup1Lvl (float group1Vol){
		float valueOUT = -80f;
		if (group1Vol != 0)
		{
			valueOUT = (Mathf.Sqrt(group1Vol)*5) - 30f;
		}
		masterMixer.SetFloat("group1Vol", valueOUT);
	}
	public void setgroup2Lvl (float group2Vol){ 
        float valueOUT = -80f;
        if (group2Vol != 0)
        {
            valueOUT = (Mathf.Sqrt(group2Vol)*5) - 30f;
        }
        masterMixer.SetFloat("group2Vol", valueOUT);
	}
	public void setgroup3Lvl (float group3Vol){
		float valueOUT = -80f;
		if (group3Vol != 0)
		{
			valueOUT = (Mathf.Sqrt(group3Vol)*5) - 30f;
		}
		masterMixer.SetFloat("group3Vol", valueOUT);
	}
}
