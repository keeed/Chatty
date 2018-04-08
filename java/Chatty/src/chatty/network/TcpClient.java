/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package chatty.network;

import chatty.logging.ILogger;
import java.io.BufferedWriter;
import java.io.DataOutputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.net.InetAddress;
import java.net.Socket;
import java.net.UnknownHostException;
import java.nio.charset.Charset;

/**
 *
 * @author Kedren Villena
 */
public class TcpClient {

    private Socket socket;

    private final String ipAddress;
    private final int port;
    private final ILogger logger;

    public TcpClient(String ipAddress, int port, ILogger logger) {
        this.ipAddress = ipAddress;
        this.port = port;
        this.logger = logger;
    }

    public boolean Connect() {

        try {
            InetAddress addr = InetAddress.getByName(ipAddress);
            socket = new Socket(addr, port);

            return true;
        } catch (UnknownHostException ex) {
            logger.Log("TcpClient", ex.getMessage());
        } catch (IOException ex) {
            logger.Log("TcpClient", ex.getMessage());
        }

        return false;
    }

    public void Disconnect() {
        try {
            socket.close();
        } catch (IOException ex) {
            logger.Log("TcpClient", ex.getMessage());
        }
    }

    public Boolean SendMessage(String message) {
        try {
            socket.getOutputStream();

            BufferedWriter bw = new BufferedWriter(
                    new OutputStreamWriter(socket.getOutputStream(), Charset.forName("US-ASCII")));
            bw.append(message + System.lineSeparator());
            bw.flush();
//            DataOutputStream outToServer = new DataOutputStream(socket.getOutputStream());
//            outToServer.writeBytes(message + System.lineSeparator());
//            outToServer.flush();

            logger.Log("You", message);

            return true;
        } catch (IOException ex) {

            // Disconnect immediately on error.
            Disconnect();

            logger.Log("TcpClient", ex.getMessage());
            return false;
        }
    }

}
