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
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

/**
 * Classe définissant les personnages joueurs
 */
public class UnJoueur extends UneCreature{
	private String sonNom_IRL;
	private JTextField sonChampNom_IRL;
	private JLabel sonLabelNom_IRL;



    /**
     * Constructeur de base d'un joueur
     * @param telEditeur éditeur dans lequel on joue
     */
    public UnJoueur(UnEditeurDonjon telEditeur){
		super(telEditeur);
    	sonChampNom_IRL = new JTextField();
		PanoTextF.add(sonChampNom_IRL);
		sonLabelNom_IRL= new JLabel("Nom IRL");
		sonLabelNom_IRL.setLabelFor(sonChampNom_IRL);
    	PanoLabel.add(sonLabelNom_IRL);
		sonChampNom_IRL.setText(sonNom_IRL);
    }//constructeur PAR DEFAUT AVEC CHAMPS

    /**
     * Constructeur pour le chargement d'un joueur
     * @param telNom Joueur à charger
     * @param telEditeur editeur dans lequel on charge
     */
    public UnJoueur(String telNom, UnEditeurDonjon telEditeur){
    	super(telEditeur);
		try{
			BufferedReader leLecteur = new BufferedReader(new FileReader(new File("Campagnes/"+telNom+".jay")));
			super.chargeToi(leLecteur, telEditeur);
			sonNom_IRL =leLecteur.readLine();
			leLecteur.close();
		}//try
		catch (Exception lException) { JOptionPane.showMessageDialog(null,"Une erreur est survenue, vérifiez le nom du personnage"); }//catch

    }//Constructeur pour charger la map

    public void actionPerformed(ActionEvent evt) {
    	JButton leValideur = new JButton();
		leValideur=(JButton)evt.getSource();
		String label=leValideur.getName();

    	super.actionPerformed(evt);
    	if(leValideur.getText()=="Enregistrer"){
			if ( saPosX==-1 && !sonChampPosX.getText().equals("-1") && saPosY==-1 && !sonChampPosY.getText().equals("-1") ){
			    				saPosX= Integer.parseInt(sonChampPosX.getText());
			    				saPosY= Integer.parseInt(sonChampPosY.getText());
			    				sonEditeur.getsaCarte().getsesCases()[saPosY][saPosX].setsonJoueur(this);
								sonEditeur.afficheLaCarte();
				}
   			sonNom_IRL = sonChampNom_IRL.getText();
   			JOptionPane.showMessageDialog(null,"Enregistrement de Joueur éffectué !");
   			}//if
    }//actionPerformed


    /**
     * Méthode héritée d'UneCreature
     */
    public JPanel afficheToi(){
		JPanel PanoRecup=new JPanel();
    	PanoRecup=super.afficheToi();
		sonChampNom_IRL = new JTextField();
		PanoTextF.add(sonChampNom_IRL);
		sonLabelNom_IRL= new JLabel("Nom IRL");
		sonLabelNom_IRL.setLabelFor(sonChampNom_IRL);
    	PanoLabel.add(sonLabelNom_IRL);
		sonChampNom_IRL.setText(sonNom_IRL);
		if(sonEditeur.getsonMode()==UnEditeurDonjon.JOUER){
			sonChampNom_IRL.setEnabled(false);
		}//if
    	updateUI();
    	return PanoRecup;
    }//Affiche
    

    /**
     * Méthode héritée d'UneCreature
     */
    public void enregistreToi(){

    	PrintWriter lEcrivain;
    	try{
    	lEcrivain = new PrintWriter(new FileWriter(new File("Campagnes/"+sonChampNom.getText()+".jay")));
    	super.enregistreToi(lEcrivain);
    	lEcrivain.println(sonNom_IRL);
		lEcrivain.close();
		}catch(Exception lException){
			JOptionPane.showMessageDialog(null,"une erreur est survenue dans joueur");
			lException.printStackTrace();}//catch
    }//enregistreToi


    /**
     * Méthode héritée d'UneCreature
     */
	public void deplaceToi(int telDestX, int telDestY){
		if(sonEditeur.getsaCarte().getsesCases()[telDestY][telDestX].getsonType().getsonFranchissement()!=0 && sonEditeur.getsaCarte().getsesCases()[telDestY][telDestX].getsaCreature()==null){
			sonEditeur.getsaCarte().getsesCases()[telDestY][telDestX].setsonJoueur(this);
			sonEditeur.getsaCarte().getsesCases()[saPosY][saPosX].setsonJoueur(null);
			saPosX=telDestX;
			saPosY=telDestY;
		}//if
		else
			JOptionPane.showMessageDialog(null, 
				"Erreur...\nVous essayez de placer un joueur sur un terrain infranchissable ou déjà occupé" );
			
	}//deplaceToi


    /**
     * Méthode héritée d'UneCreature
     */
	public JPanel editeTesStats(String telNom){
		JPanel panoRecup = new JPanel();
		panoRecup=super.editeTesStats();
		//UnJoueur leJ= new UnJoueur(telNom, telEditeur);
			return panoRecup;
	}//editeToi



    public String getsonNom_IRL(){
    	return sonNom_IRL;
    }//getsonNom


}//class