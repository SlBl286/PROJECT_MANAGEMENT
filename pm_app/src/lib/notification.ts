import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

declare global {
    var signalr: HubConnection | undefined;
}

export const notiService = globalThis.signalr || new HubConnectionBuilder().withUrl(import.meta.env.VITE_API_URL+ "/notifications-services").build()

