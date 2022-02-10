const fs = require("fs");
const path = require("path");
const { WebSocketServer } = require("ws");
const { Rooms } = require("../Utils/Room.js");
const { Vector2 } = require("../Utils/Vector2.js");
const { DataVO } = require("../VO/DataVO.js");
console.clear();

//#region init

// argv
const port = process.argv[2];
if (process.argv.length <= 2) {
    console.log("usage: ./Server/websocketServer.js [ports]");
    return;
}

const wsServer = new WebSocketServer({ port }, () => {
    console.log(`Server running on port: ${port}`);
});
//#endregion // init



let handlers = [];
let id = 0;


// Rooms.createRoom("와 센즈");
// Rooms.rooms[0].start();
// Rooms.createRoom("GGM");

// imports handler
fs.readdir(path.join(".", "Handlers"), (err, file) => {
    file.forEach(e => {
        console.log("Found Handler: " + e);
        const handler = require(path.join("../", "Handlers", e));
        handlers[handler.type] = handler;
    });
});

wsServer.on("connection", socket => {

    socket.id = id++;
    socket.room = null;
    socket.onGame = false;
    socket.server = wsServer;
    socket.ready = false;

    console.log("Connected id: " + socket.id);
    socket.send(JSON.stringify(new DataVO("init", JSON.stringify({ id: socket.id }))));

    socket.on("message", data => {
        console.log(`\r\n# MSG OF ID ${socket.id}: ${data}\r\n`);
        handleMessage(socket, data);
    });

    socket.on("close", data => {
        console.log("Disconnected: " + socket.id);
        Rooms.leaveAt(socket, socket.room);
    });
});


function handleMessage(socket, message) { // handles payload to handler
    const json = JSON.parse(message);
    if (handlers[json.type] == null) {
        console.log(`No handler found for type:${json.type}`);
        return;
    }

    handlers[json.type].handle(socket, json.payload);
}