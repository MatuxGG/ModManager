import { resolve } from "dns";
import {app, Notification} from "electron";
import {getAppData, trans} from "./appGlobals";
import https from "https";
export let isConnected = false;
let willDisconnect = false;
let firstConnection = true;


function liveCheck() {
    https.get('https://www.google.com', (res) => {
        if (res.statusCode === 200) {
            if (isConnected || firstConnection) {
            } else {
                handleReconnection();
            }
            isConnected = true;
            firstConnection = false;
        } else {
            if (isConnected)
                handleDisconnection();
        }
    }).on('error', (err) => {
        console.error(err);
        if (isConnected)
            handleDisconnection();
    });
}

function handleDisconnection() {
    if (isConnected) {
        console.log('Disconnected');
        if (!getAppData() || !getAppData().isLoaded) {
            handleDisconnectionAndQuit();
            return;
        }
        let notification = new Notification({title: trans('Connection lost'), body: trans('Mod Manager will try to reconnect during the next 30 seconds.\n If it fails, it will close.')});
        notification.show();
        willDisconnect = true;
        setTimeout(() => {
            if (willDisconnect) {
                app.quit();
                process.exit(0);
            }
        }, 30000);
    }
    isConnected = false;
}

function handleDisconnectionAndQuit() {
    console.log('Disconnected and quit');
    let notification = new Notification({title: trans('Connection lost'), body: trans('Mod Manager will close.')});
    notification.show();
    app.quit();
    process.exit(0);
}

function handleReconnection() {
    if (isConnected) return;
    console.log('Reconnected');
    let notification = new Notification({title: trans('Connection back'), body: trans('Mod Manager has reconnected.')});
    notification.show();
    willDisconnect = false;
}

export function initializeOnlineCheck() {
    liveCheck();
    setInterval(function() {
        liveCheck();
    }, 5000);
}

export function isOnline() {
    liveCheck();
    return isConnected;
}