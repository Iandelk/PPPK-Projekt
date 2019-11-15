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
public class Vozilo {



    private int Id;
    private String Tip;
    private String Marka;
    private int Godina;
    private int PocetniKilometri;
    
    public Vozilo(){
    
    }
    
        public Vozilo(String Tip, String Marka, int Godina, int PocetniKilometri) {
        this.Tip = Tip;
        this.Marka = Marka;
        this.Godina = Godina;
        this.PocetniKilometri = PocetniKilometri;
    }

    public int getId() {
        return Id;
    }

    public void setId(int Id) {
        this.Id = Id;
    }

    public String getTip() {
        return Tip;
    }

    public void setTip(String Tip) {
        this.Tip = Tip;
    }

    public String getMarka() {
        return Marka;
    }

    public void setMarka(String Marka) {
        this.Marka = Marka;
    }

    public int getGodina() {
        return Godina;
    }

    public void setGodina(int Godina) {
        this.Godina = Godina;
    }

    public int getPocetniKilometri() {
        return PocetniKilometri;
    }

    public void setPocetniKilometri(int PocetniKilometri) {
        this.PocetniKilometri = PocetniKilometri;
    }

    @Override
    public String toString() {
        return getMarka() + " " + getTip() + " " + getGodina() + " " + getPocetniKilometri();
    }

    public static ArrayList<Vozilo> VozilaCSVImport(String csvPath) {
        ArrayList<Vozilo> vozila = new ArrayList<>();
        String csvVozila = csvPath;
        String line = "";
        String delimiter = ",";

        try (BufferedReader br = new BufferedReader(new FileReader(csvVozila))) {

            while ((line = br.readLine()) != null) {
                String[] vozila_split = line.split(delimiter);
                // use comma as separator

                Vozilo vozilo = new Vozilo();

                vozilo.setMarka(vozila_split[0]);
                vozilo.setTip(vozila_split[1]);
                vozilo.setGodina(Integer.valueOf(vozila_split[2]));
                vozilo.setPocetniKilometri(Integer.valueOf(vozila_split[3]));

                vozila.add(vozilo);

            }

        } catch (IOException e) {
            e.printStackTrace();
        }
        return vozila;
    }

}
