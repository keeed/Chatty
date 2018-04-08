/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package chatty.network;

import chatty.logging.ILogger;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.Socket;
import java.net.UnknownHostException;
import java.nio.charset.Charset;

/**
 *
 * @author Kedren Villena
 */
public class UdpClient {

    private DatagramSocket socket;

    private final String ipAddress;
    private final int port;
    private final ILogger logger;

    public UdpClient(String ipAddress, int port, ILogger logger) {
        this.ipAddress = ipAddress;
        this.port = port;
        this.logger = logger;
    }

    public boolean Connect() {

        try {
            socket = new DatagramSocket();

            return true;
        } catch (IOException ex) {
            logger.Log("UdpClient", ex.getMessage());
        }

        return false;
    }

    public void Disconnect() {
        socket.close();
    }

    public Boolean SendMessage(String message) {
        try {
            InetAddress addr = InetAddress.getByName(ipAddress);
            byte[] byteData;
            byteData = message.getBytes();
            DatagramPacket packet = new DatagramPacket(byteData, byteData.length, addr, port);
            socket.send(packet);
            logger.Log("You", message);

            return true;
        } catch (IOException ex) {

            // Disconnect immediately on error.
            Disconnect();

            logger.Log("UdpClient", ex.getMessage());
            return false;
        }
    }
}
