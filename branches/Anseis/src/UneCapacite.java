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


public class UneCapacite extends JPanel implements ActionListener{
	
	protected String sonNom;
	protected String saDesc;
	protected JTextField sonChampNom;
	protected JTextArea sonChampDesc;
	private JLabel sonLabelNom;
	private JLabel sonLabelDesc;
	private JPanel lePanneauNom;
	private JPanel lePanneauDesc;
	private JPanel lePanneauValid;
	private JPanel lePanneauAlpha;
	protected PrintWriter lEcrivain;

	UneCapacite(){
		super();
		saDesc="Description";
	}
	
	UneCapacite(String telNom){
		sonNom=telNom;
		String lire = new String();
		try{
		BufferedReader leLecteur = new BufferedReader(new FileReader(new File("bundll/capacite.jay")));
			lire = leLecteur.readLine();
			while (!lire.equals(sonNom) && lire!=null){
				lire = leLecteur.readLine();
			}
			if (lire==null)
					JOptionPane.showMessageDialog(null, "Erreur, classe Non trouvé");
			sonNom = lire;
			String laLigne=leLecteur.readLine();
			saDesc="";
			while(!laLigne.equals("finCapacite")){
				saDesc+=laLigne+"\n";
				laLigne=leLecteur.readLine();
			}
		leLecteur.close();
		}
		catch (Exception lException) { JOptionPane.showMessageDialog(null,"Une erreur est survenue, vérifiez le nom de la créature"); }//catch

	}//chargeToi

		//Accesseurs

		//accesseurs

		public String getsonNom(){return sonNom;}
		public void setsonNom(String telNom){sonNom=telNom;}
		public String getsaDesc(){return saDesc;}
		public void setsaDesc(String telleDesc){saDesc=telleDesc;}

	public void actionPerformed(ActionEvent telleAction){

		try{
			sonNom=sonChampNom.getText();
			saDesc=sonChampDesc.getText();
			
		}catch (Exception lException){
			JOptionPane.showMessageDialog(null,"Un des champs est mal rempli et c'est pas bien ça...non pas bien!");
		}
		enregistreToi();
		JOptionPane.showMessageDialog(null,"Enregistrement éffectué!");
		removeAll();
		updateUI();
	}

	public void enregistreToi(){
	    	try{
    		lEcrivain = new PrintWriter(new FileWriter(new File("bundll/capacite.jay"),true));
			
			lEcrivain.println(sonNom);
			lEcrivain.println(saDesc);
			lEcrivain.println("finCapacite");
			lEcrivain.close();
			lEcrivain = new PrintWriter(new FileWriter(new File("bundll/capaciteliste.jay"),true));
			lEcrivain.println(sonNom);
			lEcrivain.close();
			}catch(Exception lException){
			System.err.print("une erreur est survenue");}//catch
	}//enregistreToi

	public void chargeToi(String telNom){
		sonNom=telNom;
		String lire = new String();
		try{
		BufferedReader leLecteur = new BufferedReader(new FileReader(new File("bundll/capacite.jay")));
			lire = leLecteur.readLine();
			while (!lire.equals(sonNom) && lire!=null){
				lire = leLecteur.readLine();
			}
			if (lire==null)
					JOptionPane.showMessageDialog(null, "Erreur, classe Non trouvé");
			sonNom = lire;
			String laLigne=leLecteur.readLine();
			saDesc="";
			while(!laLigne.equals("finCapacite")){
				saDesc+=laLigne+"\n";
				laLigne=leLecteur.readLine();
			}

		leLecteur.close();
		}
		catch (Exception lException) { JOptionPane.showMessageDialog(null,"Une erreur est survenue, vérifiez le nom de la créature"); }//catch
		afficheToi();
	}//chargeToi
	public JPanel afficheToi(){
		
		
		lePanneauNom = new JPanel();//création d'un panneau dédié au nom
		lePanneauDesc = new JPanel();
		lePanneauAlpha = new JPanel(new GridLayout(0,1));
		//JPanel[] leTabPanneau = new JPanel[3];
		
		sonChampNom = new JTextField(10);
		sonChampDesc = new JTextArea(saDesc,7,22);
		sonChampDesc.setLineWrap(true);
		sonChampDesc.setWrapStyleWord(true);

		//Initialisation des labels, c'est à dire des intitulés des champs
		sonLabelNom= new JLabel("Nom");
		sonLabelDesc= new JLabel("Desciption");

		//assignation des labels aux champs correspondants
		sonLabelNom.setLabelFor(sonChampNom);
		sonLabelDesc.setLabelFor(sonChampDesc);
		
		JButton leValideur = new JButton("Valider");//initialisation du bouton pour valider avec JButton
		lePanneauValid = new JPanel(new GridBagLayout());
		lePanneauValid.add(leValideur);
		leValideur.addActionListener(this);


		//ajout des champs dans le panneau dédié aux champs
		
		lePanneauNom.add(sonLabelNom);
		lePanneauNom.add(sonChampNom);
		lePanneauDesc.add(new JScrollPane(sonChampDesc));		
		
		lePanneauAlpha.add(lePanneauNom);
		lePanneauAlpha.add(lePanneauDesc);
		lePanneauAlpha.add(lePanneauValid,BorderLayout.SOUTH);
		
		add(lePanneauAlpha);
								
		sonChampNom.setText(sonNom);
	    sonChampDesc.setText(saDesc);
	    //leTabPanneau[0]=lePanneauLabel;
		//leTabPanneau[1]=lePanneauChamp;
		//leTabPanneau[3]=lePanneauValid;
		updateUI();
		
		    
	    return lePanneauAlpha;
    }//Affiche
    
    public JDialog consulteToi(){
		
		JDialog laFenetre = new JDialog ();
		laFenetre.setTitle("Une capacité");
		laFenetre.setSize(400, 500);
		laFenetre.setLocation(200,150);
		laFenetre.setVisible(true);
		lePanneauNom = new JPanel();//création d'un panneau dédié au nom
		lePanneauDesc = new JPanel();
		
		sonChampNom = new JTextField(10);
		sonChampDesc = new JTextArea(saDesc,7,22);
		sonChampDesc.setLineWrap(true);
		sonChampDesc.setWrapStyleWord(true);

		//Initialisation des labels, c'est à dire des intitulés des champs
		sonLabelNom= new JLabel("Nom");
		sonLabelDesc= new JLabel("Desciption");

		//assignation des labels aux champs correspondants
		sonLabelNom.setLabelFor(sonChampNom);
		sonLabelDesc.setLabelFor(sonChampDesc);
		
		//ajout des champs dans le panneau dédié aux champs
		
		lePanneauNom.add(sonLabelNom);
		lePanneauNom.add(sonChampNom);
		lePanneauDesc.add(new JScrollPane(sonChampDesc));		
		
		this.add(lePanneauNom);
		this.add(lePanneauDesc);
		
		laFenetre.setContentPane(this);
								
		sonChampNom.setText(sonNom);
	    sonChampDesc.setText(saDesc);
	    
		sonChampNom.setEditable(false);
		sonChampDesc.setEditable(false);
		updateUI();
		
		    
	    return laFenetre;
    }//Affiche
    
    public static Vector donneTesCapacite() {
		Vector<String> laListeCapacite = new Vector<String>();
		try{
			BufferedReader leLecteur = new BufferedReader(new FileReader(new File("bundll/capaciteliste.jay")));
			String laLigne = leLecteur.readLine();
			while (laLigne != null){
				laListeCapacite.add(laLigne);
				laLigne = leLecteur.readLine();
			}//while
			leLecteur.close();
		}catch (Exception lException){
			JOptionPane.showMessageDialog(null, "une erreur de chargement de capaciteliste.jay");
		}
		return laListeCapacite;
	}//donneTesSorts

    
    public String toString(){
    	return "Capacite";
    }
}