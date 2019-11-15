/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pppk_import;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

/**
 *
 * @author Phyrexian
 */
public class Vozac {
    
       private int ID;
       private String Ime;
       private String Prezime;
       private String BrojMobitela;
       private String BrojVozacke;

    public Vozac(){
        
    }
       
    public Vozac(String Ime, String Prezime, String BrojMobitela, String BrojVozacke) {
        this.Ime = Ime;
        this.Prezime = Prezime;
        this.BrojMobitela = BrojMobitela;
        this.BrojVozacke = BrojVozacke;
    }

    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public String getIme() {
        return Ime;
    }

    public void setIme(String Ime) {
        this.Ime = Ime;
    }

    public String getPrezime() {
        return Prezime;
    }

    public void setPrezime(String Prezime) {
        this.Prezime = Prezime;
    }

    public String getBrojMobitela() {
        return BrojMobitela;
    }

    public void setBrojMobitela(String BrojMobitela) {
        this.BrojMobitela = BrojMobitela;
    }

    public String getBrojVozacke() {
        return BrojVozacke;
    }

    public void setBrojVozacke(String BrojVozacke) {
        this.BrojVozacke = BrojVozacke;
    }

    @Override
    public String toString() {
        return getIme() + " " + getPrezime() + " " + BrojMobitela+ " " + BrojVozacke;
    }
    
    public static ArrayList<Vozac> VozaciCSVImport(String csvPath){
        ArrayList<Vozac> vozaci = new ArrayList<>();
          String csvVozaci = csvPath;
          String line = "";
          String delimiter = ",";
        try (BufferedReader br = new BufferedReader(new FileReader(csvVozaci))) {

            while ((line = br.readLine()) != null) {
                String[] vozac_split = line.split(delimiter);

                Vozac vozac = new Vozac();

                vozac.setIme(vozac_split[0]);
                vozac.setPrezime(vozac_split[1]);
                vozac.setBrojMobitela(vozac_split[2]);
                vozac.setBrojVozacke(vozac_split[3]);
                
                vozaci.add(vozac);
                
             

            }

        } catch (IOException e) {
            e.printStackTrace();
        }
        return vozaci;
    }
    
}
