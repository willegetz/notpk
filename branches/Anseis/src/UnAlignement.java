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

/**
 * Alignement d'une créature
 */
public class UnAlignement extends JPanel{
	private String sonLibelle;
	private String saDesc="";
	
	private JTextField sonChampLibelle;
	private JTextArea sonChampDesc;
	
	private JLabel sonLabelLibelle;
	
	private JPanel PanoField;
	private JPanel PanoLabel;

    /**
     * constructeur pour accéder aux alignements existant
     * @param telNom alignement recherché
     */
    public UnAlignement(String telNom) {
    		super();
    		sonLibelle=telNom;
    		String lire = new String();
    		try{
				BufferedReader leLecteur= new BufferedReader(new FileReader(new File("bundll/alignement.jay")));
				lire = leLecteur.readLine();
				while (!lire.equals(sonLibelle) && lire!=null){
					lire = leLecteur.readLine();
				}
				if (lire==null)
						JOptionPane.showMessageDialog(null, "Erreur, alignement Non trouvé");
				sonLibelle = lire;
				lire=leLecteur.readLine();	
				while (!lire.equals("finsonAlign;")){
					saDesc = saDesc+lire+"\n";
					lire=leLecteur.readLine();
				}//while	
				
			}//try
			catch (Exception lException) { 
				JOptionPane.showMessageDialog(null,"Une erreur est survenue, dans la classe Alignement lors du chargement"); }//catch
			
		}//constructeur
		
    /**
     * affiche les caractéristiques de l'alignement
     * @return fenêtre avec les infos
     */
	public JDialog afficheToi(){
		JDialog leDialog = new JDialog();
		leDialog.setTitle("Descriptif de l'alignement");
		leDialog.setSize(350,350);
		leDialog.setLocation(250,150);
		leDialog.setResizable(false);
		
		sonChampLibelle = new JTextField(20);
		sonChampLibelle.setText(sonLibelle);
		sonChampLibelle.setFocusable(false);



		sonChampDesc = new JTextArea(18,30);
		sonChampDesc.setText(saDesc);
		sonChampDesc.setFocusable(false);
		sonChampDesc.setLineWrap(true);//on vas à la ligne quand c'est trop grand
		sonChampDesc.setWrapStyleWord(true);//on ne coupe pas les mots en allant à la ligne

				
		PanoLabel = new JPanel();
		sonLabelLibelle = new JLabel("Nom de l'alignement");
		sonLabelLibelle.setLabelFor(sonChampLibelle);
		PanoLabel.add(sonLabelLibelle);
		PanoLabel.add(sonChampLibelle);
			
			
		this.add(PanoLabel);
		this.add(new JScrollPane(sonChampDesc));
		leDialog.setContentPane(this);
		return leDialog;
		}//afficheToi
    
}//UnAlignement