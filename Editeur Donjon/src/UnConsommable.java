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

import java.io.*;
import java.lang.String;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.lang.Float;
import java.lang.Integer;

/**
 * objet consommable
 */
public class UnConsommable extends UnObjet implements ActionListener{
	protected int saDuree;
	protected String sonEffet;
	protected JTextField sonChampDuree;
	protected JTextField sonChampEffet;
	private JLabel sonLabelDuree;
	private JLabel sonLabelEffet;

UnConsommable(){//constructeur objet sans arguments
		super();
	}
	
	UnConsommable(String telNom)throws Exception{
		super(telNom);
		try{
			BufferedReader leLecteur = new BufferedReader(new FileReader(new File("Objets/"+telNom+".jay")));
			String laLigne=leLecteur.readLine();
			while(!laLigne.equals ("finDesc")){
				laLigne=leLecteur.readLine();
			}
			saDuree = Integer.parseInt(leLecteur.readLine());
			sonEffet = leLecteur.readLine();

		leLecteur.close();
		}
		catch (Exception lException) { 
                    JOptionPane.showMessageDialog(null,"Une erreur est survenue, vérifiez le consommable"); 
                    throw (Exception)lException;
                }//catch
	}//chargeToi
	
	//accesseurs
    /**
     * 
     */
	public int getsaDuree(){return saDuree;}
    /**
     * 
     */
	public void setsaDuree(int telleDuree){saDuree=telleDuree;}
	public String getsonEffet(){return sonEffet;}
	public void setsaDesc(String telEffet){sonEffet=telEffet;}

	//fonction relative à l'action (clique) faite sur le bouton.
	public void actionPerformed(ActionEvent telleAction){

		try{
			super.actionPerformed(telleAction);
			saDuree=Integer.parseInt(sonChampDuree.getText());
			sonEffet=sonChampEffet.getText();
			enregistreToi();
		}catch (NumberFormatException lException){
			JOptionPane.showMessageDialog(null,"Un des champs Numérique est mal rempli et c'est pas bien ça...non pas bien!");
		}

	}
    /**
     * enregistrement du consommable
     */
	public void enregistreToi(){
		super.enregistreToi();
		PrintWriter lEcrivain;
	    try{
    		lEcrivain = new PrintWriter(new FileWriter(new File("Objets/"+sonChampNom.getText()+".jay"), true));
			lEcrivain.println(saDuree);
			lEcrivain.println(sonEffet);
			lEcrivain.close();
		}catch(Exception lException){
			System.err.print("une erreur est survenue");}//catch
	}//enregistreToi

    /**
     * permet de charger un consommable à partir d'un fichier
     * @param telNom nom du consommable à charger
     */
	public void chargeToi(String telNom){
		super.chargeToi(telNom);
		try{
			BufferedReader leLecteur = new BufferedReader(new FileReader(new File("Objets/"+telNom+".jay")));
			String laLigne=leLecteur.readLine();
			while(!laLigne.equals ("finDesc")){
				laLigne=leLecteur.readLine();
			}
			saDuree = Integer.parseInt(leLecteur.readLine());
			sonEffet = leLecteur.readLine();

		leLecteur.close();
		}
		catch (Exception lException) { JOptionPane.showMessageDialog(null,"Une erreur est survenue, vérifiez le nom de la créature"); }//catch
		super.afficheToi();
		afficheToi();
	}//chargeToi
    /**
     * permet d'éditer le consommable
     * @return panneau d'édition
     */
	public JPanel afficheToi(){
		super.afficheToi();
		
		sonChampDuree = new JTextField(10);//initialisation d'un champ texte avec JTextDield
		sonChampEffet = new JTextField(10);

		sonLabelDuree= new JLabel("Durée");//Initialisation des labels, c'est à dire des intitulés des champs
		sonLabelEffet= new JLabel("Effet");

		sonLabelDuree.setLabelFor(sonChampDuree);//assignation des labels aux champs correspondants
		sonLabelEffet.setLabelFor(sonChampEffet);

		lePanneauChamp.add(sonChampDuree);//ajout des champs dans le panneau dédié aux champs
		lePanneauChamp.add(sonChampEffet);

		lePanneauLabel.add(sonLabelDuree);//ajout des labels au panneau dédié aux labels.
		lePanneauLabel.add(sonLabelEffet);
		
	   sonChampDuree.setText(Integer.toString(saDuree));
	   sonChampEffet.setText(sonEffet);
	   updateUI();
	   return lePanneauAlpha;
    }//Affiche
    
    /**
     * affiche les informations de l'objet dans une boite de dialogue
     * @param lePere fenêtre mère (pour la modalité)
     * @return dialog d'information
     */
    public JDialog consulteToi(JFrame lePere){
		super.consulteToi(lePere);
		laFenetre.setTitle("Un consommable");
		
		sonChampDuree = new JTextField(10);//initialisation d'un champ texte avec JTextDield
		sonChampEffet = new JTextField(10);

		sonLabelDuree= new JLabel("Durée");//Initialisation des labels, c'est à dire des intitulés des champs
		sonLabelEffet= new JLabel("Effet");

		sonLabelDuree.setLabelFor(sonChampDuree);//assignation des labels aux champs correspondants
		sonLabelEffet.setLabelFor(sonChampEffet);

		lePanneauChamp.add(sonChampDuree);//ajout des champs dans le panneau dédié aux champs
		lePanneauChamp.add(sonChampEffet);

		lePanneauLabel.add(sonLabelDuree);//ajout des labels au panneau dédié aux labels.
		lePanneauLabel.add(sonLabelEffet);
		
	   sonChampDuree.setText(Integer.toString(saDuree));
	   sonChampEffet.setText(sonEffet);
	   
	   sonChampDuree.setEditable(false);
	   sonChampEffet.setEditable(false);
	   
		laFenetre.setVisible(true);
	   return laFenetre;
    }//consulte
    
        public String toString(){
    	return ("Consommable");
    }
}