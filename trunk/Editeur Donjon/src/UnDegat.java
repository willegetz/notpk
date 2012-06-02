/**
    Copyright 2007, Aur�lien P�cheur, Jonathan Mondon, Yannick Balla
 
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

/**
 * classe d�finissant des d�gats
 * Ils sont caract�ris�s par un type (tranchant, contondant...) et un (ou des) d�s de d�gat symbolis�s par la syntaxe (xdy)
 */
public class UnDegat extends JPanel{

	protected String sonType;
	protected String sonDeDegat;

	UnDegat(){
		sonType="";
		sonDeDegat="";
	}
	
	UnDegat(String telType,String telDeDegat){
		sonType=telType;
		sonDeDegat=telDeDegat;	
	}
	//accesseurs

		public String getsonType(){return sonType;}
		public void setsonType(String telType){sonType=telType;}
		public String getsonDeDegat(){return sonDeDegat;}
    /**
     * d�finit le d� de d�gat
     * @param telDeDegat chaine du type "xdy" o� x est le nombre de d� et y la valeur du d�
     */
		public void setsonDeDegat(String telDeDegat){sonDeDegat=telDeDegat;}

    public String toString(){
    	return (sonType+":"+sonDeDegat);
    }
}
