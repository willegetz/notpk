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
import java.util.Vector;

/**
 * inventaire d'un personnage
 */
public class UnInventaire extends JPanel implements ActionListener{
	
	private JList saListe;
	private JButton sonValid;
	private JButton sonAjout;
	private JButton saSupp;
	private JButton sonEquipe;
	private JButton sonDesequipe;
        private JButton sonUtilise;
	private JLabel sonLabelListe;
	private JScrollPane sonListScroll;
	private Vector<UnObjet> sonVecteur;
	private UneArme sonArmeEquipe;
	private UneArmure sonArmureEquipe;
	private UneCreature saCreature;

	
	UnInventaire(UneCreature telleCreature){
		super(new BorderLayout());
		saCreature = telleCreature;
		sonArmeEquipe = null;
		sonArmureEquipe = null;
		sonVecteur = new Vector<UnObjet>();
	}
	
	public JDialog afficheToi(){

		this.removeAll();
		JDialog laFenetre = new JDialog (saCreature.sonEditeur,true);
		laFenetre.setTitle("Un inventaire");
		laFenetre.setSize(450, 550);
		laFenetre.setLocation(200,150);
		
		JPanel lePannBouton=new JPanel(new GridLayout(0,1));
		JPanel lePannList=new JPanel(new GridLayout(0,1));
		JPanel lePannBoutonBis=new JPanel();
		JPanel lePannListBis=new JPanel();
		
		saListe=new JList();
		sonListScroll=new JScrollPane(saListe);
		
		String laChaine = saCreature.getsonNom();
		if (sonArmureEquipe != null && sonArmeEquipe != null){
			laChaine += " porte un(e) " + sonArmureEquipe.getsonNom() + " et tiens un(e) " + sonArmeEquipe.getsonNom() + " à la main.";
		}
		else if (sonArmureEquipe != null){
			laChaine += " porte un(e) " + sonArmureEquipe.getsonNom() + ".";
		}
		else if (sonArmeEquipe != null){
			laChaine += " tiens un(e) " + sonArmeEquipe.getsonNom() + " à la main.";
		}
		else{
			laChaine += " est nu et désarmé.";
		}
		sonLabelListe = new JLabel("<html>Inventaire de " + saCreature.getsonNom() + " :<br>"+laChaine+"</html>");
		
		JButton sonValid= new JButton("Visualiser");
		sonValid.addActionListener(this);
		sonValid.setName("choisir");
		
		JButton sonAjout= new JButton("Ajouter");
		sonAjout.addActionListener(this);
		sonAjout.setName("ajouter");
		
		JButton sonSupp= new JButton("Jeter");
		sonSupp.addActionListener(this);
		sonSupp.setName("supp");

		JButton sonEquipe = new JButton("Equiper");
		sonEquipe.addActionListener(this);
		sonEquipe.setName("equipe");

		JButton sonDesequipe = new JButton("Dénuder");
		sonDesequipe.addActionListener(this);
		sonDesequipe.setName("desequipe");
                
                JButton sonUtilise = new JButton("Consommer");
		sonUtilise.addActionListener(this);
		sonUtilise.setName("utilise");

		//saListe.setListData(sonVecteur);
		Vector<String> leVecteur = new Vector<String>();
			for (int i = 0; i < sonVecteur.size(); i++){
				leVecteur.add(sonVecteur.get(i).getsonNom());
			}
 			saListe.setListData(leVecteur);
		
		
		lePannBouton.add(sonValid);
		lePannBouton.add(sonAjout);
		lePannBouton.add(sonSupp);
                lePannBouton.add(sonUtilise);
		lePannBouton.add(sonEquipe);
		lePannBouton.add(sonDesequipe);
                
		
		lePannList.add(sonLabelListe);
		lePannList.add(saListe);
		
		lePannBoutonBis.add(lePannBouton);
		lePannListBis.add(lePannList);
		
		this.add(lePannBoutonBis,BorderLayout.EAST);
		this.add(lePannListBis,BorderLayout.WEST);
		
		laFenetre.setContentPane(this);
		
		laFenetre.setVisible(true); 
	    return laFenetre;
	}//aficheToi
	
	public void enregistreToi(PrintWriter lEcrivain){
		lEcrivain.println(sonVecteur.size());	
		for (int i=0; i<sonVecteur.size(); i++)
			lEcrivain.println(sonVecteur.get(i).getsonNom()+":"+sonVecteur.get(i).toString());
		if(sonArmeEquipe==null)
			lEcrivain.println("null");
			else
				lEcrivain.println(sonArmeEquipe.getsonNom());
		if (sonArmureEquipe==null)
			lEcrivain.println("null");
			else
				lEcrivain.println(sonArmureEquipe.getsonNom());
	}//enregistreToi
	
	public void chargeToi(BufferedReader leLecteur){
		try{
		int taille = Integer.parseInt(leLecteur.readLine());
		for (int i=0; i<taille; i++){
			String laLigne = leLecteur.readLine();
			if(laLigne.split(":")[1].equals("Arme"))
				sonVecteur.add(new UneArme(laLigne.split(":")[0]));
			if(laLigne.split(":")[1].equals("Armure"))
				sonVecteur.add(new UneArmure(laLigne.split(":")[0]));
			if(laLigne.split(":")[1].equals("Consommable"))
				sonVecteur.add(new UnConsommable(laLigne.split(":")[0]));
			if(laLigne.split(":")[1].equals("Objet"))
				sonVecteur.add(new UnObjet(laLigne.split(":")[0]));
		}//for
		String arme=leLecteur.readLine();
		String armure = leLecteur.readLine();
		if (!arme.equals("null"))
			sonArmeEquipe = new UneArme(arme);
		if (!armure.equals("null"))
			sonArmureEquipe = new UneArmure(armure);
		
		}catch(Exception exception){
			JOptionPane.showMessageDialog(null,"Erreur dans le chargement de l'inventaire ! ");
		}//catch
	}//chargeToi
	
	public void actionPerformed(ActionEvent evt) {
 		JButton leValideur = new JButton();
		leValideur=(JButton)evt.getSource();
		String label=leValideur.getName();

 		if(label.equals("choisir")){
 			try{
 			int index = saListe.getSelectedIndex();
			sonVecteur.get(index).consulteToi(saCreature.sonEditeur); 	
			}catch(Exception e){
				JOptionPane.showMessageDialog(null, "Veuillez sélectionner un élément !");
			}		
 		}
 		if(label.equals("ajouter")){
			String[] leChoix = { "Une arme", "Une armure", "Un consommable", "Un objet simple" };
			String laDecision = (String)JOptionPane.showInputDialog(null, "Que voulez vous ajouter?", "Equipement",JOptionPane.QUESTION_MESSAGE, null, leChoix, leChoix[0]);
			if(laDecision.equals("Une arme")){
                            try{
                                UneArme arme=new UneArme(JOptionPane.showInputDialog(null,"Donner le nom de l'objet à ajouter :"));
                                if(arme!=null)
                                    sonVecteur.add(arme);
                            }catch(Exception lException){}
				
			}
			if(laDecision.equals("Une armure")){
                            try{
                                UneArmure armure = new UneArmure(JOptionPane.showInputDialog(null,"Donner le nom de l'objet à ajouter :"));
                                if(armure!=null)
                                    sonVecteur.add(armure);
                            }catch(Exception lException){}
			}
			if (laDecision.equals("Un consommable")){
                            try{
                                UnConsommable conso = new UnConsommable(JOptionPane.showInputDialog(null, "Donner le nom de l'objet à ajouter :"));
                                if(conso!=null)
                                    sonVecteur.add(conso);
                            }catch(Exception lException){}
			}
			if (laDecision.equals("Un objet simple")){
                            try{
                                UnObjet objet = new UnObjet(JOptionPane.showInputDialog(null, "Donner le nom de l'objet à ajouter :"));
                                if(objet!=null)
                                    sonVecteur.add(objet);
                            }catch(Exception lException){}
			}
			Vector<String> leVecteur = new Vector<String>();
			for (int i = 0; i < sonVecteur.size(); i++){
				leVecteur.add(sonVecteur.get(i).getsonNom());
			}
 			saListe.setListData(leVecteur);
 		}

		if(label.equals("supp")){
			try{
				int lIndex = saListe.getSelectedIndex();
                                saCreature.sonEditeur.getsaCarte().getsesCases()[saCreature.getsaPosY()][saCreature.getsaPosX()].addUnObjet(sonVecteur.get(lIndex));
                                saCreature.sonEditeur.afficheLaCarte();
				sonVecteur.removeElementAt(lIndex);
			
				Vector<String> leVecteur = new Vector<String>();
				for (int i = 0; i < sonVecteur.size(); i++){
					leVecteur.add(sonVecteur.get(i).getsonNom());
				}//for
 				saListe.setListData(leVecteur);
			}catch(Exception e){
				JOptionPane.showMessageDialog(null, "Veuillez sélectionner un élément !");
			}
 	
		}
		if (label.equals("equipe")) {
			int index = saListe.getSelectedIndex();
			if(sonVecteur.get(index).toString().equals("Arme")){
				sonArmeEquipe = (UneArme)sonVecteur.get(index);
				JOptionPane.showMessageDialog(null, saCreature.getsonNom()+" est maintenant équipé de "+sonArmeEquipe.getsonNom(), "Equipement", JOptionPane.INFORMATION_MESSAGE);
			}
			else if (sonVecteur.get(index).toString().equals("Armure")){
				if (sonArmureEquipe != null){
					sonArmureEquipe.desequiper(saCreature);
				}
				sonArmureEquipe = (UneArmure)sonVecteur.get(index);
				String leNom = sonArmureEquipe.equiper(saCreature);
				JOptionPane.showMessageDialog(null, saCreature.getsonNom() + " est maintenant équipé de " + leNom, "Equipement", JOptionPane.INFORMATION_MESSAGE);
			}
			else {
				JOptionPane.showMessageDialog(null, "On ne peut pas s'équiper d'un tel objet", "Equipement", JOptionPane.WARNING_MESSAGE);
			}
			String laChaine = saCreature.getsonNom();
			if (sonArmureEquipe != null && sonArmeEquipe != null){
				laChaine += " porte un(e) " + sonArmureEquipe.getsonNom() + " et tiens un(e) " + sonArmeEquipe.getsonNom() + " à la main.";
			}
			else if (sonArmureEquipe != null){
				laChaine += " porte un(e) " + sonArmureEquipe.getsonNom() + ".";
			}
			else if (sonArmeEquipe != null){
				laChaine += " tiens un(e) " + sonArmeEquipe.getsonNom() + " à la main.";
			}
			else{
				laChaine += " est nu et désarmé.";
			}
			sonLabelListe.setText("<html>Inventaire de " + saCreature.getsonNom() + " :<br>" + laChaine + "</html>");
		}
		if (label.equals("desequipe")) {
			sonArmeEquipe = null;
			if (sonArmureEquipe != null) {
				sonArmureEquipe.desequiper(saCreature);
				sonArmureEquipe = null;
			}
			JOptionPane.showMessageDialog(null, saCreature.getsonNom() + " est maintenant nu!", "Equipement", JOptionPane.INFORMATION_MESSAGE);
			sonLabelListe.setText("<html>Inventaire de " + saCreature.getsonNom() + " :<br>" + saCreature.getsonNom() + " est nu et désarmé.</html>");
		}
                if(label.equals("utilise")){
                    int index = saListe.getSelectedIndex();
                    if(sonVecteur.get(index).toString().equals("Consommable")){
                        sonVecteur.get(index).consulteToi(saCreature.sonEditeur);
                        sonVecteur.removeElementAt(index);
                        Vector<String> leVecteur = new Vector<String>();
			for (int i = 0; i < sonVecteur.size(); i++){
				leVecteur.add(sonVecteur.get(i).getsonNom());
			}
 			saListe.setListData(leVecteur);
                        Object[] lesChoixPossibles = saCreature.sonEditeur.getsaCarte().getsesCreatures().toArray();
			try{
				UneCreature leChoixCrea = (UneCreature)JOptionPane.showInputDialog(null, "Si l'objet utilisé le nécessite, vous pouvez éditer les stats d'un personnage.\nChoisissez le dans la liste ci-dessous ou annulez.", "Consommation", JOptionPane.QUESTION_MESSAGE, null, lesChoixPossibles, lesChoixPossibles[0]);
				while (leChoixCrea != null) {
                                        JDialog leDial = new JDialog(saCreature.sonEditeur, "Editer stat", true);
					leDial.setContentPane(leChoixCrea.editeTesStats());
					leDial.setSize(300, 300);
					leDial.setVisible(true);
                                        leChoixCrea = (UneCreature)JOptionPane.showInputDialog(null, "Doit-on en modifier un autre?\nSi oui, choisissez le ci-dessous, sinon annulez.", "Consommation", JOptionPane.QUESTION_MESSAGE, null, lesChoixPossibles, lesChoixPossibles[0]);
                                }
                        }catch(Exception lException){}
                    }
                    else{
                        JOptionPane.showMessageDialog(null, "On ne peut pas consommer un tel objet", "Consommer", JOptionPane.WARNING_MESSAGE);
                    }
                }
		updateUI();
	}

    /**
     * Acesseur vers l'armée équipée
     * @return arme équipée
     */
        public UneArme getsonArme(){return sonArmeEquipe;}
    /**
     * accesseur vers l'armure équipée
     * @return armure équipée
     */
        public UneArmure getsonArmure(){return sonArmureEquipe;}
        
    /**
     * permet de ramasser un objet et de l'ajouter dans l'inventaire
     * @param telObjet objet à ramasser
     */
	public void ramasser(UnObjet telObjet) {
		sonVecteur.add(telObjet);
	}
}