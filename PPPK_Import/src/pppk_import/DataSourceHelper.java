package pppk_import;


import com.microsoft.sqlserver.jdbc.SQLServerDataSource;
import javax.sql.DataSource;


public class DataSourceHelper {
   public static DataSource kreirajDataSource() {
        SQLServerDataSource dataSource = new SQLServerDataSource();
        dataSource.setServerName("DESKTOP-2I1FI6C");
        dataSource.setPortNumber(1433);
        dataSource.setDatabaseName("PPPK_Projekt");
        dataSource.setUser("sa");
        dataSource.setPassword("SQL");
        return dataSource;
    }
}
