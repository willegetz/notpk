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

public class UnSort extends JPanel implements ActionListener{
	
	protected String sonNom;
	protected String saDesc;
	protected String sonType;
	protected JTextField sonChampNom;
	protected JTextArea sonChampDesc;
	protected JComboBox sonChampType;
	private JLabel sonLabelNom;
	private JLabel sonLabelType;
	private JPanel lePanneauNom;
	private JPanel lePanneauType;
	private JPanel lePanneauDesc;
	private JPanel lePanneauValid;
	private JPanel lePanneauAlpha;
	protected PrintWriter lEcrivain;
	private UnEditeurDonjon sonEditeur;

	UnSort(){
		super();
		saDesc="Description";
	}
	
	UnSort(String telNom){
		sonNom=telNom;
		String lire = new String();
		try{
		BufferedReader leLecteur = new BufferedReader(new FileReader(new File("bundll/sort.jay")));
			lire = leLecteur.readLine();
			while (!lire.equals(sonNom) && lire!=null){
				lire = leLecteur.readLine();
			}
			if (lire==null)
					JOptionPane.showMessageDialog(null, "Erreur, classe Non trouvé");
			sonNom = lire;
			sonType= leLecteur.readLine();
			String laLigne=leLecteur.readLine();
			saDesc="";
			while(!laLigne.equals("finSort")){
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
		public String getsonType(){return sonType;}
		public void setsonType(String telType){sonType=telType;}

		public void actionPerformed(ActionEvent telleAction){

		try{
			sonNom=sonChampNom.getText();
			saDesc=sonChampDesc.getText();
			sonType=(String)sonChampType.getSelectedItem();
			
		}catch (Exception lException){
			JOptionPane.showMessageDialog(null,"Un des champs est mal rempli et c'est pas bien ça...non pas bien!");
		}
		enregistreToi();
		JOptionPane.showMessageDialog(null,"Enregistrement éffectué!");
		removeAll();
		updateUI();
	}

	public void enregistreToi(){
	    if (sonChampNom.getText()!=""){
	    	try{
    		lEcrivain = new PrintWriter(new FileWriter(new File("bundll/sort.jay"),true));
			
			lEcrivain.println(sonNom);
			lEcrivain.println(sonType);
			lEcrivain.println(saDesc);
			lEcrivain.println("finSort");
			lEcrivain.close();
			lEcrivain = new PrintWriter(new FileWriter(new File("bundll/sortliste.jay"),true));
			lEcrivain.println(sonNom);
			lEcrivain.close();
			}catch(Exception lException){
			System.err.print("une erreur est survenue");}//catch
		}else{JOptionPane.showMessageDialog(null,"Il faut saisir un nom!");
		}
	}//enregistreToi

	public void chargeToi(String telNom){
		sonNom=telNom;
		String lire = new String();
		try{
		BufferedReader leLecteur = new BufferedReader(new FileReader(new File("bundll/sort.jay")));
			lire = leLecteur.readLine();
			while (!lire.equals(sonNom) && lire!=null){
				lire = leLecteur.readLine();
			}
			if (lire==null)
					JOptionPane.showMessageDialog(null, "Erreur, classe Non trouvé");
			sonNom = lire;
			sonType= leLecteur.readLine();
			String laLigne=leLecteur.readLine();
			saDesc="";
			while(!laLigne.equals("finSort")){
				saDesc+=laLigne+"\n";
				laLigne=leLecteur.readLine();
			}

		leLecteur.close();
		}
		catch (Exception lException) { JOptionPane.showMessageDialog(null,"Une erreur est survenue, vérifiez le nom de la créature"); }//catch
		afficheToi();
	}//chargeToi
	public JDialog consulteToi(UnEditeurDonjon telEditeur){

		sonEditeur = telEditeur;
		JDialog laFenetre = new JDialog (telEditeur,"Un sort",true);
		laFenetre.setSize(400, 300);
		laFenetre.setLocation(200,150);
		
		lePanneauNom = new JPanel();//création d'un panneau dédié au nom
		lePanneauType = new JPanel();
		lePanneauDesc = new JPanel();
		//lePanneauAlpha = new JPanel(new GridLayout(0,1));
		//JPanel[] leTabPanneau = new JPanel[3];
		
		sonChampNom = new JTextField(30);
		sonChampType = new JComboBox();
		sonChampDesc = new JTextArea(saDesc,7,22);
		sonChampDesc.setLineWrap(true);
		sonChampDesc.setWrapStyleWord(true);
		
		sonChampType.addItem("Abjuration");
		sonChampType.addItem("Divination");
		sonChampType.addItem("Enchantement");
		sonChampType.addItem("évocation");
		sonChampType.addItem("Invocation");
		sonChampType.addItem("Illusion");
		sonChampType.addItem("Nécromancie");
		sonChampType.addItem("Transmutation");

		//Initialisation des labels, c'est à dire des intitulés des champs
		sonLabelNom= new JLabel("Nom");
		sonLabelType= new JLabel("Type");

		//assignation des labels aux champs correspondants
		sonLabelNom.setLabelFor(sonChampNom);
		sonLabelType.setLabelFor(sonChampType);

		//ajout des champs dans le panneau dédié aux champs
		
		lePanneauNom.add(sonLabelNom);
		lePanneauNom.add(sonChampNom);
		lePanneauType.add(sonLabelType);
		lePanneauType.add(sonChampType);
		lePanneauDesc.add(new JScrollPane(sonChampDesc));

		this.add(lePanneauNom);
		this.add(lePanneauType);
		this.add(lePanneauDesc);
		if (sonEditeur.getsonMode() == UnEditeurDonjon.JOUER)
		{
			JPanel lePanneauInter = new JPanel();
			JButton leBouton = new JButton("editer des stats");
			leBouton.addActionListener(new ActionListener()
			{
				public void actionPerformed(ActionEvent lEvt)
				{
					Object[] lesCreatures = sonEditeur.getsaCarte().getsesCreatures().toArray();
					UneCreature leChoixCrea = (UneCreature)JOptionPane.showInputDialog(null, "Quel personnage modifie-t-on?", "Edition Personnage", JOptionPane.QUESTION_MESSAGE, null, lesCreatures, lesCreatures[0]);
					JDialog leDial = new JDialog(sonEditeur, "Editer stat", true);
					leDial.setContentPane(leChoixCrea.editeTesStats());
					leDial.setSize(300, 300);
					leDial.setVisible(true);
				}
			});
			lePanneauInter.add(leBouton);
			this.add(lePanneauInter);
		}
		
		laFenetre.setContentPane(this);
								
		sonChampNom.setText(sonNom);
		sonChampType.setSelectedItem(sonType);
	    sonChampDesc.setText(saDesc);
	    
	    sonChampNom.setEditable(false);
	    sonChampType.setEnabled(false);
	    sonChampDesc.setEditable(false);
	    
	    //leTabPanneau[0]=lePanneauLabel;
		//leTabPanneau[1]=lePanneauChamp;
		//leTabPanneau[3]=lePanneauValid;
		updateUI();

		laFenetre.setVisible(true);
	    return laFenetre;
    }//Affiche
    
    	public JPanel afficheToi(){
		
		
		lePanneauNom = new JPanel();//création d'un panneau dédié au nom
		lePanneauType = new JPanel();
		lePanneauDesc = new JPanel();
		lePanneauAlpha = new JPanel(new GridLayout(0,1));
		//JPanel[] leTabPanneau = new JPanel[3];
		
		sonChampNom = new JTextField(30);
		sonChampType = new JComboBox();
		sonChampDesc = new JTextArea(saDesc,7,22);
		sonChampDesc.setLineWrap(true);
		sonChampDesc.setWrapStyleWord(true);
		
		sonChampType.addItem("Abjuration");
		sonChampType.addItem("Divination");
		sonChampType.addItem("Enchantement");
		sonChampType.addItem("évocation");
		sonChampType.addItem("Invocation");
		sonChampType.addItem("Illusion");
		sonChampType.addItem("Nécromancie");
		sonChampType.addItem("Transmutation");
		
		//Initialisation des labels, c'est à dire des intitulés des champs
		sonLabelNom= new JLabel("Nom");
		sonLabelType= new JLabel("Type");

		//assignation des labels aux champs correspondants
		sonLabelNom.setLabelFor(sonChampNom);
		sonLabelType.setLabelFor(sonChampType);
		
		JButton leValideur = new JButton("Valider");//initialisation du bouton pour valider avec JButton
		lePanneauValid = new JPanel(new GridBagLayout());
		lePanneauValid.add(leValideur);
		leValideur.addActionListener(this);


		//ajout des champs dans le panneau dédié aux champs
		
		lePanneauNom.add(sonLabelNom);
		lePanneauNom.add(sonChampNom);
		lePanneauType.add(sonLabelType);
		lePanneauType.add(sonChampType);
		lePanneauDesc.add(new JScrollPane(sonChampDesc));		
		
		lePanneauAlpha.add(lePanneauNom);
		lePanneauAlpha.add(lePanneauType);
		lePanneauAlpha.add(lePanneauDesc);
		lePanneauAlpha.add(lePanneauValid,BorderLayout.SOUTH);
		
		add(lePanneauAlpha);
								
		sonChampNom.setText(sonNom);
		sonChampType.setSelectedItem(sonType);
	    sonChampDesc.setText(saDesc);
	    //leTabPanneau[0]=lePanneauLabel;
		//leTabPanneau[1]=lePanneauChamp;
		//leTabPanneau[3]=lePanneauValid;
		updateUI();
		
		    
	    return lePanneauAlpha;
    }//Affiche
    
    public static Vector donneTesSorts() {
		Vector<String> laListeSorts = new Vector<String>();
		try{
			BufferedReader leLecteur = new BufferedReader(new FileReader(new File("bundll/sortliste.jay")));
			String laLigne = leLecteur.readLine();
			while (laLigne != null){
				laListeSorts.add(laLigne);
				laLigne = leLecteur.readLine();
			}//while
			leLecteur.close();
		}catch (Exception lException){
			JOptionPane.showMessageDialog(null, "une erreur de chargement de sort.jay");
		}
		return laListeSorts;
	}//donneTesSorts
    
    public String toString(){
    	return "Sort";
    }
    
    public void lancer(UneCreature lanceur, UneCreature cible, UnSort sortLancer){
    	
    	JOptionPane.showMessageDialog(null,lanceur.getsonNom()+" a lancé "+sortLancer.getsonNom()+" sur "+cible.getsonNom()+".Effet : "+sortLancer.getsaDesc());
    	
    	}
}