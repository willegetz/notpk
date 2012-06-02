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
import java.awt.*;
import java.awt.event.*;
import java.lang.Integer;
import javax.swing.*;

public class UneRace extends JPanel{
	private String sonLibelle;
	private String sonType;
	private String saCapacite;
	
	private JTextField sonChampLibelle;
	private JTextField sonChampType;
	private JTextArea sonChampCapacite;
	
	private JLabel sonLabelLibelle;
	private JLabel sonLabelType;
	private JLabel sonLabelCapacite;
	
	private JPanel PanoField;
	private JPanel PanoLabel;
	
    /**
     * Constructeur permettant la création
     */
	public UneRace(){
                super(new BorderLayout());
		sonLibelle="";
		sonType="";
		saCapacite="";	
	}


    /**
     * Constructeur permettant la consultation
     * @param telNom nom de la race à charger
     */
    public UneRace(String telNom) {
    		super(new BorderLayout());
    	sonLibelle=telNom;
    		String lire = new String();
    		try{
				BufferedReader leLecteur= new BufferedReader(new FileReader(new File("bundll/race.jay")));
				lire = leLecteur.readLine();
				while (!lire.equals(sonLibelle) && lire!=null){
					lire = leLecteur.readLine();
				}
				if (lire==null)
						JOptionPane.showMessageDialog(null, "Erreur, race Non trouvé");
				sonLibelle = lire;		
				sonType = leLecteur.readLine();
				saCapacite="";
				lire=leLecteur.readLine();
				while (!lire.equals("finRace")){
					saCapacite += lire+"\n";
					lire=leLecteur.readLine();
				}
				leLecteur.close();					
			}//try
			catch (Exception lException) { 
				JOptionPane.showMessageDialog(null,"Une erreur est survenue, dans la classe Race lors du chargement"); }//catch
			
		}//constructeur
		
    /**
     * méthode d'enregistrement
     */
	public void enregistreToi(){
		PrintWriter lEcrivain;
	    	try{
    		lEcrivain = new PrintWriter(new FileWriter(new File("bundll/race.jay"),true));
			lEcrivain.println(sonLibelle);
			lEcrivain.println(sonType);
			lEcrivain.println(saCapacite);
			lEcrivain.println("finRace");
			lEcrivain.close();
			lEcrivain = new PrintWriter(new FileWriter(new File("bundll/raceliste.jay"),true));
			lEcrivain.println(sonLibelle);
			lEcrivain.close();
                        JOptionPane.showMessageDialog(null,"Enregistrement effectué avec succès","Enregistrement",JOptionPane.INFORMATION_MESSAGE);
                        removeAll();
                        updateUI();
			}catch(Exception lException){
			System.err.print("une erreur est survenue");}//catch
	}//enregistreToi
		
    /**
     * méthode de consultation
     * @return renvoie une JDialog affichant les paramètres de la race
     */
	public JDialog afficheToi(){
		JDialog leDialog = new JDialog();
		leDialog.setTitle("Descriptif de Race");
		leDialog.setSize(360,200);
		leDialog.setLocation(250,150);
		sonChampLibelle = new JTextField(25);
		sonChampLibelle.setText(sonLibelle);
		
		sonChampType = new JTextField();
		sonChampType.setText(sonType);
		
		sonChampCapacite = new JTextArea(saCapacite,5,20);
		sonChampCapacite.setLineWrap(true);
		sonChampCapacite.setWrapStyleWord(true);
		
		JScrollPane leScroll= new JScrollPane(sonChampCapacite);
			
			
		PanoField = new JPanel(new GridLayout(0,1));
		PanoField.add(sonChampLibelle);
		PanoField.add(sonChampType);
		PanoField.add(leScroll);
		
		sonChampLibelle.setFocusable(false);
		sonChampType.setFocusable(false);
		sonChampCapacite.setFocusable(false);
			
		PanoLabel = new JPanel(new GridLayout(0,1));
		sonLabelLibelle = new JLabel("Nom de Race");
		sonLabelLibelle.setLabelFor(sonChampLibelle);
		PanoLabel.add(sonLabelLibelle);
		sonLabelType = new JLabel("Type");
		sonLabelType.setLabelFor(sonChampType);
		PanoLabel.add(sonLabelType);
		sonLabelCapacite = new JLabel("Capacité");
		sonLabelCapacite.setLabelFor(sonChampCapacite);
		PanoLabel.add(sonLabelCapacite);
			
			
		this.add(PanoLabel,BorderLayout.WEST);
		this.add(PanoField,BorderLayout.LINE_END);
		leDialog.setContentPane(this);
		return leDialog;
		}//afficheToi
		
    /**
     * Méthode permettant d'afficher le formulaire de création
     * @return retourne un JPanel contenant les différents champs à éditer.
     */
	public JPanel creeToi(){
		afficheToi();
		sonChampLibelle.setFocusable(true);
		sonChampType.setFocusable(true);
		sonChampCapacite.setFocusable(true);
		
                
		JButton sonValideur=new JButton("Valider");
		sonValideur.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e){
				sonLibelle=sonChampLibelle.getText();
				sonType=sonChampType.getText();
				saCapacite=sonChampCapacite.getText();
				enregistreToi();
			}
		});
		JPanel lePanneau = new JPanel();
                lePanneau.add(sonValideur);
		this.add(lePanneau, BorderLayout.SOUTH);
                this.setSize(280,200);
		return this;
	}//afficheToi
    
}//UneRace