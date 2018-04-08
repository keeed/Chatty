/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package chatty.network;

import chatty.logging.ILogger;
import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

/**
 *
 * @author Kedren Villena
 */
public class UdpServer {

    private final String ipAddress;
    private final int port;
    private final ILogger logger;

    public Thread _serverThread;
    private DatagramSocket serverSocket;
    private boolean running;

    public UdpServer(String ipAddress, int port, ILogger logger) {
        this.ipAddress = ipAddress;
        this.port = port;
        this.logger = logger;

        _serverThread = new Thread(() -> {
            runServer();
        });
    }

    public void Start() {
        if (!_serverThread.isAlive()) {
            _serverThread.start();
        }
    }

    public void runServer() {
        try {
            InetAddress addr = InetAddress.getByName(ipAddress);
            serverSocket = new DatagramSocket(port, addr);
            logger.Log("UDPServer", "Listening at " + serverSocket.getLocalSocketAddress().toString());
        } catch (IOException ex) {
            logger.Log("UDPServer", ex.getMessage());

            return;
        }
        running = true;

        byte[] packInfo = new byte[1024];
        while (running) {
            try {
                DatagramPacket packetReceived = new DatagramPacket(packInfo, packInfo.length);
                serverSocket.receive(packetReceived);
                String message = new String(packetReceived.getData(), packetReceived.getOffset(), packetReceived.getLength());
                logger.Log(serverSocket.getLocalSocketAddress().toString(),
                        message);
            } catch (IOException ex) {
                logger.Log("UDPServer", ex.getMessage());
            }
        }
    }

    public void Stop() {
        if (_serverThread.isAlive()) {
            running = false;
            serverSocket.close();
        }
    }
}
