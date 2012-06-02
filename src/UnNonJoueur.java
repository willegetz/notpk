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
 * Classe définissant les personnages non joueurs
 */
public class UnNonJoueur extends UneCreature{
	private boolean sonAgressivite;
	private JCheckBox sonChampAgr;
	private JLabel sonLabelAgr;
	private JPanel PanoRecup;


    /**
     * Constructeur de base d'un non joueur
     * @param telEditeur éditeur dans lequel on joue
     */
    public UnNonJoueur(UnEditeurDonjon telEditeur) {
		super(telEditeur);
    	sonChampAgr = new JCheckBox();
    	PanoTextF.add(sonChampAgr);
    	sonLabelAgr= new JLabel("Aggressif");
    	sonLabelAgr.setLabelFor(sonChampAgr);
    	PanoLabel.add(sonLabelAgr);
    	if (sonAgressivite)
    		sonChampAgr.setSelected(true);
    }//constructeur

    /**
     * Constructeur pour le chargement d'un non joueur
     * @param telNom Non joueur à charger
     * @param telEditeur editeur dans lequel on charge
     */
    public UnNonJoueur(String telNom, UnEditeurDonjon telEditeur){
    	super(telEditeur);
    	try{
			BufferedReader leLecteur = new BufferedReader(new FileReader(new File("Campagnes/"+telNom+".jay")));
			super.chargeToi(leLecteur, telEditeur);
			String agress = leLecteur.readLine();
				if (agress.equals("true") )
				   	sonAgressivite=true;
				else
					sonAgressivite=false;

			leLecteur.close();
		}//try
		catch (Exception lException) { JOptionPane.showMessageDialog(null,"Une erreur est survenue, vérifiez le nom du PNJ"); }//catch
    }//constructeur appeler lors du chargement de la carte

    public void actionPerformed(ActionEvent evt) {
		JButton leValideur = new JButton();
		leValideur=(JButton)evt.getSource();
		
    	super.actionPerformed(evt);
		if(leValideur.getText()=="Enregistrer"){
				if ( saPosX==-1 && !sonChampPosX.getText().equals("-1") && saPosY==-1 && !sonChampPosY.getText().equals("-1") ){
					    	saPosX= Integer.parseInt(sonChampPosX.getText());
					    	saPosY= Integer.parseInt(sonChampPosY.getText());
					    	sonEditeur.getsaCarte().getsesCases()[saPosY][saPosX].setsonNonJoueur(this);
							sonEditeur.afficheLaCarte();}//if

    			if(sonChampAgr.isSelected())
    				sonAgressivite=true;
    			else
    				sonAgressivite=false;
		JOptionPane.showMessageDialog(null,"Enregistrement de PNJ éffectué !");
		}//if

    }//actionPerformed


    /**
     * Méthode héritée d'UneCreature
     */
	public JPanel editeTesStats(String telNom){
			PanoRecup = new JPanel();
			PanoRecup=super.editeTesStats();
			//UnNonJoueur leNPC=new UnNonJoueur(telNom);
				return PanoRecup;
	}//editeToi

    /**
     * Méthode héritée d'UneCreature
     */
    public JPanel afficheToi(){
    	JPanel PanoRecup=new JPanel();
    	PanoRecup=super.afficheToi();
    	sonChampAgr = new JCheckBox();
    	PanoTextF.add(sonChampAgr);
    	sonLabelAgr= new JLabel("Aggressif");
    	sonLabelAgr.setLabelFor(sonChampAgr);
    	PanoLabel.add(sonLabelAgr);
    	if (sonAgressivite)
    		sonChampAgr.setSelected(true);
    	if(sonEditeur.getsonMode()==UnEditeurDonjon.JOUER){
    		sonChampAgr.setEnabled(false);
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
			lEcrivain.println(sonAgressivite);
			lEcrivain.close();
		}catch(Exception lException){
			System.err.print("une erreur est survenue");}//catch
    }//enregistreToi

	public void deplaceToi(int telDestX, int telDestY){
		if (sonEditeur.getsaCarte().getsesCases()[telDestY][telDestX].getsonType().getsonFranchissement() != 0 && sonEditeur.getsaCarte().getsesCases()[telDestY][telDestX].getsaCreature()==null)
		{
			sonEditeur.getsaCarte().getsesCases()[telDestY][telDestX].setsonNonJoueur(this);
			sonEditeur.getsaCarte().getsesCases()[saPosY][saPosX].setsonNonJoueur(null);
			saPosX=telDestX;
			saPosY=telDestY;
		}//if
		else
			JOptionPane.showMessageDialog(null, 
				"Erreur...\nVous essayez de placer un joueur sur un terrain infranchissable ou déjà occupé" );
			
	}//deplaceToi

    public boolean getsonAgr(){
    	return sonAgressivite;
    }//getsonNom


}//class