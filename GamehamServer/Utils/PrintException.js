module.exports = {
    PrintException(exception, debugDataMessage) {
        console.log(`\r\n---------- ${exception} ----------`);
        console.log("DATA:");
        debugDataMessage.forEach(e => {
            console.log(`\t${e}`);
        });
        console.log("---------- END OF EXCEPTION ----------\r\n");
        throw null;
    }
}