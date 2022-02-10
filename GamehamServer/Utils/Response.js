const { DataVO } = require("../VO/DataVO");

module.exports = {
    sendResponse(socket, code) {
        if (code != 0) {
            socket.send(JSON.stringify(new DataVO("error", msg)));
        } else {
            socket.send(JSON.stringify(new DataVO("response", "")));
        }

        console.log(`Response of socket ${socket.id}'s request: ${code}`);
    }
}