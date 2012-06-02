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
import java.lang.Integer;
import javax.swing.*;
import java.util.Vector;


/**
 * La créature ne doit normalement pas être instanciée, il s'agit de la classe mère des personanges joueurs et non joueurs
 */
public class UneCreature extends JPanel implements ActionListener{
	protected String sonNom = "La créature";
	protected String saTaille;
	protected String saDesc_Visuel="";
	protected int saFor=8;
	protected int saDex=8;
	protected int saCon=8;
	protected int sonInt=8;
	protected int saSag=8;
	protected int sonCha=8;
	protected int sesPv_Max;
	protected int sesPv_Courant;
	protected int sonLevel=1;
	protected String sonDieu;
	protected String sonSexe;
	protected String sonImage;/////////////////////////////////////////////////régler le probleme de l'image
	protected int saPosX=-1;//permet de savoir où la creature est placée sur la map
	protected int saPosY=-1;
	protected Vector<String> sesComp;//tableau de compétence des creature
	protected Vector<String> sesSort;//affiche l'inventaire et son contenu
	protected JComboBox CB;//combo box permettant d'afficher toutes les compétences se trouvant dans le fichier competence.jay
	protected boolean chargeRace=false;//permet de savoir si la combo box de race a été chargé
	protected boolean chargeAlign=false;//permet de savoir si la combo box de l'alignement a été chargé
	protected boolean chargeClasse=false;//permet de savoir si la combo box de la classe a été chargé
	protected JComboBox saRace;
	protected JButton saVueRace;//bouton pour appeler le JDialog et visualiser les info propre a la Race
	protected JComboBox sonAlign;
	protected JComboBox saClasse;
	
	protected int saCA=10;
	protected String sonArmure;
	protected String sonArme;

	protected String label;//sert pour la methode actionPerformed

	protected JTextField sonChampNom;
	protected JTextField sonChampTaille;
	protected JTextArea sonChampDesc;
	protected JTextField sonChampFor;
	protected JTextField sonChampDex;
	protected JTextField sonChampCon;
	protected JTextField sonChampInt;
	protected JTextField sonChampSag;
	protected JTextField sonChampCha;
	protected JTextField sonChampPv_Max;
	protected JTextField sonChampPv_Courant;
	protected JTextField sonChampLevel;
	protected JTextField sonChampDieu;
	protected JTextField sonChampSexe;
	protected JTextField sonChampImage;///////////////////////////////////////////////Comment on fait ? =)
	protected JTextField sonChampPosY;
	protected JTextField sonChampPosX;
	protected JTextField sonChampCA;
	protected JList saListeComp;


	protected JLabel sonLabelNom;
	protected JLabel sonLabelTaille;
	protected JLabel sonLabelFor;
	protected JLabel sonLabelDex;
	protected JLabel sonLabelCon;
	protected JLabel sonLabelInt;
	protected JLabel sonLabelSag;
	protected JLabel sonLabelCha;
	protected JLabel sonLabelPv_Max;
	protected JLabel sonLabelPv_Courant;
	protected JLabel sonLabelLevel;
	protected JLabel sonLabelDieu;
	protected JLabel sonLabelSexe;
	protected JLabel sonLabelPosX;
	protected JLabel sonLabelPosY;
	protected JButton sonLabelAlign;//bouton pour appeler le JDialog et visualiser les info propre a l'alignement
	protected JButton sonLabelClasse;//bouton pour appeler le JDialog et visualiser les info propre a l'alignement
	protected JLabel sonLabelDesc;
	protected JLabel sautDeLigne = new JLabel("");
	protected JLabel optionComp;
	protected JLabel sonLabelCA;

	protected JButton leBoutonUP;
	protected JButton leBoutonDOWN;

	protected JPanel PanoTextF; //pour que les classes qui dérivent y aient acces on met en protected
	protected JPanel PanoLabel;
	protected JPanel PanoValideur;
	protected JPanel PanoAlpha;//ou je met tout les label + champ sauf pour desc
	protected JPanel PanoDesc;
	protected JPanel PanoDescLabel;
	protected JPanel PanoJoueur;//sert uniquement dans editeTesStats
	protected JPanel Pan;
	protected JPanel Pan2;
	protected UnEditeurDonjon sonEditeur;
	protected UnInventaire sonInventaire;


    /**
     * Constructeur de créature appelé par les filles.
     * @param telEditeur editeur dans lequel doit être gérée la créature
     */
    public UneCreature(UnEditeurDonjon telEditeur) {//construit le panno a vide de creature
		super();
		sonEditeur=telEditeur;
		sonInventaire = new UnInventaire(this);
		sesComp=new Vector<String>();
		creerPano();
                afficheToi();
    }//constructeur

    /**
     * Déplace la créature de sa position vers la position indiquée (téléportation à l'heure actuelle)
     * @param telDestX position X à atteindre
     * @param telDestY position Y à atteindre
     */
	public void deplaceToi(int telDestX, int telDestY) { }

    /**
     * Edition des stats des créatures (et uniquement les stats) : utilisé en mode jouer
     * @return JPanel permettant l'édition des statistiques
     */
    public JPanel editeTesStats(){//permet d'editer un personnage en mode jeu
    	PanoAlpha=new JPanel(new GridLayout(0,1));//Panneau qui pour bouton up
    	PanoValideur = new JPanel(new GridLayout(0,1));//panneau pour les boutons down
    	PanoTextF = new JPanel(new GridLayout(0,1));//panneau pour champs
    	PanoLabel = new JPanel(new GridLayout(0,1));//panneau pour les label
    	PanoJoueur = new JPanel(new GridLayout(0,1));//panneau pour le label et le nom du joueur ou du nom joueur
    	PanoDescLabel = new JPanel(new BorderLayout());//contient les panneau alpha, valideur, text
    	PanoDesc = new JPanel(new BorderLayout());//contient les panneau label et descLabel joueur

    	leBoutonDOWN = new JButton("<");
    	leBoutonDOWN.setName("-For");
    	leBoutonDOWN.addActionListener(this);
    	PanoValideur.add(leBoutonDOWN);
    	leBoutonDOWN = new JButton("<");
    	leBoutonDOWN.setName("-Dex");
    	leBoutonDOWN.addActionListener(this);
    	PanoValideur.add(leBoutonDOWN);
    	leBoutonDOWN = new JButton("<");
    	leBoutonDOWN.setName("-Con");
    	leBoutonDOWN.addActionListener(this);
    	PanoValideur.add(leBoutonDOWN);
    	leBoutonDOWN = new JButton("<");
    	leBoutonDOWN.setName("-Int");
    	leBoutonDOWN.addActionListener(this);
    	PanoValideur.add(leBoutonDOWN);
    	leBoutonDOWN = new JButton("<");
    	leBoutonDOWN.setName("-Sag");
    	leBoutonDOWN.addActionListener(this);
    	PanoValideur.add(leBoutonDOWN);
    	leBoutonDOWN = new JButton("<");
    	leBoutonDOWN.setName("-Cha");
    	leBoutonDOWN.addActionListener(this);
    	PanoValideur.add(leBoutonDOWN);
    	leBoutonDOWN = new JButton("<");
    	leBoutonDOWN.setName("-PvM");
    	leBoutonDOWN.addActionListener(this);
    	PanoValideur.add(leBoutonDOWN);
    	leBoutonDOWN = new JButton("<");
    	leBoutonDOWN.setName("-PvC");
    	leBoutonDOWN.addActionListener(this);
    	PanoValideur.add(leBoutonDOWN);
    	leBoutonDOWN = new JButton("<");
    	leBoutonDOWN.setName("-Lvl");
    	leBoutonDOWN.addActionListener(this);
    	PanoValideur.add(leBoutonDOWN);


    	leBoutonDOWN = new JButton(">");
    	leBoutonDOWN.setName("+For");
    	leBoutonDOWN.addActionListener(this);
    	PanoAlpha.add(leBoutonDOWN);
    	leBoutonDOWN = new JButton(">");
    	leBoutonDOWN.setName("+Dex");
    	leBoutonDOWN.addActionListener(this);
    	PanoAlpha.add(leBoutonDOWN);
   		leBoutonDOWN = new JButton(">");
    	leBoutonDOWN.setName("+Con");
    	leBoutonDOWN.addActionListener(this);
    	PanoAlpha.add(leBoutonDOWN);
    	leBoutonDOWN = new JButton(">");
    	leBoutonDOWN.setName("+Int");
    	leBoutonDOWN.addActionListener(this);
    	PanoAlpha.add(leBoutonDOWN);
    	leBoutonDOWN = new JButton(">");
    	leBoutonDOWN.setName("+Sag");
    	leBoutonDOWN.addActionListener(this);
    	PanoAlpha.add(leBoutonDOWN);
    	leBoutonDOWN = new JButton(">");
    	leBoutonDOWN.setName("+Cha");
    	leBoutonDOWN.addActionListener(this);
    	PanoAlpha.add(leBoutonDOWN);
    	leBoutonDOWN = new JButton(">");
    	leBoutonDOWN.setName("+PvM");
    	leBoutonDOWN.addActionListener(this);
    	PanoAlpha.add(leBoutonDOWN);
    	leBoutonDOWN = new JButton(">");
    	leBoutonDOWN.setName("+PvC");
    	leBoutonDOWN.addActionListener(this);
    	PanoAlpha.add(leBoutonDOWN);
    	leBoutonDOWN = new JButton(">");
    	leBoutonDOWN.setName("+Lvl");
    	leBoutonDOWN.addActionListener(this);
    	PanoAlpha.add(leBoutonDOWN);


    	sonChampFor= new JTextField(5);
    	sonChampFor.setFocusable(false);
    	PanoTextF.add(sonChampFor);
    	sonChampDex= new JTextField();
    	sonChampDex.setFocusable(false);
    	PanoTextF.add(sonChampDex);
    	sonChampCon= new JTextField();
    	sonChampCon.setFocusable(false);
    	PanoTextF.add(sonChampCon);
    	sonChampInt= new JTextField();
    	sonChampInt.setFocusable(false);
    	PanoTextF.add(sonChampInt);
    	sonChampSag= new JTextField();
    	sonChampSag.setFocusable(false);
    	PanoTextF.add(sonChampSag);
    	sonChampCha= new JTextField();
    	sonChampCha.setFocusable(false);
    	PanoTextF.add(sonChampCha);
    	sonChampPv_Max= new JTextField();
    	sonChampPv_Max.setFocusable(false);
    	PanoTextF.add(sonChampPv_Max);
    	sonChampPv_Courant= new JTextField();
    	sonChampPv_Courant.setFocusable(false);
    	PanoTextF.add(sonChampPv_Courant);
    	sonChampLevel= new JTextField();
    	sonChampLevel.setFocusable(false);
    	PanoTextF.add(sonChampLevel);

    	////////les labels
    	sonLabelFor = new JLabel("Force");
    	sonLabelFor.setLabelFor(sonChampFor);
    	PanoLabel.add(sonLabelFor);
    	sonLabelDex = new JLabel("Dextérité");
    	sonLabelDex.setLabelFor(sonChampDex);
    	PanoLabel.add(sonLabelDex);
    	sonLabelCon = new JLabel("Constitution");
    	sonLabelCon.setLabelFor(sonChampCon);
    	PanoLabel.add(sonLabelCon);
    	sonLabelInt = new JLabel("Intelligence");
    	sonLabelInt.setLabelFor(sonChampInt);
    	PanoLabel.add(sonLabelInt);
    	sonLabelSag = new JLabel("Sagesse");
    	sonLabelSag.setLabelFor(sonChampSag);
    	PanoLabel.add(sonLabelSag);
    	sonLabelCha = new JLabel("Chance");
    	sonLabelCha.setLabelFor(sonChampCha);
    	PanoLabel.add(sonLabelCha);
    	sonLabelPv_Max = new JLabel("Point de vie Max");
    	sonLabelPv_Max.setLabelFor(sonChampPv_Max);
    	PanoLabel.add(sonLabelPv_Max);
    	sonLabelPv_Courant = new JLabel("Point de vie Courant");
    	sonLabelPv_Courant.setLabelFor(sonChampPv_Courant);
    	PanoLabel.add(sonLabelPv_Courant);
    	sonLabelLevel = new JLabel("Level");
    	sonLabelLevel.setLabelFor(sonChampLevel);
    	PanoLabel.add(sonLabelLevel);

    	//boutton denregistrement
    	JButton leValideur = new JButton("Enregistrer");
		leValideur.addActionListener(this);

    	//panneau contenant le nom du joueur
    	sonChampNom = new JTextField(15);
    	sonChampNom.setFocusable(false);
    	sonLabelNom = new JLabel("Nom personnage");
    	sonLabelNom.setLabelFor(sonChampNom);
    	PanoJoueur.add(sonLabelNom);
    	PanoJoueur.add(sonChampNom);


    	PanoDescLabel.add(PanoAlpha, BorderLayout.EAST);
    	PanoDescLabel.add(PanoValideur, BorderLayout.WEST);
    	PanoDescLabel.add(PanoTextF, BorderLayout.CENTER);

    	PanoDesc.add(PanoDescLabel, BorderLayout.CENTER);
    	PanoDesc.add(PanoLabel, BorderLayout.WEST);
    	PanoDesc.add(PanoJoueur, BorderLayout.NORTH);
    	PanoDesc.add(leValideur, BorderLayout.SOUTH);
    	
    	sonChampNom.setText(sonNom);
    	sonChampTaille.setText(saTaille);
    	sonChampDesc.setText(saDesc_Visuel);
    	sonChampFor.setText(Integer.toString(saFor));
    	sonChampDex.setText(Integer.toString(saDex));
    	sonChampCon.setText(Integer.toString(saCon));
    	sonChampInt.setText(Integer.toString(sonInt));
    	sonChampSag.setText(Integer.toString(saSag));
    	sonChampCha.setText(Integer.toString(sonCha));
    	sonChampPv_Max.setText(Integer.toString(sesPv_Max));
    	sonChampPv_Courant.setText(Integer.toString(sesPv_Courant));
    	sonChampLevel.setText(Integer.toString(sonLevel));
    	sonChampDieu.setText(sonDieu);
    	sonChampSexe.setText(sonSexe);

    	return PanoDesc;
    }//editeTesStats

 	public void actionPerformed(ActionEvent evt) {
 		JButton leValideur = new JButton();
		leValideur=(JButton)evt.getSource();
		String label=leValideur.getName();

 		if(leValideur.getText()=="Enregistrer")
 		{
 			try{
 			sonNom=sonChampNom.getText();
       			saTaille=sonChampTaille.getText();
    			saDesc_Visuel=sonChampDesc.getText();
    			saFor= Integer.parseInt(sonChampFor.getText());
    			saDex= Integer.parseInt(sonChampDex.getText());
    			saCon= Integer.parseInt(sonChampCon.getText());
    			sonInt= Integer.parseInt(sonChampInt.getText());
    			saSag= Integer.parseInt(sonChampSag.getText());
    			sonCha= Integer.parseInt(sonChampCha.getText());
    			sesPv_Max= Integer.parseInt(sonChampPv_Max.getText());
    			sesPv_Courant= Integer.parseInt(sonChampPv_Courant.getText());
    			saCA= Integer.parseInt(sonChampCA.getText());
    			sonLevel= Integer.parseInt(sonChampLevel.getText());
    			sonDieu=sonChampDieu.getText();
    			sonSexe=sonChampSexe.getText();

 			}catch (NumberFormatException lException){
				JOptionPane.showMessageDialog(null,"Un des champs Numérique est mal rempli et c'est pas bien ça...non pas bien!");
 			}//catch
 		}//if enregistrer

		else if(leValideur.getText()=="Inventaire"){
			sonInventaire.afficheToi();
		}
 		
 			
 		else {
 			if(label.equals("ok")){
 				sesComp.add((String)CB.getSelectedItem());
 				JOptionPane.showMessageDialog(null,"Vous venez de choisir la compétence "+(String)CB.getSelectedItem()+" N'oublier pas d'enregistrer !");
 				saListeComp.setListData(sesComp);
 			}
 			
 			if(label.equals("supprimer")){
 				try{
 				sesComp.removeElement((String)saListeComp.getSelectedValue());
 				JOptionPane.showMessageDialog(null,
 				"Vous venez de supprimer la compétence "+(String)CB.getSelectedItem()+" N'oublier pas d'enregistrer !");
 				saListeComp.setListData(sesComp);
 				}catch(Exception e){
 					JOptionPane.showMessageDialog(null, "Erreur...\nSélectionner une compétence");
 				}
 			}
 			
 			if(label.equals("infoRace")){//affichage du JDialog pour les Races
 				String laStr = new String();
 				try{
 					laStr=(String)saRace.getSelectedItem();
 					UneRace laRace = new UneRace(laStr);
 					laRace.afficheToi().setVisible(true);
 				}catch(Exception e){
 					JOptionPane.showMessageDialog(null, "Erreur...\nLa fenêtre correspondant à la race ne peut pas s'afficher");
 				}//catch
 			}//affichage du JDialog pour les Races
 			
 			if(label.equals("infoAlign")){//affichage du JDialog pour l'alignement
 				String laStr = new String();
 				try{
 					laStr=(String)sonAlign.getSelectedItem();
 					UnAlignement lAlign = new UnAlignement(laStr);
 					lAlign.afficheToi().setVisible(true);
 				}catch(Exception e){
 					JOptionPane.showMessageDialog(null, "Erreur...\nLa fenêtre correspondant à la race ne peut pas s'afficher");
 				}//catch
 			}//affichage du JDialog pour l'alignement
 			
 			if(label.equals("infoClasse")){//affichage du JDialog pour l'alignement
 				String laStr = new String();
 				try{
 					laStr=(String)saClasse.getSelectedItem();
 					UneClasse laCl = new UneClasse(laStr);
 					laCl.consulteToi().setVisible(true);
 				}catch(Exception e){
 					JOptionPane.showMessageDialog(null, "Erreur...\nLa fenêtre correspondant à la race ne peut pas s'afficher");
 				}//catch
 			}//affichage du JDialog pour l'alignement

 			if(label.equals("visualise")){//affichage de la JDialog de competence
			 	String laStr = new String();
			 	try{
					laStr=(String)saListeComp.getSelectedValue();
					UneCompetence laCom = new UneCompetence(laStr);
					laCom.afficheToi(sonEditeur).setVisible(true);
				}catch(Exception e){
					try{
						laStr = (String)saListeComp.getSelectedValue();
						UnSort laCom = new UnSort(laStr);
						laCom.consulteToi(sonEditeur);
					}
					catch (Exception expt)
					{
						JOptionPane.showMessageDialog(null, "Erreur...\nLa fenêtre correspondant à la compétence ou au sort ne peut pas s'afficher");
					}
				}//catch


 			}

 			if(label.equals("-For")){
			DOWNsaFor(1);
			sonChampFor.setText(Integer.toString(saFor));
			}//if -For

			if(label.equals("+For")){
			UPsaFor(1);
			sonChampFor.setText(Integer.toString(saFor));
			}//if +For

			if(label.equals("+Dex")){
			UPsaDex(1);
			sonChampDex.setText(Integer.toString(saDex));
			}//if +Dex

			if(label.equals("-Dex")){
			DOWNsaDex(1);
			sonChampDex.setText(Integer.toString(saDex));
			}//if -Dex

			if(label.equals("+Con")){
			UPsaCon(1);
			sonChampCon.setText(Integer.toString(saCon));
			}//if +Con

			if(label.equals("-Con")){
			DOWNsaCon(1);
			sonChampCon.setText(Integer.toString(saCon));
			}//if -Con

			if(label.equals("+Int")){
			UPsonInt(1);
			sonChampInt.setText(Integer.toString(sonInt));
			}//if +Int

			if(label.equals("-Int")){
			DOWNsonInt(1);
			sonChampInt.setText(Integer.toString(sonInt));
			}//if -Int

			if(label.equals("+Sag")){
			UPsaSag(1);
			sonChampSag.setText(Integer.toString(saSag));
			}//if +Sag

			if(label.equals("-Sag")){
			DOWNsaSag(1);
			sonChampSag.setText(Integer.toString(saSag));
			}//if -Sag

			if(label.equals("+Cha")){
			UPsonCha(1);
			sonChampCha.setText(Integer.toString(sonCha));
			}//if +Cha

			if(label.equals("-Cha")){
			DOWNsonCha(1);
			sonChampCha.setText(Integer.toString(sonCha));
			}//if -Cha

			if(label.equals("+PvM")){
			UPsesPvM(1);
			sonChampPv_Max.setText(Integer.toString(sesPv_Max));
			}//if +PvM

			if(label.equals("-PvM")){
			DOWNsesPvM(1);
			sonChampPv_Max.setText(Integer.toString(sesPv_Max));
			}//if -PvM

			if(label.equals("+PvC")){
			UPsesPvC(1);
			sonChampPv_Courant.setText(Integer.toString(sesPv_Courant));
			}//if +PvC

			if(label.equals("-PvC")){
			DOWNsesPvC(1);
			sonChampPv_Courant.setText(Integer.toString(sesPv_Courant));
			}//if -PvC

			if(label.equals("+Lvl")){
			UPsonLevel(1);
			sonChampLevel.setText(Integer.toString(sonLevel));
			}//if +Lvl

			if(label.equals("-Lvl")){
			DOWNsonLevel(1);
			sonChampLevel.setText(Integer.toString(sonLevel));
			}//if -Lvl


 		}//else



    }//actionPerformed

    public JPanel creerPano(){
    	Pan=new JPanel(new BorderLayout());
		PanoTextF = new JPanel(new GridLayout(0,1));//panneau des text field
		////////////Creation des champ de remplissage
		sonChampNom= new JTextField(10);//il faut absolument mettre une dimension
      	sonChampTaille= new JTextField();
      	
      	if (chargeRace==true)
      		saRace.setEnabled(false);

      		else
      			saRace=new JComboBox(donneTesRaces());
      			
      	if (chargeAlign==true)
      		sonAlign.setEnabled(false);
      		else
      			sonAlign=new JComboBox(donneTesAlign());
      			
      	if (chargeClasse==true)
      		saClasse.setEnabled(false);
      		else
      			saClasse=new JComboBox(donneTesClass());
      		
       	sonChampDesc= new JTextArea(10,13);
       	sonChampDesc.setLineWrap(true);//on vas à la ligne quand c'est trop grand
		sonChampDesc.setWrapStyleWord(true);//on ne coupe pas les mots en allant à la ligne
       	sonChampFor= new JTextField();
   		sonChampDex= new JTextField();
   		sonChampCon= new JTextField();
   		sonChampInt= new JTextField();
		sonChampSag= new JTextField();
		sonChampCha= new JTextField();
		sonChampPv_Max= new JTextField();
		sonChampPv_Courant= new JTextField();
		sonChampLevel= new JTextField();
		sonChampDieu= new JTextField();
		sonChampSexe= new JTextField();
		sonChampPosX= new JTextField();
		sonChampPosY= new JTextField();
		sonChampCA= new JTextField();
		sonChampCA.setEnabled(false);
		sonImage="VIDEUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUH";///A REVOIIIIIR
		saListeComp= new JList();
		saListeComp.setVisible(true);

		
		optionComp=new JLabel("Options des compétences:");
		CB = new JComboBox(donneTesTypes());//combo box affichant la liste des competence
		JButton ok= new JButton("Ajouter");
		ok.addActionListener(this);
		ok.setName("ok");
		JButton suppr= new JButton("Supprimer");
		suppr.addActionListener(this);
		suppr.setName("supprimer");
		JButton visualise=new JButton("Information");//bouton pour visualiser les info de la competence
		visualise.addActionListener(this);
		visualise.setName("visualise");
				

		if (saPosX!=-1)
			sonChampPosX.setEnabled(false);
		if (saPosY!=-1)
			sonChampPosY.setEnabled(false);

		///////////On ajoute les champ dans le panneau
		sonChampNom.setText(sonNom);
		PanoTextF.add(sonChampNom);
		PanoTextF.add(sonChampTaille);
		PanoTextF.add(saRace);
		PanoTextF.add(sonAlign);
		PanoTextF.add(saClasse);
		PanoTextF.add(sonChampFor);
		PanoTextF.add(sonChampDex);
		PanoTextF.add(sonChampCon);
		PanoTextF.add(sonChampInt);
		PanoTextF.add(sonChampSag);
		PanoTextF.add(sonChampCha);
		PanoTextF.add(sonChampPv_Max);
		PanoTextF.add(sonChampPv_Courant);
		PanoTextF.add(sonChampCA);
		PanoTextF.add(sonChampLevel);
		PanoTextF.add(sonChampDieu);
		PanoTextF.add(sonChampSexe);
		PanoTextF.add(sonChampPosX);
		PanoTextF.add(sonChampPosY);
		


		PanoLabel= new JPanel(new GridLayout(0,1));//panneau pour les panel
		///////////Creation des label
		sonLabelNom= new JLabel("Nom");
		sonLabelTaille= new JLabel("Taille");
		saVueRace = new JButton("Info sur la race");
		saVueRace.setName("infoRace");
		saVueRace.addActionListener(this);
		sonLabelFor= new JLabel("Force");
		sonLabelDex= new JLabel("Dextérité");
		sonLabelCon= new JLabel("Constitution");
		sonLabelInt= new JLabel("Intelligence");
		sonLabelSag= new JLabel("Sagesse");
		sonLabelCha= new JLabel("Charisme");
		sonLabelPv_Max= new JLabel("PV Maximum");
		sonLabelPv_Courant= new JLabel("PV Courant");
		sonLabelCA= new JLabel("CA");
		sonLabelLevel= new JLabel("Level");
		sonLabelDieu= new JLabel("Dieu");
		sonLabelSexe= new JLabel("Sexe");
		sonLabelPosX= new JLabel("Position X sur la carte");
		sonLabelPosY= new JLabel("Position Y sur la carte");
		sonLabelAlign= new JButton("Alignement");
		sonLabelAlign.setName("infoAlign");
		sonLabelAlign.addActionListener(this);
		sonLabelClasse= new JButton("Classe");
		sonLabelClasse.setName("infoClasse");
		sonLabelClasse.addActionListener(this);
		


		//////////On associe les label aux champs field
		sonLabelNom.setLabelFor(sonChampNom);
		sonLabelTaille.setLabelFor(sonChampTaille);
		sonLabelFor.setLabelFor(sonChampFor);
		sonLabelDex.setLabelFor(sonChampDex);
		sonLabelCon.setLabelFor(sonChampCon);
		sonLabelInt.setLabelFor(sonChampInt);
		sonLabelSag.setLabelFor(sonChampSag);
		sonLabelCha.setLabelFor(sonChampCha);
		sonLabelPv_Max.setLabelFor(sonChampPv_Max);
		sonLabelPv_Courant.setLabelFor(sonChampPv_Courant);
		sonLabelCA.setLabelFor(sonChampCA);
		sonLabelLevel.setLabelFor(sonChampLevel);
		sonLabelDieu.setLabelFor(sonChampDieu);
		sonLabelSexe.setLabelFor(sonChampSexe);
		sonLabelPosX.setLabelFor(sonChampPosX);
		sonLabelPosY.setLabelFor(sonChampPosY);


		/////////On ajoute les label au panneau
		PanoLabel.add(sonLabelNom);
		PanoLabel.add(sonLabelTaille);
		PanoLabel.add(saVueRace);
		PanoLabel.add(sonLabelAlign);
		PanoLabel.add(sonLabelClasse);
		PanoLabel.add(sonLabelFor);
		PanoLabel.add(sonLabelDex);
		PanoLabel.add(sonLabelCon);
		PanoLabel.add(sonLabelInt);
		PanoLabel.add(sonLabelSag);
		PanoLabel.add(sonLabelCha);
		PanoLabel.add(sonLabelPv_Max);
		PanoLabel.add(sonLabelPv_Courant);
		PanoLabel.add(sonLabelCA);
		PanoLabel.add(sonLabelLevel);
		PanoLabel.add(sonLabelDieu);
		PanoLabel.add(sonLabelSexe);
		PanoLabel.add(sonLabelPosX);
		PanoLabel.add(sonLabelPosY);
		
		
		//////////PANNEAU POUR LES DESCRIPTIONS
		PanoDesc = new JPanel(new BorderLayout());
		sonLabelDesc= new JLabel("    Description   ");
		PanoDesc.add(sonLabelDesc,BorderLayout.NORTH);
		PanoDesc.add(new JScrollPane(sonChampDesc),BorderLayout.CENTER);
		PanoDesc.add(saListeComp,BorderLayout.SOUTH);

		///////Valider avec un boutton
		PanoValideur = new JPanel(new GridLayout(0,1));
		
		JPanel PanoA = new JPanel(new BorderLayout());
		PanoA.add(optionComp,BorderLayout.NORTH);
		PanoA.add(ok,BorderLayout.WEST);
		PanoA.add(suppr,BorderLayout.CENTER);
		PanoA.add(visualise,BorderLayout.EAST);
		PanoValideur.add(CB);
		PanoValideur.add(PanoA);
		JButton lInven = new JButton("Inventaire");
		PanoValideur.add(lInven);
		lInven.addActionListener(this);
		PanoValideur.add(sautDeLigne);
		JButton leValideur = new JButton("Enregistrer");
		PanoValideur.add(leValideur);
		leValideur.addActionListener(this);
				
		///panneau alpha
		PanoAlpha = new JPanel(new BorderLayout());


		////////on reuni les 3 panel dans un panelAlpha
		PanoAlpha.add(PanoLabel, BorderLayout.CENTER);
		PanoAlpha.add(PanoTextF, BorderLayout.LINE_END);
		PanoAlpha.add(PanoDesc, BorderLayout.SOUTH);

		/////ON réunis les 3 panel dans le panel appelé par Pan
		Pan.add(PanoAlpha, BorderLayout.NORTH);
		Pan.add(PanoValideur, BorderLayout.SOUTH);
		
		if(sonEditeur.getsonMode()==UnEditeurDonjon.JOUER){
			saRace.setEnabled(false);
			sonAlign.setEnabled(false);
			saClasse.setEnabled(false);
			leValideur.setVisible(false);
			ok.setVisible(false);
			suppr.setVisible(false);
			CB.setVisible(false);
		}//if

		return Pan;
    }//creerPano

    public JPanel afficheToi(){//permet d'afficher une creature seulement si elle a été chargé avec le constructeur par argument
		Pan2=new JPanel();
		Pan2 = creerPano();

		try{
    		sonChampNom.setText(sonNom);
    		sonChampTaille.setText(saTaille);
    		sonChampDesc.setText(saDesc_Visuel);
    		sonChampFor.setText(Integer.toString(saFor));
    		sonChampDex.setText(Integer.toString(saDex));
    		sonChampCon.setText(Integer.toString(saCon));
    		sonChampInt.setText(Integer.toString(sonInt));
    		sonChampSag.setText(Integer.toString(saSag));
    		sonChampCha.setText(Integer.toString(sonCha));
    		sonChampPv_Max.setText(Integer.toString(sesPv_Max));
    		sonChampPv_Courant.setText(Integer.toString(sesPv_Courant));
    		sonChampCA.setText(Integer.toString(saCA));
    		sonChampLevel.setText(Integer.toString(sonLevel));
    		sonChampDieu.setText(sonDieu);
    		sonChampSexe.setText(sonSexe);
    		sonChampPosX.setText(Integer.toString(saPosX));
    		sonChampPosY.setText(Integer.toString(saPosY));
    		saListeComp.setListData(sesComp);
    		updateUI();
    		if(sonEditeur.getsonMode()==UnEditeurDonjon.JOUER){
    			sonChampNom.setEnabled(false);
    			sonChampTaille.setEnabled(false);
    			sonChampDesc.setEnabled(false);
    			sonChampFor.setEnabled(false);
    			sonChampDex.setEnabled(false);
    			sonChampCon.setEnabled(false);
    			sonChampInt.setEnabled(false);
    			sonChampSag.setEnabled(false);
    			sonChampCha.setEnabled(false);
    			sonChampPv_Max.setEnabled(false);
    			sonChampPv_Courant.setEnabled(false);
    			sonChampCA.setEnabled(false);
    			sonChampLevel.setEnabled(false);
    			sonChampDieu.setEnabled(false);
    			sonChampSexe.setEnabled(false);
    			sonChampPosX.setEnabled(false);
    			sonChampPosY.setEnabled(false);
    		}//if
		}catch(Exception telExc){
			JOptionPane.showMessageDialog(null,"Une erreur est survenue dans afficheToi de uneCreature");
		}
    	return Pan2;

    }//Affiche

    /**
     * Méthode d'enregistrement de la créature
     * @param lEcrivain fichier en cours d'écriture dans la classe fille
     */
	public void enregistreToi(PrintWriter lEcrivain){
	//les classes filles passent un Ecrivain en parametre et c'est elles qui s'occupent d'ouvrir et de fermer le fichier
			lEcrivain.println(sonNom);
			lEcrivain.println(saTaille);
			lEcrivain.println(saRace.getSelectedIndex());
			lEcrivain.println(sonAlign.getSelectedIndex());
			lEcrivain.println(saClasse.getSelectedIndex());
			lEcrivain.println(saDesc_Visuel);
			lEcrivain.println("finsaDesc;");
			lEcrivain.println(saFor);
			lEcrivain.println(saDex);
			lEcrivain.println(saCon);
			lEcrivain.println(sonInt);
			lEcrivain.println(saSag);
			lEcrivain.println(sonCha);
			lEcrivain.println(sesPv_Max);
			lEcrivain.println(sesPv_Courant);
			lEcrivain.println(saCA);
			lEcrivain.println(sonLevel);
			lEcrivain.println(sonDieu);
			lEcrivain.println(sonSexe);
			lEcrivain.println(sonImage);
			lEcrivain.println(saPosX);
			lEcrivain.println(saPosY);
			lEcrivain.println(sesComp.size());
			for (int i=0; i<sesComp.size();i++){
				String lEnreg=sesComp.elementAt(i);
				lEcrivain.println(lEnreg);
			}//for
			sonInventaire.enregistreToi(lEcrivain);
	}//enregistreToi

    /**
     * Méthode permettant de charger la créature
     * @param leLecteur fichier en cours de lecture (à partir d'une des classes filles)
     * @param telEditeur l'éditeur dans lequel doit être chargée la créature
     */
	public void chargeToi(BufferedReader leLecteur, UnEditeurDonjon telEditeur){
			sonEditeur=telEditeur;
			sesComp=new Vector<String>();
			saListeComp=new JList();
		try{

			sonNom = leLecteur.readLine();
			saTaille = leLecteur.readLine();
			saRace.setSelectedIndex(Integer.parseInt(leLecteur.readLine()));
			chargeRace=true;
			sonAlign.setSelectedIndex(Integer.parseInt(leLecteur.readLine()));
			chargeAlign=true;
			saClasse.setSelectedIndex(Integer.parseInt(leLecteur.readLine()));
			chargeClasse=true;
			String laLigne=leLecteur.readLine();
			saDesc_Visuel = laLigne;
			laLigne=leLecteur.readLine();
			while (!laLigne.equals("finsaDesc;")){
				saDesc_Visuel = saDesc_Visuel+"\n"+laLigne;
				laLigne=leLecteur.readLine();
			}//while
			saFor = Integer.parseInt(leLecteur.readLine());
			saDex = Integer.parseInt(leLecteur.readLine());
			saCon = Integer.parseInt(leLecteur.readLine());
			sonInt = Integer.parseInt(leLecteur.readLine());
			saSag = Integer.parseInt(leLecteur.readLine());
			sonCha = Integer.parseInt(leLecteur.readLine());
			sesPv_Max = Integer.parseInt(leLecteur.readLine());
			sesPv_Courant = Integer.parseInt(leLecteur.readLine());
			saCA = Integer.parseInt(leLecteur.readLine());
			sonLevel = Integer.parseInt(leLecteur.readLine());
			sonDieu = leLecteur.readLine();
			sonSexe = leLecteur.readLine();
			sonImage = leLecteur.readLine();
			saPosX = Integer.parseInt(leLecteur.readLine());
			saPosY = Integer.parseInt(leLecteur.readLine());
			int tailleComp = Integer.parseInt(leLecteur.readLine());
			for (int i=0; i<tailleComp;i++){
				String lect=leLecteur.readLine();
				sesComp.insertElementAt(lect,i);
			}//for
			sonInventaire = new UnInventaire(this);
			sonInventaire.chargeToi(leLecteur);
		}//try
		catch (Exception lException) { JOptionPane.showMessageDialog(null,"Une erreur est survenue, dans la classe créature"); }//catch

	}//chargeToi
	
    /**
     * Méthode caculant le modificateur d'une stat
     * @param telleStat la stat pour laquelle on veut obtenir le modificateur
     * @return le modificateur
     */
	public int modificateurs(int telleStat){
		int leBonus;
		int leResInt;
		
		leResInt=telleStat-10;
		leBonus=leResInt / 2;
		
		return leBonus;
	}
	
	/*public int calculSaCA(){
		saCA = 10+sonBonusArmure+sonBonusBouclier+sonModDex+sonModTaille+sonBonusArmureNaturelle+sonBonusParade+sesmodificateurs;
	}//calculSaCA*/

    /**
     * Méthode statique pour obtenir les compétence possibles
     * @return tableau de compétences et sorts disponibles
     */
	public static Vector donneTesTypes() {
		Vector<String> laListe = new Vector<String>();
		try{
			BufferedReader leLecteur = new BufferedReader(new FileReader(new File("bundll/competenceliste.jay")));
			String laLigne = leLecteur.readLine();
			while (laLigne != null){
				laListe.add(laLigne);
				laLigne = leLecteur.readLine();
			}//while
			leLecteur.close();
		}catch (Exception lException){
			JOptionPane.showMessageDialog(null, "une erreur de chargement de competenceliste.jay");
		}
		try{
			BufferedReader leLecteur = new BufferedReader(new FileReader(new File("bundll/sortliste.jay")));
			String laLigne = leLecteur.readLine();
			while (laLigne != null)
			{
				laListe.add(laLigne);
				laLigne = leLecteur.readLine();
			}//while
			leLecteur.close();
		}catch (Exception lException){
			JOptionPane.showMessageDialog(null, "une erreur de chargement de sortliste.jay");
		}
		return laListe;
	}//donneTesTypes
	
    /**
     * Méthode statique permettant d'obtenir les races disponible
     * @return tableau des races disponibles
     */
	public static Vector donneTesRaces() {
		Vector<String> laListeRace = new Vector<String>();
		try{
			BufferedReader leLecteur = new BufferedReader(new FileReader(new File("bundll/raceliste.jay")));
			String laLigne = leLecteur.readLine();
			while (laLigne != null){
				laListeRace.add(laLigne);
				laLigne = leLecteur.readLine();
			}//while
			leLecteur.close();
		}catch (Exception lException){
			JOptionPane.showMessageDialog(null, "une erreur de chargement de race.jay");
		}
		return laListeRace;
	}//donneTesTypes
	
    /**
     * Méthode statique permettant d'obtenir les alignements disponibles
     * @return tableau des alignements disponibles
     */
	public static Vector donneTesAlign() {
		Vector<String> laListeAlign = new Vector<String>();
		try{
			BufferedReader leLecteur = new BufferedReader(new FileReader(new File("bundll/alignementliste.jay")));
			String laLigne = leLecteur.readLine();
			while (laLigne != null){
				laListeAlign.add(laLigne);
				laLigne = leLecteur.readLine();
			}//while
			leLecteur.close();
		}catch (Exception lException){
			JOptionPane.showMessageDialog(null, "une erreur de chargement de alignementliste.jay");
		}
		return laListeAlign;
	}//donneTesAlign
	
    /**
     * Méthode statique permettant d'obtenir les classes disponible
     * @return tableau des classes disponibles
     */
	public static Vector donneTesClass() {
		Vector<String> laListeClass = new Vector<String>();
		try{
			BufferedReader leLecteur = new BufferedReader(new FileReader(new File("bundll/classeliste.jay")));
			String laLigne = leLecteur.readLine();
			while (laLigne != null){
				laListeClass.add(laLigne);
				laLigne = leLecteur.readLine();
			}//while
			leLecteur.close();
		}catch (Exception lException){
			JOptionPane.showMessageDialog(null, "une erreur de chargement de classeliste.jay");
		}
		return laListeClass;
	}//donneTesAlign
	
	public void afficheCA(){
		sonChampCA.setText(Integer.toString(saCA));
		updateUI();
	}

///////////////////////////LES ACCESSEURS ET MODIFICATEURS//////////////////////////////////////////////////////
    /**
     * Calcule la CA réelle de la créature.
     * @return la CA de la créature
     */
	public int getsaCA(){
		return saCA+modificateurs(saDex);
	}
	
	public UnInventaire getsonInventaire() {
		return sonInventaire;
	}//getsonInventaire
	
	public String getsonNom(){
		return sonNom;
	}//getsonNom

	public String getsaTaille(){
		return saTaille;
	}//getsaTaille

	public String getsaDesc(){
		return saDesc_Visuel;
	}//getsaDex


    public int getsaFor(){
    	return saFor;
    }//accesseur

    public void UPsaFor(int leNb){
    	saFor=saFor+leNb;
    }//monter la force

    public void DOWNsaFor(int leNb){
    	if(saFor<leNb)
    		JOptionPane.showMessageDialog(null,"Sa force n'est pas assez haute pour la diminuer","Erreur",JOptionPane.WARNING_MESSAGE);
    	else
    		saFor=saFor-leNb;
    }//diminuer la force

    public int getsaDex(){
	    return saDex;
	}//accesseur

	public void UPsaDex(int leNb){
	    saDex=saDex+leNb;
	}//monter la dex

	 public void DOWNsaDex(int leNb){
	   	if(saDex<leNb)
	    	JOptionPane.showMessageDialog(null,"Sa dextérité n'est pas assez haute pour la diminuer","Erreur",JOptionPane.WARNING_MESSAGE);
	    else
	    	saDex=saDex-leNb;
    }//diminuer la dex

    public int getsaCon(){
		return saCon;
	}//accesseur

	public void UPsaCon(int leNb){
		saCon=saCon+leNb;
	}//monter la con

	public void DOWNsaCon(int leNb){
		if(saCon<leNb)
			JOptionPane.showMessageDialog(null,"Sa constitution n'est pas assez haute pour la diminuer","Erreur",JOptionPane.WARNING_MESSAGE);
		else
			saCon=saCon-leNb;
    }//diminuer la con


	public int getsonInt(){
		return sonInt;
	}//accesseur

	public void UPsonInt(int leNb){
		sonInt=sonInt+leNb;
	}//monter l'intelligence

	public void DOWNsonInt(int leNb){
		if(sonInt<leNb)
			JOptionPane.showMessageDialog(null,"Son intelligence n'est pas assez haute pour la diminuer","Erreur",JOptionPane.WARNING_MESSAGE);
		else
			sonInt=sonInt-leNb;
    }//diminuer l'intelligence


	public int getsaSag(){
		return saSag;
	}//accesseur

	public void UPsaSag(int leNb){
		saSag=saSag+leNb;
	}//monter la sagesse

	public void DOWNsaSag(int leNb){
		if(saSag<leNb)
			JOptionPane.showMessageDialog(null,"Sa sagesse n'est pas assez haute pour la diminuer","Erreur",JOptionPane.WARNING_MESSAGE);
		else
			saSag=saSag-leNb;
    }//diminuer la sagesse

	public int getsaCha(){
		return sonCha;
	}//accesseur

	public void UPsonCha(int leNb){
		sonCha=sonCha+leNb;
	}//monter le Charisme

	public void DOWNsonCha(int leNb){
		if(sonCha<leNb)
			JOptionPane.showMessageDialog(null,"Sa chance n'est pas assez haute pour la diminuer","Erreur",JOptionPane.WARNING_MESSAGE);
		else
			sonCha=sonCha-leNb;
    }//diminuer le charisme

    public int getsesPvM(){
		return sesPv_Max;
	}//accesseur

	public void UPsesPvM(int leNb){
		sesPv_Max=sesPv_Max+leNb;
	}//monter les point de vie

	public void DOWNsesPvM(int leNb){
		if(sesPv_Max-leNb<=-10){
			JOptionPane.showMessageDialog(null,"Ses Points de Vie sont tombés à -10, votre créature est morte !","Erreur",JOptionPane.WARNING_MESSAGE);
			sesPv_Max=-10;}
		else
			sesPv_Max=sesPv_Max-leNb;
    }//diminuer les point de vie

    public int getsesPvC(){
		return sesPv_Courant;
	}//accesseur

	public void UPsesPvC(int leNb){
		if ((sesPv_Courant + leNb) <= sesPv_Max)
			sesPv_Courant = sesPv_Courant + leNb;
		else
			sesPv_Courant = sesPv_Max;
	}//monter les point de vie courant

	public void DOWNsesPvC(int leNb){
		if(sesPv_Courant<=-9)
			JOptionPane.showMessageDialog(null,sonNom+" est mort!","Alerte",JOptionPane.WARNING_MESSAGE);
		sesPv_Courant=sesPv_Courant-leNb;
    }//diminuer les point de vie courant

	public int getsonLevel(){
		return sonLevel;
	}//accesseur

	public void UPsonLevel(int leNb){
		sonLevel=sonLevel+leNb;
	}//monter le Level

	public void DOWNsonLevel(int leNb){
		if(sonLevel<leNb)
			JOptionPane.showMessageDialog(null,"Son level n'est pas assez haute pour la diminuer","Erreur",JOptionPane.WARNING_MESSAGE);
		else
			sonLevel=sonLevel-leNb;
    }//diminuer le level

    public String getsonDieu(){
    	return sonDieu;
    }//getsonDieu

    public String getsonSexe(){
    	return sonSexe;
    }//getsonSexe

	public int getsaPosX(){
		return saPosX;
	}//getsaPosX

	public void setsaPosX(int telX){
		saPosX=telX;
	}//setsaPosX

	public int getsaPosY(){
		return saPosY;
	}//getsaPosY

	public void setsaPosY(int telY){
		saPosY=telY;
	}//setsaPosY

	public String getsonEtat() { 
		if(sesPv_Courant<=-10)
			return "mort";
		if (sesPv_Courant <= 0)
			return "coma";
		return "vie";
	}//getsonEtat

	public String toString() {
		return sonNom;
	}

	public Vector<String> getsesComp() {
		return sesComp;
	}
}//class creature