module.exports = {
    wsServer: null,
    broadcast(socket, payload) {
        socket.server.clients.forEach(e => {
            e.send(payload);
        });
    }
}