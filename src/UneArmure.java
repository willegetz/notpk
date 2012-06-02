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

public class UneArmure extends UnObjet implements ActionListener{

	private String sonType;
	private int sonBonusCA;
	private int sonBonusDex;
	private int saPenalite;
	private int sonEchecSort;
	private int saVitMax;
	private String saPropSpec;
	private JComboBox sonChampType;;
	private JTextField sonChampBonusCA;
	private JTextField sonChampBonusDex;
	private JTextField sonChampPenalite;
	private JTextField sonChampEchecSort;
	private JTextField sonChampVitMax;
	private JTextField sonChampPropSpec;
	private JLabel sonLabelType;
	private JLabel sonLabelBonusCA;
	private JLabel sonLabelBonusDex;
	private JLabel sonLabelPenalite;
	private JLabel sonLabelEchecSort;
	private JLabel sonLabelVitMax;
	private JLabel sonLabelPropSpec;

	UneArmure(){//constructeur  sans arguments
		super();
		
	}
	
	UneArmure(String telNom) throws Exception{

		super(telNom);
		try{
		BufferedReader leLecteur = new BufferedReader(new FileReader(new File("Objets/"+telNom+".jay")));
			String laLigne=leLecteur.readLine();
			while(!laLigne.equals ("finDesc")){
				laLigne=leLecteur.readLine();
			}
			sonType = leLecteur.readLine();
			sonBonusCA = Integer.parseInt(leLecteur.readLine());
			sonBonusDex = Integer.parseInt(leLecteur.readLine());
			saPenalite = Integer.parseInt(leLecteur.readLine());
			sonEchecSort = Integer.parseInt(leLecteur.readLine());
			saVitMax = Integer.parseInt(leLecteur.readLine());
			saPropSpec = leLecteur.readLine();

		leLecteur.close();
		}
		catch (Exception lException) { 
                    JOptionPane.showMessageDialog(null,"Une erreur est survenue, vérifiez l'armure");
                    throw (Exception)lException;
		}//catch
	}//chargeToi
	
	//accesseurs
	public String getsonType(){return sonType;}
	public void setsonType(String telType){sonType=telType;}
	public int getsonBonusCA(){return sonBonusCA;}
	public void setsonBonusCA(int telBonusCA){sonBonusCA=telBonusCA;}
	public int getsonBonusDex(){return sonBonusDex;}
	public void setsonBonusDex(int telBonusDex){sonBonusDex=telBonusDex;}
	public int getsonEchecSort(){return sonEchecSort;}
	public void setsonEchecSort(int telEchecSort){sonEchecSort=telEchecSort;}
	public int getsaVitMax(){return saVitMax;}
	public void setsaVitMax(int telleVitMax){saVitMax=telleVitMax;}
	public String getsaPropSpec(){return saPropSpec;}
	public void setsaPropSpec(String tellePropSpec){saPropSpec=tellePropSpec;}

	//fonction relative à l'action (clique) faite sur le bouton.
	public void actionPerformed(ActionEvent telleAction){

		try{
			super.actionPerformed(telleAction);
			sonType=(String)sonChampType.getSelectedItem();
			saPropSpec=sonChampPropSpec.getText();
			sonBonusCA=Integer.parseInt(sonChampBonusCA.getText());
			sonBonusDex=Integer.parseInt(sonChampBonusDex.getText());
			saPenalite=Integer.parseInt(sonChampPenalite.getText());
			sonEchecSort=Integer.parseInt(sonChampEchecSort.getText());
			saVitMax=Integer.parseInt(sonChampVitMax.getText());
			enregistreToi();
		}catch (NumberFormatException lException){
			JOptionPane.showMessageDialog(null,"Un des champs Numérique est mal rempli et c'est pas bien ça...non pas bien!");
		}
	}
	public void enregistreToi(){
		super.enregistreToi();
		PrintWriter lEcrivain;
	    try{
	   		lEcrivain = new PrintWriter(new FileWriter(new File("Objets/"+sonChampNom.getText()+".jay"),true));
			lEcrivain.println(sonType);
			lEcrivain.println(sonBonusCA);
			lEcrivain.println(sonBonusDex);
			lEcrivain.println(saPenalite);
			lEcrivain.println(sonEchecSort);
			lEcrivain.println(saVitMax);
			lEcrivain.println(saPropSpec);
			lEcrivain.println("finArmure");
			lEcrivain.close();
		}catch(Exception lException){
			System.err.print("une erreur est survenue");}//catch
	}//enregistreToi

	public void chargeToi(String telNom){

		super.chargeToi(telNom);
		try{
		BufferedReader leLecteur = new BufferedReader(new FileReader(new File("Objets/"+telNom+".jay")));
			String laLigne=leLecteur.readLine();
			while(!laLigne.equals ("finDesc")){
				laLigne=leLecteur.readLine();
			}
			sonType = leLecteur.readLine();
			sonBonusCA = Integer.parseInt(leLecteur.readLine());
			sonBonusDex = Integer.parseInt(leLecteur.readLine());
			saPenalite = Integer.parseInt(leLecteur.readLine());
			sonEchecSort = Integer.parseInt(leLecteur.readLine());
			saVitMax = Integer.parseInt(leLecteur.readLine());
			saPropSpec = leLecteur.readLine();

		leLecteur.close();
		}
		catch (Exception lException) { JOptionPane.showMessageDialog(null,"Une erreur est survenue, vérifiez le nom de la créature"); }//catch
		super.afficheToi();
		afficheToi();
	}//chargeToi
	public JPanel afficheToi(){
		super.afficheToi();
		sonChampType = new JComboBox();//initialisation d'un champ texte avec JTextDield
		sonChampBonusCA = new JTextField(10);
		sonChampBonusDex = new JTextField(10);
		sonChampPenalite = new JTextField(10);
		sonChampEchecSort = new JTextField(10);
		sonChampVitMax = new JTextField(10);
		sonChampPropSpec = new JTextField(10);
		
		sonChampType.addItem("Légère");
		sonChampType.addItem("Intermédiaire");
		sonChampType.addItem("Lourde");

		sonLabelType= new JLabel("Type");//Initialisation des labels, c'est à dire des intitulés des champs
		sonLabelBonusCA= new JLabel("Bonus CA");
		sonLabelBonusDex= new JLabel("Bonus Dextérité");
		sonLabelPenalite= new JLabel("Pénalité");
		sonLabelEchecSort= new JLabel("Échec Sort");
		sonLabelVitMax= new JLabel("Vitesse Max");
		sonLabelPropSpec= new JLabel("Propriété spéciale");

		sonLabelType.setLabelFor(sonChampType);//assignation des labels aux champs correspondants
		sonLabelBonusCA.setLabelFor(sonChampBonusCA);
		sonLabelBonusDex.setLabelFor(sonChampBonusDex);
		sonLabelPenalite.setLabelFor(sonChampPenalite);
		sonLabelEchecSort.setLabelFor(sonChampEchecSort);
		sonLabelVitMax.setLabelFor(sonChampVitMax);
		sonLabelPropSpec.setLabelFor(sonChampPropSpec);

		lePanneauChamp.add(sonChampType);//ajout des champs dans le panneau dédié aux champs
		lePanneauChamp.add(sonChampBonusCA);
		lePanneauChamp.add(sonChampBonusDex);
		lePanneauChamp.add(sonChampPenalite);
		lePanneauChamp.add(sonChampEchecSort);
		lePanneauChamp.add(sonChampVitMax);
		lePanneauChamp.add(sonChampPropSpec);

		lePanneauLabel.add(sonLabelType);//ajout des labels au panneau dédié aux labels.
		lePanneauLabel.add(sonLabelBonusCA);
		lePanneauLabel.add(sonLabelBonusDex);
		lePanneauLabel.add(sonLabelPenalite);
		lePanneauLabel.add(sonLabelEchecSort);
		lePanneauLabel.add(sonLabelVitMax);
		lePanneauLabel.add(sonLabelPropSpec);

	   sonChampType.setSelectedItem(sonType);
	   sonChampBonusCA.setText(Integer.toString(sonBonusCA));
	   sonChampBonusDex.setText(Integer.toString(sonBonusDex));
	   sonChampPenalite.setText(Integer.toString(saPenalite));
	   sonChampEchecSort.setText(Integer.toString(sonEchecSort));
	   sonChampVitMax.setText(Integer.toString(saVitMax));
	   sonChampPropSpec.setText(saPropSpec);
	   updateUI();
	   return lePanneauAlpha;
   }//Affiche
   
    public JDialog consulteToi(JFrame lePere){
		super.consulteToi(lePere);
		laFenetre.setTitle("Une Armure");
		sonChampType = new JComboBox();//initialisation d'un champ texte avec JTextDield
		sonChampBonusCA = new JTextField(10);
		sonChampBonusDex = new JTextField(10);
		sonChampPenalite = new JTextField(10);
		sonChampEchecSort = new JTextField(10);
		sonChampVitMax = new JTextField(10);
		sonChampPropSpec = new JTextField(10);
		
		sonChampType.addItem("Légère");
		sonChampType.addItem("Intermédiaire");
		sonChampType.addItem("Lourde");

		sonLabelType= new JLabel("Type");//Initialisation des labels, c'est à dire des intitulés des champs
		sonLabelBonusCA= new JLabel("Bonus CA");
		sonLabelBonusDex= new JLabel("Bonus Dextérité");
		sonLabelPenalite= new JLabel("Pénalité");
		sonLabelEchecSort= new JLabel("Échec Sort");
		sonLabelVitMax= new JLabel("Vitesse Max");
		sonLabelPropSpec= new JLabel("Propriété spéciale");

		sonLabelType.setLabelFor(sonChampType);//assignation des labels aux champs correspondants
		sonLabelBonusCA.setLabelFor(sonChampBonusCA);
		sonLabelBonusDex.setLabelFor(sonChampBonusDex);
		sonLabelPenalite.setLabelFor(sonChampPenalite);
		sonLabelEchecSort.setLabelFor(sonChampEchecSort);
		sonLabelVitMax.setLabelFor(sonChampVitMax);
		sonLabelPropSpec.setLabelFor(sonChampPropSpec);

		lePanneauChamp.add(sonChampType);//ajout des champs dans le panneau dédié aux champs
		lePanneauChamp.add(sonChampBonusCA);
		lePanneauChamp.add(sonChampBonusDex);
		lePanneauChamp.add(sonChampPenalite);
		lePanneauChamp.add(sonChampEchecSort);
		lePanneauChamp.add(sonChampVitMax);
		lePanneauChamp.add(sonChampPropSpec);

		lePanneauLabel.add(sonLabelType);//ajout des labels au panneau dédié aux labels.
		lePanneauLabel.add(sonLabelBonusCA);
		lePanneauLabel.add(sonLabelBonusDex);
		lePanneauLabel.add(sonLabelPenalite);
		lePanneauLabel.add(sonLabelEchecSort);
		lePanneauLabel.add(sonLabelVitMax);
		lePanneauLabel.add(sonLabelPropSpec);

	   sonChampType.setSelectedItem(sonType);
	   sonChampBonusCA.setText(Integer.toString(sonBonusCA));
	   sonChampBonusDex.setText(Integer.toString(sonBonusDex));
	   sonChampPenalite.setText(Integer.toString(saPenalite));
	   sonChampEchecSort.setText(Integer.toString(sonEchecSort));
	   sonChampVitMax.setText(Integer.toString(saVitMax));
	   sonChampPropSpec.setText(saPropSpec);
	   
	   sonChampType.setEnabled(false);
	   sonChampBonusCA.setEditable(false);
	   sonChampBonusDex.setEditable(false);
	   sonChampPenalite.setEditable(false);
	   sonChampEchecSort.setEditable(false);
	   sonChampVitMax.setEditable(false);
	   sonChampPropSpec.setEditable(false);
	   
		laFenetre.setVisible(true);
	   return laFenetre;
   }//Consulte
   
   public String equiper(UneCreature laCreature){
   		laCreature.saCA+=sonBonusCA;
   		laCreature.afficheCA();
   		return sonNom;
   }
   
   public String desequiper(UneCreature laCreature){
   		laCreature.saCA-=sonBonusCA;
   		laCreature.afficheCA();
   		return sonNom;
   }
   
   public String toString(){
    	return ("Armure");
    }
}