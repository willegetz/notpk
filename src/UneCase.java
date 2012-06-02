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

import java.awt.*;
import java.util.Vector;
import javax.swing.*;
import java.awt.event.*;
import java.io.*;

public class UneCase implements ActionListener{

	private int sonX, sonY;
	private UnType sonType;
	private UnJoueur sonJoueur;
	private UnNonJoueur sonNonJoueur;
	private Vector<UnObjet> sonTabObjet;
	private String saDescription;
	UnEditeurDonjon sonEditeurDonjon;
	private UnEvenement sonEvenement;

	UneCase(int telX, int telY, UnType telType, UnEditeurDonjon telEditeur){
		sonEditeurDonjon = telEditeur;
		sonX = telX;
		sonY = telY;
		sonType = telType;
		sonTabObjet = new Vector<UnObjet>();
		sonJoueur = null;
		sonNonJoueur = null;
		saDescription = null;
		sonEvenement = null;
	}

	public void setsonType(UnType telType) {
		sonType = telType;
	}
	public void setsonJoueur(UnJoueur telJoueur) { sonJoueur = telJoueur; }
	public void setsonNonJoueur(UnNonJoueur telNonJoueur) { sonNonJoueur = telNonJoueur; }
	public void setsaDescription(String telleDesc) { saDescription = telleDesc; }
	public void setsonEvenement(UnEvenement telEvenement) { sonEvenement = telEvenement; }

	public UneCreature getsaCreature() {
		if (sonJoueur != null)
			return sonJoueur;
		else if (sonNonJoueur != null)
			return sonNonJoueur;
		else
			return null;
	}
	public UnType getsonType() { return sonType; }
	public UnJoueur getsonJoueur() { return sonJoueur; }
	public UnNonJoueur getsonNonJoueur() { return sonNonJoueur; }
	public Vector<UnObjet> getsonTabObjet() { return sonTabObjet; }
	public String getsaDescription() { return saDescription; }
	public int getsonX() { return sonX; }
	public int getsonY() { return sonY; }
	public UnEvenement getsonEvenement() { return sonEvenement; }

	public void addUnObjet(UnObjet telObjet) { sonTabObjet.add(telObjet); }
	public void removeUnObjet(UnObjet telObjet) { sonTabObjet.removeElement(telObjet); }


	public JButton afficheToi(){
		JButton leBouton;

		String laChaine = "./img_types/";
		if (getsaCreature() != null)
			laChaine += "perso_";
		if (sonTabObjet.size() > 0)
			laChaine += "coffre_";
		if (sonEvenement != null || (sonNonJoueur!= null && sonNonJoueur.getsonAgr()))
			laChaine += "evt_";
		if (!new File(laChaine + sonType.getsonImage()).exists())
			laChaine = "./img_types/";
		leBouton = new JButton(new ImageIcon(laChaine + sonType.getsonImage()));
		leBouton.setMargin(new Insets(-1, -1, -1, -1));
		leBouton.addActionListener(this);

		if ((sonEditeurDonjon.getsonMode() == UnEditeurDonjon.JOUER) && sonEvenement != null)
			if (sonEvenement.doitSeDeclencher())
				sonEvenement.declencheToi();
				
			return leBouton;
	}

	public void actionPerformed(ActionEvent telleAction){
		if (sonEditeurDonjon.getsonMode() != UnEditeurDonjon.CHANGER_TERRAIN)
			sonEditeurDonjon.afficheEnContexte(affichePanneauEditeLaCase());
		else if (sonEditeurDonjon.getsonMode() == UnEditeurDonjon.CHANGER_TERRAIN){
			UnType leType = new UnType(sonEditeurDonjon.getsonTypeSelectionne());
			if ((leType.getsonFranchissement() == 0) && (sonJoueur != null || sonNonJoueur != null))
				JOptionPane.showMessageDialog(null, "Cet endroit possède un personnage, vous ne pouvez pas le rendre infranchissable.", "Action impossible", JOptionPane.WARNING_MESSAGE);
			else{
				sonType = leType;
				sonEditeurDonjon.afficheLaCarte();
			}
		}
	}

	public void editeEvenement(ActionEvent lEvt) {
		String[] leChoix = { "Editer", " Supprimer", " Annuler" };
		int laDecision = JOptionPane.showOptionDialog(null, "Que fait-on?", "Modifier un événement", JOptionPane.YES_NO_CANCEL_OPTION, JOptionPane.QUESTION_MESSAGE, null, leChoix, leChoix[2]);
		if (laDecision == JOptionPane.YES_OPTION)
		{
			sonEditeurDonjon.afficheEnContexte(sonEvenement.editeToi());
		}
		if (laDecision == JOptionPane.NO_OPTION)
		{
			sonEvenement = null;
			sonEditeurDonjon.afficheEnContexte(affichePanneauEditeLaCase());
		}
		sonEditeurDonjon.afficheLaCarte();
	}

	public void ajouteEvenement(ActionEvent lEvt) {
		String[] leChoix = { "Un Dialogue", " Un Piege", " Un point d'entree/sortie" };
		int laDecision = JOptionPane.showOptionDialog(null, "Que doit-on ajouter?", "ajouter un événement", JOptionPane.YES_NO_CANCEL_OPTION, JOptionPane.QUESTION_MESSAGE, null, leChoix, leChoix[2]);
		if (laDecision == JOptionPane.YES_OPTION){
			if (sonNonJoueur == null)
				JOptionPane.showMessageDialog(null, "Il n'y a pas de pnj ici, impossible de mettre un dialogue", "Ajouter un Dialogue", JOptionPane.WARNING_MESSAGE);
			else{
				sonEvenement = new UnDialogue(this);
				sonEditeurDonjon.afficheEnContexte(sonEvenement.editeToi());
			}
		}
		if (laDecision == JOptionPane.NO_OPTION){
			sonEvenement = new UnPiege(this);
			sonEditeurDonjon.afficheEnContexte(sonEvenement.editeToi());
		}
                if (laDecision == JOptionPane.CANCEL_OPTION){
                    sonEvenement = new UneEntreeSortie(this);
                    sonEditeurDonjon.afficheEnContexte(sonEvenement.editeToi());
                }
		sonEditeurDonjon.afficheLaCarte();
	}

	public void deplaceJoueur(ActionEvent lEvt) {
		String laDest = JOptionPane.showInputDialog(null, "Veuillez indiquer la destination de " + getsaCreature().getsonNom() + ".\nUtilisez le format suivant : direction,distance.\nDirections possibles : N,S,E,O,NE,NO,SE,SO.\nLa distance est en case (rappel : 1 case = 1,5m)", "Deplacement", JOptionPane.QUESTION_MESSAGE);
		sonEditeurDonjon.deplaceLePerso(getsaCreature(), laDest);
	}
	public void voirJoueur(ActionEvent lEvt){
		sonEditeurDonjon.afficheEnContexte(getsaCreature().afficheToi());
	}
	public void ramasserObjet(ActionEvent lEvt) {
		int lIndex = Integer.parseInt(((JLabel)((JButton)lEvt.getSource()).getParent().getComponent(0)).getText().split(":")[0]);//permet de récupérer le bon objet
		getsaCreature().getsonInventaire().ramasser(sonTabObjet.elementAt(lIndex - 1));
		sonTabObjet.removeElementAt(lIndex - 1);
		sonEditeurDonjon.afficheEnContexte(affichePanneauEditeLaCase());
		if(sonTabObjet.size()==0)
			sonEditeurDonjon.afficheLaCarte();
	}
	public void voirObjet(ActionEvent lEvt){
		int lIndex = Integer.parseInt(((JLabel)((JButton)lEvt.getSource()).getParent().getComponent(0)).getText().split(":")[0]);//permet de récupérer le bon objet
		sonTabObjet.elementAt(lIndex - 1).consulteToi(sonEditeurDonjon);
	}

	public void editeObjet(ActionEvent lEvt){
		String[] leChoix = { "Editer", " Supprimer", " Annuler" };
		int lIndex = Integer.parseInt(((JLabel)((JButton)lEvt.getSource()).getParent().getComponent(0)).getText().split(":")[0]);//permet de récupérer le bon objet
		int laDecision = JOptionPane.showOptionDialog(null, "Que fait-on?", "Modifier un objet", JOptionPane.YES_NO_CANCEL_OPTION, JOptionPane.QUESTION_MESSAGE, null, leChoix, leChoix[2]);
		if (laDecision == JOptionPane.YES_OPTION){
			sonEditeurDonjon.afficheEnContexte(sonTabObjet.elementAt(lIndex-1).afficheToi());
		}
		if (laDecision == JOptionPane.NO_OPTION){
			sonTabObjet.removeElementAt(lIndex - 1);
			sonEditeurDonjon.afficheEnContexte(affichePanneauEditeLaCase());
		}
		sonEditeurDonjon.afficheLaCarte();
	}

	public void editeJoueur(ActionEvent lEvt){
		String[] leChoix = { "Editer", " Supprimer", " Annuler" };
		int laDecision = JOptionPane.showOptionDialog(null, "Que fait-on?", "Modifier une créature", JOptionPane.YES_NO_CANCEL_OPTION, JOptionPane.QUESTION_MESSAGE, null, leChoix, leChoix[2]);
		if (laDecision == JOptionPane.YES_OPTION) {
			sonEditeurDonjon.afficheEnContexte(sonJoueur.afficheToi());
		}
		if (laDecision == JOptionPane.NO_OPTION) {
			sonJoueur = null;
			sonEditeurDonjon.afficheEnContexte(affichePanneauEditeLaCase());
		}
		sonEditeurDonjon.afficheLaCarte();
	}

	public void editeNonJoueur(ActionEvent lEvt){
		String[] leChoix = { "Editer", " Supprimer", " Annuler" };
		int laDecision = JOptionPane.showOptionDialog(null, "Que fait-on?", "Modifier une créature", JOptionPane.YES_NO_CANCEL_OPTION, JOptionPane.QUESTION_MESSAGE, null, leChoix, leChoix[2]);
		if (laDecision == JOptionPane.YES_OPTION) {
			sonEditeurDonjon.afficheEnContexte(sonNonJoueur.afficheToi());
		}
		if (laDecision == JOptionPane.NO_OPTION) {
			sonNonJoueur = null;
			sonEditeurDonjon.afficheEnContexte(affichePanneauEditeLaCase());
		}
		sonEditeurDonjon.afficheLaCarte();
	}

	public void ajouteCreature(ActionEvent lEvt){
		if (sonType.getsonFranchissement() == 0)
			JOptionPane.showMessageDialog(null, "Cet endroit est infranchissable, vous ne pouvez donc pas ajouter de personnage.", "Action impossible", JOptionPane.WARNING_MESSAGE);
		else{
			String[] leChoix = { "Un joueur", " Un PNJ", " Annuler" };
			int laDecision = JOptionPane.showOptionDialog(null, "Que doit-on ajouter?", "ajouter une créature", JOptionPane.YES_NO_CANCEL_OPTION, JOptionPane.QUESTION_MESSAGE, null, leChoix, leChoix[2]);
			if (laDecision == JOptionPane.YES_OPTION){
				sonJoueur = new UnJoueur(sonEditeurDonjon);
				sonJoueur.setsaPosX(sonX);
				sonJoueur.setsaPosY(sonY);
				sonEditeurDonjon.afficheEnContexte(sonJoueur.afficheToi());
			}
			if (laDecision == JOptionPane.NO_OPTION){
				sonNonJoueur = new UnNonJoueur(sonEditeurDonjon);
				sonNonJoueur.setsaPosX(sonX);
				sonNonJoueur.setsaPosY(sonY);
				sonEditeurDonjon.afficheEnContexte(sonNonJoueur.afficheToi());
			}
			sonEditeurDonjon.afficheLaCarte();
		}
	}

	public void changeTerrain(ActionEvent lEvt) {
		UnType leType = new UnType((String)((JComboBox)lEvt.getSource()).getSelectedItem());
		if ((leType.getsonFranchissement() == 0) && (sonJoueur != null || sonNonJoueur != null))
			JOptionPane.showMessageDialog(null, "Cet endroit possède un personnage, vous ne pouvez pas le rendre infranchissable.", "Action impossible", JOptionPane.WARNING_MESSAGE);
		else {
			sonType = leType;
			sonEditeurDonjon.afficheLaCarte();
		}
	}


	JPanel affichePanneauEditeLaCase() {
		JPanel lePanneau = new JPanel(new GridLayout(0,1));
		JPanel lePanneauInter = new JPanel();
		JLabel leLabel = new JLabel("Propriétés de la case("+sonX+","+sonY+")");
		lePanneauInter.add(leLabel);
		lePanneau.add(lePanneauInter);
		if (sonEditeurDonjon.getsonMode() == UnEditeurDonjon.EDITER){
			lePanneauInter = new JPanel();
			leLabel = new JLabel("Son type de terrain est : ");
			JComboBox sonCombo = new JComboBox(UnType.donneTesTypes());
			sonCombo.setSelectedItem(sonType.getsonNom());
			sonCombo.addActionListener(new ActionListener()
			{
				public void actionPerformed(java.awt.event.ActionEvent lEvt)
				{
					changeTerrain(lEvt);
				}
			});
			leLabel.setLabelFor(sonCombo);
			lePanneauInter.add(leLabel);
			lePanneauInter.add(sonCombo);
			lePanneau.add(lePanneauInter);
		}

		lePanneauInter = new JPanel();
		JTextArea leChampDesc;
		if ((sonType.getsonFranchissement() != 1) && (saDescription == null))
		{
			leChampDesc = new JTextArea("Description facultative.", 7, 22);
			leChampDesc.selectAll();
		}
		else if ((sonType.getsonFranchissement() == 1) && (saDescription == null))
		{
			leChampDesc = new JTextArea(sonType.getsonPourquoi(), 7, 22);
		}
		else
		{
			leChampDesc = new JTextArea(saDescription, 7, 22);
		}
		leChampDesc.setLineWrap(true);
		leChampDesc.setWrapStyleWord(true);
		leChampDesc.addKeyListener(new KeyListener(){
			public void keyTyped(KeyEvent lEvt){}
			public void keyReleased(KeyEvent lEvt){
				saDescription = ((JTextArea)lEvt.getSource()).getText();
				if (saDescription.equals(""))
					saDescription = null;
			}
			public void keyPressed(KeyEvent lEvt){}
		});
		lePanneauInter.add(new JScrollPane(leChampDesc));
		lePanneau.add(lePanneauInter);

		if (sonJoueur != null){
			lePanneauInter = new JPanel();
			leLabel = new JLabel("Un joueur nommé : " + sonJoueur.getsonNom());
			lePanneauInter.add(leLabel);
			if (sonEditeurDonjon.getsonMode() == UnEditeurDonjon.EDITER){
                                JButton leBouton = new JButton("Deplacer");
				leBouton.addActionListener(new ActionListener()
				{
					public void actionPerformed(java.awt.event.ActionEvent lEvt)
					{
						deplaceJoueur(lEvt);
					}
				});
				lePanneauInter.add(leBouton);
				leBouton = new JButton("Modifier");
				leBouton.addActionListener(new ActionListener()
				{
					public void actionPerformed(java.awt.event.ActionEvent lEvt)
					{
						editeJoueur(lEvt);
					}
				});
				lePanneauInter.add(leBouton);
				lePanneau.add(lePanneauInter);
			}
			else {
				JButton leBouton = new JButton("Deplacer");
				leBouton.addActionListener(new ActionListener()
				{
					public void actionPerformed(java.awt.event.ActionEvent lEvt)
					{
						deplaceJoueur(lEvt);
					}
				});
				lePanneauInter.add(leBouton);
				leBouton = new JButton("Voir");
				leBouton.addActionListener(new ActionListener(){
					public void actionPerformed(java.awt.event.ActionEvent lEvt){
						voirJoueur(lEvt);
					}
				});
				lePanneauInter.add(leBouton);
				lePanneau.add(lePanneauInter);
			}
		}else if (sonNonJoueur != null){
			lePanneauInter = new JPanel();
			leLabel = new JLabel("Un pnj nommé : " + sonNonJoueur.getsonNom());
			lePanneauInter.add(leLabel);
			if (sonEditeurDonjon.getsonMode() == UnEditeurDonjon.EDITER){
                                JButton leBouton = new JButton("Deplacer");
				leBouton.addActionListener(new ActionListener()
				{
					public void actionPerformed(java.awt.event.ActionEvent lEvt)
					{
						deplaceJoueur(lEvt);
					}
				});
				lePanneauInter.add(leBouton);
				leBouton = new JButton("Modifier");
				leBouton.addActionListener(new ActionListener()
				{
					public void actionPerformed(java.awt.event.ActionEvent lEvt)
					{
						editeNonJoueur(lEvt);
					}
				}); ;
				lePanneauInter.add(leBouton);
				lePanneau.add(lePanneauInter);
			}else {
				JButton leBouton = new JButton("Deplacer");
				leBouton.addActionListener(new ActionListener()
				{
					public void actionPerformed(java.awt.event.ActionEvent lEvt)
					{
						deplaceJoueur(lEvt);
					}
				});
				lePanneauInter.add(leBouton);
				leBouton = new JButton("Voir");
				leBouton.addActionListener(new ActionListener(){
					public void actionPerformed(java.awt.event.ActionEvent lEvt){
						voirJoueur(lEvt);
					}
				});
				lePanneauInter.add(leBouton);
				lePanneau.add(lePanneauInter);
			}
		}
		else if (sonEditeurDonjon.getsonMode() == UnEditeurDonjon.EDITER){
			lePanneauInter = new JPanel();
			leLabel = new JLabel("Pas de créature");
			lePanneauInter.add(leLabel);
			JButton leBouton = new JButton("Ajouter Créature");
			leBouton.addActionListener(new ActionListener() {
            	public void actionPerformed(java.awt.event.ActionEvent lEvt) {
                	ajouteCreature(lEvt);
            }});
			lePanneauInter.add(leBouton);
			lePanneau.add(lePanneauInter);
		}
		if (sonEditeurDonjon.getsonMode() == UnEditeurDonjon.EDITER){
			if (sonEvenement != null){
				lePanneauInter = new JPanel();
				leLabel = new JLabel(sonEvenement.sonNom);
				lePanneauInter.add(leLabel);
				JButton leBouton = new JButton("Modifier");
				leBouton.addActionListener(new ActionListener()
				{
					public void actionPerformed(java.awt.event.ActionEvent lEvt)
					{
						editeEvenement(lEvt);
					}
				});
				lePanneauInter.add(leBouton);
				lePanneau.add(lePanneauInter);
			}else{
				lePanneauInter = new JPanel();
				leLabel = new JLabel("Pas d'événement");
				lePanneauInter.add(leLabel);
				JButton leBouton = new JButton("Ajouter Evénement");
				leBouton.addActionListener(new ActionListener(){
					public void actionPerformed(java.awt.event.ActionEvent lEvt){
						ajouteEvenement(lEvt);
					}
				});
				lePanneauInter.add(leBouton);
				lePanneau.add(lePanneauInter);
			}
		}
		lePanneauInter = new JPanel(new GridLayout(0,1));
		for (int i = 0; i < sonTabObjet.size(); i++) {
			if(i==0){
				leLabel = new JLabel("Contient les objet :");
				lePanneauInter.add(leLabel);
			}
			JPanel lePanneauInter2 = new JPanel();
			leLabel = new JLabel((i+1)+": " + ((UnObjet)sonTabObjet.get(i)).getsonNom());
			lePanneauInter2.add(leLabel);
			if (sonEditeurDonjon.getsonMode() == UnEditeurDonjon.EDITER){
				JButton leBouton = new JButton("Modifier");
				leBouton.addActionListener(new ActionListener(){
					public void actionPerformed(java.awt.event.ActionEvent lEvt){
						editeObjet(lEvt);
					}
				});
				lePanneauInter2.add(leBouton);
				lePanneauInter.add(lePanneauInter2);
			}
			else if (getsaCreature() != null){
				JButton leBouton = new JButton("Ramasser");
				leBouton.addActionListener(new ActionListener(){
					public void actionPerformed(java.awt.event.ActionEvent lEvt){
						ramasserObjet(lEvt);
					}
				});
				lePanneauInter2.add(leBouton);
				leBouton = new JButton("Voir");
				leBouton.addActionListener(new ActionListener(){
					public void actionPerformed(java.awt.event.ActionEvent lEvt){
						voirObjet(lEvt);
					}
				});
				lePanneauInter2.add(leBouton);
				lePanneauInter.add(lePanneauInter2);
			}
			else {
				JButton leBouton = new JButton("Voir");
				leBouton.addActionListener(new ActionListener(){
					public void actionPerformed(java.awt.event.ActionEvent lEvt){
						voirObjet(lEvt);
					}
				});
				lePanneauInter2.add(leBouton);
				lePanneauInter.add(lePanneauInter2);
			}
		}
		if (sonTabObjet.size() == 0 ) {
			JPanel lePanneauInter2 = new JPanel();
			String laChaine = "Pas d'objet";
			if (sonEditeurDonjon.getsonMode() == UnEditeurDonjon.EDITER)
				laChaine += ", vous pouvez ajouter des :";
			leLabel = new JLabel(laChaine);
			lePanneauInter2.add(leLabel);
			lePanneauInter.add(lePanneauInter2);
		}
		lePanneau.add(lePanneauInter);
		if (sonEditeurDonjon.getsonMode() == UnEditeurDonjon.EDITER)
		{
			lePanneauInter = new JPanel();
			JButton leBouton = new JButton("Arme");
			leBouton.setMargin(new Insets(0, 0, 0, 0));
			leBouton.addActionListener(new ActionListener()
			{
				public void actionPerformed(java.awt.event.ActionEvent lEvt)
				{
					String[] leChoix = { "Arme existante", " Nouvelle arme", " Annuler" };
					int laDecision = JOptionPane.showOptionDialog(null, "Que doit-on ajouter?", "ajouter une arme", JOptionPane.YES_NO_CANCEL_OPTION, JOptionPane.QUESTION_MESSAGE, null, leChoix, leChoix[2]);
					if (laDecision == JOptionPane.YES_OPTION)
					{
                                                String choix = JOptionPane.showInputDialog(null, "Nom de l'arme?", "ajouter une arme existante", JOptionPane.QUESTION_MESSAGE);
						if(choix!=null){
                                                    try{
                                                        UneArme lArme = new UneArme(choix);
                                                        sonTabObjet.add(lArme);
                                                        sonEditeurDonjon.afficheEnContexte(affichePanneauEditeLaCase());
                                                    }catch(Exception lException){JOptionPane.showMessageDialog(null,"Ceci n'est pas une arme","Erreur de saisie",JOptionPane.ERROR_MESSAGE);}
                                                }
                                                
					}
					if (laDecision == JOptionPane.NO_OPTION)
					{
						sonTabObjet.add(new UneArme());
						sonEditeurDonjon.afficheEnContexte((sonTabObjet.get(sonTabObjet.size() - 1)).afficheToi());
					}
					sonEditeurDonjon.afficheLaCarte();
				}
			});
			lePanneauInter.add(leBouton);
			leBouton = new JButton("Armure");
			leBouton.setMargin(new Insets(1, 1, 1, 1));
			leBouton.addActionListener(new ActionListener()
			{
				public void actionPerformed(java.awt.event.ActionEvent lEvt)
				{
					String[] leChoix = { "Armure existante", " Nouvelle armure", " Annuler" };
					int laDecision = JOptionPane.showOptionDialog(null, "Que doit-on ajouter?", "ajouter une armure", JOptionPane.YES_NO_CANCEL_OPTION, JOptionPane.QUESTION_MESSAGE, null, leChoix, leChoix[2]);
					if (laDecision == JOptionPane.YES_OPTION)
					{
                                            String choix = JOptionPane.showInputDialog(null, "Nom de l'armure?", "ajouter une armure existante", JOptionPane.QUESTION_MESSAGE);
                                            if(choix!=null){
                                                try{
                                                    UneArmure lArmure = new UneArmure(choix);
                                                    sonTabObjet.add(lArmure);
                                                    sonEditeurDonjon.afficheEnContexte(affichePanneauEditeLaCase());
                                                }catch(Exception lException){JOptionPane.showMessageDialog(null,"Ceci n'est pas une armure","Erreur de saisie",JOptionPane.ERROR_MESSAGE);}
                                            }
					}
					if (laDecision == JOptionPane.NO_OPTION)
					{
						sonTabObjet.add(new UneArmure());
						sonEditeurDonjon.afficheEnContexte((sonTabObjet.get(sonTabObjet.size() - 1)).afficheToi());
					}
					sonEditeurDonjon.afficheLaCarte();
				}
			});
			lePanneauInter.add(leBouton);
			leBouton = new JButton("Conso");
			leBouton.setMargin(new Insets(1, 1, 1, 1));
			leBouton.addActionListener(new ActionListener()
			{
				public void actionPerformed(java.awt.event.ActionEvent lEvt)
				{
					String[] leChoix = { "Consommable existant", " Nouveau consommable", " Annuler" };
					int laDecision = JOptionPane.showOptionDialog(null, "Que doit-on ajouter?", "ajouter un consommable", JOptionPane.YES_NO_CANCEL_OPTION, JOptionPane.QUESTION_MESSAGE, null, leChoix, leChoix[2]);
					if (laDecision == JOptionPane.YES_OPTION)
					{
                                            String choix = JOptionPane.showInputDialog(null, "Nom du consommable?", "ajouter un consommable existant", JOptionPane.QUESTION_MESSAGE);
                                            if(choix!=null){
                                                try{
                                                    UnConsommable leConso = new UnConsommable(choix);
                                                    sonTabObjet.add(leConso);
                                                    sonEditeurDonjon.afficheEnContexte(affichePanneauEditeLaCase());
                                                }catch(Exception lException){JOptionPane.showMessageDialog(null,"Ceci n'est pas un consommable","Erreur de saisie",JOptionPane.ERROR_MESSAGE);}
                                            }
					}
					if (laDecision == JOptionPane.NO_OPTION)
					{
						sonTabObjet.add(new UnConsommable());
						sonEditeurDonjon.afficheEnContexte((sonTabObjet.get(sonTabObjet.size() - 1)).afficheToi());
					}
					sonEditeurDonjon.afficheLaCarte();
				}
			});
			lePanneauInter.add(leBouton);
			leBouton = new JButton("Autre");
			leBouton.setMargin(new Insets(1, 1, 1, 1));
			leBouton.addActionListener(new ActionListener()
			{
				public void actionPerformed(java.awt.event.ActionEvent lEvt)
				{
					String[] leChoix = { "Objet existant", " Nouvel objet", " Annuler" };
					int laDecision = JOptionPane.showOptionDialog(null, "Que doit-on ajouter?", "ajouter un objet", JOptionPane.YES_NO_CANCEL_OPTION, JOptionPane.QUESTION_MESSAGE, null, leChoix, leChoix[2]);
					if (laDecision == JOptionPane.YES_OPTION)
					{
						UnObjet lObjet = new UnObjet(JOptionPane.showInputDialog(null, "Nom de l'objet?", "ajouter un objet existant", JOptionPane.QUESTION_MESSAGE));
						sonTabObjet.add(lObjet);
						sonEditeurDonjon.afficheEnContexte(affichePanneauEditeLaCase());
					}
					if (laDecision == JOptionPane.NO_OPTION)
					{
						sonTabObjet.add(new UnObjet());
						sonEditeurDonjon.afficheEnContexte((sonTabObjet.get(sonTabObjet.size() - 1)).afficheToi());
					}
					sonEditeurDonjon.afficheLaCarte();
				}
			});
			lePanneauInter.add(leBouton);
			lePanneau.add(lePanneauInter);
		}
		return lePanneau;
	}
}
