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
 * Les compétences représentent les actions que les personnages sont capables de faire.
 */
public class UneCompetence extends JPanel{
	private String sonLibelle;
	private int sonNiveau;
	private String saDesc="";
	
	private JTextField sonChampLibelle;
	private JTextField sonChampNiveau;
	private JTextArea sonChampDesc;
	
	private JLabel sonLabelLibelle;
	private JLabel sonLabelNiveau;
	
	private JPanel PanoField;
	private JPanel PanoLabel;
	
	private UnEditeurDonjon sonEditeur;

    /**
     * Charge une compétence
     * @param telNom nom de la compétence à charger
     * @throws java.lang.Exception erreur de lecture du fichier (ce n'est pas une compétence)
     */
    public UneCompetence(String telNom) throws Exception{
    		super();
    		sonLibelle=telNom;
    		String lire = new String();
    		try{
				BufferedReader leLecteur= new BufferedReader(new FileReader(new File("bundll/competence.jay")));
				lire = leLecteur.readLine();
				while (!lire.equals(sonLibelle) && lire!=null){
					lire = leLecteur.readLine();
				}
				if (lire==null)
					JOptionPane.showMessageDialog(null, "Erreur, competence Non trouvé");
                                                
				sonNiveau=Integer.parseInt(leLecteur.readLine());
				lire=leLecteur.readLine();	
				while (!lire.equals("finComp")){
					saDesc = saDesc+lire+"\n";
					lire=leLecteur.readLine();
				}//while	
				
			}//try
			catch (Exception lException) { 
				throw (Exception)lException; }//catch
			
		}//constructeur
		
    /**
     * Affiche les informations relatives à une compétence.
     * @param telEditeur fenêtre mère
     * @return JDialog avec les informations
     */
	public JDialog afficheToi(UnEditeurDonjon telEditeur){
		sonEditeur = telEditeur;
		JDialog leDialog = new JDialog();
		leDialog = new JDialog(telEditeur, "Visualisation de Compétence",true);
		leDialog.setSize(300,480);
		leDialog.setLocation(250,150);
		
		sonChampLibelle = new JTextField(20);
		sonChampLibelle.setText(sonLibelle);
		sonChampLibelle.setFocusable(false);
		
		sonChampNiveau = new JTextField(4);
		sonChampNiveau.setText(Integer.toString(sonNiveau));
		sonChampNiveau.setFocusable(false);



		sonChampDesc = new JTextArea(18,30);
		sonChampDesc.setText(saDesc);
		sonChampDesc.setFocusable(false);
		sonChampDesc.setLineWrap(true);//on vas à la ligne quand c'est trop grand
		sonChampDesc.setWrapStyleWord(true);//on ne coupe pas les mots en allant à la ligne

				
		PanoLabel = new JPanel();
		sonLabelLibelle = new JLabel("Nom de la competence");
		sonLabelLibelle.setLabelFor(sonChampLibelle);
		sonLabelNiveau = new JLabel("Degré d'aptitude");
		sonLabelNiveau.setLabelFor(sonChampNiveau);
		PanoLabel.add(sonLabelLibelle);
		PanoLabel.add(sonChampLibelle);
                this.add(PanoLabel);
                PanoLabel = new JPanel();
		PanoLabel.add(sonLabelNiveau);
		PanoLabel.add(sonChampNiveau);
			
			
		this.add(PanoLabel);
		this.add(new JScrollPane(sonChampDesc));
		
		if (sonEditeur.getsonMode() == UnEditeurDonjon.JOUER) {
				JPanel lePanneauInter = new JPanel();
				JButton leBouton = new JButton("editer des stats");
				leBouton.addActionListener(new ActionListener() {
					public void actionPerformed(ActionEvent lEvt) { 
						Object[] lesCreatures = sonEditeur.getsaCarte().getsesCreatures().toArray();
						UneCreature leChoixCrea = (UneCreature)JOptionPane.showInputDialog(null, "Quel personnage modifie-t-on?", "Edition Personnage", JOptionPane.QUESTION_MESSAGE, null, lesCreatures, lesCreatures[0]);
						JDialog leDial = new JDialog(sonEditeur, "Editer stat", true);
						leDial.setContentPane(leChoixCrea.editeTesStats());
						leDial.setSize(300, 300);
						leDial.setVisible(true);
					}
				});
				lePanneauInter.add(leBouton);
				this.add(lePanneauInter, BorderLayout.SOUTH);
		}
		leDialog.setContentPane(this);
		return leDialog;
        }
    
}//UneCompetence


