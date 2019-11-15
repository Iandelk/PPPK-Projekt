/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pppk_import;

import java.sql.Connection;
import java.sql.Date;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.Format;
import java.time.LocalDate;
import java.time.Month;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.sql.DataSource;

/**
 *
 * @author Phyrexian
 */
public class PPPK_Import {

    final static String dodajVozaceQuery = "INSERT INTO Vozac (Ime, Prezime, BrojMobitela, BrojVozacke) VALUES (?, ?, ?,?)";
    final static String dodajVozilaQuery = "INSERT INTO Vozila (Tip, Marka, Godina, PocetniKilometri) VALUES (?, ?, ?,?)";

    public static void main(String[] args) {
        DataSource dataSource = DataSourceHelper.kreirajDataSource();
        ArrayList<Vozac> vozaciIzCSV = Vozac.VozaciCSVImport("vozaci.csv");
        ArrayList<Vozilo> vozilaIzCSV = Vozilo.VozilaCSVImport("vozila.csv");

        ImportajVozaceUBazu();
        ImportajVozilaUBazu();

        try {
            ArrayList<Vozac> vozaciIzBaze = dohvatiVozace(dataSource.getConnection());
            for (int i = 0; i < vozaciIzCSV.size(); i++) {

                if (!vozaciIzBaze.get(i).toString().equals(vozaciIzCSV.get(i).toString())) {
                    System.out.println("Validacija vozaca nije prosla, ne odgovaraju si vozaci - " + vozaciIzBaze.get(i) + " i " + vozaciIzCSV.get(i));

                    break;

                }

            }
        } catch (SQLException ex) {
            Logger.getLogger(PPPK_Import.class.getName()).log(Level.SEVERE, null, ex);
        }
        try {
            ArrayList<Vozilo> vozilaIzBaze = dohvatiVozila(dataSource.getConnection());
            for (int i = 0; i < vozilaIzCSV.size(); i++) {

                if (!vozilaIzBaze.get(i).toString().equals(vozilaIzCSV.get(i).toString())) {
                    System.out.println("Validacija vozila nije prosla, ne odgovaraju si vozila - " + vozilaIzBaze.get(i) + " i " + vozilaIzCSV.get(i));

                    break;

                }

            }
        } catch (SQLException ex) {
            Logger.getLogger(PPPK_Import.class.getName()).log(Level.SEVERE, null, ex);
        }

    }

    private static void ImportajVozaceUBazu() {
        ArrayList<Vozac> vozaci = Vozac.VozaciCSVImport("vozaci.csv");
        DataSource dataSource = DataSourceHelper.kreirajDataSource();
        try (Connection connection = dataSource.getConnection()) {
            connection.setAutoCommit(false);

            try (PreparedStatement dodajVozaceStmnt = connection.prepareStatement(dodajVozaceQuery);) {
                int counter = 0;
                for (Vozac vozac : vozaci) {
                    dodajVozaceStmnt.setString(1, vozac.getIme());
                    dodajVozaceStmnt.setString(2, vozac.getPrezime());
                    dodajVozaceStmnt.setString(3, vozac.getBrojMobitela());
                    dodajVozaceStmnt.setString(4, vozac.getBrojVozacke());
                    dodajVozaceStmnt.addBatch();
                    counter++;

                    if (counter == 10) {
                        dodajVozaceStmnt.executeBatch();
                        dodajVozaceStmnt.clearBatch();
                        counter = 0;
                    }

                }
                dodajVozaceStmnt.executeBatch();

                connection.commit();

            } catch (Exception e) {
                connection.rollback();
                System.out.println("Nije uspio unos Vozaca - " + e.getMessage());
            } finally {
                connection.setAutoCommit(true);
            }
        } catch (SQLException e) {
            System.err.println("Exception: " + e.getMessage());
        }
    }

    private static void ImportajVozilaUBazu() {
        ArrayList<Vozilo> vozila = Vozilo.VozilaCSVImport("vozila.csv");
        DataSource dataSource = DataSourceHelper.kreirajDataSource();

        try (Connection connection = dataSource.getConnection()) {
            connection.setAutoCommit(false);

            try (PreparedStatement dodajVozilaStmnt = connection.prepareStatement(dodajVozilaQuery);) {

                int counter = 0;
                for (Vozilo vozilo : vozila) {
                    dodajVozilaStmnt.setString(1, vozilo.getTip());
                    dodajVozilaStmnt.setString(2, vozilo.getMarka());                 
                    dodajVozilaStmnt.setDate(3, Date.valueOf(LocalDate.of(vozilo.getGodina(), 1, 1)) );
                    dodajVozilaStmnt.setInt(4, vozilo.getPocetniKilometri());
                    dodajVozilaStmnt.addBatch();
                    counter++;

                    if (counter == 10) {
                        dodajVozilaStmnt.executeBatch();
                        dodajVozilaStmnt.clearBatch();
                        counter = 0;

                    }

                }
                dodajVozilaStmnt.executeBatch();

                connection.commit();

            } catch (Exception e) {
                connection.rollback();
                System.out.println("Nije uspio unos Vozila - " + e.getMessage());
            } finally {
                connection.setAutoCommit(true);
            }
        } catch (SQLException e) {
            System.err.println("Exception: " + e.getMessage());
        }
    }

    private static ArrayList<Vozac> dohvatiVozace(Connection connection) throws SQLException {
        ArrayList<Vozac> result = new ArrayList<>();
        try (Statement statement = connection.createStatement()) {
            ResultSet resultSet = statement.executeQuery("SELECT * FROM Vozac");
            while (resultSet.next()) {
                result.add(new Vozac(resultSet.getString("Ime"), resultSet.getString("Prezime"), resultSet.getString("BrojMobitela"), resultSet.getString("BrojVozacke")));
            }
        }
        return result;
    }

    private static ArrayList<Vozilo> dohvatiVozila(Connection connection) throws SQLException {
        ArrayList<Vozilo> result = new ArrayList<>();
        try (Statement statement = connection.createStatement()) {
            ResultSet resultSet = statement.executeQuery("SELECT * FROM Vozila");
            while (resultSet.next()) {
                result.add(new Vozilo(resultSet.getString("Tip"), resultSet.getString("Marka"), resultSet.getDate("Godina").toLocalDate().getYear(),  resultSet.getInt("PocetniKilometri")));
            }
        }
        return result;
    }

}
