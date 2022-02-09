const { Rooms } = require("../Utils/Room");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "ready",
    handle(socket, payload) {
        const res = Rooms.ready(socket);
        if (res === "") {
            let payload = JSON.stringify({ id: socket.id, status: socket.ready });
            Rooms.rooms[socket.room].broadcast(JSON.stringify(new DataVO("ready", payload)));
            console.log("Sending: " + payload);
        } else {
            socket.send(JSON.stringify(new DataVO("error", res)));
        }

    }
}