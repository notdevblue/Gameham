const { WebSocketServer } = require("ws");
const fs = require("fs");
const { handle } = require("../Handlers/exampleHandler");

//#region init
// argv
if (process.argv.length <= 2) {
    console.log("usage: ./Server/websocketServer.js [ports]");
    return;
}
const wsServer = new WebSocketServer({ port }, () => {
    console.log(`Server running on port:${port}`);
});
//#endregion // init

const port = process.argv[2];
let handlers = [];

// imports handler
fs.readdir(path.join(".", "Handlers"), (err, file) => {
    console.log(file);
    const handler = require(path.join(".", "Handlers", file));
    handlers[handler.type] = handler;
});


wsServer.on("connection", socket => {
    socket.on("message", data => {
        handleMessage(socket, data);
    });
});


function handleMessage(socket, message) { // handles payload to handler
    const json = JSON.parse(message);
    if (handlers[json.type] == null) {
        console.log(`No handler found for type:${json.type}`);
        return;
    }

    handlers[json.type].handle(socekt, json.payload);
}