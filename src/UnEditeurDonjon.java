/**
    Copyright 2007, Aur�lien P�cheur, Jonathan Mondon, Yannick Balla
 
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
import java.io.*;
import java.util.*;
import org.jvnet.substance.*;

/**
 * la classe principale
 */
public class UnEditeurDonjon extends JFrame implements ActionListener, ItemListener{

	private UneCarte saCarte;//carte en cours
	private String sonTypeSelectionne;//type s�lectionn�, utile pour le mode CHANGER_TERRAIN

	//les diff�rents panneaux
	private JSplitPane lePanneauDeBase;
	private JPanel sonPanneauContexte;
	private JPanel saZoneCarte;

	//classe permettant le parcours de dossier
	private JFileChooser sonSelectionneurDeFichier;

	//le mode et les constantes correspondant
	private int sonMode;
    /**
     * Mode jouer
     */
	public final static int JOUER = 0;
    /**
     * mode �diter
     */
	public final static int EDITER = 1;
    /**
     * mode changement de terrain
     */
	public final static int CHANGER_TERRAIN = 2;
    /**
     * mode interm�diaire, permet dans certains cas d'�viter des erreurs
     */
	public final static int ETAT_INTER = 3;


	UnEditeurDonjon(){
		//Cree la fen�tre
		super("Manager of Dungeons and Dragons Campaign");
		Toolkit leToolkit = Toolkit.getDefaultToolkit();
		Image lImage = leToolkit.getImage("./aide/perso.gif");
		setIconImage(lImage);
		try{
			UIManager.setLookAndFeel(new SubstanceLookAndFeel());
			SubstanceLookAndFeel.setCurrentTheme("org.jvnet.substance.theme.SubstanceBrownTheme");
		}
		catch (Exception lException) { }
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

		setJMenuBar(creeLaBarreDeMenu());
		setContentPane(creeLesPanneaux());
		//Cr�er le s�lectionneur de fichier
		sonSelectionneurDeFichier = new JFileChooser("./Campagnes/");
		sonSelectionneurDeFichier.setFileFilter(new javax.swing.filechooser.FileFilter(){
			public boolean accept(File telFic) {
				String lExtension = telFic.getName().substring((telFic.getName().lastIndexOf(".")+1));
				if (lExtension.equals("cjay") || lExtension.equals(telFic.getName()))
					return true;
				else
					return false;
			}

			public String getDescription() { return "Map File - Editor Dungeons and Dragons (.cjay)"; }
		});
		sonSelectionneurDeFichier.setAcceptAllFileFilterUsed(false);

		//Affichage
		setSize(1024, 740);
		setVisible(true);

		sonMode = EDITER;
	}

	private JMenuBar creeLaBarreDeMenu(){
		JMenuBar laBarreDeMenu;
		JMenu leMenu, leSousMenu;
		JMenuItem lOption;
		JRadioButtonMenuItem lOptionRadio;

		//cr�ation de la barre de menu
		laBarreDeMenu = new JMenuBar();

		//cr�ation du premier menu : fichier
		leMenu = new JMenu("File");
		laBarreDeMenu.add(leMenu);

		//ajouts de choix dans le menu
		lOption = new JMenuItem("New", KeyEvent.VK_N);
		lOption.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_N, ActionEvent.CTRL_MASK));//raccourcis clavier ctrl+N
		lOption.addActionListener(this);//pr�viens qu'une action a lieux
		leMenu.add(lOption);
		lOption = new JMenuItem("Open", KeyEvent.VK_O);
		lOption.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_O, ActionEvent.CTRL_MASK));
		lOption.addActionListener(this);
		leMenu.add(lOption);
		leMenu.addSeparator();
		lOption = new JMenuItem("Save", KeyEvent.VK_S);
		lOption.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_S, ActionEvent.CTRL_MASK));
		lOption.addActionListener(this);
		leMenu.add(lOption);
		leMenu.addSeparator();
		lOption = new JMenuItem("Quit", KeyEvent.VK_Q);
		lOption.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_Q, ActionEvent.CTRL_MASK));
		lOption.addActionListener(this);
		leMenu.add(lOption);

		//cr�ation du deuxi�me menu : mode
		leMenu = new JMenu("Mode");
		leMenu.setEnabled(false);
		laBarreDeMenu.add(leMenu);

		//ajouts de boutons radio (choix du mode)
		ButtonGroup leGroupeDeBouton = new ButtonGroup();
		lOptionRadio = new JRadioButtonMenuItem("Edit");
		lOptionRadio.setSelected(true);
		leGroupeDeBouton.add(lOptionRadio);
		lOptionRadio.addItemListener(this);//pr�viens qu'un objet change de statut
		leMenu.add(lOptionRadio);

		lOptionRadio = new JRadioButtonMenuItem("Change the field");
		leGroupeDeBouton.add(lOptionRadio);
		lOptionRadio.addItemListener(this);
		leMenu.add(lOptionRadio);

		lOptionRadio = new JRadioButtonMenuItem("Play");
		leGroupeDeBouton.add(lOptionRadio);
		lOptionRadio.addItemListener(this);
		leMenu.add(lOptionRadio);

		//cr�ation du troisi�me menu : edition
		leMenu = new JMenu("Edit");
		leMenu.setEnabled(false);
		laBarreDeMenu.add(leMenu);

		//Premier sous menu : Personnages
		leSousMenu = new JMenu("Characters...");
		lOption = new JMenuItem("Create a character player");
		lOption.addActionListener(this);
		leSousMenu.add(lOption);
		lOption = new JMenuItem("Create a non-player character");
		lOption.addActionListener(this);
		leSousMenu.add(lOption);
		lOption = new JMenuItem("Edit character");
		lOption.addActionListener(this);
		leSousMenu.add(lOption);
		leMenu.add(leSousMenu);

		//Deuxi�me sous menu : Objet
		leSousMenu = new JMenu("Objects...");

		lOption = new JMenuItem("Poser a simple object");
		lOption.addActionListener(this);
		leSousMenu.add(lOption);
		lOption = new JMenuItem("Poser a weapon");
		lOption.addActionListener(this);
		leSousMenu.add(lOption);
		lOption = new JMenuItem("Poser an armour");
		lOption.addActionListener(this);
		leSousMenu.add(lOption);
		lOption = new JMenuItem("Poser a consumable");
		lOption.addActionListener(this);
		leSousMenu.add(lOption);
		leMenu.add(leSousMenu);

		//autres choix
		lOption = new JMenuItem("Modifier la description");
		lOption.addActionListener(this);
		leMenu.add(lOption);


		//cr�ation du quatri�me menu : cr�ation (pour tout ce qui peut se cr�er sans avoir de carte)
		leMenu = new JMenu("Creation");
		laBarreDeMenu.add(leMenu);
		leSousMenu = new JMenu("Objects...");
		lOption = new JMenuItem("Create a simple object");
		lOption.addActionListener(this);
		leSousMenu.add(lOption);
		lOption = new JMenuItem("Create a weapon");
		lOption.addActionListener(this);
		leSousMenu.add(lOption);
		lOption = new JMenuItem("Create a consumable");
		lOption.addActionListener(this);
		leSousMenu.add(lOption);
		lOption = new JMenuItem("Create an armour");
		lOption.addActionListener(this);
		leSousMenu.add(lOption);
		leSousMenu.addSeparator();
		lOption = new JMenuItem("Edit a simple object");
		lOption.addActionListener(this);
		leSousMenu.add(lOption);
		lOption = new JMenuItem("Edit a weapon");
		lOption.addActionListener(this);
		leSousMenu.add(lOption);
		lOption = new JMenuItem("Edit an armour");
		lOption.addActionListener(this);
		leSousMenu.add(lOption);
		lOption = new JMenuItem("Edit a consumable");
		lOption.addActionListener(this);
		leSousMenu.add(lOption);
		leMenu.add(leSousMenu);
		lOption = new JMenuItem("Create a type of box(?)");
		lOption.addActionListener(this);
		leMenu.add(lOption);
        lOption = new JMenuItem("Create a race");
		lOption.addActionListener(this);
		leMenu.add(lOption);
		lOption = new JMenuItem("Create a class");
		lOption.addActionListener(this);
		leMenu.add(lOption);
		lOption = new JMenuItem("Create a spell");
		lOption.addActionListener(this);
		leMenu.add(lOption);
		lOption = new JMenuItem("Build capacity");
		lOption.addActionListener(this);
		leMenu.add(lOption);
                

		//cr�ation du quatri�me menu : jouer
		leMenu = new JMenu("Play");
		leMenu.setEnabled(false);
		laBarreDeMenu.add(leMenu);
		
		leSousMenu = new JMenu("See the list...");
		lOption = new JMenuItem("events");
		lOption.addActionListener(this);
		leSousMenu.add(lOption);
		lOption = new JMenuItem("characters");
		lOption.addActionListener(this);
		leSousMenu.add(lOption);
		leMenu.add(leSousMenu);

		lOption = new JMenuItem("Move one character", KeyEvent.VK_D);
		lOption.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_D, ActionEvent.CTRL_MASK));//raccourcis clavier ctrl+D
		lOption.addActionListener(this);
		leMenu.add(lOption);
		lOption = new JMenuItem("Edit the stats", KeyEvent.VK_E);
		lOption.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_E, ActionEvent.CTRL_MASK));//raccourcis clavier ctrl+D
		lOption.addActionListener(this);
		leMenu.add(lOption);
		lOption = new JMenuItem("Roll dice", KeyEvent.VK_L);
		lOption.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_L, ActionEvent.CTRL_MASK));//raccourcis clavier ctrl+L
		lOption.addActionListener(this);
		leMenu.add(lOption);




		//cr�ation du sixi�me menu : � propos
		leMenu = new JMenu("?");
		laBarreDeMenu.add(leMenu);
		lOption = new JMenuItem("Aide");
		lOption.addActionListener(this);
		leMenu.add(lOption);
		lOption = new JMenuItem("A propos...");
		lOption.addActionListener(this);
		leMenu.add(lOption);

		return laBarreDeMenu;
	}

	private Container creeLesPanneaux(){
		//Cree le Panneau Carte
		saZoneCarte = new JPanel();

		//Cree le Panneau Contextuel
		sonPanneauContexte = new JPanel();

		//On met les 2 panneaux dans la fen�tre
		//JSplitPane
		lePanneauDeBase = new JSplitPane(JSplitPane.HORIZONTAL_SPLIT, true, saZoneCarte, sonPanneauContexte);
		lePanneauDeBase.setOneTouchExpandable(false);
		lePanneauDeBase.setDividerLocation(650);

		//Taille minimum des panneaux
		saZoneCarte.setMinimumSize(new Dimension(500, 100));
		sonPanneauContexte.setMinimumSize(new Dimension(300, 100));

		//Taille pr�f�r�e pour le panneau principal
		lePanneauDeBase.setPreferredSize(new Dimension(1024, 700));

		return lePanneauDeBase;
	}


	//Capture d'action dans les menus
    /**
     * r�action des menus
     * @param telleAction menu activ�
     */
	public void actionPerformed(ActionEvent telleAction){
		JMenuItem laSource = (JMenuItem)(telleAction.getSource());
		String leChoix = laSource.getText();
		if(leChoix=="New"){
			UneCarte laCarte = new UneCarte(this,this);
			if (!laCarte.getsonNom().equals("")){
				saCarte = laCarte;
				afficheLaCarte();
				afficheEnContexte(new JPanel());
				sonTypeSelectionne = saCarte.getsonType();
				getJMenuBar().getMenu(2).setEnabled(true);
				getJMenuBar().getMenu(1).setEnabled(true);
				getJMenuBar().updateUI();
			}
		}

		if (leChoix == "Open"){
			 int leRetour = sonSelectionneurDeFichier.showOpenDialog(UnEditeurDonjon.this);
			 if (leRetour == JFileChooser.APPROVE_OPTION) {
				//Ouverture du fichier
			 	File leFichier = sonSelectionneurDeFichier.getSelectedFile();
				UneCarte laCarte = new UneCarte(leFichier, this);
				if (!laCarte.getsonNom().equals("")){
					saCarte = laCarte;
					afficheLaCarte();
					afficheEnContexte(new JPanel());
					sonTypeSelectionne = saCarte.getsonType();
					getJMenuBar().getMenu(2).setEnabled(true);
					getJMenuBar().getMenu(1).setEnabled(true);
					getJMenuBar().updateUI();
				}
			 }
		}

		if (leChoix == "Save"){
			int leRetour = sonSelectionneurDeFichier.showSaveDialog(UnEditeurDonjon.this);
			if (leRetour == JFileChooser.APPROVE_OPTION) {
			    //Ouvre le fichier (pour enregistrer)
			    File leFichier = sonSelectionneurDeFichier.getSelectedFile();
				saCarte.enregistreToi(leFichier);
			}
		}

		if (leChoix == "Quit"){
			int laDecision = JOptionPane.showConfirmDialog(this, "D�sirez-vous sauvegarder avant de quitter?\n", "Quit", JOptionPane.YES_NO_CANCEL_OPTION,JOptionPane.QUESTION_MESSAGE);
			if (laDecision == JOptionPane.YES_OPTION) {
				int leRetour = sonSelectionneurDeFichier.showSaveDialog(UnEditeurDonjon.this);
				if (leRetour == JFileChooser.APPROVE_OPTION) {
					//Ouvre le fichier (pour enregistrer)
					File leFichier = sonSelectionneurDeFichier.getSelectedFile();
					saCarte.enregistreToi(leFichier);
				}
				System.exit(0);
			}
			if (laDecision == JOptionPane.NO_OPTION) { System.exit(0); }
		}

		if (leChoix == "Create a character player"){
			afficheEnContexte(new UnJoueur(this).afficheToi());
		}
		if (leChoix == "Create a non-player character"){
			afficheEnContexte(new UnNonJoueur(this).afficheToi());
		}
		if (leChoix == "Create a simple object"){
			afficheEnContexte(new UnObjet().afficheToi());
		}
		if (leChoix == "Create an armour"){
			afficheEnContexte(new UneArmure().afficheToi());
		}
		if (leChoix == "Create a weapon"){
			afficheEnContexte(new UneArme().afficheToi());
		}
		if (leChoix == "Create a consumable"){
			afficheEnContexte(new UnConsommable().afficheToi());
		}
		if (leChoix == "Create a type of box(?)"){
			afficheEnContexte(new UnType());
		}
		if (leChoix == "Create a class"){
			afficheEnContexte(new UneClasse().afficheToi());
		}
		if (leChoix == "Create a spell") {
			afficheEnContexte(new UnSort().afficheToi());
		}
                if (leChoix == "Create a race"){
			afficheEnContexte(new UneRace().creeToi());
		}
		if (leChoix == "Build capacity"){
			afficheEnContexte(new UneCapacite().afficheToi());
		}
		if ((leChoix == "Edit character") || (leChoix == "Edit the stats")){
			Vector<UneCreature> lesCreatures = saCarte.getsesCreatures();
			String[] lesChoixPossibles = new String[lesCreatures.size()];
			for (int i = 0; i < lesCreatures.size(); i++) {
				lesChoixPossibles[i] = lesCreatures.get(i).getsonNom();
			}
			try{
				String leChoixCrea = (String)JOptionPane.showInputDialog(null, "Quel personnage modifie-t-on?", "Edition Personnage", JOptionPane.QUESTION_MESSAGE, null, lesChoixPossibles, lesChoixPossibles[0]);
				if (leChoixCrea != null) {
					int i=0;
					while (!leChoixCrea.equals(lesChoixPossibles[i])) i++;
					if (leChoix == "Edit character")
						afficheEnContexte(lesCreatures.get(i).afficheToi());
					else
						afficheEnContexte(lesCreatures.get(i).editeTesStats());
				}
			}
			catch (Exception lException) { JOptionPane.showMessageDialog(null, "Il n'y a aucun personnage sur la carte.", "Edition Personnage", JOptionPane.WARNING_MESSAGE); }
		}
		if (leChoix == "Edit a simple object"){
			String choix = JOptionPane.showInputDialog(null, "Un objet nomm�?", "Editer objet", JOptionPane.QUESTION_MESSAGE);
			if(choix!=null)
				afficheEnContexte(new UnObjet(choix).afficheToi());
		}
		if (leChoix == "Edit an armour"){
			String choix =JOptionPane.showInputDialog(null, "Un armure nomm�?", "Editer objet", JOptionPane.QUESTION_MESSAGE);
			if (choix != null)
                                try{
                                    afficheEnContexte(new UneArmure(choix).afficheToi());
                                }catch(Exception lException){ JOptionPane.showMessageDialog(null,"Ceci n'est pas une armure.","Erreur",JOptionPane.WARNING_MESSAGE);}
		}
		if (leChoix == "Edit a weapon"){
			String choix =JOptionPane.showInputDialog(null, "Un arme nomm�?", "Editer objet", JOptionPane.QUESTION_MESSAGE);
			if (choix != null)
                            try{
				afficheEnContexte(new UneArme(choix).afficheToi());
                           }catch(Exception lException){ JOptionPane.showMessageDialog(null,"Ceci n'est pas une arme","Erreur",JOptionPane.WARNING_MESSAGE);}
		}
		if (leChoix == "Edit a consumable"){
			String choix = JOptionPane.showInputDialog(null, "Un consommable nomm�?", "Editer objet", JOptionPane.QUESTION_MESSAGE);
			if (choix != null)
                            try{
				afficheEnContexte(new UnConsommable(choix).afficheToi());
                            }catch(Exception lException){ JOptionPane.showMessageDialog(null,"Ceci n'est pas un consommable","Erreur",JOptionPane.WARNING_MESSAGE);}
		}
		if (leChoix == "Poser a simple object"){
			String laChaine = JOptionPane.showInputDialog(null, "Quel objet pose-t-on et o�?\nDonnez les informations au format suivant : nom,X,Y", "Poser un objet", JOptionPane.QUESTION_MESSAGE);
			if (laChaine!=null)
				try{
					int X = Integer.parseInt(laChaine.split(",")[1]);
					int Y = Integer.parseInt(laChaine.split(",")[2]);
					saCarte.getsesCases()[Y][X].addUnObjet(new UnObjet(laChaine.split(",")[0]));
					afficheLaCarte();
				}
				catch (Exception lException) { JOptionPane.showMessageDialog(null, "Format de donn�e non reconnu ou case inexistante", "ERREUR", JOptionPane.ERROR_MESSAGE); }
		}
		if (leChoix == "Poser an armour"){
			String laChaine = JOptionPane.showInputDialog(null, "Quelle armure pose-t-on et o�?\nDonnez les informations au format suivant : nom,X,Y", "Poser un objet", JOptionPane.QUESTION_MESSAGE);
				if (laChaine!=null)
				try{
					int X = Integer.parseInt(laChaine.split(",")[1]);
					int Y = Integer.parseInt(laChaine.split(",")[2]);
					saCarte.getsesCases()[Y][X].addUnObjet(new UneArmure(laChaine.split(",")[0]));
					afficheLaCarte();
				}
				catch (Exception lException) { JOptionPane.showMessageDialog(null, "Format de donn�e non reconnu ou case inexistante", "ERREUR", JOptionPane.ERROR_MESSAGE); }
		}
		if (leChoix == "Poser a weapon"){
			String laChaine = JOptionPane.showInputDialog(null, "Quelle arme pose-t-on et o�?\nDonnez les informations au format suivant : nom,X,Y", "Poser un objet", JOptionPane.QUESTION_MESSAGE);
			if (laChaine!=null)
				try{
					int X = Integer.parseInt(laChaine.split(",")[1]);
					int Y = Integer.parseInt(laChaine.split(",")[2]);
					saCarte.getsesCases()[Y][X].addUnObjet(new UneArme(laChaine.split(",")[0]));
					afficheLaCarte();
				}
				catch (Exception lException) { JOptionPane.showMessageDialog(null, "Format de donn�e non reconnu ou case inexistante", "ERREUR", JOptionPane.ERROR_MESSAGE); }
		}
		if (leChoix == "Poser a consumable"){
			String laChaine = JOptionPane.showInputDialog(null, "Quel consommable pose-t-on et o�?\nDonnez les informations au format suivant : nom,X,Y", "Poser un objet", JOptionPane.QUESTION_MESSAGE);
			if (laChaine!=null)
				try{
					int X = Integer.parseInt(laChaine.split(",")[1]);
					int Y = Integer.parseInt(laChaine.split(",")[2]);
					saCarte.getsesCases()[Y][X].addUnObjet(new UnConsommable(laChaine.split(",")[0]));
					afficheLaCarte();
				}
				catch (Exception lException) { JOptionPane.showMessageDialog(null, "Format de donn�e non reconnu ou case inexistante", "ERREUR", JOptionPane.ERROR_MESSAGE); }
		}
		if (leChoix == "Move one character") {
			Vector<UnJoueur> lesJoueurs = saCarte.getsesJoueurs();
			String[] lesChoixPossibles = new String[lesJoueurs.size()+1];
			lesChoixPossibles[0] = "All players";
			for (int i = 1; i <= lesJoueurs.size(); i++){
				lesChoixPossibles[i] = lesJoueurs.get(i-1).getsonNom();
			}
			try{
				String leChoixCrea = (String)JOptionPane.showInputDialog(this, "Qui d�place-t-on?", "Deplacement Personnage", JOptionPane.QUESTION_MESSAGE, null, lesChoixPossibles, lesChoixPossibles[0]);
				if (leChoixCrea != null){
					String laDest = JOptionPane.showInputDialog(this, "Veuillez indiquer la destination de " + leChoixCrea + ".\nUtilisez le format suivant : direction,distance.\nDirections possibles : N,S,E,O,NE,NO,SE,SO.\nLa distance est en case (rappel : 1 case = 1,5m)", "Deplacement", JOptionPane.QUESTION_MESSAGE);
					if (leChoixCrea.equals(lesChoixPossibles[0])){
						sonMode = ETAT_INTER;
						for (int i = 0; i < lesJoueurs.size(); i++){
							deplaceLePerso(lesJoueurs.get(i), laDest);
						}
						sonMode = JOUER;
						afficheLaCarte();
					}
					else{
						int i = 1;
						while (!leChoixCrea.equals(lesChoixPossibles[i])) i++;
						deplaceLePerso(lesJoueurs.get(i-1), laDest);
					}
				}
			}
			catch (Exception lException) { JOptionPane.showMessageDialog(this, "Il n'y a aucun joueur sur la carte.", "Edition Personnage", JOptionPane.WARNING_MESSAGE); }		
		}
		if (leChoix == "Roll dice"){
			String lesDes = JOptionPane.showInputDialog(this, "You are about to launch the dice.\nUse the following syntax: x y, f x is the number of dice, and their value.", "Roll dice", JOptionPane.QUESTION_MESSAGE);
			if(lesDes!=null){
				if (lesDes.split("[dD]").length != 2)
					JOptionPane.showMessageDialog(null, "Erreur : vous n'avez pas respect� le format.", "Erreur : mauvaise saisie!", JOptionPane.ERROR_MESSAGE);
				else{
					try{
						int[] leResultat = lanceLesDes(lesDes);
						int total = 0;
						String laChaine = "R�sultat : \n";
						for (int i = 0; i < leResultat.length; i++){
							laChaine += "D� " + (i + 1) + " : " + leResultat[i] + "\n";
							total += leResultat[i];
						}
						laChaine += "total : " + total;
						JOptionPane.showMessageDialog(null, laChaine);
					}
					catch (Exception lException){
						JOptionPane.showMessageDialog(null, "Erreur : vous n'avez pas respect� le format.", "Erreur : mauvaise saisie!", JOptionPane.ERROR_MESSAGE);
					}
				}
			}
		}
		if (leChoix == "events") {
			Vector<UnEvenement> lesEvenements = saCarte.getsesEvenements();
			String laChaine = "<HTML>List of events : <br>";
			if (lesEvenements.size() == 0)
				laChaine += "There are no events on the map";
			else
				for (int i = 0; i < lesEvenements.size(); i++){
					laChaine += lesEvenements.get(i).sonNom + " (" + lesEvenements.get(i).saCase.getsonX() + "," + lesEvenements.get(i).saCase.getsonY() + ")<br>";
				}
			laChaine += "</HTML>";
			JPanel lePanneau = new JPanel();
			lePanneau.add(new JLabel(laChaine));
			afficheEnContexte(lePanneau);
		}
		if (leChoix == "characters"){
			Vector<UneCreature> lesCreatures = saCarte.getsesCreatures();
			String laChaine = "<HTML>List of characters: <br>";
			if (lesCreatures.size() == 0)
				laChaine += "There are no characters on the map";
			else
				for (int i = 0; i < lesCreatures.size(); i++){
					laChaine += lesCreatures.get(i).getsonNom() + " (" + lesCreatures.get(i).getsaPosX() + "," + lesCreatures.get(i).getsaPosY() + ")<br>";
				}
			laChaine += "</HTML>";
			JPanel lePanneau = new JPanel();
			lePanneau.add(new JLabel(laChaine));
			afficheEnContexte(lePanneau);
		}
		if (leChoix == "A propos...")
			JOptionPane.showMessageDialog(this, "<html><table border='0'><tr><td><img src='http://wankin.net/perso_coffre_evt_exemple.jpg' width='60' height='60'></td><th><div align='left'><p>L'&eacute;diteur Donjons et Dragons - version beta 0.7<br>Copyright &copy; 2007, Aur&eacute;lien P&ecirc;cheur, Jonathan Mondon, Yannick Balla<br>L'&eacute;diteur Donjons et Dragons est un logiciel d'aide &agrave; la gestion de campagne pour le jeu &quot;Donjons et Dragons&quot;.<br>Merci &agrave; Jean-Philippe Farrugia l'ensemble du corps enseignant de l'IUT A - Lyon 1 pour leur aide et formation.</p></div></th></tr></table><p><br>This program is free software: you can redistribute it and/or modify it under the terms of the GNU General<br>Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option)<br>any later version.</p><p><br>This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without <br>even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the<br>GNU General Public License for more details.</p><p><br>You should have received a copy of the GNU General Public License along with this program. <br></p><p>If not, see <a href='http://www.gnu.org/licenses/'>http://www.gnu.org/licenses/</a>.</p></html>", "A propos...", JOptionPane.PLAIN_MESSAGE);
		if (leChoix == "Aide")
			JOptionPane.showMessageDialog(this, "Vous trouverez les fichiers d'aide et tutoriaux dans le r�pertoire \"Aide\" l� o� vous avez install� l'Editeur Donjon et Dragon.","A propos...", JOptionPane.INFORMATION_MESSAGE);
		if (leChoix == "Modifier la description")
			saCarte.changeSaDescription();
	}

    /**
     * r�action du menu mode
     * @param telleAction mode activ�
     */
	public void itemStateChanged(ItemEvent telleAction){

		//on g�re les changements de mode
		JMenuItem laSource = (JMenuItem)(telleAction.getSource());
		String leChoix = laSource.getText();
		if ((leChoix == "Play") && (telleAction.getStateChange() == ItemEvent.SELECTED)) {
			getJMenuBar().getMenu(2).setEnabled(false);
                        getJMenuBar().getMenu(3).setEnabled(true);
			getJMenuBar().getMenu(4).setEnabled(true);
			sonMode = JOUER;
			afficheEnContexte(new JPanel());
			getJMenuBar().updateUI();
			JOptionPane.showMessageDialog(this, saCarte.getsaDescription(), saCarte.getsonNom(), JOptionPane.PLAIN_MESSAGE);
			afficheLaCarte();//� voir
		}
		if ((leChoix == "Change the field") && (telleAction.getStateChange() == ItemEvent.SELECTED)){
			getJMenuBar().getMenu(2).setEnabled(false);
                        getJMenuBar().getMenu(3).setEnabled(false);
			getJMenuBar().getMenu(4).setEnabled(false);
			sonMode = CHANGER_TERRAIN;
			changeLeTerrain();
			getJMenuBar().updateUI();
		}
		if ((leChoix == "Edit") && (telleAction.getStateChange() == ItemEvent.SELECTED)){
			getJMenuBar().getMenu(2).setEnabled(true);
                        getJMenuBar().getMenu(3).setEnabled(true);
			getJMenuBar().getMenu(4).setEnabled(false);
			sonMode = EDITER;
			afficheEnContexte(new JPanel());
			getJMenuBar().updateUI();
		}
	}

    /**
     * M�thode permettant en mode CHANGER_TERRAIN de savoir quel terrain doit �tre appliqu� sur les cases
     * @param telleAction clic sur un terrain du menu contextuel
     */
	public void selectionneLeTerrain(ItemEvent telleAction){
		JRadioButton laSource = (JRadioButton)telleAction.getSource();
		if(telleAction.getStateChange()==ItemEvent.SELECTED)
			sonTypeSelectionne = laSource.getText().split("/")[0];
	}

	//m�thodes permettant l'affichage dans les diff�rents panneaux
    /**
     * M�thode permettant le rafraichissement de la carte.
     */
	public void afficheLaCarte(){
		//m�thode de mise � jour du panneau carte, utilis�e par la carte
		saZoneCarte = saCarte.afficheToi();
		JPanel lePanneau2 = new JPanel();
		lePanneau2.add(saZoneCarte);
		JScrollPane leScroll = new JScrollPane(lePanneau2);
		lePanneauDeBase.setLeftComponent(leScroll);
		lePanneauDeBase.updateUI();
	}

    /**
     * M�thode permettant d'afficher un panneau  dans le menu contextuel.
     * @param telPanneau le panneau � afficher
     */
	public void afficheEnContexte(JPanel telPanneau){
		JPanel lePanneau = new JPanel();
		lePanneau.add(telPanneau);
		JScrollPane leScroll = new JScrollPane(lePanneau);
		lePanneauDeBase.setRightComponent(leScroll);
		lePanneauDeBase.updateUI();
	}

	private void changeLeTerrain() {
		JPanel lePanneau = new JPanel(new GridLayout(0,1));
		JPanel lePanneauLabel = new JPanel(new GridLayout(0, 1));
		JLabel leLabel = new JLabel("CHANGEMENT DE TERRAIN");
		lePanneauLabel.add(leLabel);
		leLabel = new JLabel("1) Cliquez sur l'image du type voulu");
		lePanneauLabel.add(leLabel);
		leLabel = new JLabel("2) Cliquez sur la carte pour changer le terrain");
		lePanneauLabel.add(leLabel);
		lePanneau.add(lePanneauLabel);
		Vector lesTypes = UnType.donneTesTypes();
		ButtonGroup leGroupeDeBouton = new ButtonGroup();
		for (int i = 0; i < lesTypes.size(); i++) {
			UnType leType = new UnType((String)lesTypes.elementAt(i));
			JRadioButton lOptionRadio = new JRadioButton(leType.toString(),new ImageIcon("./img_types/" + leType.getsonImage()));
			lOptionRadio.addItemListener(new ItemListener(){
				public void itemStateChanged(ItemEvent lEvt){
					selectionneLeTerrain(lEvt);
				}
			});
			leGroupeDeBouton.add(lOptionRadio);
			lePanneau.add(lOptionRadio);
		}
		afficheEnContexte(lePanneau);
	}


	//quelques accesseurs
    /**
     * M�thode permettant de savoir dans quel mode on se trouve.
     * @return Renvoie une constante (JOUER,EDITER,MODE_INTER ou CHANGER_TERRAIN)
     */
	public int getsonMode() { return sonMode; }
    /**
     * Renvoie le type de terrain  s�lectionn� pendant le changement de terrain.
     * @return type de terrain s�lectionn�
     */
	public String getsonTypeSelectionne() { return sonTypeSelectionne; }
    /**
     * accesseur vers la carte
     * @return renvoie l'objet UneCarte associ�.
     */
	public UneCarte getsaCarte(){return saCarte;}
        public void setsaCarte(UneCarte telleCarte){saCarte = telleCarte;}
    /**
     * change le mode de l'�diteur
     * @param telMode Constante correspondant au mode.
     */
	public void setsonMode(int telMode) { sonMode=telMode; }
	//m�thodes utiles pour plusieurs classes
    /**
     * Lance des d�s � l'aide d'une chaine et renvoie le r�sultat sous forme de tableau.
     * @param lesDes Chaine de type "xDy"
     * @return les r�sultats
     */
	public static int[] lanceLesDes(String lesDes){
		int leNb = Integer.parseInt(lesDes.split("[dD]")[0]);
		int laValeur = Integer.parseInt(lesDes.split("[dD]")[1]);
		int[] leRetour= new int[leNb];
		for (int i=0; i<leRetour.length;i++){
			leRetour[i]=(int)((laValeur)*Math.random()+1);
		}
		return leRetour;
	}

    /**
     * D�place un personnage dans la direction voulue
     * @param telleCreature le personnage � d�placer
     * @param telleDestination chaine de type Direction,Destance
     */
	public void deplaceLePerso(UneCreature telleCreature, String telleDestination) {
		if (telleDestination != null)
		{
			int leX = telleCreature.getsaPosX();
			int leY = telleCreature.getsaPosY();
			try
			{
				int laDist = Integer.parseInt(telleDestination.split(",")[1]);
				String laDest = telleDestination.split(",")[0];
				if (laDest.equalsIgnoreCase("N"))
				{
					telleCreature.deplaceToi(leX, leY - laDist);
					afficheLaCarte();
					afficheEnContexte(saCarte.getsesCases()[leY - laDist][leX].affichePanneauEditeLaCase());
				}
				else if (laDest.equalsIgnoreCase("S"))
				{
					telleCreature.deplaceToi(leX, leY + laDist);
					afficheLaCarte();
					afficheEnContexte(saCarte.getsesCases()[leY + laDist][leX].affichePanneauEditeLaCase());
				}
				else if (laDest.equalsIgnoreCase("E"))
				{
					telleCreature.deplaceToi(leX + laDist, leY);
					afficheLaCarte();
					afficheEnContexte(saCarte.getsesCases()[leY][leX + laDist].affichePanneauEditeLaCase());
				}
				else if (laDest.equalsIgnoreCase("O"))
				{
					telleCreature.deplaceToi(leX - laDist, leY);
					afficheLaCarte();
					afficheEnContexte(saCarte.getsesCases()[leY][leX - laDist].affichePanneauEditeLaCase());
				}
				else if (laDest.equalsIgnoreCase("NE"))
				{
					telleCreature.deplaceToi(leX + laDist, leY - laDist);
					afficheLaCarte();
					afficheEnContexte(saCarte.getsesCases()[leY - laDist][leX + laDist].affichePanneauEditeLaCase());
				}
				else if (laDest.equalsIgnoreCase("NO"))
				{
					telleCreature.deplaceToi(leX - laDist, leY - laDist);
					afficheLaCarte();
					afficheEnContexte(saCarte.getsesCases()[leY - laDist][leX - laDist].affichePanneauEditeLaCase());
				}
				else if (laDest.equalsIgnoreCase("SE"))
				{
					telleCreature.deplaceToi(leX + laDist, leY + laDist);
					afficheLaCarte();
					afficheEnContexte(saCarte.getsesCases()[leY + laDist][leX + laDist].affichePanneauEditeLaCase());
				}
				else if (laDest.equalsIgnoreCase("SO"))
				{
					telleCreature.deplaceToi(leX - laDist, leY + laDist);
					afficheLaCarte();
					afficheEnContexte(saCarte.getsesCases()[leY + laDist][leX - laDist].affichePanneauEditeLaCase());
				}
				else
				{
					JOptionPane.showMessageDialog(null, "Destination inconnue.\nD�placement annul�.", "Erreur", JOptionPane.ERROR_MESSAGE);
				}
			}
			catch (NumberFormatException lException) { JOptionPane.showMessageDialog(null, "La distance a �t� mal saisie.\nD�placement annul�.", "Erreur", JOptionPane.ERROR_MESSAGE); }
			catch (Exception lException) { 
                            JOptionPane.showMessageDialog(null, "Format non reconnus ou trop grande distance.\nD�placement annul�.", "Erreur", JOptionPane.ERROR_MESSAGE);
                        }               
		}
	}

    /**
     * 
     */
	public static void main(String[] args)
	{
		//Schedule a job for the event-dispatching thread:
		//creating and showing this application's GUI.
		javax.swing.SwingUtilities.invokeLater(new Runnable()
		{
			public void run()
			{
				new UnEditeurDonjon();
			}
		});
	}

}