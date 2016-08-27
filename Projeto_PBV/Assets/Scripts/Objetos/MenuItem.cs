﻿using UnityEngine;
using System.Collections;

public class MenuItem : MonoBehaviour {

    public enum tipoBotao {
        NOVO_JOGO,
        LOAD,
        OPTIONS
    }

    public tipoBotao meuTipo;
    private bool teste = false;

	// Use this for initialization
	void Start () {
	
	}

    public void AtivaBotao() {
        StartCoroutine(AtivaBotaoCo());
    }

    public IEnumerator AtivaBotaoCo() {
        
        switch (meuTipo){
            case tipoBotao.NOVO_JOGO: {
                    Debug.Log("Novo Jogo");
                    if (!SaveLoad.instance.CheckIfLoadExists())
                    {
                        MainMenuManager.instance.FadeOutMenu();

                        //while (MainMenuManager.instance.GetMenuFading()) {
                        // yield return new WaitForSeconds(0.3f);
                        // }

                        SceneLoader.Settings options = new SceneLoader.Settings();
                        options.async = false;
                        options.fadeIN = true;
                        options.fadeOUT = true;
                        options.loadingScreen = true;

                        SceneLoader.instance.CarregaCena(3, options);

                    }
                    else {
                        Debug.Log("Aviso de save existente");
                    }
                }break;

            case tipoBotao.LOAD: {
                    Debug.Log("Load");
                }break;

            case tipoBotao.OPTIONS: {
                    Debug.Log("Options");
                }break;
        }
        yield return null;
    }
}