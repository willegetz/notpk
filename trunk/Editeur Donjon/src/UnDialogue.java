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
 * classe permettant de définir une phrase dite à la rencontre d'un personnage
 */
public class UnDialogue extends UnEvenement {

	String sonTexte = "Texte que devra dire le personnage.";
	UnJoueur sonPerso;

	UnDialogue(UneCase telleCase){
		saCase = telleCase;
		sonNom = "Dialogue avec "+saCase.getsonNonJoueur().getsonNom();
	}

	UnDialogue(UneCase telleCase, String telNom, int telleRepetition, String telTexte) {
		super(telleCase,telNom,telleRepetition);
		sonTexte = telTexte;
	}

    /**
     * permet de modifier les paramètres
     * @return panneau d'édition
     */
	public JPanel editeToi(){
		JPanel lePanneau = new JPanel(new GridLayout(0, 1));
		creerRadio(lePanneau);

		JTextArea leChampTexte = new JTextArea(sonTexte, 9, 26);
		leChampTexte.setLineWrap(true);
		leChampTexte.setWrapStyleWord(true);
		lePanneau.add(new JScrollPane(leChampTexte));

		JPanel lePanneauInter = new JPanel();
		JButton leBouton = new JButton("Valider");
		leBouton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent telleAction) {
				sonTexte = ((JTextArea)((JViewport)((JScrollPane)((JPanel)((JButton)telleAction.getSource()).getParent().getParent()).getComponent(1)).getComponent(0)).getComponent(0)).getText();
				JOptionPane.showMessageDialog(null, "Changement effectué!");
			}
		});
		lePanneauInter.add(leBouton);
		lePanneau.add(lePanneauInter);

		return lePanneau;
	}

	public String toString() {
		String []leTab = sonTexte.split("\n");
		String leTexte=leTab[0];
		for (int i=1;i<leTab.length;i++){
			leTexte+="\t"+leTab[i];
		}

		return super.toString()+"dialogue:"+leTexte; 
	}

    /**
     * indique si les condition requise pour déclencher le dialogue sont réunies
     * @return vrai si l'événement doit se déclencher, faux sinon
     */
	public  boolean doitSeDeclencher(){
		for (int x = -1; x <= 1; x++) {
			for (int y = -1; y <= 1; y++) {
				try{
					if ((saCase.sonEditeurDonjon.getsaCarte().getsesCases()[saCase.getsonY() + y][saCase.getsonX() + x].getsonJoueur() != null)&&(saRepetition==REPETABLE || saRepetition==UNIQUE)){
						sonPerso = saCase.sonEditeurDonjon.getsaCarte().getsesCases()[saCase.getsonY() + y][saCase.getsonX() + x].getsonJoueur();
						return true;
					}
				}catch (Exception lException) {/*on évite l'erreur et on continue*/ }
			}
		}
		return false;
	}

    /**
     * déroulement du dialoque
     */
	public void declencheToi() {
		if(saRepetition == UNIQUE)
			saRepetition = UNIQUE_FAIT;
		JDialog leDialogue = new JDialog((JFrame)saCase.sonEditeurDonjon,"Evenement : dialogue!",false);
		JPanel lePanneau = new JPanel();
		JLabel leLabel = new JLabel("<html><u><font color=blue>"+saCase.getsonNonJoueur().getsonNom()+"</font></u></html>");
		leLabel.addMouseListener(new MouseListener() {
			public void mouseClicked(MouseEvent e){
				saCase.sonEditeurDonjon.afficheEnContexte(saCase.getsonNonJoueur().afficheToi());
			}
			public void mouseEntered(MouseEvent e) { }
			public void mouseExited(MouseEvent e) { }
			public void mousePressed(MouseEvent e) { }
			public void mouseReleased(MouseEvent e) {}
		});
		lePanneau.add(leLabel);

		leLabel = new JLabel(" s'adresse à ");
		lePanneau.add(leLabel);

		leLabel = new JLabel("<html><u><font color=blue>" + sonPerso.getsonNom() + "</font></u></html>");
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

		JTextArea leChampTexte = new JTextArea(sonTexte, 9, 24);
		leChampTexte.setLineWrap(true);
		leChampTexte.setWrapStyleWord(true);
		leChampTexte.addKeyListener(new KeyListener(){
			public void keyTyped(KeyEvent lEvt){}
			public void keyReleased(KeyEvent lEvt){
				sonTexte = ((JTextArea)lEvt.getSource()).getText();
				if (sonTexte.equals(""))
					sonTexte = null;
			}
			public void keyPressed(KeyEvent lEvt){}
		});
		lePanneau.add(new JScrollPane(leChampTexte));
		leDialogue.add(lePanneau);
		leDialogue.setSize(300, 250);
		leDialogue.setVisible(true);
	}
}
