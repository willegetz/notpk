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

public class UnPiege extends UnEvenement {

	int saZoneX;
	int saZoneY;
	UnDegat sonDegat;
	String saDesc;
	UneCreature sonPerso;
	int saResistance;


	UnPiege(UneCase telleCase){
		saCase = telleCase;
		saDesc = "Description du piege de la case (" + saCase.getsonX() + "," + saCase.getsonY() + ")";
		sonDegat = new UnDegat();
	}

	UnPiege(UneCase telleCase, String telNom, int telleRepetition, int telleZoneX, int telleZoneY,String telleDesc, int telleResistance, UnDegat telDegat) {
		super(telleCase,telNom,telleRepetition);
		saZoneX = telleZoneX;
		saZoneY = telleZoneY;
		sonDegat = telDegat;
		saDesc = telleDesc;
		saResistance = telleResistance;
	}

	public JPanel editeToi(){
		JPanel lePanneau = new JPanel(new GridLayout(0, 1));

		JPanel lePanneauInter = new JPanel();
		JTextArea leChampTexte = new JTextArea(saDesc, 9, 26);
		leChampTexte.setLineWrap(true);
		leChampTexte.setWrapStyleWord(true);
		lePanneauInter.add(new JScrollPane(leChampTexte));
		lePanneau.add(lePanneauInter);

		JPanel lePanneauChamps = new JPanel(new GridLayout(0, 1));
		creerRadio(lePanneauChamps);
		lePanneauInter = new JPanel();
		JLabel leLabel = new JLabel("Taille horizontale (autour de la case)");
		JTextField leChamp = new JTextField(Integer.toString(saZoneX),2);
		lePanneauInter.add(leLabel);
		lePanneauInter.add(leChamp);
		lePanneauChamps.add(lePanneauInter);
		lePanneauInter = new JPanel();
		leLabel = new JLabel("Taille verticale(autour de la case)");
		leChamp = new JTextField(Integer.toString(saZoneY), 2);
		lePanneauInter.add(leLabel);
		lePanneauInter.add(leChamp);
		lePanneauChamps.add(lePanneauInter);
		lePanneauInter = new JPanel();
		leLabel = new JLabel("Type de dégat");
		leChamp = new JTextField(sonDegat.getsonType(), 10);
		lePanneauInter.add(leLabel);
		lePanneauInter.add(leChamp);
		lePanneauChamps.add(lePanneauInter);
		lePanneauInter = new JPanel();
		leLabel = new JLabel("Dé de dégât (ex : 1d12)");
		leChamp = new JTextField(sonDegat.getsonDeDegat(), 3);
		lePanneauInter.add(leLabel);
		lePanneauInter.add(leChamp);
		lePanneauChamps.add(lePanneauInter);
		lePanneauInter = new JPanel();
		leLabel = new JLabel("Résistance nécessaire");
		leChamp = new JTextField(Integer.toString(saResistance), 2);
		lePanneauInter.add(leLabel);
		lePanneauInter.add(leChamp);
		lePanneauChamps.add(lePanneauInter);
		lePanneau.add(lePanneauChamps);

		lePanneauInter = new JPanel();
		JButton leBouton = new JButton("Valider");
		leBouton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent telleAction) {
				//pour chaque variable on cherche son champ (on remonte la hiérarchie des panneaux, puis on redescend jusqu'au bon champ)
				try{
					saDesc = ((JTextArea)((JViewport)((JScrollPane)((JPanel)((JPanel)((JButton)telleAction.getSource()).getParent().getParent()).getComponent(0)).getComponent(0)).getComponent(0)).getComponent(0)).getText();
					saZoneX = Integer.parseInt(((JTextField)((JPanel)((JPanel)((JPanel)((JButton)telleAction.getSource()).getParent().getParent()).getComponent(1)).getComponent(1)).getComponent(1)).getText());
					saZoneY = Integer.parseInt(((JTextField)((JPanel)((JPanel)((JPanel)((JButton)telleAction.getSource()).getParent().getParent()).getComponent(1)).getComponent(2)).getComponent(1)).getText());
					sonDegat.setsonType((((JTextField)((JPanel)((JPanel)((JPanel)((JButton)telleAction.getSource()).getParent().getParent()).getComponent(1)).getComponent(3)).getComponent(1)).getText()));
					saResistance = Integer.parseInt(((JTextField)((JPanel)((JPanel)((JPanel)((JButton)telleAction.getSource()).getParent().getParent()).getComponent(1)).getComponent(5)).getComponent(1)).getText());
					sonDegat.setsonDeDegat((((JTextField)((JPanel)((JPanel)((JPanel)((JButton)telleAction.getSource()).getParent().getParent()).getComponent(1)).getComponent(4)).getComponent(1)).getText()));
					sonNom = "Piege de zone " + saZoneX + "x" + saZoneY;
					if (sonDegat.getsonDeDegat().split("[dD]").length !=2){
						JOptionPane.showMessageDialog(null, "Erreur : vous n'avez pas respecté le format pour les dés de dégats.", "Erreur : mauvaise saisie!", JOptionPane.ERROR_MESSAGE);
					}else {
						JOptionPane.showMessageDialog(null, "changements validés!");
					}
				}catch (Exception lException) { JOptionPane.showMessageDialog(null, "Erreur : mauvais remplissage des champs numériques","Erreur : mauvaise saisie!", JOptionPane.ERROR_MESSAGE); }
			}
		});
		lePanneauInter.add(leBouton);
		lePanneau.add(lePanneauInter);

		return lePanneau;
	}

	public String toString(){
		String[] leTab = saDesc.split("\n");
		String leTexte = leTab[0];
		for (int i = 1; i < leTab.length; i++){
			leTexte += "\t" + leTab[i];
		}
		return super.toString() + "piege:" + saZoneX + ":" + saZoneY + ":" + saResistance + ":" + sonDegat.toString() + ":" + leTexte;
	}

	public  boolean doitSeDeclencher(){
            if (((saCase.sonEditeurDonjon.getsaCarte().getsesCases()[saCase.getsonY()][saCase.getsonX()].getsonJoueur() != null) || (saCase.sonEditeurDonjon.getsaCarte().getsesCases()[saCase.getsonY()][saCase.getsonX()].getsonNonJoueur() != null) )&& (saRepetition == REPETABLE || saRepetition == UNIQUE)){
			sonPerso = saCase.sonEditeurDonjon.getsaCarte().getsesCases()[saCase.getsonY()][saCase.getsonX()].getsaCreature();
			return true;
            }
            return false;
	}

	public void declencheToi(){ 
		if(saRepetition == UNIQUE)
			saRepetition = UNIQUE_FAIT;
		JDialog leDialogue = new JDialog((JFrame)saCase.sonEditeurDonjon,"Evenement : piege!",false);
		JPanel lePanneau = new JPanel();
		JTextArea leChampTexte = new JTextArea(saDesc, 4, 24);
		leChampTexte.setLineWrap(true);
		leChampTexte.setWrapStyleWord(true);
		leChampTexte.addKeyListener(new KeyListener()
		{
			public void keyTyped(KeyEvent lEvt) { }
			public void keyReleased(KeyEvent lEvt)
			{
				saDesc = ((JTextArea)lEvt.getSource()).getText();
				if (saDesc.equals(""))
					saDesc = null;
			}
			public void keyPressed(KeyEvent lEvt) { }
		});
		lePanneau.add(new JScrollPane(leChampTexte));

		JLabel leLabel = new JLabel("<html><u><font color=blue>" + sonPerso.getsonNom() + "</font></u> déclenche le piege.</html>");
		leLabel.addMouseListener(new MouseListener(){
			public void mouseClicked(MouseEvent e){
				saCase.sonEditeurDonjon.afficheEnContexte(sonPerso.afficheToi());
			}
			public void mouseEntered(MouseEvent e) { }
			public void mouseExited(MouseEvent e) { }
			public void mousePressed(MouseEvent e) { }
			public void mouseReleased(MouseEvent e) { }
		});
		lePanneau.add(leLabel);
		leLabel = new JLabel("Il faut faire un jet de résistance supérieur à " + saResistance + " pour ne rien subir.");
		lePanneau.add(leLabel);

		if (saZoneX == 0 && saZoneY == 0) {
			//si le piege ne concerne qu'un perso, on ne s'occupe que de lui
			leLabel = new JLabel("Résiste-t-il?");
			lePanneau.add(leLabel);
			JButton leBouton = new JButton("oui");
			leBouton.addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent lEvt) {
					((JDialog)((JButton)lEvt.getSource()).getParent().getParent().getParent().getParent().getParent()).dispose();
				}
			});
			lePanneau.add(leBouton);
			leBouton = new JButton("non");
			leBouton.addActionListener(new ActionListener(){
				public void actionPerformed(ActionEvent lEvt){
					((JDialog)((JButton)lEvt.getSource()).getParent().getParent().getParent().getParent().getParent()).dispose();
					int[] leTab = UnEditeurDonjon.lanceLesDes(sonDegat.getsonDeDegat());
					String laChaine = "Résultat :\n";
					int leTotalDegat = 0;
					for (int i = 0; i < leTab.length; i++) {
						laChaine += "Dé " + (i + 1) + " : " + leTab[i]+"\n";
						leTotalDegat += leTab[i];
					}
					sonPerso.DOWNsesPvC(leTotalDegat);
					laChaine += "Le personnage a subit un total de " + leTotalDegat + " point de dégat "+sonDegat.getsonType()+".\nSa vie courante est à " + sonPerso.getsesPvC();
					JOptionPane.showMessageDialog(null,laChaine,"Aïe ça a du faire mal!",JOptionPane.INFORMATION_MESSAGE);
				}
			});
			leDialogue.setSize(320, 180);
			lePanneau.add(leBouton);
		} else {
			JPanel lePanneauBouton = new JPanel(new GridLayout(0,1));
			int nbPanel = 0;
			for (int x = -saZoneX; x <= saZoneX; x++) {
				for (int y = -saZoneY; y <= saZoneY; y++) {
					if (((saCase.sonEditeurDonjon.getsaCarte().getsesCases()[saCase.getsonY() + y][saCase.getsonX() + x].getsonJoueur() != null) || (saCase.sonEditeurDonjon.getsaCarte().getsesCases()[saCase.getsonY() + y][saCase.getsonX() + x].getsonNonJoueur() != null))){
						UneCreature lePerso = saCase.sonEditeurDonjon.getsaCarte().getsesCases()[saCase.getsonY() + y][saCase.getsonX() + x].getsaCreature();
						//si on a une créature prise dans le piege
						JPanel lePanneauInter = new JPanel();
						leLabel = new JLabel(lePerso.getsonNom() + " tombe dans le piege ( "+(saCase.getsonX() + x) +","+( saCase.getsonY() + y)+" ). Il résiste?");
						JCheckBox laBox = new JCheckBox("(cocher = oui)",false);
						lePanneauInter.add(leLabel);
						lePanneauInter.add(laBox);
						lePanneauBouton.add(lePanneauInter);
						nbPanel++;
					}
				}
			}
			JPanel lePanneauInter = new JPanel();
			JButton leBouton = new JButton("Valider");
			leBouton.setName(Integer.toString(nbPanel));//on stocke le nombre de panneau en guise de nom de bouton pour l'evenement
			leBouton.addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent lEvt) {
					((JDialog)((JButton)lEvt.getSource()).getParent().getParent().getParent().getParent().getParent().getParent().getParent()).dispose();
					int nbPanel = Integer.parseInt(((JButton)lEvt.getSource()).getName());//récupération du nombre de panneau
					for (int i = 0; i < nbPanel; i++) {
						if (!((JCheckBox)((JPanel)((JPanel)((JButton)lEvt.getSource()).getParent().getParent()).getComponent(i)).getComponent(1)).isSelected()){
							int leX = Integer.parseInt(((JLabel)((JPanel)((JPanel)((JButton)lEvt.getSource()).getParent().getParent()).getComponent(i)).getComponent(0)).getText().split(",")[0].split(" ")[6]);//on coupe le label correspondant à la créature pour trouver la coordonnée x
							int leY = Integer.parseInt(((JLabel)((JPanel)((JPanel)((JButton)lEvt.getSource()).getParent().getParent()).getComponent(i)).getComponent(0)).getText().split(",")[1].split(" ")[0]);//on coupe le label correspondant à la créature pour trouver la coordonnée y
							sonPerso = saCase.sonEditeurDonjon.getsaCarte().getsesCases()[leY][leX].getsaCreature();
							int[] leTab = UnEditeurDonjon.lanceLesDes(sonDegat.getsonDeDegat());
							String laChaine = "Résultat :\n";
							int leTotalDegat = 0;
							for (int j = 0; j < leTab.length; j++){
								laChaine += "Dé " + (j + 1) + " : " + leTab[j] + "\n";
								leTotalDegat += leTab[j];
							}
							sonPerso.DOWNsesPvC(leTotalDegat);
							laChaine += sonPerso.getsonNom()+" a subit un total de " + leTotalDegat + " point de dégat " + sonDegat.getsonType() + ".\nSa vie courante est à " + sonPerso.getsesPvC();
							JOptionPane.showMessageDialog(null, laChaine, "Aïe ça a du faire mal!", JOptionPane.INFORMATION_MESSAGE);
						}
					}
				}
			});
			lePanneauInter.add(leBouton);
			lePanneauBouton.add(lePanneauInter);
			lePanneau.add(lePanneauBouton);
			leDialogue.setSize(320, 210 + (nbPanel * 40));
		}

		leDialogue.add(lePanneau);
		
		leDialogue.setVisible(true);
	}
}
