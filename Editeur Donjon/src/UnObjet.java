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

public class UnObjet extends JPanel implements ActionListener{

	protected String sonNom;
	protected String saDesc;
	protected float sonPoids;
	protected float sonPrix;
	protected JTextField sonChampNom;
	protected TextArea sonChampDesc;
	protected JTextField sonChampPoids;
	protected JTextField sonChampPrix;
	private JLabel sonLabelNom;
	private JLabel sonLabelDesc;
	private JLabel sonLabelPoids;
	private JLabel sonLabelPrix;
	protected JPanel lePanneauChamp;
	protected JPanel lePanneauLabel;
	protected JPanel lePanneauValid;
	protected JPanel lePanneauDesc;
	protected JPanel lePanneauLabelDesc;
	protected JPanel lePanneauAlpha;
	protected PrintWriter lEcrivain;
	protected JDialog laFenetre;

	UnObjet(){//constructeur objet sans arguments
		super();
	}
	UnObjet(String telNom){
		try{
		BufferedReader leLecteur = new BufferedReader(new FileReader(new File("Objets/"+telNom+".jay")));

			sonNom = leLecteur.readLine();
			sonPoids = Float.parseFloat(leLecteur.readLine());
			sonPrix = Float.parseFloat(leLecteur.readLine());
			String laLigne=leLecteur.readLine();
			saDesc="";
			while(!laLigne.equals("finDesc")){
				saDesc+=laLigne+"\n";
				laLigne=leLecteur.readLine();
			}
		leLecteur.close();
		}
		catch (Exception lException) { JOptionPane.showMessageDialog(null,"Une erreur est survenue"); }//catch
	}//chargeToi

	//accesseurs
	public String getsonNom(){return sonNom;}
	public void setsonNom(String telNom){sonNom=telNom;}
	public String getsaDesc(){return saDesc;}
	public void setsaDesc(String telleDesc){saDesc=telleDesc;}
	public float getsonPoids(){return sonPoids;}
	public void setsonPoids(float telPoids){sonPoids=telPoids;}
	public float getsonPrix(){return sonPrix;}
	public void setsonPrix(float telPrix){sonPrix=telPrix;}

	//fonction relative à l'action (clique) faite sur le bouton.
	public void actionPerformed(ActionEvent telleAction){

		try{
			sonNom=sonChampNom.getText();
			saDesc=sonChampDesc.getText();
			sonPoids=Float.parseFloat(sonChampPoids.getText());
			sonPrix=Float.parseFloat(sonChampPrix.getText());
		}catch (NumberFormatException lException){
			JOptionPane.showMessageDialog(null,"Un des champs Numérique est mal rempli et c'est pas bien ça...non pas bien!");
		}
		enregistreToi();
		JOptionPane.showMessageDialog(null,"Enregistrement éffectué!");
	}
	public void enregistreToi(){
	    	try{
    		lEcrivain = new PrintWriter(new FileWriter(new File("Objets/"+sonChampNom.getText()+".jay")));
			lEcrivain.println(sonNom);
			lEcrivain.println(sonPoids);
			lEcrivain.println(sonPrix);
			lEcrivain.println(saDesc);
			lEcrivain.println("finDesc");
			lEcrivain.close();
			}catch(Exception lException){
			System.err.print("une erreur est survenue");}//catch
	}//enregistreToi

	public void chargeToi(String telNom){
		try{
		BufferedReader leLecteur = new BufferedReader(new FileReader(new File("Objets/"+telNom+".jay")));

			sonNom = leLecteur.readLine();
			sonPoids = Float.parseFloat(leLecteur.readLine());
			sonPrix = Float.parseFloat(leLecteur.readLine());
			String laLigne=leLecteur.readLine();
			saDesc="";
			while(!laLigne.equals("finDesc")){
				saDesc+=laLigne+"\n";
				laLigne=leLecteur.readLine();
			}
		leLecteur.close();
		}
		catch (Exception lException) { JOptionPane.showMessageDialog(null,"Une erreur est survenue"); }//catch
		afficheToi();
	}//chargeToi
	public JPanel afficheToi(){
		lePanneauChamp = new JPanel(new GridLayout(0,1));//création d'un panneau dédié aux champs
		lePanneauLabel = new JPanel(new GridLayout(0,1));//création d'un panneau dédié aux labels
		lePanneauDesc = new JPanel(new GridLayout(0,1));//création d'un panneau dédié à la description
		//lePanneauLabelDesc = new JPanel(new GridLayout(0,1));//création d'un panneau dédié au label de la descritpion
		lePanneauAlpha=new JPanel(new GridLayout(0,2));//création d'un panneau destiné à recevoir les labels et les champs.

		sonChampNom = new JTextField(10);//initialisation d'un champ texte avec JTextDield
		sonChampDesc = new TextArea("",5,5,1);
		sonChampPoids = new JTextField(10);
		sonChampPrix = new JTextField(10);

		sonLabelNom= new JLabel("Nom");//Initialisation des labels, c'est à dire des intitulés des champs
		sonLabelPoids= new JLabel("Poids");
		sonLabelPrix= new JLabel("Prix");
		//sonLabelDesc= new JLabel("Description");

		sonLabelNom.setLabelFor(sonChampNom);//assignation des labels aux champs correspondants
		sonLabelPoids.setLabelFor(sonChampPoids);
		sonLabelPrix.setLabelFor(sonChampPrix);
		//sonLabelDesc.setLabelFor(sonChampDesc);

		lePanneauChamp.add(sonChampNom);//ajout des champs dans le panneau dédié aux champs
		lePanneauChamp.add(sonChampPoids);
		lePanneauChamp.add(sonChampPrix);

		lePanneauLabel.add(sonLabelNom);//ajout des labels au panneau dédié aux labels.
		lePanneauLabel.add(sonLabelPoids);
		lePanneauLabel.add(sonLabelPrix);

		lePanneauDesc.add(sonChampDesc);
		//lePanneauLabelDesc.add(sonLabelDesc);

		// création du bouton "valider"

		JButton leValideur = new JButton("Valider");//initialisation du bouton pour valider avec JButton
		lePanneauValid = new JPanel(new GridBagLayout());
		lePanneauValid.add(leValideur);
		leValideur.addActionListener(this);

		// On réunis les 3 panneaux dans la fenêtre
		lePanneauAlpha.add(lePanneauLabel,BorderLayout.NORTH);
		lePanneauAlpha.add(lePanneauChamp,BorderLayout.NORTH);
		//lePanneauAlpha.add(lePanneauLabelDesc,BorderLayout.SOUTH);
		lePanneauAlpha.add(lePanneauValid,BorderLayout.SOUTH);
		lePanneauAlpha.add(lePanneauDesc,BorderLayout.SOUTH);
		add(lePanneauAlpha);
		//add(lePanneauValid);
	   	sonChampNom.setText(sonNom);
	   	sonChampPoids.setText(Float.toString(sonPoids));
	   	sonChampPrix.setText(Float.toString(sonPrix));
	   	sonChampDesc.setText(saDesc);
	   	updateUI();
	   	return lePanneauAlpha;
    }//Affiche

	public JDialog consulteToi(JFrame lePere){
		
		laFenetre = new JDialog (lePere,true);
		laFenetre.setTitle("Un Objet");
		laFenetre.setSize(400, 500);
		laFenetre.setLocation(200,150);
		laFenetre.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
		
		this.removeAll();
		
		lePanneauChamp = new JPanel(new GridLayout(0,1));//création d'un panneau dédié aux champs
		lePanneauLabel = new JPanel(new GridLayout(0,1));//création d'un panneau dédié aux labels
		lePanneauDesc = new JPanel(new GridLayout(0,1));//création d'un panneau dédié à la description
		lePanneauLabelDesc = new JPanel(new GridLayout(0,1));//création d'un panneau dédié au label de la descritpion
		lePanneauAlpha=new JPanel(new GridLayout(0,2));//création d'un panneau destiné à recevoir les labels et les champs.
		sonChampNom = new JTextField(10);//initialisation d'un champ texte avec JTextDield
		sonChampDesc = new TextArea("",5,5,1);
		sonChampPoids = new JTextField(10);
		sonChampPrix = new JTextField(10);

		sonLabelNom= new JLabel("Nom");//Initialisation des labels, c'est à dire des intitulés des champs
		sonLabelPoids= new JLabel("Poids");
		sonLabelPrix= new JLabel("Prix");
		sonLabelDesc= new JLabel("Description");

		sonLabelNom.setLabelFor(sonChampNom);//assignation des labels aux champs correspondants
		sonLabelPoids.setLabelFor(sonChampPoids);
		sonLabelPrix.setLabelFor(sonChampPrix);
		//sonLabelDesc.setLabelFor(sonChampDesc);

		lePanneauChamp.add(sonChampNom);//ajout des champs dans le panneau dédié aux champs
		lePanneauChamp.add(sonChampPoids);
		lePanneauChamp.add(sonChampPrix);

		lePanneauLabel.add(sonLabelNom);//ajout des labels au panneau dédié aux labels.
		lePanneauLabel.add(sonLabelPoids);
		lePanneauLabel.add(sonLabelPrix);

		lePanneauDesc.add(sonChampDesc);

		// On réunis les 3 panneaux dans la fenêtre
		lePanneauAlpha.add(lePanneauLabel,BorderLayout.NORTH);
		lePanneauAlpha.add(lePanneauChamp,BorderLayout.NORTH);
		lePanneauAlpha.add(lePanneauLabelDesc,BorderLayout.SOUTH);
		lePanneauAlpha.add(lePanneauDesc,BorderLayout.SOUTH);
		this.add(lePanneauAlpha);
		
		laFenetre.setContentPane(this);
		
		sonChampNom.setEditable(false);
		sonChampPoids.setEditable(false);
		sonChampPrix.setEditable(false);
		sonChampDesc.setEditable(false);

	   	sonChampNom.setText(sonNom);
	   	sonChampPoids.setText(Float.toString(sonPoids));
	   	sonChampPrix.setText(Float.toString(sonPrix));
	   	sonChampDesc.setText(saDesc);
	   	if(toString().equals("Objet"))
	   		laFenetre.setVisible(true);
	   	return laFenetre;
    }//ConsulteToi


    public String toString(){
		return "Objet";
	}
}