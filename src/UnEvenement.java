/**
    Copyright 2007, Aurélien Pêcheur, Jonathan Mondon, Yannick Balla
 
    This file is part of Editeur Donjon.

    Editeur Donjon is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.

    Editeur Donjon is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Editeur Donjon; if not, write to the Free Software
    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
 **/
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

/**
 * Classe définissant les événements pouvant se produire. 
 * Il s'agit d'une classe abstraite et elle ne peut donc pas être instanciée.
 * De nombreuses classes filles sont envisageables (changement de carte, embuscade...)
 */
public abstract class UnEvenement {

	String sonNom;

	//constante pour la répétition
	static int UNIQUE = 0;
	static int REPETABLE = 1;
	static int UNIQUE_FAIT = 2;
	int saRepetition;

	UneCase saCase;

	UnEvenement(){}

	UnEvenement(UneCase telleCase, String telNom, int telleRepetition) {
		sonNom = telNom;
		saCase = telleCase;
		saRepetition = telleRepetition;
	}

    /**
     * Méthode d'édition de l'événement
     * @return JPanel contenant les champs à modifier
     */
	public abstract JPanel editeToi();

	protected void creerRadio(JPanel telPanneau) {
		JPanel lePanneauInter = new JPanel();
		ButtonGroup leGroupeDeBouton = new ButtonGroup();
		JRadioButton lOptionRadio = new JRadioButton("Evenement unique", true);
		lOptionRadio.addItemListener(new ItemListener() {
			public void itemStateChanged(ItemEvent telleAction){
				if (telleAction.getStateChange() == ItemEvent.SELECTED)
					saRepetition = UNIQUE;
				else
					saRepetition = REPETABLE;
			}
		});
		leGroupeDeBouton.add(lOptionRadio);
		lePanneauInter.add(lOptionRadio);
		lOptionRadio = new JRadioButton("Evenement répétable");
		leGroupeDeBouton.add(lOptionRadio);
		lePanneauInter.add(lOptionRadio);
		telPanneau.add(lePanneauInter);
	}

    /**
     * Renvoie toute les informations de l'événement sous forme d'une String. Utilisée lors de l'enregistrement d'une case.
     * @return chaine formattée pour être compréhensible au chargement
     */
	public String toString() { return "    evenement:"+sonNom + ":" + saRepetition + ":"; }

    /**
     * Vérifie si les conditions requises pour le déclenchement d'un événement sont réunies
     * @return true si l'événement doit se déclencher, false sinon
     */
	public abstract boolean doitSeDeclencher();

    /**
     * L'événement se réalise
     */
	public abstract void declencheToi();
}