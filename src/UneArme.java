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

public class UneArme extends UnObjet implements ActionListener{

	private int sonBonusAtt;
	private int saPortee;
	private int sonCritique;
	private String saPropSpec;
	private String saTaille;
	private UnDegat sesDegats;
	private JTextField sonChampBonusAtt;
	private JTextField sonChampPortee;
	private JTextField sonChampCritique;
	private JTextField sonChampPropSpec;
	private JComboBox sonChampTaille;
	private JTextField sonChampTypeDeg;
	private JTextField sonChampDeDegat;
	private JLabel sonLabelBonusAtt;
	private JLabel sonLabelPortee;
	private JLabel sonLabelCritique;
	private JLabel sonLabelPropSpec;
	private JLabel sonLabelTaille;
	private JLabel sonLabelTypeDeg;
	private JLabel sonLabelDeDegat;

	UneArme(){//constructeur  sans arguments
		super();
		sesDegats= new UnDegat();
	}
	
		UneArme(String telNom)throws Exception{
		super(telNom);
		sesDegats=new UnDegat();
		try{
		BufferedReader leLecteur = new BufferedReader(new FileReader(new File("Objets/"+telNom+".jay")));
			String laLigne=leLecteur.readLine();
			while(!laLigne.equals ("finDesc")){
				laLigne=leLecteur.readLine();
			}
			sesDegats.sonType=leLecteur.readLine();
			sesDegats.sonDeDegat=leLecteur.readLine();
			sonBonusAtt =Integer.parseInt(leLecteur.readLine());
			saPortee = Integer.parseInt(leLecteur.readLine());
			sonCritique = Integer.parseInt(leLecteur.readLine());
			saPropSpec = leLecteur.readLine();
			saTaille = leLecteur.readLine();
		leLecteur.close();
		}
		catch (Exception lException) { 
                    JOptionPane.showMessageDialog(null,"Une erreur est survenue, vérifiez l'arme");
                    throw (Exception)lException;
		}//catch
	}//chargeToi

	//Accesseurs
	public int getsonBonusAtt(){return sonBonusAtt;}
	public void setsonBonusAtt(int telBonusAtt){sonBonusAtt=telBonusAtt;}
	public int getsaPortee(){return saPortee;}
	public void setsaPortee(int tellePortee){saPortee=tellePortee;}
	public int getsonCritique(){return sonCritique;}
	public void setsonCritique(int telCritique){sonCritique=telCritique;}
	public String getsaPropSpec(){return saPropSpec;}
	public void setsaPropSpec(String tellePropSpec){saPropSpec=tellePropSpec;}
	public String getsaTaille(){return saTaille;}
	public void setsaTaille(String telleTaille){saTaille=telleTaille;}
	public String getsonDeDegat(){return sesDegats.getsonDeDegat();}

	//fonction relative à l'action (clique) faite sur le bouton.
	public void actionPerformed(ActionEvent telleAction){

		try{
			super.actionPerformed(telleAction);
			sonBonusAtt=Integer.parseInt(sonChampBonusAtt.getText());
			saPortee=Integer.parseInt(sonChampPortee.getText());
			sonCritique=Integer.parseInt(sonChampCritique.getText());
			saPropSpec=sonChampPropSpec.getText();
			saTaille=(String)sonChampTaille.getSelectedItem();
			sesDegats.sonType=sonChampTypeDeg.getText();
			sesDegats.sonDeDegat=sonChampDeDegat.getText();
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
			lEcrivain.println(sesDegats.sonType);
			lEcrivain.println(sesDegats.sonDeDegat);
			lEcrivain.println(sonBonusAtt);
			lEcrivain.println(saPortee);
			lEcrivain.println(sonCritique);
			lEcrivain.println(saPropSpec);
			lEcrivain.println(saTaille);
			lEcrivain.println("finArme");
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
			sesDegats.sonType=leLecteur.readLine();
			sesDegats.sonDeDegat=leLecteur.readLine();
			sonBonusAtt =Integer.parseInt(leLecteur.readLine());
			saPortee = Integer.parseInt(leLecteur.readLine());
			sonCritique = Integer.parseInt(leLecteur.readLine());
			saPropSpec = leLecteur.readLine();
			saTaille = leLecteur.readLine();
		leLecteur.close();
		}
		catch (Exception lException) { JOptionPane.showMessageDialog(null,"Une erreur est survenue, vérifiez l'arme"); }//catch
		super.afficheToi();
		afficheToi();
	}//chargeToi
	public JPanel afficheToi(){
	   super.afficheToi();
	   sonChampBonusAtt = new JTextField(10);//initialisation d'un champ texte avec JTextField
		sonChampPortee = new JTextField(10);
		sonChampCritique= new JTextField(10);
		sonChampPropSpec = new JTextField(10);
		sonChampTypeDeg = new JTextField(10);
		sonChampDeDegat = new JTextField(10);
		sonChampTaille = new JComboBox();
				
		sonChampTaille.addItem("I");
		sonChampTaille.addItem("TP");
		sonChampTaille.addItem("P");
		sonChampTaille.addItem("M");
		sonChampTaille.addItem("G");
		sonChampTaille.addItem("TG");
		sonChampTaille.addItem("Gig");
		sonChampTaille.addItem("Col");
		

		sonLabelBonusAtt= new JLabel("Bonus attaque");//Initialisation des labels, c'est à dire des intitulés des champs
		sonLabelPortee= new JLabel("Portée");
		sonLabelCritique= new JLabel("Zone critique");
		sonLabelPropSpec= new JLabel("Propriété(s) spéciale(s)");
		sonLabelTaille= new JLabel("Taille");
		sonLabelTypeDeg= new JLabel("Type de dégâts");
		sonLabelDeDegat= new JLabel("Dés de dégats");


		sonLabelBonusAtt.setLabelFor(sonChampBonusAtt);//assignation des labels aux champs correspondants
		sonLabelPortee.setLabelFor(sonChampPortee);
		sonLabelCritique.setLabelFor(sonChampCritique);
		sonLabelPropSpec.setLabelFor(sonChampPropSpec);
		sonLabelTaille.setLabelFor(sonChampTaille);
		sonLabelTypeDeg.setLabelFor(sonChampTypeDeg);
		sonLabelDeDegat.setLabelFor(sonChampDeDegat);

		lePanneauChamp.add(sonChampTaille);//ajout des champs dans le panneau dédié aux champs
		lePanneauChamp.add(sonChampPortee);
		lePanneauChamp.add(sonChampCritique);
		lePanneauChamp.add(sonChampPropSpec);
		lePanneauChamp.add(sonChampBonusAtt);
		lePanneauChamp.add(sonChampTypeDeg);
		lePanneauChamp.add(sonChampDeDegat);


		lePanneauLabel.add(sonLabelTaille);//ajout des labels au panneau dédié aux labels.
		lePanneauLabel.add(sonLabelPortee);
		lePanneauLabel.add(sonLabelCritique);
		lePanneauLabel.add(sonLabelPropSpec);
		lePanneauLabel.add(sonLabelBonusAtt);
		lePanneauLabel.add(sonLabelTypeDeg);
		lePanneauLabel.add(sonLabelDeDegat);
		
		
	   sonChampBonusAtt.setText(Integer.toString(sonBonusAtt));
	   sonChampPortee.setText(Integer.toString(saPortee));
	   sonChampCritique.setText(Integer.toString(sonCritique));
	   sonChampPropSpec.setText(saPropSpec);
	   sonChampTaille.setSelectedItem(saTaille);
	   sonChampTypeDeg.setText(sesDegats.sonType);
	   sonChampDeDegat.setText(sesDegats.sonDeDegat);
	   updateUI();
	   return lePanneauAlpha;
   }//Affiche
   
    public JDialog consulteToi(JFrame lePere){
		super.consulteToi(lePere);	   
	    laFenetre.setTitle("Une Arme");	   
	    sonChampBonusAtt = new JTextField(10);//initialisation d'un champ texte avec JTextField
		sonChampPortee = new JTextField(10);
		sonChampCritique= new JTextField(10);
		sonChampPropSpec = new JTextField(10);
		sonChampTypeDeg = new JTextField(10);
		sonChampDeDegat = new JTextField(10);
		sonChampTaille = new JComboBox();
				
		sonChampTaille.addItem("I");
		sonChampTaille.addItem("TP");
		sonChampTaille.addItem("P");
		sonChampTaille.addItem("M");
		sonChampTaille.addItem("G");
		sonChampTaille.addItem("TG");
		sonChampTaille.addItem("Gig");
		sonChampTaille.addItem("Col");
		

		sonLabelBonusAtt= new JLabel("Bonus attaque");//Initialisation des labels, c'est à dire des intitulés des champs
		sonLabelPortee= new JLabel("Portée");
		sonLabelCritique= new JLabel("Zone critique");
		sonLabelPropSpec= new JLabel("Propriété(s) spéciale(s)");
		sonLabelTaille= new JLabel("Taille");
		sonLabelTypeDeg= new JLabel("Type de dégâts");
		sonLabelDeDegat= new JLabel("Dés de dégats");


		sonLabelBonusAtt.setLabelFor(sonChampBonusAtt);//assignation des labels aux champs correspondants
		sonLabelPortee.setLabelFor(sonChampPortee);
		sonLabelCritique.setLabelFor(sonChampCritique);
		sonLabelPropSpec.setLabelFor(sonChampPropSpec);
		sonLabelTaille.setLabelFor(sonChampTaille);
		sonLabelTypeDeg.setLabelFor(sonChampTypeDeg);
		sonLabelDeDegat.setLabelFor(sonChampDeDegat);

		lePanneauChamp.add(sonChampTaille);//ajout des champs dans le panneau dédié aux champs
		lePanneauChamp.add(sonChampPortee);
		lePanneauChamp.add(sonChampCritique);
		lePanneauChamp.add(sonChampPropSpec);
		lePanneauChamp.add(sonChampBonusAtt);
		lePanneauChamp.add(sonChampTypeDeg);
		lePanneauChamp.add(sonChampDeDegat);


		lePanneauLabel.add(sonLabelTaille);//ajout des labels au panneau dédié aux labels.
		lePanneauLabel.add(sonLabelPortee);
		lePanneauLabel.add(sonLabelCritique);
		lePanneauLabel.add(sonLabelPropSpec);
		lePanneauLabel.add(sonLabelBonusAtt);
		lePanneauLabel.add(sonLabelTypeDeg);
		lePanneauLabel.add(sonLabelDeDegat);
		
		
	   sonChampBonusAtt.setText(Integer.toString(sonBonusAtt));
	   sonChampPortee.setText(Integer.toString(saPortee));
	   sonChampCritique.setText(Integer.toString(sonCritique));
	   sonChampPropSpec.setText(saPropSpec);
	   sonChampTaille.setSelectedItem(saTaille);
	   sonChampTypeDeg.setText(sesDegats.sonType);
	   sonChampDeDegat.setText(sesDegats.sonDeDegat);
	   
	   sonChampBonusAtt.setEditable(false);
	   sonChampPortee.setEditable(false);
	   sonChampCritique.setEditable(false);
	   sonChampPropSpec.setEditable(false);
	   sonChampTaille.setEnabled(false);
	   sonChampTypeDeg.setEditable(false);
	   sonChampDeDegat.setEditable(false);
	   
	   laFenetre.setVisible(true);
	   return laFenetre;
   }//Consulte
       public String toString(){
    	return ("Arme");
    }
   
}