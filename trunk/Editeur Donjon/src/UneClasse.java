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

public class UneClasse extends JPanel implements ActionListener{
	
	private String sonNom;
	private String sonNbSortMax;
	private int sonAjoutPv;
	private int sonBonusAttak;
	private int sonBonusVigueur;
	private int sonBonusVolonte;
	private int sonBonusReflx;
	private int sonBonusCompNiv1;
	private int sonBonusComp;
	private JTextField sonChampNom;
	private JTextField sonChampSort;
	private JTextField sonChampAjoutPv;
	private JTextField sonChampBonusAttak;
	private JTextField sonChampBonusVigueur;
	private JTextField sonChampBonusVolonte;
	private JTextField sonChampBonusReflx;
	private JTextField sonChampBonusCompNiv1;
	private JTextField sonChampBonusComp;
	private JLabel sonLabelNom;
	private JLabel sonLabelSort;
	private JLabel sonLabelAjoutPv;
	private JLabel sonLabelBonusAttak;
	private JLabel sonLabelBonusVigueur;
	private JLabel sonLabelBonusVolonte;
	private JLabel sonLabelBonusReflx;
	private JLabel sonLabelBonusCompNiv1;
	private JLabel sonLabelBonusComp;
	private JPanel lePanneauChamp;
	private JPanel lePanneauLabel;
	private JPanel lePanneauValid;
	private JPanel lePanneauDesc;
	private JPanel lePanneauLabelDesc;
	private JPanel lePanneauAlpha;
	private PrintWriter lEcrivain;
	
	UneClasse(){
		super();
	}
	
	UneClasse(String telNom){
		sonNom=telNom;
		String lire = new String();
		try{
		BufferedReader leLecteur = new BufferedReader(new FileReader(new File("bundll/classe.jay")));
			lire = leLecteur.readLine();
			while (!lire.equals(sonNom) && lire!=null){
				lire = leLecteur.readLine();
			}
			if (lire==null)
					JOptionPane.showMessageDialog(null, "Erreur, classe Non trouvé");
			sonNom = lire;
			sonNbSortMax = leLecteur.readLine();
			sonAjoutPv = Integer.parseInt(leLecteur.readLine());
			sonBonusAttak = Integer.parseInt(leLecteur.readLine());
			sonBonusVigueur = Integer.parseInt(leLecteur.readLine());
			sonBonusVolonte = Integer.parseInt(leLecteur.readLine());
			sonBonusReflx = Integer.parseInt(leLecteur.readLine());
			sonBonusCompNiv1 = Integer.parseInt(leLecteur.readLine());
			sonBonusComp = Integer.parseInt(leLecteur.readLine());
			
		leLecteur.close();
		}
		catch (Exception lException) { JOptionPane.showMessageDialog(null,"Une erreur est survenue, vérifiez le nom de la classe");
		}//catch
	}//chargeToi
	
	//accesseurs
	public String getsonNom(){return sonNom;}
	public void setsonNom(String telNom){sonNom=telNom;}
	public String getsonNbSortMax(){return sonNbSortMax;}
	public void setsonNbSortMax(String telNbSortMax){sonNbSortMax=telNbSortMax;}
	public int getsonAjoutPv(){return sonAjoutPv;}
	public void setsonAjoutPv(int telAjoutPv){sonAjoutPv=telAjoutPv;}
	public int getsonBonusAttak(){return sonBonusAttak;}
	public void setsonBonusAttak(int telBonusAttak){sonBonusAttak=telBonusAttak;}
	public int getsonBonusVigueur(){return sonBonusVigueur;}
	public void setsonBonusVigueur(int telBonusVigueur){sonBonusVigueur=telBonusVigueur;}
	public int getsonBonusVolonte(){return sonBonusVolonte;}
	public void setsonBonusVolonte(int telBonusVolonte){sonBonusVolonte=telBonusVolonte;}
	public int getsonBonusReflx(){return sonBonusReflx;}
	public void setsonBonusReflx(int telBonusReflx){sonBonusReflx=telBonusReflx;}
	public int getsonBonusCompNiv1(){return sonBonusCompNiv1;}
	public void setsonBonusCompNiv1(int telBonusCompNiv1){sonBonusCompNiv1=telBonusCompNiv1;}
	public int getsonBonusComp(){return sonBonusComp;}
	public void setsonBonusComp(int telBonusComp){sonBonusComp=telBonusComp;}
	
	//fonction relative à l'action (clique) faite sur le bouton.
	public void actionPerformed(ActionEvent telleAction){

		try{
			sonNom=sonChampNom.getText();
			sonNbSortMax=sonChampSort.getText();
			sonAjoutPv=Integer.parseInt(sonChampAjoutPv.getText());
			sonBonusAttak=Integer.parseInt(sonChampBonusAttak.getText());
			sonBonusVigueur=Integer.parseInt(sonChampBonusVigueur.getText());
			sonBonusVolonte=Integer.parseInt(sonChampBonusVolonte.getText());
			sonBonusReflx=Integer.parseInt(sonChampBonusReflx.getText());
			sonBonusCompNiv1=Integer.parseInt(sonChampBonusCompNiv1.getText());
			sonBonusComp=Integer.parseInt(sonChampBonusComp.getText());
		}catch (NumberFormatException lException){
			JOptionPane.showMessageDialog(null,"Un des champs Numérique est mal rempli et c'est pas bien ça...non pas bien!");
		}
		enregistreToi(lEcrivain);
		JOptionPane.showMessageDialog(null,"Enregistrement éffectué!");
		removeAll();
		updateUI();
	}
	
	public void enregistreToi(PrintWriter lEcrivain){
	    	try{
    		lEcrivain = new PrintWriter(new FileWriter(new File("bundll/classe.jay"),true));
			lEcrivain.println(sonNom);
			lEcrivain.println(sonNbSortMax);
			lEcrivain.println(sonAjoutPv);
			lEcrivain.println(sonBonusAttak);
			lEcrivain.println(sonBonusVigueur);
			lEcrivain.println(sonBonusVolonte);
			lEcrivain.println(sonBonusReflx);
			lEcrivain.println(sonBonusCompNiv1);
			lEcrivain.println(sonBonusComp);
			lEcrivain.println("finClasse");
			lEcrivain.close();
			lEcrivain = new PrintWriter(new FileWriter(new File("bundll/classeliste.jay"),true));
			lEcrivain.println(sonNom);
			lEcrivain.close();
			}catch(Exception lException){
			System.err.print("une erreur est survenue");}//catch
	}//enregistreToi

	public void chargeToi(String telNom){
		sonNom=telNom;
		String lire = new String();
		try{
		BufferedReader leLecteur = new BufferedReader(new FileReader(new File("bundll/classe.jay")));
			lire = leLecteur.readLine();
			while (!lire.equals(sonNom) && lire!=null){
				lire = leLecteur.readLine();
			}
			if (lire==null)
					JOptionPane.showMessageDialog(null, "Erreur, classe Non trouvé");
			sonNom = lire;
			sonNbSortMax = leLecteur.readLine();
			sonAjoutPv = Integer.parseInt(leLecteur.readLine());
			sonBonusAttak = Integer.parseInt(leLecteur.readLine());
			sonBonusVigueur = Integer.parseInt(leLecteur.readLine());
			sonBonusVolonte = Integer.parseInt(leLecteur.readLine());
			sonBonusReflx = Integer.parseInt(leLecteur.readLine());
			sonBonusCompNiv1 = Integer.parseInt(leLecteur.readLine());
			sonBonusComp = Integer.parseInt(leLecteur.readLine());
			
		leLecteur.close();
		}
		catch (Exception lException) { JOptionPane.showMessageDialog(null,"Une erreur est survenue, vérifiez le nom de la créature"); }//catch
		afficheToi();
	}//chargeToi
	public JPanel afficheToi(){
		lePanneauChamp = new JPanel(new GridLayout(0,1));//création d'un panneau dédié aux champs
		lePanneauLabel = new JPanel(new GridLayout(0,1));//création d'un panneau dédié aux labels
		lePanneauAlpha=new JPanel(new GridLayout(0,2));//création d'un panneau destiné à recevoir les labels et les champs.
		JPanel lePanneauFinal=new JPanel(new GridLayout(0,1));

		sonChampNom = new JTextField(10);//initialisation d'un champ texte avec JTextDield
		sonChampSort = new JTextField(10);
		sonChampAjoutPv = new JTextField(10);
		sonChampBonusAttak = new JTextField(10);
		sonChampBonusVigueur = new JTextField(10);
		sonChampBonusVolonte = new JTextField(10);
		sonChampBonusReflx = new JTextField(10);
		sonChampBonusCompNiv1 = new JTextField(10);
		sonChampBonusComp = new JTextField(10);

		sonLabelNom= new JLabel("Nom");//Initialisation des labels, c'est à dire des intitulés des champs
		sonLabelSort= new JLabel("Nombre de sorts par jour");
		sonLabelAjoutPv= new JLabel("Pv ajoutés par niveau");
		sonLabelBonusAttak= new JLabel("Bonus à l'attaque");
		sonLabelBonusVigueur= new JLabel("Bonus de vigueur");
		sonLabelBonusVolonte= new JLabel("Bonus de volonté");
		sonLabelBonusReflx= new JLabel("Bonus de reflexes");
		sonLabelBonusCompNiv1= new JLabel("Bonus compétences au niveau 1");
		sonLabelBonusComp= new JLabel("Bonus compétences");

		sonLabelNom.setLabelFor(sonChampNom);//assignation des labels aux champs correspondants
		sonLabelSort.setLabelFor(sonChampSort);
		sonLabelAjoutPv.setLabelFor(sonChampAjoutPv);
		sonLabelBonusAttak.setLabelFor(sonChampBonusAttak);
		sonLabelBonusVigueur.setLabelFor(sonChampBonusVigueur);
		sonLabelBonusVolonte.setLabelFor(sonChampBonusVolonte);
		sonLabelBonusReflx.setLabelFor(sonChampBonusReflx);
		sonLabelBonusCompNiv1.setLabelFor(sonChampBonusCompNiv1);
		sonLabelBonusComp.setLabelFor(sonChampBonusComp);
		

		lePanneauChamp.add(sonChampNom);//ajout des champs dans le panneau dédié aux champs
		lePanneauChamp.add(sonChampSort);
		lePanneauChamp.add(sonChampAjoutPv);
		lePanneauChamp.add(sonChampBonusAttak);
		lePanneauChamp.add(sonChampBonusVigueur);
		lePanneauChamp.add(sonChampBonusVolonte);
		lePanneauChamp.add(sonChampBonusReflx);
		lePanneauChamp.add(sonChampBonusCompNiv1);
		lePanneauChamp.add(sonChampBonusComp);

		lePanneauLabel.add(sonLabelNom);//ajout des labels au panneau dédié aux labels.
		lePanneauLabel.add(sonLabelSort);
		lePanneauLabel.add(sonLabelAjoutPv);
		lePanneauLabel.add(sonLabelBonusAttak);
		lePanneauLabel.add(sonLabelBonusVigueur);
		lePanneauLabel.add(sonLabelBonusVolonte);
		lePanneauLabel.add(sonLabelBonusReflx);
		lePanneauLabel.add(sonLabelBonusCompNiv1);
		lePanneauLabel.add(sonLabelBonusComp);

		// création du bouton "valider"

		JButton leValideur = new JButton("Valider");//initialisation du bouton pour valider avec JButton
		lePanneauValid = new JPanel(new GridBagLayout());
		lePanneauValid.add(leValideur);
		leValideur.addActionListener(this);

		// On réunis les 3 panneaux dans la fenêtre
		lePanneauAlpha.add(lePanneauLabel);
		lePanneauAlpha.add(lePanneauChamp);
		lePanneauFinal.add(lePanneauAlpha);
		lePanneauFinal.add(lePanneauValid);
		this.add(lePanneauFinal);
	   sonChampNom.setText(sonNom);
	   sonChampSort.setText(sonNbSortMax);
	   sonChampAjoutPv.setText(Integer.toString(sonAjoutPv));
	   sonChampBonusAttak.setText(Integer.toString(sonBonusAttak));
	   sonChampBonusVigueur.setText(Integer.toString(sonBonusVigueur));
	   sonChampBonusVolonte.setText(Integer.toString(sonBonusVolonte));
	   sonChampBonusReflx.setText(Integer.toString(sonBonusReflx));
	   sonChampBonusCompNiv1.setText(Integer.toString(sonBonusCompNiv1));
	   sonChampBonusComp.setText(Integer.toString(sonBonusComp));
	   updateUI();
	   return this;
	   
    }//Affiche
    
    /**
     * Affiche les infos relatives à la classe
     * @return JDialog donnant les informations sur la classe
     */
    public JDialog consulteToi(){
		
		JDialog laFenetre = new JDialog ();
		laFenetre.setTitle("Une classe");
		laFenetre.setSize(350, 300);
		laFenetre.setLocation(200,150);
		laFenetre.setVisible(true);
		
		lePanneauDesc = new JPanel();
		lePanneauAlpha = new JPanel(new GridLayout(0,1));
		lePanneauChamp = new JPanel(new GridLayout(0,1));//création d'un panneau dédié aux champs
		lePanneauLabel = new JPanel(new GridLayout(0,1));//création d'un panneau dédié aux labels
		
		sonChampNom = new JTextField(10);//initialisation d'un champ texte avec JTextDield
		sonChampSort = new JTextField(10);
		sonChampAjoutPv = new JTextField(10);
		sonChampBonusAttak = new JTextField(10);
		sonChampBonusVigueur = new JTextField(10);
		sonChampBonusVolonte = new JTextField(10);
		sonChampBonusReflx = new JTextField(10);
		sonChampBonusCompNiv1 = new JTextField(10);
		sonChampBonusComp = new JTextField(10);

		sonLabelNom= new JLabel("Nom");//Initialisation des labels, c'est à dire des intitulés des champs
		sonLabelSort= new JLabel("Nombre de sorts par jour");
		sonLabelAjoutPv= new JLabel("Pv ajoutés par niveau");
		sonLabelBonusAttak= new JLabel("Bonus à l'attaque");
		sonLabelBonusVigueur= new JLabel("Bonus de vigueur");
		sonLabelBonusVolonte= new JLabel("Bonus de volonté");
		sonLabelBonusReflx= new JLabel("Bonus de reflexes");
		sonLabelBonusCompNiv1= new JLabel("Bonus compétences au niveau 1");
		sonLabelBonusComp= new JLabel("Bonus compétences");

		sonLabelNom.setLabelFor(sonChampNom);//assignation des labels aux champs correspondants
		sonLabelSort.setLabelFor(sonChampSort);
		sonLabelAjoutPv.setLabelFor(sonChampAjoutPv);
		sonLabelBonusAttak.setLabelFor(sonChampBonusAttak);
		sonLabelBonusVigueur.setLabelFor(sonChampBonusVigueur);
		sonLabelBonusVolonte.setLabelFor(sonChampBonusVolonte);
		sonLabelBonusReflx.setLabelFor(sonChampBonusReflx);
		sonLabelBonusCompNiv1.setLabelFor(sonChampBonusCompNiv1);
		sonLabelBonusComp.setLabelFor(sonChampBonusComp);
		

		lePanneauChamp.add(sonChampNom);//ajout des champs dans le panneau dédié aux champs
		lePanneauChamp.add(sonChampSort);
		lePanneauChamp.add(sonChampAjoutPv);
		lePanneauChamp.add(sonChampBonusAttak);
		lePanneauChamp.add(sonChampBonusVigueur);
		lePanneauChamp.add(sonChampBonusVolonte);
		lePanneauChamp.add(sonChampBonusReflx);
		lePanneauChamp.add(sonChampBonusCompNiv1);
		lePanneauChamp.add(sonChampBonusComp);

		lePanneauLabel.add(sonLabelNom);//ajout des labels au panneau dédié aux labels.
		lePanneauLabel.add(sonLabelSort);
		lePanneauLabel.add(sonLabelAjoutPv);
		lePanneauLabel.add(sonLabelBonusAttak);
		lePanneauLabel.add(sonLabelBonusVigueur);
		lePanneauLabel.add(sonLabelBonusVolonte);
		lePanneauLabel.add(sonLabelBonusReflx);
		lePanneauLabel.add(sonLabelBonusCompNiv1);
		lePanneauLabel.add(sonLabelBonusComp);

		// On réunis les 3 panneaux dans la fenêtre
		this.add(lePanneauLabel);
		this.add(lePanneauChamp);
		laFenetre.setContentPane(this);
		
	   sonChampNom.setText(sonNom);
	   sonChampSort.setText(sonNbSortMax);
	   sonChampAjoutPv.setText(Integer.toString(sonAjoutPv));
	   sonChampBonusAttak.setText(Integer.toString(sonBonusAttak));
	   sonChampBonusVigueur.setText(Integer.toString(sonBonusVigueur));
	   sonChampBonusVolonte.setText(Integer.toString(sonBonusVolonte));
	   sonChampBonusReflx.setText(Integer.toString(sonBonusReflx));
	   sonChampBonusCompNiv1.setText(Integer.toString(sonBonusCompNiv1));
	   sonChampBonusComp.setText(Integer.toString(sonBonusComp));
	   
	   sonChampNom.setEditable(false);
	   sonChampSort.setEditable(false);
	   sonChampAjoutPv.setEditable(false);
	   sonChampBonusAttak.setEditable(false);
	   sonChampBonusVigueur.setEditable(false);
	   sonChampBonusVolonte.setEditable(false);
	   sonChampBonusReflx.setEditable(false);
	   sonChampBonusCompNiv1.setEditable(false);	
	   sonChampBonusComp.setEditable(false);	   
	   
	   updateUI();
	   return laFenetre;
	   
    }//Affiche
    
    /**
     * inutile à l'heure actuelle
     * @return 
     */
        public String toString(){
    	return ("Classe");
    }
	
}