/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package chatty.network;

import chatty.logging.ILogger;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.InetAddress;
import java.net.ServerSocket;
import java.net.Socket;

/**
 *
 * @author Kedren Villena
 */
public class TcpServer {

    private ServerSocket serverSocket;

    private Thread _serverThread;

    private final String ipAddress;
    private final int port;
    private final ILogger logger;

    private boolean running = false;

    public TcpServer(String ipAddress, int port, ILogger logger) {
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

    private void runServer() {
        try {
            InetAddress addr = InetAddress.getByName(ipAddress);
            serverSocket = new ServerSocket(port, 50, addr);
            logger.Log("TCPServer", "Listening at " + serverSocket.getLocalSocketAddress().toString());
        } catch (IOException ex) {
            logger.Log("TCPServer", ex.getMessage());

            return;
        }
        running = true;
        while (running) {
            try {
                Socket connectionSocket = serverSocket.accept();

                Thread clientThread = new Thread(() -> {
                    handleClient(connectionSocket);
                });

                clientThread.start();

            } catch (IOException ex) {
                logger.Log("TCPServer", ex.getMessage());
            }
        }
    }

    private void handleClient(Socket client) {
        boolean keepRunning = true;
        while (keepRunning) {
            BufferedReader bufferedReader;
            try {
                bufferedReader = new BufferedReader(new InputStreamReader(client.getInputStream()));
                String line = bufferedReader.readLine();
                if (line == null) {
                    logger.Log("TCPServer", client.getRemoteSocketAddress() + " disconnected");
                    keepRunning = false;
                    continue;
                }
                logger.Log(client.getRemoteSocketAddress().toString(),
                        line);
            } catch (IOException ex) {
                logger.Log("TCPServer", ex.getMessage());
                keepRunning = false;
            }
        }
    }

    public void Stop() {
        if (_serverThread.isAlive()) {
            running = false;
            try {
                serverSocket.close();
            } catch (IOException ex) {
                logger.Log("TCPServer", ex.getMessage());
            }
        }
    }
}
