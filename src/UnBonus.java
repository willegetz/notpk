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

public class UnBonus extends JPanel{
	
	private String sonNomCarac;
	private int saValeur;
	
	private JTextField sonChampNom;
	private JTextField sonChampValeur;
	
	private JLabel sonLabelNom;
	private JLabel sonLabelValeur;
	
	private JPanel PanoField;
	private JPanel PanoLabel;

    public UnBonus(String telNom) {
   		super(new BorderLayout());
   		
    		try{
				BufferedReader leLecteur= new BufferedReader(new FileReader(new File(telNom+".jay")));
				sonNomCarac = leLecteur.readLine();
				saValeur = Integer.parseInt(leLecteur.readLine());		
			}//try
			catch (Exception lException) { 
				JOptionPane.showMessageDialog(null,"Une erreur est survenue, dans la classe Bonus lors du chargement"); }//catch
		
		PanoField = new JPanel(new GridLayout(0,1));
		sonChampNom = new JTextField(10);
		sonChampNom.setText(sonNomCarac);
		sonChampValeur = new JTextField();
		sonChampValeur.setText(Integer.toString(saValeur));
		PanoField.add(sonChampNom);
		PanoField.add(sonChampValeur);
		
		PanoLabel = new JPanel(new GridLayout(0,1));
		sonLabelNom = new JLabel("Nom caractéristique");
		sonLabelNom.setLabelFor(sonChampNom);
		sonLabelValeur = new JLabel("Valeur");
		sonLabelValeur.setLabelFor(sonChampValeur);
		PanoLabel.add(sonLabelNom);
		PanoLabel.add(sonLabelValeur);		
		
		add(PanoField,BorderLayout.LINE_END);
		add(PanoLabel,BorderLayout.WEST);	
		
    }//constructeur
    
    
}//UnBonus