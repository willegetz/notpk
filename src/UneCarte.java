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

/**
 * Classe gérant toute les méthode liées à la carte, affichage, création, et lancement des combats...
 */
public class UneCarte extends JDialog implements ActionListener{

	private int sonX, sonY;
	private String sonNom, saDescription;
	private UnType sonType;
	private UneCase [][]sesCases;

	private JTextField sonChampNom, sonChampX, sonChampY;
	private JComboBox sonCombo;
	private JTextArea sonChampDesc;

	private UnEditeurDonjon sonEditeur;

	//vecteurs utiles pour le combat
	Vector<UnJoueur> lesJoueurs;
	Vector<UnNonJoueur> lesMonstres;
	Vector<String> lePassage;


	UneCarte(File telFichier,UnEditeurDonjon telEditeur ) {
		sonEditeur = telEditeur;
		//constructeur appelé quand on doit charger à partir du fichier
		//on lit le fichier ligne à ligne, en appelant les constructeurs qui conviennent en cas de besoin.
		try
		{
			BufferedReader leLecteur = new BufferedReader(new FileReader(telFichier));
			sonNom = leLecteur.readLine().split(":")[1];
			sonX = Integer.parseInt(leLecteur.readLine().split(":")[1]);
			sonY = Integer.parseInt(leLecteur.readLine().split(":")[1]);
			sesCases = new UneCase[sonY][sonX];
			sonType = new UnType(leLecteur.readLine().split(":")[1]);
			for (int i = 0; i < sonY; i++){
				for (int j = 0; j < sonX; j++){
					sesCases[i][j] = new UneCase(j, i, sonType, sonEditeur);
				}
			}
			saDescription = leLecteur.readLine().split(":")[1];
			String laLigne = leLecteur.readLine();
			while ((!laLigne.equals("FinDescCarte")) && (laLigne != null)){
				saDescription += "\n" + laLigne;
				laLigne = leLecteur.readLine();
			}
			//carte de base créée

			laLigne = leLecteur.readLine();
			while (laLigne != null){
				laLigne = laLigne.split(":")[1];
				int leX = Integer.parseInt(laLigne.split(",")[0]);
				int leY = Integer.parseInt(laLigne.split(",")[1]);
				sesCases[leY][leX].setsonType(new UnType(leLecteur.readLine().split(":")[1]));
				laLigne = leLecteur.readLine();
				if ((laLigne != null) && laLigne.split(":")[0].equals("    joueur ")){
					sesCases[leY][leX].setsonJoueur(new UnJoueur(laLigne.split(":")[1],sonEditeur));
					laLigne = leLecteur.readLine();
				}
				if ((laLigne != null) && laLigne.split(":")[0].equals("    pnj ")){
					sesCases[leY][leX].setsonNonJoueur(new UnNonJoueur(laLigne.split(":")[1],sonEditeur));
					laLigne = leLecteur.readLine();
				}
				int i=0;
				while ((laLigne!=null) && (laLigne.split(":")[0].equals("    objet " + i + " ")) ) {
					if(laLigne.split(":")[2].equals("Arme"))
						sesCases[leY][leX].addUnObjet(new UneArme(laLigne.split(":")[1]));
					if (laLigne.split(":")[2].equals("Armure"))
						sesCases[leY][leX].addUnObjet(new UneArmure(laLigne.split(":")[1]));
					if (laLigne.split(":")[2].equals("Consommable"))
						sesCases[leY][leX].addUnObjet(new UnConsommable(laLigne.split(":")[1]));
					if (laLigne.split(":")[2].equals("Objet"))
						sesCases[leY][leX].addUnObjet(new UnObjet(laLigne.split(":")[1]));
					i++;
					laLigne = leLecteur.readLine();
				}
				if((laLigne != null) && (laLigne.split(":")[0].equals("    description "))){
					String laChaine = laLigne.split(":")[1];
					laLigne = leLecteur.readLine();
					while ((!laLigne.equals("FinDescCase")) && (laLigne != null)){
						laChaine += "\n" + laLigne;
						laLigne = leLecteur.readLine();
					}
					laLigne = leLecteur.readLine();
					sesCases[leY][leX].setsaDescription(laChaine);
				}
				if ((laLigne != null) && (laLigne.split(":")[0].equals("    evenement"))) {
					String leNom = laLigne.split(":")[1];
					int laRepet = Integer.parseInt(laLigne.split(":")[2]);
					if(laLigne.split(":")[3].equals("dialogue")){
						String leTexte = laLigne.split(":")[4];
						for (int z = 5; z < laLigne.split(":").length; z++){
							leTexte += ":" + laLigne.split(":")[z];
						}
						String[] leTab = leTexte.split("\t");
						leTexte=leTab[0];
						for (int z=1;z<leTab.length;z++){
							leTexte+="\n"+leTab[z];
						}
						sesCases[leY][leX].setsonEvenement(new UnDialogue(sesCases[leY][leX],leNom,laRepet,leTexte));
					}
					else if (laLigne.split(":")[3].equals("piege")){
						int laZoneX = Integer.parseInt(laLigne.split(":")[4]);
						int laZoneY = Integer.parseInt(laLigne.split(":")[5]);
						int laResistance = Integer.parseInt(laLigne.split(":")[6]);
						String leType = laLigne.split(":")[7];
						String leDe = laLigne.split(":")[8];
						String laDesc = laLigne.split(":")[9];
						for (int z = 10; z < laLigne.split(":").length; z++){
							laDesc += ":" + laLigne.split(":")[z];
						}
						String[] leTab = laDesc.split("\t");
						laDesc = leTab[0];
						for (int z = 1; z < leTab.length; z++){
							laDesc += "\n" + leTab[z];
						}
						sesCases[leY][leX].setsonEvenement(new UnPiege(sesCases[leY][leX], leNom, laRepet, laZoneX,laZoneY,laDesc,laResistance,new UnDegat(leType,leDe)));
					}
                                        else if (laLigne.split(":")[3].equals("carte")){
                                            String leFic = laLigne.split(":")[4];
                                            if(!leFic.equals("null")){
                                                leFic += ":"+laLigne.split(":")[5];
                                                sesCases[leY][leX].setsonEvenement(new UneEntreeSortie(sesCases[leY][leX],leNom,laRepet,leFic));
                                            }
                                            else{
                                                sesCases[leY][leX].setsonEvenement(new UneEntreeSortie(sesCases[leY][leX],leNom,laRepet,sonEditeur.getsaCarte()));
                                            }
                                        }
					laLigne = leLecteur.readLine();
				}
			}
			leLecteur.close();
		}
		//cases spéciales (pas le terrain de base, ou ayant un perso ou un objet) créées
		catch (Exception lException) { JOptionPane.showMessageDialog(null, "une erreur de chargement\n"+lException.toString()+"\n"+lException.getClass());
		lException.printStackTrace();}
	}

	UneCarte(JFrame laFenetreDepart, UnEditeurDonjon telEditeur){
		super(laFenetreDepart,"Création d'une nouvelle carte",true);
		sonNom = ""; //petite sécurité au cas où on annule
		sonEditeur = telEditeur;
		setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
		setSize(300, 450);
		setResizable(false);
		JPanel lePanneauFond = new JPanel(new GridLayout(0, 1));

		//champ nom
		JPanel lePanneau = new JPanel(new GridLayout(0,2));
		JLabel leLabel = new JLabel("Nom de la carte : ");
		sonChampNom = new JTextField(15);
		leLabel.setLabelFor(sonChampNom);
		lePanneau.add(leLabel);
		lePanneau.add(sonChampNom);

		//champs longueur et largeur
		leLabel = new JLabel("Longueur (en case) : ");
		sonChampX = new JTextField(2);
		leLabel.setLabelFor(sonChampX);
		lePanneau.add(leLabel) ;
		lePanneau.add(sonChampX);

		leLabel = new JLabel("Hauteur (en case) : ");
		sonChampY = new JTextField(2);
		leLabel.setLabelFor(sonChampY);
		lePanneau.add(leLabel);
		lePanneau.add(sonChampY);

		//choix du terrain de base
		leLabel = new JLabel("Type de terrain : ");
		sonCombo = new JComboBox(UnType.donneTesTypes());//liste déroulante des types
		sonCombo.setSelectedIndex(0);
		leLabel.setLabelFor(sonCombo);
		lePanneau.add(leLabel);
		lePanneau.add(sonCombo);
		lePanneauFond.add(lePanneau);

		//Description
		lePanneau = new JPanel();
		sonChampDesc = new JTextArea("Saisissez l'introduction de votre scénario ici (vous pouvez la modifier plus tard).",9,26);
		sonChampDesc.setLineWrap(true);
		sonChampDesc.setWrapStyleWord(true);
		lePanneau.add(new JScrollPane(sonChampDesc));
		lePanneauFond.add(lePanneau);

		//valideur
		JButton leBouton = new JButton("Valider");
		leBouton.addActionListener(this);
		lePanneau.add(leBouton);
		lePanneauFond.add(lePanneau);
		add(lePanneauFond);
		setVisible(true);
	}

    /**
     * 
     * @param telEvenement 
     */
	public void actionPerformed(ActionEvent telEvenement){

		try{
			sonX = Integer.parseInt(sonChampX.getText());
			sonY = Integer.parseInt(sonChampY.getText());
			sonNom = sonChampNom.getText();
			saDescription = sonChampDesc.getText();
			sonType = new UnType((String)sonCombo.getSelectedItem());
			sesCases = new UneCase[sonY][sonX];
			for (int i = 0; i < sonY; i++){
				for (int j = 0; j < sonX; j++){
					sesCases[i][j] = new UneCase(j, i, sonType, sonEditeur);
				}
			}
			dispose();

		}
		catch (Exception telleException){
			JOptionPane.showMessageDialog(null, "Une erreur est survenue : les champs numériques sont mal remplis.", "Erreur de saisie", JOptionPane.ERROR_MESSAGE);
		}
	}

    /**
     * méthode d'affichage de la carte
     * @return Panneau contenant l'image de la carte
     */
	public JPanel afficheToi() {
		JPanel lImage = new JPanel(new GridLayout(sonY, sonX));
		lImage.setSize(sonX*40,sonY*40);
		UnNonJoueur leMonstre = null;
		for (int i = 0; i < sonY; i++){
			for (int j = 0; j < sonX; j++){
				lImage.add(sesCases[i][j].afficheToi());
				if (sonEditeur.getsonMode()==UnEditeurDonjon.JOUER && sesCases[i][j].getsonNonJoueur() != null && sesCases[i][j].getsonNonJoueur().getsonAgr() && sesCases[i][j].getsonNonJoueur().getsonEtat().equals("vie") && leMonstre==null) {
                                    try{
                                        for (int x = -1; x <= 1; x++) {
                                            for (int y = -1; y <= 1; y++){
                                                if(sesCases[i+y][j+x].getsonJoueur()!=null && sesCases[i+y][j+x].getsonJoueur().getsonEtat().equals("vie"))
                                                    leMonstre = sesCases[i][j].getsonNonJoueur();
                                            }
                                        }
                                    }catch(Exception lException){}
                                }
			}
		}
		if (leMonstre != null)
			lancerLeCombat(leMonstre);
		return lImage;
	}

    /**
     * permet de démarrer un combat
     * @param telMonstre le monstre qui lance le combat
     */
		public void lancerLeCombat(UnNonJoueur telMonstre) {
			JOptionPane.showMessageDialog(null, "Un combat va avoir lieu", "Combat", JOptionPane.INFORMATION_MESSAGE);
			lesMonstres = new Vector<UnNonJoueur>();
			lesJoueurs = new Vector<UnJoueur>();
			lesMonstres.add(telMonstre);
			for (int m = 0; m < lesMonstres.size(); m++) { 
			
				//recherche des créatures autour du monstre
				for (int x = -1; x <= 1; x++) {
					for (int y = -1; y <= 1; y++){
						try{
							if ((sesCases[lesMonstres.get(m).getsaPosY() + y][lesMonstres.get(m).getsaPosX() + x].getsonJoueur() != null) && (!lesJoueurs.contains(sesCases[lesMonstres.get(m).getsaPosY() + y][lesMonstres.get(m).getsaPosX() + x].getsonJoueur()))){
								lesJoueurs.add(sesCases[lesMonstres.get(m).getsaPosY() + y][lesMonstres.get(m).getsaPosX() + x].getsonJoueur());
								//on ajoute que si le joueur n'existe pas déjà dans le tableau
							}
							else if ((sesCases[lesMonstres.get(m).getsaPosY() + y][lesMonstres.get(m).getsaPosX() + x].getsonNonJoueur() != null && sesCases[lesMonstres.get(m).getsaPosY() + y][lesMonstres.get(m).getsaPosX() + x].getsonNonJoueur().getsonAgr()&& (sesCases[lesMonstres.get(m).getsaPosY() + y][lesMonstres.get(m).getsaPosX() + x].getsonNonJoueur().getsonEtat().equals("vie"))) && (!lesMonstres.contains(sesCases[lesMonstres.get(m).getsaPosY() + y][lesMonstres.get(m).getsaPosX() + x].getsonNonJoueur()))){
								lesMonstres.add(sesCases[lesMonstres.get(m).getsaPosY() + y][lesMonstres.get(m).getsaPosX() + x].getsonNonJoueur());
								//on ajoute que si le monstre n'existe pas déjà dans le tableau et est agressif
							}
						}
						catch (Exception lException) {
							//on évite l'erreur et on continue 
						}
					}
				}

				//recherche des créatures autours des joueurs
				for (int j = 0; j < lesJoueurs.size(); j++) {
					for (int x = -1; x <= 1; x++){
						for (int y = -1; y <= 1; y++){
							try{
								if ((sesCases[lesJoueurs.get(j).getsaPosY() + y][lesJoueurs.get(j).getsaPosX() + x].getsonJoueur() != null) && (!lesJoueurs.contains(sesCases[lesJoueurs.get(j).getsaPosY() + y][lesJoueurs.get(j).getsaPosX() + x].getsonJoueur())))
								{
									lesJoueurs.add(sesCases[lesJoueurs.get(j).getsaPosY() + y][lesJoueurs.get(j).getsaPosX() + x].getsonJoueur());
								}
								else if ((sesCases[lesJoueurs.get(j).getsaPosY() + y][lesJoueurs.get(j).getsaPosX() + x].getsonNonJoueur() != null && sesCases[lesJoueurs.get(j).getsaPosY() + y][lesJoueurs.get(j).getsaPosX() + x].getsonNonJoueur().getsonAgr() && (sesCases[lesJoueurs.get(j).getsaPosY() + y][lesJoueurs.get(j).getsaPosX() + x].getsonNonJoueur().getsonEtat().equals("vie") ) )&& (!lesMonstres.contains(sesCases[lesJoueurs.get(j).getsaPosY() + y][lesJoueurs.get(j).getsaPosX() + x].getsonNonJoueur())))
								{
									lesMonstres.add(sesCases[lesJoueurs.get(j).getsaPosY() + y][lesJoueurs.get(j).getsaPosX() + x].getsonNonJoueur());
								}
							}
							catch (Exception lException) {
								//on évite l'erreur et on continue 
							}
						}
					}
				}

			}//fin recherche

			//à ce stade on a 2 tableaux contenant l'ensemble des protagonistes on doit établir l'ordre de passage
			JDialog leDialogue = new JDialog(sonEditeur, "Combat - ordre de passage", false);
			JPanel lePanneau = new JPanel();
			JLabel leTexte = new JLabel("<html>Saisissez l'ordre de passage des combattants (0 s'il ne participe pas)<br>Faites CTRL+L, et saisissez " + lesMonstres.size() + "d20 pour lancer les dés pour les monstres.</html>"); 
			lePanneau.add(leTexte);

			JPanel lePanneauBouton = new JPanel(new GridLayout(0,1));
		
			leTexte = new JLabel("<html><u>Les monstres</u></html>");
			lePanneauBouton.add(leTexte);

			for (int i = 0; i < lesMonstres.size(); i++) {
				JPanel lePanneauInter = new JPanel();
				JLabel leLabel = new JLabel("M" + (i + 1) + ": " + lesMonstres.get(i).getsonNom());
				JTextField leChamp = new JTextField(2);
				lePanneauInter.add(leLabel);
				lePanneauInter.add(leChamp);
				lePanneauBouton.add(lePanneauInter);
			}

			leTexte = new JLabel("<html><u>Les joueurs</u></html>");
			lePanneauBouton.add(leTexte);

			for (int i = 0; i < lesJoueurs.size(); i++){
				JPanel lePanneauInter = new JPanel();
				JLabel leLabel = new JLabel("J" + (i + 1) + ": " + lesJoueurs.get(i).getsonNom());
				JTextField leChamp = new JTextField(2);
				lePanneauInter.add(leLabel);
				lePanneauInter.add(leChamp);
				lePanneauBouton.add(lePanneauInter);
			}

			JPanel lePanneauInter = new JPanel();
			JButton leBouton = new JButton("Valider");
			leBouton.addActionListener(new ActionListener(){
				public void actionPerformed(ActionEvent lEvt){
					((JDialog)((JButton)lEvt.getSource()).getParent().getParent().getParent().getParent().getParent().getParent()).dispose();
					lePassage = new Vector<String>() ;
					for (int i = 0; i < lesMonstres.size() + lesJoueurs.size(); i++)
						lePassage.add("");

					for ( int i = 1; i <= lesMonstres.size()+ lesJoueurs.size()+1 ; i++){
						if(i<=lesMonstres.size())
	 						lePassage.setElementAt("M "+i , Integer.parseInt(((JTextField)((JPanel)((JPanel)((JButton)lEvt.getSource()).getParent().getParent()).getComponent(i)).getComponent(1)).getText())-1) ;
						if(i>lesMonstres.size()+1)
							lePassage.setElementAt("J " + (i - (1 + lesMonstres.size())), Integer.parseInt(((JTextField)((JPanel)((JPanel)((JButton)lEvt.getSource()).getParent().getParent()).getComponent(i)).getComponent(1)).getText()) - 1);

					}
					derouleLeCombat();
				}
				});
			lePanneauInter.add(leBouton);
			lePanneauBouton.add(lePanneauInter);

			lePanneau.add(lePanneauBouton);
			leDialogue.setContentPane(lePanneau);
			leDialogue.setSize(380, 160 + ((lesMonstres.size() + lesJoueurs.size()) * 40));
			leDialogue.setVisible(true);
		}

    /**
     * déroulement du combat
     */
		private void derouleLeCombat() {
			while (lesMonstres.size() > 0 && lesJoueurs.size() > 0) {
				for (int i = 0; i < lePassage.size(); i++) {
					String laCrea = lePassage.get(i);
					int index = Integer.parseInt(laCrea.split(" ")[1])-1;
					laCrea = laCrea.split(" ")[0];
					String[] leChoix = { "Attaque simple", " Sort/Compétence", " Inventaire" };
					if(laCrea.equals("M")){
						if (!lesMonstres.get(index).getsonEtat().equals("vie")){
                                                        lesMonstres.removeElementAt(index);
                                                        lePassage.removeElementAt(i);
						}
						else
						{
							int laDecision = JOptionPane.showOptionDialog(null, "C'est au tour du monstre " + lesMonstres.get(index).getsonNom() + ".\nQue fait-il?", "Action du combat", JOptionPane.YES_NO_CANCEL_OPTION, JOptionPane.QUESTION_MESSAGE, null, leChoix, leChoix[2]);
							if (laDecision == JOptionPane.YES_OPTION && lesJoueurs.size()>0){
								Object[] lesChoixPossibles = lesJoueurs.toArray();
								UneCreature leChoixCrea = (UneCreature)JOptionPane.showInputDialog(null, "Quel joueur attaque-t-il??", "Attaque simple", JOptionPane.QUESTION_MESSAGE, null, lesChoixPossibles, lesChoixPossibles[0]);
								if(leChoixCrea!=null){
									int[] leResult = UnEditeurDonjon.lanceLesDes("1d20");
									if(leResult[0]>=leChoixCrea.getsaCA()){
										String leDe = "1d3";
										int degat = lesMonstres.get(index).modificateurs(lesMonstres.get(index).getsaFor());
										UneArme lArme = lesMonstres.get(index).getsonInventaire().getsonArme();
                                                                                if( lArme !=null ){
											if(lArme.getsaPortee()>=3)
												degat = lesMonstres.get(index).modificateurs(lesMonstres.get(index).getsaDex());
											leDe = lArme.getsonDeDegat();
										}
										try{
											leResult=UnEditeurDonjon.lanceLesDes(leDe);
                                                                                        for(int d=0;d<leResult.length;d++)
                                                                                            degat+=leResult[d];
                                                                                        if(degat<=0)
                                                                                            degat=1;
											leChoixCrea.DOWNsesPvC(degat);
											JOptionPane.showMessageDialog(null,leChoixCrea.getsonNom()+" a subit "+degat+" points de dégats\nSa vie passe a "+leChoixCrea.getsesPvC()+".","Dégats subits",JOptionPane.INFORMATION_MESSAGE);
											if (leChoixCrea.getsonEtat().equals("mort"))
												lesJoueurs.removeElementAt(index);
										}catch(Exception lException){
											JOptionPane.showMessageDialog(null,"L'arme est bizarre, erreur dans le calcul des dégats.","Erreur",JOptionPane.ERROR_MESSAGE);
										}
										
									}else{
										JOptionPane.showMessageDialog(null,lesMonstres.get(index).getsonNom()+" a raté son coup.","Coup raté",JOptionPane.INFORMATION_MESSAGE);
									}
									
								}

							}
							try{
								if (laDecision == JOptionPane.NO_OPTION){
									Object[] lesChoixPossibles = lesMonstres.get(index).getsesComp().toArray();
									String leChoixCrea = (String)JOptionPane.showInputDialog(null, "Quel compétence/sort utilise-t-il?\nVous allez voir sa description, modifiez des stats (ctrl+E) ou racontez ce qui se passe en conséquence.", "Sort", JOptionPane.QUESTION_MESSAGE, null, lesChoixPossibles, lesChoixPossibles[0]);
									try{
										UneCompetence laCom = new UneCompetence(leChoixCrea);
										laCom.afficheToi(sonEditeur).setVisible(true);
									}catch (Exception e){
										try{
											UnSort laCom = new UnSort(leChoixCrea);
											laCom.consulteToi(sonEditeur);
										}catch (Exception expt){
											JOptionPane.showMessageDialog(null, "Erreur...\nLa fenêtre correspondant à la compétence ou au sort ne peut pas s'afficher");
										}
									}//catch
								}
							}catch(Exception lException){}
							if (laDecision == JOptionPane.CANCEL_OPTION) {
								lesMonstres.get(index).getsonInventaire().afficheToi();
							}
						}
					}
					if (laCrea.equals("J"))
					{
						if (!lesJoueurs.get(index).getsonEtat().equals("vie"))
						{
							lesJoueurs.get(index).DOWNsesPvC(1);
							if (lesJoueurs.get(index).getsonEtat().equals("mort"))
								lesJoueurs.removeElementAt(index);
						}
						else
						{
							int laDecision = JOptionPane.showOptionDialog(null, "C'est au tour du joueur " + lesJoueurs.get(index).getsonNom() + ".\nQue fait-il?", "Action du combat", JOptionPane.YES_NO_CANCEL_OPTION, JOptionPane.QUESTION_MESSAGE, null, leChoix, leChoix[2]);
							if (laDecision == JOptionPane.YES_OPTION && lesMonstres.size()>0)
							{
								Object[] lesChoixPossibles = lesMonstres.toArray();
								UneCreature leChoixCrea = (UneCreature)JOptionPane.showInputDialog(null, "Quel monstre attaque-t-il?", "Attaque simple", JOptionPane.QUESTION_MESSAGE, null, lesChoixPossibles, lesChoixPossibles[0]);
								if (leChoixCrea != null)
								{
									String resultat = JOptionPane.showInputDialog(null,"Valeur du jet d'attaque\n(1 dé de 20 lancé par le joueur)","Attaque",JOptionPane.QUESTION_MESSAGE);
                                                                        int leResult = 0;
                                                                        try{
                                                                            leResult=Integer.parseInt(resultat);
                                                                        }catch(Exception lException){
                                                                            //on évite l'erreur : annulation du coup.
                                                                        }
									if(leResult>=leChoixCrea.getsaCA()){
										int degat = lesJoueurs.get(index).modificateurs(lesJoueurs.get(index).getsaFor());
                                                                                UneArme lArme = lesJoueurs.get(index).getsonInventaire().getsonArme();
                                                                                String laChaine = lesJoueurs.get(index).getsonNom()+" donne un coup de ";
										if(lArme !=null){
                                                                                        laChaine+=lArme.getsonNom()+" ("+lArme.getsonDeDegat()+").";
											if(lArme.getsaPortee()>=3)
												degat = lesJoueurs.get(index).modificateurs(lesJoueurs.get(index).getsaDex());
										}else{
                                                                                    laChaine+="poing (1d3).";
                                                                                }
                                                                                resultat = JOptionPane.showInputDialog(null,laChaine+"\nIndiquez le résultat du dé de dégat.","Attaque",JOptionPane.QUESTION_MESSAGE);
										leResult = 0;
                                                                                try{
                                                                                      leResult=Integer.parseInt(resultat);
                                                                                }catch(Exception lException){
                                                                                            //on évite l'erreur : annulation du coup.
                                                                                }
                                                                                degat+=leResult;
                                                                                if(degat<=0)
                                                                                   degat=1;
                                                                		leChoixCrea.DOWNsesPvC(degat);
										JOptionPane.showMessageDialog(null,leChoixCrea.getsonNom()+" a subit "+degat+" points de dégats\nSa vie passe a "+leChoixCrea.getsesPvC()+".","Dégats subits",JOptionPane.INFORMATION_MESSAGE);
										if (leChoixCrea.getsonEtat().equals("mort")){
											lesMonstres.removeElementAt(index);
                                                                                        lePassage.removeElement("M "+index);
                                                                                }
									}else{
										JOptionPane.showMessageDialog(null,lesJoueurs.get(index).getsonNom()+" a raté son coup.","Coup raté",JOptionPane.INFORMATION_MESSAGE);
									}
								}

							}
							try
							{
								if (laDecision == JOptionPane.NO_OPTION)
								{
									Object[] lesChoixPossibles = lesJoueurs.get(index).getsesComp().toArray();
									String leChoixCrea = (String)JOptionPane.showInputDialog(null, "Quel compétence/sort utilise-t-il?\nVous allez voir sa description, modifiez des stats (ctrl+E) ou racontez ce qui se passe en conséquence.", "Sort", JOptionPane.QUESTION_MESSAGE, null, lesChoixPossibles, lesChoixPossibles[0]);
									try
									{
										UneCompetence laCom = new UneCompetence(leChoixCrea);
										laCom.afficheToi(sonEditeur).setVisible(true);
									}
									catch (Exception e)
									{
										try
										{
											UnSort laCom = new UnSort(leChoixCrea);
											laCom.consulteToi(sonEditeur);
										}
										catch (Exception expt)
										{
											JOptionPane.showMessageDialog(null, "Erreur...\nLa fenêtre correspondant à la compétence ou au sort ne peut pas s'afficher");
										}
									}//catch
								}
							}
							catch (Exception lException) { }
							if (laDecision == JOptionPane.CANCEL_OPTION)
							{
								lesJoueurs.get(index).getsonInventaire().afficheToi();
							}

						}
					}
				}
			}//fin du combat
                        if(lesJoueurs.size()>0){
                              JOptionPane.showMessageDialog(null,"Victoire des joueurs!","Fin du combat",JOptionPane.INFORMATION_MESSAGE);
                        }else{
                              JOptionPane.showMessageDialog(null,"Victoire des monstres!","Fin du combat",JOptionPane.INFORMATION_MESSAGE);
                        }
		}

    /**
     * méthode permettant l'enregistrement de la carte et de tout les objets liés
     * @param leFic fichier dans lequel on enregistre
     */
	public void enregistreToi(File leFic)
	{
		if (!leFic.getName().substring((leFic.getName().lastIndexOf(".") + 1)).equals("cjay")){
			leFic = new File(leFic.getAbsolutePath() + ".cjay");
		}
		try{
			PrintWriter lEcrivain;
			lEcrivain = new PrintWriter(new FileWriter(leFic));
			lEcrivain.println("nom :" + sonNom);
			lEcrivain.println("largeur :" + sonX);
			lEcrivain.println("hauteur :" + sonY);
			lEcrivain.println("type de terrain :" + sonType.getsonNom());
			lEcrivain.println("description :" + saDescription);
			lEcrivain.println("FinDescCarte");
			for (int i = 0; i < sonY; i++){
				for (int j = 0; j < sonX; j++){
					if ((!sesCases[i][j].getsonType().getsonNom().equals(sonType.getsonNom())) || (sesCases[i][j].getsonJoueur() != null) || (sesCases[i][j].getsonNonJoueur() != null) || (sesCases[i][j].getsonTabObjet().size() > 0) || (sesCases[i][j].getsaDescription() != null) || (sesCases[i][j].getsonEvenement() != null)){
						lEcrivain.println("case :" + j + "," + i);
						lEcrivain.println("    type :" + sesCases[i][j].getsonType().getsonNom());
						if (sesCases[i][j].getsonJoueur() != null){
							lEcrivain.println("    joueur :" + sesCases[i][j].getsonJoueur().getsonNom());
							sesCases[i][j].getsonJoueur().enregistreToi();
						}
						if (sesCases[i][j].getsonNonJoueur() != null){
							lEcrivain.println("    pnj :" + sesCases[i][j].getsonNonJoueur().getsonNom());
							sesCases[i][j].getsonNonJoueur().enregistreToi();
						}
						for (int y = 0; y < (sesCases[i][j].getsonTabObjet().size()); y++){
							lEcrivain.println("    objet " + y + " :" + sesCases[i][j].getsonTabObjet().get(y).getsonNom() + ":" + (sesCases[i][j].getsonTabObjet().get(y).toString()));
						}
						if (sesCases[i][j].getsaDescription() != null) {
							lEcrivain.println("    description :" + sesCases[i][j].getsaDescription());
							lEcrivain.println("FinDescCase");
						}
						if (sesCases[i][j].getsonEvenement() != null) {
							lEcrivain.println(sesCases[i][j].getsonEvenement().toString());
						}
					}
				}
			}
			lEcrivain.close();
		}
		catch (Exception lException) { JOptionPane.showMessageDialog(null, "On a eu un problème d'enregistrement, vérifiez que le fichier ne soit pas protégé en écriture", "Erreur", JOptionPane.ERROR_MESSAGE); }
	}

    /**
     * affiche un panneau pour modifier la description de la carte.
     */
	public void changeSaDescription(){
		//panneau pour changer la description et le nom de la carte
		JPanel lePanneau = new JPanel(new GridLayout(0,1));
		JPanel lePanneauInter = new JPanel();
		JLabel leLabel = new JLabel("Nom de la carte :");
		JTextField leChamp = new JTextField(sonNom,20);
		lePanneauInter.add(leLabel);
		lePanneauInter.add(leChamp);
		lePanneau.add(lePanneauInter);
		sonChampDesc = new JTextArea(saDescription, 9, 26);
		sonChampDesc.setLineWrap(true);
		sonChampDesc.setWrapStyleWord(true);
		lePanneau.add(new JScrollPane(sonChampDesc));
		JButton leBouton = new JButton("Valider");
		leBouton.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent telEvenement) {
				sonNom = ((JTextField)((JPanel)((JPanel)((JButton)telEvenement.getSource()).getParent().getParent()).getComponent(0)).getComponent(1)).getText();
				saDescription = ((JTextArea)((JViewport)((JScrollPane)((JPanel)((JButton)telEvenement.getSource()).getParent().getParent()).getComponent(1)).getComponent(0)).getComponent(0)).getText() ;
				JOptionPane.showMessageDialog(null, "Changement effectué!");
			}
		});
		lePanneauInter = new JPanel();
		lePanneauInter.add(leBouton);
		lePanneau.add(lePanneauInter);
		sonEditeur.afficheEnContexte(lePanneau);
	}

	//les accesseurs!
    /**
     * accesseur
     * @return nom de la carte
     */
	public String getsonNom() { return sonNom; }
    /**
     * accesseur
     * @return description de la carte
     */
	public String getsaDescription() { return saDescription; }
	public int getsonX() { return sonX; }
	public int getsonY() { return sonY; }
	public String getsonType() { return sonType.getsonNom(); }
	public UneCase[][] getsesCases() { return sesCases; }
    /**
     * 
     * @return liste des créatures de la carte
     */
	public Vector<UneCreature> getsesCreatures() {
		Vector<UneCreature> sesCreatures = new Vector<UneCreature>();
		for (int i = 0; i < sonY; i++){
			for (int j = 0; j < sonX; j++){
				if (sesCases[i][j].getsaCreature() != null){
					sesCreatures.add(sesCases[i][j].getsaCreature());
				}
			}
		}
		return sesCreatures;
	}
    /**
     * 
     * @return liste des joueurs sur la carte
     */
	public Vector<UnJoueur> getsesJoueurs(){
		Vector<UnJoueur> sesJoueurs = new Vector<UnJoueur>();
		for (int i = 0; i < sonY; i++){
			for (int j = 0; j < sonX; j++){
				if (sesCases[i][j].getsonJoueur() != null){
					sesJoueurs.add(sesCases[i][j].getsonJoueur());
				}
			}
		}
		return sesJoueurs;
	}
    /**
     * 
     * @return liste des événements
     */
	public Vector<UnEvenement> getsesEvenements() {
		Vector<UnEvenement> sesEvenements = new Vector<UnEvenement>();
		for (int i = 0; i < sonY; i++){
			for (int j = 0; j < sonX; j++){
				if (sesCases[i][j].getsonEvenement() != null){
					sesEvenements.add(sesCases[i][j].getsonEvenement());
				}
			}
		}
		return sesEvenements;
	}

}
