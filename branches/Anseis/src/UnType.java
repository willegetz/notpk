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
import javax.swing.*;
import java.util.Vector;
import java.nio.channels.FileChannel;

public class UnType extends JPanel implements ActionListener{

	//variables d'utilisation
	private String sonNom;
	private String sonImage;
	private int sonFranchissement;//0 : infranchissable, 1 : avec des difficultés(expliquées sur la description de la case normalement), 2 : franchissable
	private String sonPourquoi;

	//variables nécessaires pour le panneau
	private JTextField sonChampNom;
	private JTextField sonChampImage;
	private JRadioButton sonOptionRadio1;
	private JRadioButton sonOptionRadio2;
	private JRadioButton sonOptionRadio3;
	private JFileChooser sonSelectionneurDeFichier;
	private File sonFichier;

	UnType(String telNom){
		//constructeur appelé quand on doit charger à partir du fichier, on connait juste le nom
		try{
			BufferedReader leLecteur = new BufferedReader(new FileReader(new File("bundll/types.jay")));
			String laLigne = leLecteur.readLine();
			while ( !(telNom.equalsIgnoreCase(laLigne)) && (laLigne != null)){
				laLigne = leLecteur.readLine();
			}
			if (laLigne == null){
				//le type n'est pas trouvé : on crée un type par défaut, à changer par le lancement d'une exception
				sonImage = "blank.jpg";
				sonFranchissement = 0;
			}else{
				sonNom = telNom;
				sonImage = leLecteur.readLine();
				laLigne = leLecteur.readLine();
				if (laLigne.split(":")[0].equals("1"))
					sonPourquoi = laLigne.split(":")[1];
				else
					sonPourquoi = null;
				sonFranchissement = Integer.parseInt(laLigne.split(":")[0]);
			}
			leLecteur.close();
		}
		catch (Exception lException) { JOptionPane.showMessageDialog(null, "une erreur de chargement"); }

	}

	UnType(){
		//constructeur de base, création d'un type de case
		super(new GridLayout(0,1));
		creerLesPanneaux();
	}

	private void creerLesPanneaux() {
		//permettra de refaire le panneau dans un autre constructeur en cas de besoin
		
		//outil de sélection de fichier : initialisation et création de filtres (on ne peut pas mettre n'importe quoi)
		sonSelectionneurDeFichier = new JFileChooser();
		sonSelectionneurDeFichier.setAcceptAllFileFilterUsed(false);
		//filtre jpeg
		sonSelectionneurDeFichier.addChoosableFileFilter(new javax.swing.filechooser.FileFilter()
		{
			public boolean accept(File telFic)
			{
				String lExtension = telFic.getName().substring((telFic.getName().lastIndexOf(".") + 1));
				if (((lExtension.equals("jpg") || lExtension.equals("JPG") || lExtension.equals("jpeg")) && (new ImageIcon(telFic.getAbsolutePath()).getIconWidth() == 40) && (new ImageIcon(telFic.getAbsolutePath()).getIconHeight() == 40) )|| lExtension.equals(telFic.getName()))
					return true;

				else
					return false;
			}

			public String getDescription() { return "Images JPEG 40x40(*.jpg, *.jpeg, *.JPG)"; }
		});
		//filtre gif
		sonSelectionneurDeFichier.addChoosableFileFilter(new javax.swing.filechooser.FileFilter()
		{
			public boolean accept(File telFic)
			{
				String lExtension = telFic.getName().substring((telFic.getName().lastIndexOf(".") + 1));
				if (((lExtension.equals("gif") || lExtension.equals("GIF")) && (new ImageIcon(telFic.getAbsolutePath()).getIconWidth() == 40) && (new ImageIcon(telFic.getAbsolutePath()).getIconHeight() == 40)) || lExtension.equals(telFic.getName()))
					return true;
				else
					return false;
			}

			public String getDescription() { return "Images CompuServe GIF 40x40(*.gif, *.GIF)"; }
		});
		//filtre bmp
		sonSelectionneurDeFichier.addChoosableFileFilter(new javax.swing.filechooser.FileFilter()
		{
			public boolean accept(File telFic)
			{
				String lExtension = telFic.getName().substring((telFic.getName().lastIndexOf(".") + 1));
				if (((lExtension.equals("bmp") || lExtension.equals("BMP") )&& (new ImageIcon(telFic.getAbsolutePath()).getIconWidth() == 40) && (new ImageIcon(telFic.getAbsolutePath()).getIconHeight() == 40)) || lExtension.equals(telFic.getName()))
					return true;
				else
					return false;
			}

			public String getDescription() { return "Images Bitmap BMP 40x40(*.bmp,*.BMP)"; }
		});
		//filtre png
		sonSelectionneurDeFichier.addChoosableFileFilter(new javax.swing.filechooser.FileFilter()
		{
			public boolean accept(File telFic)
			{
				String lExtension = telFic.getName().substring((telFic.getName().lastIndexOf(".") + 1));
				if (((lExtension.equals("png") || lExtension.equals("PNG")) && (new ImageIcon(telFic.getAbsolutePath()).getIconWidth() == 40) && (new ImageIcon(telFic.getAbsolutePath()).getIconHeight() == 40)) || lExtension.equals(telFic.getName()))
					return true;
				else
					return false;
			}

			public String getDescription() { return "Images PNG 40x40(*.png, *.PNG)"; }
		});
		//filtre tout format suporté
		sonSelectionneurDeFichier.addChoosableFileFilter(new javax.swing.filechooser.FileFilter()
		{
			public boolean accept(File telFic)
			{
				String lExtension = telFic.getName().substring((telFic.getName().lastIndexOf(".") + 1));
				if (((lExtension.equals("jpg") || lExtension.equals("JPG") || lExtension.equals("jpeg") || lExtension.equals("png") || lExtension.equals("PNG") || lExtension.equals("bmp") || lExtension.equals("BMP") || lExtension.equals("gif") || lExtension.equals("GIF")) && (new ImageIcon(telFic.getAbsolutePath()).getIconWidth() == 40) && (new ImageIcon(telFic.getAbsolutePath()).getIconHeight() == 40)) || lExtension.equals(telFic.getName()))
					return true;
				else
					return false;
			}

			public String getDescription() { return "Tous les formats supportés 40x40"; }
		});

		//le nom
		JPanel lePanneau = new JPanel();
		sonChampNom = new JTextField(13);
		JLabel leLabel = new JLabel("Nom du type :  ");
		leLabel.setLabelFor(sonChampNom);
		lePanneau.add(leLabel);
		lePanneau.add(sonChampNom);
		add(lePanneau);

		//l'image
		lePanneau = new JPanel();
		sonChampImage = new JTextField(10);
		sonChampImage.setEditable(false);
		JButton leBouton = new JButton("Charger l'image");
		leBouton.addActionListener(this);
		lePanneau.add(sonChampImage);
		lePanneau.add(leBouton);
		add(lePanneau);

		//le franchissement
		lePanneau = new JPanel(new GridLayout(0,1));
		ButtonGroup leGroupeDeBouton = new ButtonGroup();
		sonOptionRadio1 = new JRadioButton("Infranchissable",true);
		leGroupeDeBouton.add(sonOptionRadio1);
		lePanneau.add(sonOptionRadio1);
		sonOptionRadio2 = new JRadioButton("Difficile à franchir");
		leGroupeDeBouton.add(sonOptionRadio2);
		lePanneau.add(sonOptionRadio2);
		sonOptionRadio3 = new JRadioButton("Franchissable");
		leGroupeDeBouton.add(sonOptionRadio3);
		lePanneau.add(sonOptionRadio3);
		add(lePanneau);

		//bouton valider
		leBouton = new JButton("Enregistrer");
		leBouton.addActionListener(this);
		lePanneau.add(leBouton);
		add(lePanneau);
	}

	public void actionPerformed(ActionEvent telleAction) {
		String laSource = telleAction.getActionCommand();
		//cas du bouton de chargement d'image
		if (laSource == "Charger l'image") {
			int leRetour = sonSelectionneurDeFichier.showOpenDialog(getParent());
			if (leRetour == JFileChooser.APPROVE_OPTION) {
				//Ouverture du fichier
			 	sonFichier = sonSelectionneurDeFichier.getSelectedFile();
				sonChampImage.setText(sonFichier.getName());
			}
		}

		//cas du bouton enregistrer
		if (laSource == "Enregistrer") {
			sonNom = sonChampNom.getText();
			sonImage = sonChampImage.getText();
			if (sonNom.equals("") || sonImage.equals("")){
				JOptionPane.showMessageDialog(null, "Un des champs est mal remplis, vérifiez votre saisie", "Erreur de saisie", JOptionPane.WARNING_MESSAGE);
			}else {
				if (!enregistreToi()){
					JOptionPane.showMessageDialog(null, "Une erreur est survenue lors de l'enregistrement, vérifiez si vous avez les droits d'écriture sur ce disque.", "Erreur d'enregistrement", JOptionPane.ERROR_MESSAGE);
				}
				else {
					removeAll();
					updateUI();
					JOptionPane.showMessageDialog(null, "Le type de terrain a été créé avec succès!\nVous pouvez ajouter les fichiers : \nperso_" + sonImage + "\ncoffre_" + sonImage + "\nperso_coffre_" + sonImage + "\nperso_evt_" + sonImage + "\ncoffre_evt_" + sonImage + "\nperso_coffre_evt_" + sonImage + "\nevt_"+sonImage+"\n dans le dossier \"img_type\" si vous le désirez.\nAidez vous du modèle dans les ressources si besoin est.", "Enregistrement terminé", JOptionPane.INFORMATION_MESSAGE);
				}
			}
		}
	}

	public String getsonImage() { return sonImage; }
	public String getsonNom() { return sonNom; }
	public int getsonFranchissement() { return sonFranchissement; }
	public String getsonPourquoi() { return sonPourquoi; }

	public String toString(){
		String laChaine = sonNom;
		if (sonFranchissement == 0)
			laChaine += "/ infranchissable";
		else if (sonFranchissement == 1)
			laChaine += "/ difficile";
		else if (sonFranchissement == 2)
			laChaine += "/ franchissable";
		return laChaine;
	}

	private boolean enregistreToi(){
		PrintWriter lEcrivain;
		String laDest = "./img_types/" + sonImage;
		if (!new File("./img_types").exists()) { new File("./img_types").mkdirs(); }
		try{
			//enregistrement de l'image
			FileChannel leFicSource = new FileInputStream(sonFichier).getChannel();
			FileChannel leFicDest = new FileOutputStream(laDest).getChannel();
			leFicSource.transferTo(0, leFicSource.size(), leFicDest);
			leFicSource.close();
			leFicDest.close();

			//enregistrement des valeurs
			lEcrivain = new PrintWriter(new FileWriter(new File("bundll/types.jay"), true));
			lEcrivain.println(sonNom);
			lEcrivain.println(sonImage);
			if (sonOptionRadio1.isSelected()) { lEcrivain.println("0:?"); }
			if (sonOptionRadio2.isSelected()) { 
				lEcrivain.println("1:"+JOptionPane.showInputDialog(null,"Vous avez choisis de rendre ce terrain difficile à franchir.\nVeuillez en indiquer la raison.","Demande de précision",JOptionPane.INFORMATION_MESSAGE)); 
			}
			if (sonOptionRadio3.isSelected()) { lEcrivain.println("2:?"); }
			lEcrivain.close();
			return true;

		}catch(Exception lException){
			return false;
		}
	}

	public static Vector donneTesTypes() {
		Vector<String> laListe = new Vector<String>();
		try
		{
			BufferedReader leLecteur = new BufferedReader(new FileReader(new File("bundll/types.jay")));
			String laLigne = leLecteur.readLine();
			int lIndice = 0;
			while (laLigne != null){

				if (lIndice % 3 == 0 || lIndice == 0){
					//tout les titres de types sont dans des indices multiples de 3.
					laListe.add(laLigne);
				}
				laLigne = leLecteur.readLine();
				lIndice++;
			}
			leLecteur.close();
		}
		catch (Exception lException){
			laListe.add("Pas de Terrains existant");
		}
		return laListe;
	}

}
